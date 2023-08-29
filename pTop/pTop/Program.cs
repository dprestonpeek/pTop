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

namespace pScript
{
    class Program
    {
        static string programName = "pScript";

        static string cmdFile = "commands.txt";

        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        static NotifyIcon notifyIcon = new NotifyIcon();
        static ContextMenuStrip commandMenu = new ContextMenuStrip();
        static ContextMenuStrip pTopMenu = new ContextMenuStrip();

        static string currentSelected = "";

        static void Main(string[] args)
        {
            notifyIcon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            notifyIcon.Visible = true;
            notifyIcon.Text = Application.ProductName;
            notifyIcon.MouseClick += OpenContextMenu;
            commandMenu.ShowCheckMargin = true;

            //if commands exist, load them, else create new file
            if (File.Exists(cmdFile))
            {
                LoadCommands();
            }
            else
            {
                File.WriteAllText(cmdFile, "");
            }

            Application.Run();
        }

        public static void LoadCommands()
        {
            string commandText = File.ReadAllText(cmdFile);
            string[] commands = commandText.Split('~');
            for (int i = 0; i < commands.Length - 1; i += 3)
            {
                Commands.commandList.Add(new Command(commands[i], commands[i + 1], bool.Parse(commands[i + 2])));
            }
        }

        public static void SaveCommands()
        {
            string saveText = "";
            foreach (Command cmd in Commands.commandList)
            {
                saveText += cmd.displayText + "~" + cmd.commandText + "~" + cmd.togglable;
                if (cmd.displayText != Commands.commandList[Commands.commandList.Count - 1].displayText)
                {
                    saveText += "~";
                }
            }
            File.WriteAllText(cmdFile, saveText);
        }

        private static void OpenContextMenu(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                notifyIcon.ContextMenuStrip = commandMenu;
                commandMenu.Items.Clear();
                foreach (Command command in Commands.commandList)
                {
                    string displayName = command.displayText;
                    ToolStripMenuItem item = (ToolStripMenuItem)commandMenu.Items.Add(displayName);
                    item.Click += ClickedItem;
                    item.Checked = command.isOn;
                }
                ToolStripMenuItem divider = (ToolStripMenuItem)commandMenu.Items.Add("____________");
                divider.Enabled = false;
                ToolStripMenuItem editCommand = (ToolStripMenuItem)commandMenu.Items.Add("Edit Commands...");
                editCommand.Name = "Edit";
                editCommand.Click += ClickedItem;
                ToolStripMenuItem close = (ToolStripMenuItem)commandMenu.Items.Add("Close Menu");
                close.Name = "Close";
                close.Click += ClickedItem;
                ToolStripMenuItem quit = (ToolStripMenuItem)commandMenu.Items.Add("Quit " + programName);
                quit.Name = "Quit";
                quit.Click += ClickedItem;
                commandMenu.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private static void ClickedItem(object sender, EventArgs e)
        {
            ToolStripMenuItem option = (ToolStripMenuItem)sender;
            if (option.Name == "Edit")
            {
                new EditCommands().ShowDialog();
            }
            if (option.Name == "Close")
            {
                return;
            }
            else if (option.Name == "Quit")
            {
                Application.Exit();
                return;
            }

            foreach (Command command in Commands.commandList)
            {
                string displayName = command.displayText;
                if (displayName == option.Text)
                {
                    //Do command here
                    Commands.FireCommand(displayName);
                }
            }
        }

        private static bool IsSelected(string action)
        {
            if (currentSelected == action)
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
