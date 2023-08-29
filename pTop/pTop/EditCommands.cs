using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pScript
{
    public partial class EditCommands : Form
    {
        bool aboutToAdd = false;
        bool adding = false;
        bool editing = false;

        string displayText = "";
        string commandText = "";
        bool togglable = false;

        public EditCommands()
        {
            InitializeComponent();
            RefreshList();
        }

        private void RefreshList()
        {
            CommandList.Items.Clear();
            foreach (Command cmd in Commands.commandList)
            {
                CommandList.Items.Add(cmd.displayText);
            }
        }

        private void CommandList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableEditing();
            if (adding)
            {
                //CommandList.Items.RemoveAt(CommandList.SelectedIndex);
                adding = false;
            }
            else if (aboutToAdd)
            {
                adding = true;
                aboutToAdd = false;
            }
            else
            {
                UpdateUI();
            }
        }

        private void EnableDisableEditing()
        {
            if (CommandList.SelectedIndex == -1)
            {
                DisableEditing();
            }
            else
            {
                DisplayTextBox.Enabled = true;
                CommandTextBox.Enabled = true;
                TogglableCheckbox.Enabled = true;
                SaveButton.Enabled = true;
                DisplayTextBox.Text = "";
                CommandTextBox.Text = "";
                TogglableCheckbox.Checked = false;
                ReorderUp.Enabled = true;
                ReorderDown.Enabled = true;
            }
        }

        private void DisableEditing()
        {
            DisplayTextBox.Enabled = false;
            CommandTextBox.Enabled = false;
            TogglableCheckbox.Enabled = false;
            SaveButton.Enabled = false;
            DisplayTextBox.Text = "";
            CommandTextBox.Text = "";
            TogglableCheckbox.Checked = false;
            ReorderUp.Enabled = false;
            ReorderDown.Enabled = false;
            editing = false;
        }

        private void UpdateUI()
        {
            if (CommandList.SelectedIndex > -1)
            {
                Command selectedCommand = Commands.commandList[CommandList.SelectedIndex];
                DisplayTextBox.Text = selectedCommand.displayText;
                CommandTextBox.Text = selectedCommand.commandText;
                TogglableCheckbox.Checked = selectedCommand.togglable;
            }
            else
            {
                DisplayTextBox.Text = "";
                CommandTextBox.Text = "";
                TogglableCheckbox.Checked = false;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            SaveChanges.Visible = false;
            editing = false;
            displayText = DisplayTextBox.Text;
            commandText = CommandTextBox.Text;
            togglable = TogglableCheckbox.Checked;
            if (adding)
            {
                adding = false;
                CommandList.Items[CommandList.SelectedIndex] = displayText;
            }
            Command newCommand = new Command(displayText, commandText, togglable);
            Commands.commandList[CommandList.SelectedIndex] = newCommand;
            Program.SaveCommands();
            DisableEditing();
            RefreshList();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (SaveChanges.Visible)
            {
                editing = false;
            }
            if (editing)
            {
                SaveChanges.Visible = true;
            }
            else
            {
                Close();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            aboutToAdd = true;
            int i = CommandList.Items.Add("New Command...");
            CommandList.SelectedIndex = i;
            Commands.commandList.Add(new Command("", "", false));
            EnableDisableEditing();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int i = CommandList.SelectedIndex;
            CommandList.Items.RemoveAt(i);
            Commands.commandList.RemoveAt(i);
            Program.SaveCommands();
        }

        private void ReorderUp_Click(object sender, EventArgs e)
        {
            int index = CommandList.SelectedIndex;
            if (index > 0)
            {
                Command cmdToMove = Commands.commandList[index];
                Command temp = Commands.commandList[index - 1];
                Commands.commandList[index - 1] = cmdToMove;
                Commands.commandList[index] = temp;
                RefreshList();
                DisableEditing();
            }
        }

        private void ReorderDown_Click(object sender, EventArgs e)
        {
            int index = CommandList.SelectedIndex;
            if (index != CommandList.Items.Count - 1)
            {
                Command cmdToMove = Commands.commandList[index];
                Command temp = Commands.commandList[index + 1];
                Commands.commandList[index + 1] = cmdToMove;
                Commands.commandList[index] = temp;
                RefreshList();
                DisableEditing();
            }
        }

        private void DisplayTextBox_TextChanged(object sender, EventArgs e)
        {
            editing = true;
        }

        private void CommandTextBox_TextChanged(object sender, EventArgs e)
        {
            editing = true;
        }

        private void TogglableCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            editing = true;
        }
    }
}
