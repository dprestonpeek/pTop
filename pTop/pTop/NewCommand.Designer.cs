
namespace pScript
{
    partial class NewCommand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCommand));
            this.label1 = new System.Windows.Forms.Label();
            this.DisplayTextBox = new System.Windows.Forms.TextBox();
            this.CommandTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TogglableCheckbox = new System.Windows.Forms.CheckBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Display Text:";
            // 
            // DisplayTextBox
            // 
            this.DisplayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayTextBox.Location = new System.Drawing.Point(139, 6);
            this.DisplayTextBox.Name = "DisplayTextBox";
            this.DisplayTextBox.Size = new System.Drawing.Size(343, 23);
            this.DisplayTextBox.TabIndex = 1;
            // 
            // CommandTextBox
            // 
            this.CommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandTextBox.Location = new System.Drawing.Point(139, 35);
            this.CommandTextBox.Name = "CommandTextBox";
            this.CommandTextBox.Size = new System.Drawing.Size(343, 165);
            this.CommandTextBox.TabIndex = 2;
            this.CommandTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Command Text:";
            // 
            // TogglableCheckbox
            // 
            this.TogglableCheckbox.AutoSize = true;
            this.TogglableCheckbox.Location = new System.Drawing.Point(139, 209);
            this.TogglableCheckbox.Name = "TogglableCheckbox";
            this.TogglableCheckbox.Size = new System.Drawing.Size(165, 19);
            this.TogglableCheckbox.TabIndex = 4;
            this.TogglableCheckbox.Text = "This action can be toggled";
            this.TogglableCheckbox.UseVisualStyleBackColor = true;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(407, 206);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 5;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(326, 206);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NewCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 233);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.TogglableCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CommandTextBox);
            this.Controls.Add(this.DisplayTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewCommand";
            this.Text = "New Command";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CancelButton;
        public System.Windows.Forms.TextBox DisplayTextBox;
        public System.Windows.Forms.RichTextBox CommandTextBox;
        public System.Windows.Forms.CheckBox TogglableCheckbox;
    }
}