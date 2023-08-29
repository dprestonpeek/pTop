
namespace pScript
{
    partial class EditCommands
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCommands));
            this.label1 = new System.Windows.Forms.Label();
            this.CommandList = new System.Windows.Forms.ListBox();
            this.TogglableCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CommandTextBox = new System.Windows.Forms.RichTextBox();
            this.DisplayTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ReorderDown = new System.Windows.Forms.Button();
            this.ReorderUp = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveChanges = new System.Windows.Forms.Label();
            this.FlashTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Commands:";
            // 
            // CommandList
            // 
            this.CommandList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandList.FormattingEnabled = true;
            this.CommandList.ItemHeight = 15;
            this.CommandList.Location = new System.Drawing.Point(276, 31);
            this.CommandList.Name = "CommandList";
            this.CommandList.Size = new System.Drawing.Size(191, 244);
            this.CommandList.TabIndex = 2;
            this.CommandList.SelectedIndexChanged += new System.EventHandler(this.CommandList_SelectedIndexChanged);
            // 
            // TogglableCheckbox
            // 
            this.TogglableCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TogglableCheckbox.AutoSize = true;
            this.TogglableCheckbox.Enabled = false;
            this.TogglableCheckbox.Location = new System.Drawing.Point(12, 280);
            this.TogglableCheckbox.Name = "TogglableCheckbox";
            this.TogglableCheckbox.Size = new System.Drawing.Size(150, 19);
            this.TogglableCheckbox.TabIndex = 9;
            this.TogglableCheckbox.Text = "This action is togglable ";
            this.TogglableCheckbox.UseVisualStyleBackColor = true;
            this.TogglableCheckbox.CheckedChanged += new System.EventHandler(this.TogglableCheckbox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Command Text:";
            // 
            // CommandTextBox
            // 
            this.CommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandTextBox.Enabled = false;
            this.CommandTextBox.Location = new System.Drawing.Point(12, 77);
            this.CommandTextBox.Name = "CommandTextBox";
            this.CommandTextBox.Size = new System.Drawing.Size(258, 197);
            this.CommandTextBox.TabIndex = 7;
            this.CommandTextBox.Text = "";
            this.CommandTextBox.TextChanged += new System.EventHandler(this.CommandTextBox_TextChanged);
            // 
            // DisplayTextBox
            // 
            this.DisplayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayTextBox.Enabled = false;
            this.DisplayTextBox.Location = new System.Drawing.Point(12, 33);
            this.DisplayTextBox.Name = "DisplayTextBox";
            this.DisplayTextBox.Size = new System.Drawing.Size(258, 23);
            this.DisplayTextBox.TabIndex = 6;
            this.DisplayTextBox.TextChanged += new System.EventHandler(this.DisplayTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Display Text:";
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(393, 281);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 11;
            this.OKButton.Text = "Close";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(195, 280);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ReorderDown
            // 
            this.ReorderDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReorderDown.Location = new System.Drawing.Point(354, 7);
            this.ReorderDown.Name = "ReorderDown";
            this.ReorderDown.Size = new System.Drawing.Size(23, 23);
            this.ReorderDown.TabIndex = 12;
            this.ReorderDown.Text = "↓";
            this.ReorderDown.UseVisualStyleBackColor = true;
            this.ReorderDown.Click += new System.EventHandler(this.ReorderDown_Click);
            // 
            // ReorderUp
            // 
            this.ReorderUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReorderUp.Location = new System.Drawing.Point(379, 7);
            this.ReorderUp.Name = "ReorderUp";
            this.ReorderUp.Size = new System.Drawing.Size(23, 23);
            this.ReorderUp.TabIndex = 13;
            this.ReorderUp.Text = "↑";
            this.ReorderUp.UseVisualStyleBackColor = true;
            this.ReorderUp.Click += new System.EventHandler(this.ReorderUp_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(445, 7);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(23, 23);
            this.AddButton.TabIndex = 14;
            this.AddButton.Text = "+";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(420, 7);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(23, 23);
            this.DeleteButton.TabIndex = 15;
            this.DeleteButton.Text = "-";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SaveChanges
            // 
            this.SaveChanges.AutoSize = true;
            this.SaveChanges.ForeColor = System.Drawing.Color.Red;
            this.SaveChanges.Location = new System.Drawing.Point(302, 284);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(85, 15);
            this.SaveChanges.TabIndex = 16;
            this.SaveChanges.Text = "Save Changes?";
            this.SaveChanges.Visible = false;
            // 
            // FlashTimer
            // 
            this.FlashTimer.Interval = 10;
            // 
            // EditCommands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 311);
            this.Controls.Add(this.SaveChanges);
            this.Controls.Add(this.TogglableCheckbox);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ReorderUp);
            this.Controls.Add(this.ReorderDown);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CommandTextBox);
            this.Controls.Add(this.DisplayTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CommandList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditCommands";
            this.Text = "Edit Commands";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox CommandList;
        public System.Windows.Forms.CheckBox TogglableCheckbox;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RichTextBox CommandTextBox;
        public System.Windows.Forms.TextBox DisplayTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ReorderDown;
        private System.Windows.Forms.Button ReorderUp;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label SaveChanges;
        public System.Windows.Forms.Timer FlashTimer;
    }
}