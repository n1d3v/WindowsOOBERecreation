// Doesn't work as of now, looking into this!

using System;
using System.Runtime.InteropServices;
using System.ServiceProcess;

namespace WindowsOOBERecreation
{
    public enum NetworkLocation { Home = 0, Work = 1, Public = 2 }

    [ComImport]
    [Guid("DCB00000-570F-4A9B-8D69-199FDBA5723B")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    internal interface INetworkListManager
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        object GetNetworks(int Flags);
    }

    [ComImport]
    [Guid("DCB00003-570F-4A9B-8D69-199FDBA5723B")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    internal interface IEnumNetworks
    {
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object NewEnum();
        void Next(uint celt, [Out, MarshalAs(UnmanagedType.Interface)] out object rgelt, out uint pceltFetched);
    }

    [ComImport]
    [Guid("DCB00002-570F-4A9B-8D69-199FDBA5723B")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    internal interface INetwork
    {
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetName();
        void SetName([MarshalAs(UnmanagedType.BStr)] string szNetworkNewName);
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetDescription();
        void SetDescription([MarshalAs(UnmanagedType.BStr)] string szDescription);
        Guid GetNetworkId();
        int GetDomainType();
        [return: MarshalAs(UnmanagedType.Interface)]
        object GetNetworkConnections();
        void GetTimeCreatedAndConnected(out uint pdwLowCreated, out uint pdwHighCreated, out uint pdwLowConnected, out uint pdwHighConnected);
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool get_IsConnectedToInternet();
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool get_IsConnected();
        int GetConnectivity();
        int GetCategory();
        void SetCategory(int NewCategory);
    }

    public static class NetworkLocationManager
    {
        private const int nlmEnumNetworkConnected = 1;
        private const int nlmCategoryPublic = 0;
        private const int nlmCategoryPrivate = 1;

        private static readonly Guid clsidNetworkListManager = new Guid("DCB00C01-570F-4A9B-8D69-199FDBA5723B");

        private static int CategoryFor(NetworkLocation location)
        {
            if (location == NetworkLocation.Public) { return nlmCategoryPublic; }
            return nlmCategoryPrivate;
        }

        public static int Apply(NetworkLocation location)
        {
            int nwCategory = CategoryFor(location);
            int applied = 0;

            Type managerType = Type.GetTypeFromCLSID(clsidNetworkListManager, true);
            INetworkListManager manager = (INetworkListManager)Activator.CreateInstance(managerType);
            try
            {
                IEnumNetworks networkEnum = (IEnumNetworks)manager.GetNetworks(nlmEnumNetworkConnected);
                try
                {
                    while (true)
                    {
                        object item;
                        uint fetched;

                        networkEnum.Next(1, out item, out fetched);
                        if (fetched == 0 || item == null) { break; }

                        INetwork network = (INetwork)item;
                        try
                        {
                            network.SetCategory(nwCategory);
                            applied++;
                        }
                        finally { Marshal.FinalReleaseComObject(network); }
                    }
                }
                finally { Marshal.FinalReleaseComObject(networkEnum); }
            }
            finally { Marshal.FinalReleaseComObject(manager); }
            return applied;
        }

        public static bool LocationUsesHomeGroup(NetworkLocation location) { return location == NetworkLocation.Home; }

        public static void EnsureHomeGroup()
        {
            try
            {
                using (var serviceCont = new ServiceController("HomeGroupProvider"))
                {
                    if (serviceCont.Status == ServiceControllerStatus.Stopped)
                    {
                        serviceCont.Start();
                        serviceCont.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                    }
                }
            }
            catch (Exception) { }
        }
    }
}