using System;
using System.Runtime.InteropServices;

namespace NuForVS.Core
{
    public class Win32
    {
        [DllImport("user32", CharSet = CharSet.Auto)]
        private extern static int SendMessage(
           IntPtr hwnd,
           int wMsg,
           int wParam,
           int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

        private const int EC_LEFTMARGIN = 0x1;
        private const int EC_RIGHTMARGIN = 0x2;
        private const int EC_USEFONTINFO = 0xFFFF;
        private const int EM_SETMARGINS = 0xD3;
        private const int EM_GETMARGINS = 0xD4;
        private static uint ECM_FIRST = 0x1500;
        private static uint EM_SETCUEBANNER = ECM_FIRST + 1;

        [DllImport("user32", CharSet = CharSet.Auto)]
        private extern static int GetWindowLong(
           IntPtr hWnd,
           int dwStyle);

        private const int GWL_EXSTYLE = (-20);
        private const int WS_EX_RIGHT = 0x00001000;
        private const int WS_EX_LEFT = 0x00000000;
        private const int WS_EX_RTLREADING = 0x00002000;
        private const int WS_EX_LTRREADING = 0x00000000;
        private const int WS_EX_LEFTSCROLLBAR = 0x00004000;
        private const int WS_EX_RIGHTSCROLLBAR = 0x00000000;

        private static bool IsRightToLeft(IntPtr handle)
        {
            int style = GetWindowLong(handle, GWL_EXSTYLE);
            return (
               ((style & WS_EX_RIGHT) == WS_EX_RIGHT) ||
               ((style & WS_EX_RTLREADING) == WS_EX_RTLREADING) ||
               ((style & WS_EX_LEFTSCROLLBAR) == WS_EX_LEFTSCROLLBAR));
        }
        
        public static void NearMargin(IntPtr handle, int margin)
        {
            int message = IsRightToLeft(handle) ? EC_RIGHTMARGIN : EC_LEFTMARGIN;
            if (message == EC_LEFTMARGIN)
            {
                margin = margin & 0xFFFF;
            }
            else
            {
                margin = margin * 0x10000;
            }
            SendMessage(handle, EM_SETMARGINS, message, margin);
        }
        
        public static void FarMargin(IntPtr handle, int margin)
        {
            int message = IsRightToLeft(handle) ? EC_LEFTMARGIN : EC_RIGHTMARGIN;
            if (message == EC_LEFTMARGIN)
            {
                margin = margin & 0xFFFF;
            }
            else
            {
                margin = margin * 0x10000;
            }
            SendMessage(handle, EM_SETMARGINS, message, margin);
        }

        public static void SetCueBanner(IntPtr handle, string cueBanner)
        {
            SendMessage(handle, EM_SETCUEBANNER, IntPtr.Zero, cueBanner);
        }
    }
}
