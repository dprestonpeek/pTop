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
    public partial class NewCommand : Form
    {
        public NewCommand()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Commands.commandList.Add(new Command(DisplayTextBox.Text, CommandTextBox.Text, TogglableCheckbox.Checked));
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
