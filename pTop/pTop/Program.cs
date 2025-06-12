using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;
using HWND = System.IntPtr;
using System.Drawing;
using System.Threading;

namespace pTop
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        static extern UInt32 GetWindowLong(IntPtr hWnd, IntPtr nIndex);
        
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        static readonly IntPtr GWL_EXSTYLE = new IntPtr(-20);
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly UInt32 WS_EX_TOPMOST = 0x0008;
        static readonly UInt32 SWP_NOSIZE = 0x0001;
        static readonly UInt32 SWP_NOMOVE = 0x0002;
        static readonly UInt32 SWP_SHOWWINDOW = 0x0040;
        static readonly byte HighBit = 0x80;

        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        static NotifyIcon notifyIcon = new NotifyIcon();
        static ContextMenuStrip windowMenu = new ContextMenuStrip();
        static ContextMenuStrip pTopMenu = new ContextMenuStrip();

        static Dictionary<string, string> longWindowNames = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            notifyIcon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            notifyIcon.Visible = true;
            notifyIcon.Text = Application.ProductName;
            notifyIcon.MouseClick += OpenContextMenu;
            windowMenu.ShowCheckMargin = true;

            Application.Run();
        }

        public static bool IsTopMost(IntPtr hwnd)
        {
            return (GetWindowLong(hwnd, GWL_EXSTYLE) & WS_EX_TOPMOST) != 0;
        }

        public static bool ToggleTopMost(IntPtr hwnd)
        {
            bool now_topmost = IsTopMost(hwnd);

            SetTopMost(hwnd, !now_topmost);
            return !now_topmost;
        }

        public static void SetTopMost(IntPtr hwnd, bool topmost)
        {
            RECT rt = new RECT();
            int x = 0, y = 0, width = 0, height = 0;
            if (GetWindowRect(hwnd, out rt))
            {
                x = rt.Left;
                y = rt.Top;
                width = rt.Right - rt.Left;
                height = rt.Bottom - rt.Top;
            }
            SetWindowPos(hwnd, topmost ? HWND_TOPMOST : HWND_NOTOPMOST, x, y, width, height, topmost ? WS_EX_TOPMOST : SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }

        private static void OpenContextMenu(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                notifyIcon.ContextMenuStrip = windowMenu;
                windowMenu.Items.Clear();
                longWindowNames.Clear();

                Dictionary<string, int> duplicates = new Dictionary<string, int>();
                foreach (KeyValuePair<System.IntPtr, string> window in OpenWindowGetter.GetOpenWindows())
                {
                    string displayName = window.Value;
                    if (displayName == "Windows Input Experience")
                    {
                        SetTopMost(window.Key, true);
                        continue;
                    }

                    // if name is long, we'll want to save the original
                    string longName = displayName;
                    if (displayName.Length > 50)
                    {
                        displayName = displayName.Substring(0, 50);
                        displayName += "...";
                    }

                    // add name to list to keep track of long names
                    if (longWindowNames.ContainsKey(displayName))
                    {
                        // check if a duplicate already exists
                        if (duplicates.ContainsKey(displayName))
                        {
                            duplicates[displayName]++;
                        }
                        else
                        {
                            duplicates.Add(displayName, 1);
                        }
                        displayName += " (" + duplicates[displayName] + ")";
                    }
                    longWindowNames.Add(displayName, longName);

                    ToolStripMenuItem item = (ToolStripMenuItem)windowMenu.Items.Add(displayName);
                    item.Click += ClickedItem;
                    item.Checked = IsTopMost(window.Key);
                }
                ToolStripMenuItem divider = (ToolStripMenuItem)windowMenu.Items.Add("____________");
                divider.Enabled = false;
                ToolStripMenuItem close = (ToolStripMenuItem)windowMenu.Items.Add("Close Menu");
                close.Name = "Close";
                close.Click += ClickedItem;
                ToolStripMenuItem quit = (ToolStripMenuItem)windowMenu.Items.Add("Quit pTop");
                quit.Name = "Quit";
                quit.Click += ClickedItem;
                windowMenu.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private static void ClickedItem(object sender, EventArgs e)
        {
            ToolStripMenuItem window = (ToolStripMenuItem)sender;
            if (window.Name == "Close")
            {
                return;
            }
            else if (window.Name == "Quit")
            {
                Application.Exit();
            }

            longWindowNames.TryGetValue(window.Text, out string windowText);
            IntPtr hwnd = FindWindow(null, windowText);

            ToggleTopMost(hwnd);
        }
    }

/// <summary>Contains functionality to get all the open windows.</summary>
public static class OpenWindowGetter
    {
        /// <summary>Returns a dictionary that contains the handle and title of all the open windows.</summary>
        /// <returns>A dictionary that contains the handle and title of all the open windows.</returns>
        public static IDictionary<HWND, string> GetOpenWindows()
        {
            HWND shellWindow = GetShellWindow();
            Dictionary<HWND, string> windows = new Dictionary<HWND, string>();

            EnumWindows(delegate (HWND hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                StringBuilder builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();
                return true;

            }, 0);

            return windows;
        }

        private delegate bool EnumWindowsProc(HWND hWnd, int lParam);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(HWND hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(HWND hWnd);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct RECT
{
    public int Left;        // x position of upper-left corner
    public int Top;         // y position of upper-left corner
    public int Right;       // x position of lower-right corner
    public int Bottom;      // y position of lower-right corner
}

