using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NuForVS.Core
{
    public class IniFile
    {
        private string _path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern uint GetPrivateProfileSection(string lpAppName,
           IntPtr lpReturnedString, uint nSize, string lpFileName);

        public IniFile(string path)
        {
            _path = path;
        }

        public void WriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, _path);
        }

        public string ReadValue(string section, string key)
        {
            var sb = new StringBuilder(255);
            var i = GetPrivateProfileString(section, key, "", sb, sb.Capacity, _path);
            return sb.ToString();
        }

        public string[] GetSection(string section)
        {
            var items = new string[0];

            if (!System.IO.File.Exists(_path))
                return items;

            uint MAX_BUFFER = 32767;

            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER);

            uint bytesReturned = GetPrivateProfileSection(section, pReturnedString, MAX_BUFFER, _path);

            if ((bytesReturned == MAX_BUFFER - 2) || (bytesReturned == 0))
            {
                Marshal.FreeCoTaskMem(pReturnedString);
                return items;
            }

            //bytesReturned -1 to remove trailing \0

            // NOTE: Calling Marshal.PtrToStringAuto(pReturnedString) will 
            //       result in only the first pair being returned
            string returnedString = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned - 1);

            items = returnedString.Split('\0');

            Marshal.FreeCoTaskMem(pReturnedString);
            return items;
        }
    }
}
