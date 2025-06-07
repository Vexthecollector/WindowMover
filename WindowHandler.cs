using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowMover
{
    public class WindowHandler
    {
        private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();
        [DllImport("kernel32.dll")]
        static extern int GetProcessId(IntPtr handle);
        public delegate bool EnumChildCallback(IntPtr hwnd, ref IntPtr lParam);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildCallback lpEnumFunc, ref IntPtr lParam);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
            public int Width()
            {
                return Math.Abs(Right - Left);
            }
            public int Height()
            {
                return Math.Abs(Top- Bottom);
            }
        }

        public struct WindowData
        {
            public string Name;
            public Process Process;
            public IntPtr Handle;
            public HandleRef HandleRef;
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int width, int height, int wFlags);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        private const uint SW_RESTORE = 0x09;
        private const uint SW_MINIMIZE = 0x06;
        private const uint SW_NORMAL = 0x01;
        const short SWP_NOMOVE = 0X2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 0X4;
        const int SWP_SHOWWINDOW = 0x0040;

        List<WindowData> Windows = new List<WindowData>();

        //IDictionary<IntPtr,string> Windows = new Dictionary<IntPtr,string>();


        private static readonly WindowHandler instance = new WindowHandler();
        static WindowHandler() { }
        private WindowHandler() { GetAllWindows(); }

        public static WindowHandler Instance { get { return instance; } }



        public IDictionary<IntPtr, string> GetOpenWindowsFromPID(int processID)
        {
            IntPtr hShellWindow = GetShellWindow();
            Dictionary<IntPtr, string> dictWindows = new Dictionary<IntPtr, string>();

            EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
                if (hWnd == hShellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                uint windowPid;
                GetWindowThreadProcessId(hWnd, out windowPid);
                if (windowPid != processID) return true;

                StringBuilder stringBuilder = new StringBuilder(length);
                GetWindowText(hWnd, stringBuilder, length + 1);
                dictWindows.Add(hWnd, stringBuilder.ToString());
                return true;
            }, 0);

            return dictWindows;
        }

        public void GetAllWindows()
        {

            Windows.Clear();
            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                WindowData windowData = new WindowData();

                try
                {

                    GetOpenWindowsFromPID(process.Id).ToList().ForEach(x =>
                    {
                        windowData.Name = x.Value;
                        windowData.Handle = x.Key;
                        windowData.Process = process;
                        windowData.HandleRef = new HandleRef(process, process.MainWindowHandle);
                        Windows.Add(windowData);
                    });
                }
                catch { }
            }
        }
        public void MoveSpecificWindow(IntPtr handle, int X, int Y, int width, int height)
        {
            ShowWindow(handle, SW_RESTORE);
            SetWindowPos(handle, 0, X, Y, width, height, SWP_NOZORDER | SWP_SHOWWINDOW);

        }

        public void RestoreWindow(IntPtr handle)
        {
            ShowWindow(handle, SW_RESTORE);
        }
        public void MinimizeWindow(IntPtr handle)
        {
            ShowWindow(handle, SW_MINIMIZE);
        }

        public RECT GetWindowRectangle(HandleRef hWnd)
        {
            RECT windowRectangle;
            new HandleRef();
            GetWindowRect(hWnd, out windowRectangle);
            return windowRectangle;
        }


        public List<WindowData> windows { get => Windows; }
    }
}
