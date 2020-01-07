using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace GHelper.Helper
{
    [Serializable()]
    public static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static IntPtr LastWindowHandle;


        public const uint WM_QUIT = 0x12;
        [DllImport("user32.dll", EntryPoint = "PostThreadMessage", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostThreadMessage(int idThread, uint Msg, IntPtr wParam, IntPtr lParam);


        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        public const UInt32 SWP_NOSIZE = 0x0001;
        public const UInt32 SWP_NOMOVE = 0x0002;
        public const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public enum WindowShowStyle : int
        {
            /// <summary>Hides the window and activates another window.</summary>
            /// <remarks>See SW_HIDE</remarks>
            Hide = 0,
            /// <summary>Activates and displays a window. If the window is minimized
            /// or maximized, the system restores it to its original size and
            /// position. An application should specify this flag when displaying
            /// the window for the first time.</summary>
            /// <remarks>See SW_SHOWNORMAL</remarks>
            ShowNormal = 1,
            /// <summary>Activates the window and displays it as a minimized window.</summary>
            /// <remarks>See SW_SHOWMINIMIZED</remarks>
            ShowMinimized = 2,
            /// <summary>Activates the window and displays it as a maximized window.</summary>
            /// <remarks>See SW_SHOWMAXIMIZED</remarks>
            ShowMaximized = 3,
            /// <summary>Maximizes the specified window.</summary>
            /// <remarks>See SW_MAXIMIZE</remarks>
            Maximize = 3,
            /// <summary>Displays a window in its most recent size and position.
            /// This value is similar to "ShowNormal", except the window is not
            /// actived.</summary>
            /// <remarks>See SW_SHOWNOACTIVATE</remarks>
            ShowNormalNoActivate = 4,
            /// <summary>Activates the window and displays it in its current size
            /// and position.</summary>
            /// <remarks>See SW_SHOW</remarks>
            Show = 5,
            /// <summary>Minimizes the specified window and activates the next
            /// top-level window in the Z order.</summary>
            /// <remarks>See SW_MINIMIZE</remarks>
            Minimize = 6,
            /// <summary>Displays the window as a minimized window. This value is
            /// similar to "ShowMinimized", except the window is not activated.</summary>
            /// <remarks>See SW_SHOWMINNOACTIVE</remarks>
            ShowMinNoActivate = 7,
            /// <summary>Displays the window in its current size and position. This
            /// value is similar to "Show", except the window is not activated.</summary>
            /// <remarks>See SW_SHOWNA</remarks>
            ShowNoActivate = 8,
            /// <summary>Activates and displays the window. If the window is
            /// minimized or maximized, the system restores it to its original size
            /// and position. An application should specify this flag when restoring
            /// a minimized window.</summary>
            /// <remarks>See SW_RESTORE</remarks>
            Restore = 9,
            /// <summary>Sets the show state based on the SW_ value specified in the
            /// STARTUPINFO structure passed to the CreateProcess function by the
            /// program that started the application.</summary>
            /// <remarks>See SW_SHOWDEFAULT</remarks>
            ShowDefault = 10,
            /// <summary>Windows 2000/XP: Minimizes a window, even if the thread
            /// that owns the window is hung. This flag should only be used when
            /// minimizing windows from a different thread.</summary>
            /// <remarks>See SW_FORCEMINIMIZE</remarks>
            ForceMinimized = 11
        }

        #region Refresh Notification Area

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass,
            string lpszWindow);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        #endregion Refresh Notification Area


        public static class CurrentStateUsb
        {
            public const int Wmdevicechange = 0x0219;
        }
        public class USBDeviceInfo
        {
            public USBDeviceInfo(string description)
            {
                Description = description;
            }
            public string Description { get; private set; }
        }

        [SecurityCritical]
        [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
        public abstract class CriticalHandle : CriticalFinalizerObject
        {
            [DllImport("user32.dll", EntryPoint = "PostThreadMessage", CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool PostThreadMessage(int idThread, uint Msg, IntPtr wParam, IntPtr lParam);

            public const uint WM_QUIT = 0x12;

            [StructLayout(LayoutKind.Sequential)]
            struct Rect
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
            [SecurityCritical]
            [SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
            public static class ScreenDetection
            {
                [DllImport("user32.dll", CharSet = CharSet.Unicode)]
                static extern IntPtr GetForegroundWindow();
                [DllImport("user32.dll", CharSet = CharSet.Unicode)]
                static extern IntPtr GetDesktopWindow();
                [DllImport("user32.dll", CharSet = CharSet.Unicode)]
                static extern IntPtr GetShellWindow();
                [DllImport("user32.dll", CharSet = CharSet.Unicode)]
                static extern uint GetWindowRect(IntPtr hwnd, out Rect rc);
                [DllImport("user32.dll", CharSet = CharSet.Unicode)]
                static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

                public static bool AreApplicationFullScreen()
                {
                    const int maxChars = 256;
                    StringBuilder className = new StringBuilder(maxChars);
                    IntPtr handle = GetForegroundWindow();
                    bool runningFullScreen = false;
                    System.Drawing.Rectangle screenBounds;
                    IntPtr hWnd;
                    hWnd = GetForegroundWindow();
                    if (!hWnd.Equals(null) && !hWnd.Equals(IntPtr.Zero))
                    {
                        if (!(hWnd.Equals(GetDesktopWindow()) || hWnd.Equals(GetShellWindow())))
                        {
                            if (GetClassName(handle, className, maxChars) > 0)
                            {
                                string cName = className.ToString();
                                var Handle = GetWindowRect(hWnd, out Rect appBounds);
                                if (!Handle.Equals(null) && cName != "Progman" && cName != "WorkerW")
                                {
                                    screenBounds = Screen.FromHandle(hWnd).Bounds;
                                    if ((appBounds.Bottom - appBounds.Top) == screenBounds.Height
                                        && (appBounds.Right - appBounds.Left) == screenBounds.Width)
                                    {
                                        runningFullScreen = true;
                                    }
                                }
                            }
                        }
                    }
                    return runningFullScreen;
                }
            }
        }

        public static void RefreshTrayArea()
        {
            IntPtr systemTrayContainerHandle = NativeMethods.FindWindow("Shell_TrayWnd", null);
            IntPtr systemTrayHandle = NativeMethods.FindWindowEx(systemTrayContainerHandle, IntPtr.Zero, "TrayNotifyWnd", null);
            IntPtr sysPagerHandle = NativeMethods.FindWindowEx(systemTrayHandle, IntPtr.Zero, "SysPager", null);
            IntPtr notificationAreaHandle = NativeMethods.FindWindowEx(sysPagerHandle, IntPtr.Zero, "ToolbarWindow32", "Notification Area");
            if (notificationAreaHandle == IntPtr.Zero)
            {
                notificationAreaHandle = NativeMethods.FindWindowEx(sysPagerHandle, IntPtr.Zero, "ToolbarWindow32",
                    "User Promoted Notification Area");
                IntPtr notifyIconOverflowWindowHandle = NativeMethods.FindWindow("NotifyIconOverflowWindow", null);
                IntPtr overflowNotificationAreaHandle = NativeMethods.FindWindowEx(notifyIconOverflowWindowHandle, IntPtr.Zero,
                    "ToolbarWindow32", "Overflow Notification Area");
                RefreshTrayArea(overflowNotificationAreaHandle);
            }
            RefreshTrayArea(notificationAreaHandle);
        }

        private static void RefreshTrayArea(IntPtr windowHandle)
        {
            const uint wmMousemove = 0x0200;
            NativeMethods.GetClientRect(windowHandle, out NativeMethods.RECT rect);
            for (var x = 0; x < rect.right; x += 5)
            {
                for (var y = 0; y < rect.bottom; y += 5)
                {
                    NativeMethods.SendMessage(windowHandle, wmMousemove, 0, (y << 16) + x);
                }
            }
        }
    }
}
