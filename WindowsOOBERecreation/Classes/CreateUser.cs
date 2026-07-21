// Reconstructed by reverse engineering the Windows 7 OOBE.

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsOOBERecreation
{
    public static class CreateUser
    {
        private static readonly Guid CLSID_LocalUserAccounts = new Guid("4f6bcd94-c2a5-42ce-8dbc-31e794be4630");
        private static readonly Guid CLSID_LocalGroups = new Guid("8f3080a6-af99-4f2e-a806-f3d5702a0444");

        private static readonly Guid FMTID_Sam = new Guid("705d8364-7547-468c-8c88-84860bcbed4c");

        private static PROPERTYKEY PKEY_SAM_UserAccountControl { get { return new PROPERTYKEY(FMTID_Sam, 19); } }
        private static PROPERTYKEY PKEY_SAM_PasswordHint { get { return new PROPERTYKEY(FMTID_Sam, 25); } }
        private static PROPERTYKEY PKEY_SAM_GroupMembers { get { return new PROPERTYKEY(FMTID_Sam, 102); } }

        private const uint DOMAIN_ALIAS_RID_ADMINS = 0x220;

        private const uint UF_NORMAL_ACCOUNT = 0x200;
        private const uint UF_MNS_LOGON_ACCOUNT = 0x20000;

        private const ushort VT_UI4 = 0x13;
        private const ushort VT_UNKNOWN = 0x0D;
        private const ushort VT_LPWSTR = 0x1F;

        private const uint WinBuiltinUsersSid = 27;
        private const uint USER_INFO_PASSWORD_LEVEL = 1003;
        private const int NERR_Success = 0;

        private static readonly IntPtr HKEY_LOCAL_MACHINE = new IntPtr(unchecked((int)0x80000002));
        private const uint KEY_SET_VALUE = 0x0002;
        private const uint REG_SZ = 1;
        private const int SECURITY_MAX_SID_SIZE = 68;

        public static void CreateAcc(string username, string password, string passwordHint, bool administrator = true)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Username is required.", "username");

            object mgrObj = Activator.CreateInstance(Type.GetTypeFromCLSID(CLSID_LocalUserAccounts, true));

            ILocalAccounts mgr = (ILocalAccounts)mgrObj;
            IPropertyStore user = null;

            try
            {
                Check(mgr.CreateItem(username, out user), "create user");

                uint uac = GetUInt32(user, PKEY_SAM_UserAccountControl);
                uac = (uac & ~UF_MNS_LOGON_ACCOUNT) | UF_NORMAL_ACCOUNT;

                SetUInt32(user, PKEY_SAM_UserAccountControl, uac);

                if (!string.IsNullOrEmpty(passwordHint))
                    SetString(user, PKEY_SAM_PasswordHint, passwordHint);
                if (administrator)
                    AddToGroup(user, DOMAIN_ALIAS_RID_ADMINS);

                Check(user.Commit(), "commit user");
            }
            finally
            {
                if (user != null) Marshal.ReleaseComObject(user);
                Marshal.ReleaseComObject(mgr);
            }

            SetAccountPassword(username, password ?? string.Empty);

            if (administrator)
                RemoveFromLocalGroup(username, WinBuiltinUsersSid);

            SetRegisteredOwner(username);
        }

        private static void SetAccountPassword(string username, string password)
        {
            USER_INFO_1003 info = new USER_INFO_1003();
            info.usri1003_password = password;

            uint parmError;
            int rc = NetUserSetInfo(null, username, USER_INFO_PASSWORD_LEVEL, ref info, out parmError);

            if (rc != NERR_Success)
                throw new Win32Exception(rc, "CreateUser failed to set the account password.");
        }

        private static void RemoveFromLocalGroup(string username, uint wellKnownSid)
        {
            string groupName = LocalGroupNameFromWellKnownSid(wellKnownSid);
            if (string.IsNullOrEmpty(groupName))
                return;

            LOCALGROUP_MEMBERS_INFO_3 member = new LOCALGROUP_MEMBERS_INFO_3();
            member.lgrmi3_domainandname = username;

            IntPtr buffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(LOCALGROUP_MEMBERS_INFO_3)));

            try
            {
                Marshal.StructureToPtr(member, buffer, false);
                NetLocalGroupDelMembers(null, groupName, 3, buffer, 1);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        private static string LocalGroupNameFromWellKnownSid(uint wellKnownSid)
        {
            byte[] sid = new byte[SECURITY_MAX_SID_SIZE];
            uint sidLength = (uint)sid.Length;

            if (!CreateWellKnownSid(wellKnownSid, IntPtr.Zero, sid, ref sidLength))
                return null;

            StringBuilder name = new StringBuilder(256);
            uint nameLength = (uint)name.Capacity;

            StringBuilder domain = new StringBuilder(256);
            uint domainLength = (uint)domain.Capacity;

            int use;

            if (!LookupAccountSid(null, sid, name, ref nameLength, domain, ref domainLength, out use))
                return null;

            return name.ToString();
        }

        private static void SetRegisteredOwner(string username)
        {
            IntPtr key;

            if (RegOpenKeyExW(HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows NT\\CurrentVersion", 0, KEY_SET_VALUE, out key) != 0)
                return;

            try
            {
                byte[] data = Encoding.Unicode.GetBytes(username + "\0");
                RegSetValueExW(key, "RegisteredOwner", 0, REG_SZ, data, (uint)data.Length);
            }
            finally
            {
                RegCloseKey(key);
            }
        }

        private static void SetString(IPropertyStore store, PROPERTYKEY key, string value)
        {
            PROPVARIANT pv = new PROPVARIANT();

            pv.vt = VT_LPWSTR;
            pv.p = Marshal.StringToCoTaskMemUni(value);

            try { Check(store.SetValue(ref key, ref pv), "set property " + key.pid); }
            finally { PropVariantClear(ref pv); }
        }

        private static void SetUInt32(IPropertyStore store, PROPERTYKEY key, uint value)
        {
            PROPVARIANT pv = new PROPVARIANT();
            pv.vt = VT_UI4;
            pv.uintVal = value;

            Check(store.SetValue(ref key, ref pv), "set property " + key.pid);
        }

        private static uint GetUInt32(IPropertyStore store, PROPERTYKEY key)
        {
            PROPVARIANT pv = new PROPVARIANT();
            Check(store.GetValue(ref key, out pv), "get property " + key.pid);

            uint v = pv.uintVal;
            PropVariantClear(ref pv);

            return v;
        }

        private static void AddToGroup(IPropertyStore user, uint rid)
        {
            object grpObj = Activator.CreateInstance(Type.GetTypeFromCLSID(CLSID_LocalGroups, true));

            ILocalAccounts groups = (ILocalAccounts)grpObj;
            IPropertyStore group = null;

            try
            {
                Check(groups.GetItemByRid(rid, out group), "open group");

                PROPVARIANT pv = new PROPVARIANT();

                pv.vt = VT_UNKNOWN;
                pv.p = Marshal.GetIUnknownForObject(user);

                PROPERTYKEY key = PKEY_SAM_GroupMembers;

                try
                {
                    Check(group.SetValue(ref key, ref pv), "set group members");
                    Check(group.Commit(), "commit group");
                }
                finally { PropVariantClear(ref pv); }
            }
            finally
            {
                if (group != null) Marshal.ReleaseComObject(group);
                Marshal.ReleaseComObject(groups);
            }
        }

        private static void Check(int hr, string what)
        {
            if (hr < 0)
                throw new COMException("CreateUser failed to " + what + string.Format(" (hr=0x{0:X8})", hr), hr);
        }

        [DllImport("ole32.dll")]
        private static extern int PropVariantClear(ref PROPVARIANT pvar);

        [DllImport("netapi32.dll")]
        private static extern int NetUserSetInfo([MarshalAs(UnmanagedType.LPWStr)] string serverName, [MarshalAs(UnmanagedType.LPWStr)] string userName, uint level, ref USER_INFO_1003 buf, out uint parmError);

        [DllImport("netapi32.dll")]
        private static extern int NetLocalGroupDelMembers([MarshalAs(UnmanagedType.LPWStr)] string serverName, [MarshalAs(UnmanagedType.LPWStr)] string groupName, uint level, IntPtr buf, uint totalEntries);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CreateWellKnownSid(uint wellKnownSidType, IntPtr domainSid, byte[] sid, ref uint sidLength);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool LookupAccountSid(string systemName, byte[] sid, StringBuilder name, ref uint nameLength, StringBuilder domainName, ref uint domainLength, out int use);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        private static extern int RegOpenKeyExW(IntPtr hKey, string subKey, uint options, uint samDesired, out IntPtr result);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        private static extern int RegSetValueExW(IntPtr hKey, string valueName, uint reserved, uint type, byte[] data, uint cbData);

        [DllImport("advapi32.dll")]
        private static extern int RegCloseKey(IntPtr hKey);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct USER_INFO_1003
        {
            public string usri1003_password;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct LOCALGROUP_MEMBERS_INFO_3
        {
            public string lgrmi3_domainandname;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PROPERTYKEY
        {
            public Guid fmtid;
            public uint pid;
            public PROPERTYKEY(Guid fmtid, uint pid) { this.fmtid = fmtid; this.pid = pid; }
        }

        [StructLayout(LayoutKind.Explicit, Size = 24)]
        private struct PROPVARIANT
        {
            [FieldOffset(0)] public ushort vt;
            [FieldOffset(2)] public ushort wReserved1;
            [FieldOffset(4)] public ushort wReserved2;
            [FieldOffset(6)] public ushort wReserved3;
            [FieldOffset(8)] public IntPtr p;
            [FieldOffset(8)] public uint uintVal;
        }

        [ComImport]
        [Guid("886d8eeb-8cf2-4446-8d02-cdba1dbdcf99")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IPropertyStore
        {
            [PreserveSig] int GetCount(out uint cProps);
            [PreserveSig] int GetAt(uint iProp, out PROPERTYKEY pkey);
            [PreserveSig] int GetValue(ref PROPERTYKEY key, out PROPVARIANT pv);
            [PreserveSig] int SetValue(ref PROPERTYKEY key, ref PROPVARIANT pv);
            [PreserveSig] int Commit();
        }

        [ComImport]
        [Guid("3c708557-c99d-4fa3-9231-56518418b4e4")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface ILocalAccounts
        {
            [PreserveSig] int _slot3();
            [PreserveSig] int _slot4();
            [PreserveSig] int _slot5();
            [PreserveSig] int _slot6();
            [PreserveSig]
            int CreateItem([In, MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.Interface)] out IPropertyStore item);
            [PreserveSig] int _slot8();
            [PreserveSig] int _slot9();
            [PreserveSig]
            int GetItemByRid(uint rid, [MarshalAs(UnmanagedType.Interface)] out IPropertyStore item);
        }
    }
}