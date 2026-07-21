using System;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using ManagedNativeWifi;

namespace WindowsOOBERecreation
{
    internal static class WlanConnection
    {
        public static string BuildProfileXml(AvailableNetworkPack network, string securityKey, bool autoConnect)
        {
            string ssid = SecurityElement.Escape(network.Ssid.ToString());
            string connectionMode = autoConnect ? "auto" : "manual";

            string authentication;
            string encryption;

            switch (network.AuthenticationAlgorithm)
            {
                case AuthenticationAlgorithm.Open:
                    authentication = "open";
                    encryption = "none";
                    break;
                case AuthenticationAlgorithm.WPA_PSK:
                    authentication = "WPAPSK";
                    encryption = "TKIP";
                    break;
                case AuthenticationAlgorithm.WPA3_SAE:
                    authentication = "WPA3SAE";
                    encryption = "AES";
                    break;
                default:
                    authentication = "WPA2PSK";
                    encryption = "AES";
                    break;
            }

            return BuildXmlCore(ssid, authentication, encryption, securityKey, connectionMode, nonBroadcast: false);
        }

        public static string BuildHiddenProfileXml(string ssid, string authentication, string encryption, string securityKey, bool autoConnect)
        {
            string escapedSsid = SecurityElement.Escape(ssid);
            string connectionMode = autoConnect ? "auto" : "manual";
            return BuildXmlCore(escapedSsid, authentication, encryption, securityKey, connectionMode, nonBroadcast: true);
        }

        private static string BuildXmlCore(string ssid, string authentication, string encryption, string securityKey, string connectionMode, bool nonBroadcast)
        {
            string nonBroadcastXml = nonBroadcast ? "\n                        <nonBroadcast>true</nonBroadcast>" : "";

            string sharedKey = "";
            if (encryption != "none" && !string.IsNullOrEmpty(securityKey))
            {
                string keyType = encryption == "WEP" ? "networkKey" : "passPhrase";
                string key = SecurityElement.Escape(securityKey);
                sharedKey = $@"
                    <sharedKey>
                        <keyType>{keyType}</keyType>
                        <protected>false</protected>
                        <keyMaterial>{key}</keyMaterial>
                    </sharedKey>";
            }

            return $@"
                <?xml version=""1.0""?>
                <WLANProfile xmlns=""http://www.microsoft.com/networking/WLAN/profile/v1"">
                    <name>{ssid}</name>
                    <SSIDConfig>
                        <SSID>
                            <name>{ssid}</name>
                        </SSID>{nonBroadcastXml}
                    </SSIDConfig>
                    <connectionType>ESS</connectionType>
                    <connectionMode>{connectionMode}</connectionMode>
                    <MSM>
                        <security>
                            <authEncryption>
                                <authentication>{authentication}</authentication>
                                <encryption>{encryption}</encryption>
                                <useOneX>false</useOneX>
                            </authEncryption>
                        {sharedKey}
                        </security>
                    </MSM>
                </WLANProfile>";
        }

        public static async Task<bool> ConnectToNetworkAsync(AvailableNetworkPack network, string securityKey, bool autoConnect)
        {
            string profileXml = BuildProfileXml(network, securityKey, autoConnect).Trim();
            try
            {
                if (!NativeWifi.SetProfile(network.InterfaceInfo.Id, ProfileType.AllUser, profileXml, null, true))
                    return false;
                return await NativeWifi.ConnectNetworkAsync(network.InterfaceInfo.Id, network.Ssid.ToString(), network.BssType, TimeSpan.FromSeconds(10));
            }
            catch { return false; }
        }

        public static async Task<bool> ConnectToHiddenNetworkAsync(string ssid, string authentication, string encryption, string securityKey, bool autoConnect)
        {
            var iface = NativeWifi.EnumerateInterfaces().FirstOrDefault();
            if (iface == null) return false;

            string profileXml = BuildHiddenProfileXml(ssid, authentication, encryption, securityKey, autoConnect).Trim();
            try
            {
                if (!NativeWifi.SetProfile(iface.Id, ProfileType.AllUser, profileXml, null, true))
                    return false;
                return await NativeWifi.ConnectNetworkAsync(iface.Id, ssid, BssType.Infrastructure, TimeSpan.FromSeconds(10));
            }
            catch { return false; }
        }
    }
}