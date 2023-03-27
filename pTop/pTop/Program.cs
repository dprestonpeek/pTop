using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;
using HWND = System.IntPtr;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Media;

namespace pTop
{
    class Program
    {
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        static NotifyIcon notifyIcon = new NotifyIcon();
        static ContextMenuStrip windowMenu = new ContextMenuStrip();
        static ContextMenuStrip pTopMenu = new ContextMenuStrip();

        static string soundFiles = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "pNoiseSounds");
        static string currentSelected = "";

        static SoundPlayer player = new SoundPlayer("player");

        static void Main(string[] args)
        {
            notifyIcon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            notifyIcon.Visible = true;
            notifyIcon.Text = Application.ProductName;
            notifyIcon.MouseClick += OpenContextMenu;
            windowMenu.ShowCheckMargin = true;

            Application.Run();
        }

        private static void OpenContextMenu(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                notifyIcon.ContextMenuStrip = windowMenu;
                windowMenu.Items.Clear();
                foreach (string file in Directory.GetFiles(soundFiles))
                {
                    string displayName = Path.GetFileNameWithoutExtension(file);
                    ToolStripMenuItem item = (ToolStripMenuItem)windowMenu.Items.Add(displayName);
                    item.Click += ClickedItem;
                    item.Checked = IsSelected(displayName);
                }
                ToolStripMenuItem divider = (ToolStripMenuItem)windowMenu.Items.Add("____________");
                divider.Enabled = false;
                ToolStripMenuItem close = (ToolStripMenuItem)windowMenu.Items.Add("Close Menu");
                close.Name = "Close";
                close.Click += ClickedItem;
                ToolStripMenuItem quit = (ToolStripMenuItem)windowMenu.Items.Add("Quit pNoise");
                quit.Name = "Quit";
                quit.Click += ClickedItem;
                windowMenu.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private static void ClickedItem(object sender, EventArgs e)
        {
            ToolStripMenuItem option = (ToolStripMenuItem)sender;
            if (option.Name == "Close")
            {
                return;
            }
            else if (option.Name == "Quit")
            {
                Application.Exit();
                return;
            }

            foreach (string file in Directory.GetFiles(soundFiles))
            {
                string displayName = Path.GetFileNameWithoutExtension(file);
                if (displayName == option.Text)
                {
                    //stop playing
                    if (currentSelected == displayName)
                    {
                        player.Stop();
                        currentSelected = "";
                    }
                    else //start playing
                    {
                        currentSelected = displayName;
                        player.SoundLocation = file;
                        player.PlayLooping();
                    }
                }
            }
        }

        private static bool IsSelected(string filename)
        {
            if (currentSelected == filename)
            {
                return true;
            }
            return false;
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
