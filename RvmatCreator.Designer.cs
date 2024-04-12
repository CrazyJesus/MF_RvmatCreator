namespace MF_RvmatCreator
{
    partial class RvmatCreator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RvmatCreator));
            CreateRvmatBTN = new Button();
            PathTextBox = new TextBox();
            SelectPathBTN = new Button();
            RvmatComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            RvmatManagerBTN = new Button();
            OrganizeIntoFolder = new CheckBox();
            CreateDamageRvmat = new CheckBox();
            ViewRvmatBTN = new Button();
            VerisonText = new Label();
            DiscordLink = new LinkLabel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // CreateRvmatBTN
            // 
            CreateRvmatBTN.Location = new Point(327, 149);
            CreateRvmatBTN.Name = "CreateRvmatBTN";
            CreateRvmatBTN.Size = new Size(111, 23);
            CreateRvmatBTN.TabIndex = 0;
            CreateRvmatBTN.Text = "Create RVMAT";
            CreateRvmatBTN.UseVisualStyleBackColor = true;
            CreateRvmatBTN.Click += CreateRvmatBTN_Click;
            // 
            // PathTextBox
            // 
            PathTextBox.Location = new Point(12, 28);
            PathTextBox.Name = "PathTextBox";
            PathTextBox.Size = new Size(345, 23);
            PathTextBox.TabIndex = 1;
            PathTextBox.Text = "Path";
            PathTextBox.TextChanged += PathTextBox_TextChanged;
            // 
            // SelectPathBTN
            // 
            SelectPathBTN.Location = new Point(363, 28);
            SelectPathBTN.Name = "SelectPathBTN";
            SelectPathBTN.Size = new Size(75, 23);
            SelectPathBTN.TabIndex = 2;
            SelectPathBTN.Text = "Select path";
            SelectPathBTN.UseVisualStyleBackColor = true;
            SelectPathBTN.Click += SelectPathBTN_Click;
            // 
            // RvmatComboBox
            // 
            RvmatComboBox.FormattingEnabled = true;
            RvmatComboBox.Location = new Point(12, 72);
            RvmatComboBox.Name = "RvmatComboBox";
            RvmatComboBox.Size = new Size(204, 23);
            RvmatComboBox.TabIndex = 3;
            RvmatComboBox.SelectedIndexChanged += RvmatComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 54);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 4;
            label1.Text = "Rvmat Types";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 5;
            label2.Text = "Path to textures";
            // 
            // RvmatManagerBTN
            // 
            RvmatManagerBTN.Location = new Point(327, 120);
            RvmatManagerBTN.Name = "RvmatManagerBTN";
            RvmatManagerBTN.Size = new Size(111, 23);
            RvmatManagerBTN.TabIndex = 6;
            RvmatManagerBTN.Text = "RVMAT Manager";
            RvmatManagerBTN.UseVisualStyleBackColor = true;
            RvmatManagerBTN.Click += RvmatManagerBTN_Click;
            // 
            // OrganizeIntoFolder
            // 
            OrganizeIntoFolder.AutoSize = true;
            OrganizeIntoFolder.Checked = true;
            OrganizeIntoFolder.CheckState = CheckState.Checked;
            OrganizeIntoFolder.Location = new Point(12, 133);
            OrganizeIntoFolder.Name = "OrganizeIntoFolder";
            OrganizeIntoFolder.Size = new Size(240, 19);
            OrganizeIntoFolder.TabIndex = 7;
            OrganizeIntoFolder.Text = "Organize the types of rvmats into folders";
            OrganizeIntoFolder.UseVisualStyleBackColor = true;
            OrganizeIntoFolder.CheckedChanged += OrganizeIntoFolder_CheckedChanged;
            // 
            // CreateDamageRvmat
            // 
            CreateDamageRvmat.AutoSize = true;
            CreateDamageRvmat.Checked = true;
            CreateDamageRvmat.CheckState = CheckState.Checked;
            CreateDamageRvmat.Location = new Point(12, 108);
            CreateDamageRvmat.Name = "CreateDamageRvmat";
            CreateDamageRvmat.Size = new Size(145, 19);
            CreateDamageRvmat.TabIndex = 8;
            CreateDamageRvmat.Text = "Create damage rvmats";
            CreateDamageRvmat.UseVisualStyleBackColor = true;
            CreateDamageRvmat.CheckedChanged += CreateDamageRvmat_CheckedChanged;
            // 
            // ViewRvmatBTN
            // 
            ViewRvmatBTN.Location = new Point(327, 91);
            ViewRvmatBTN.Name = "ViewRvmatBTN";
            ViewRvmatBTN.Size = new Size(110, 23);
            ViewRvmatBTN.TabIndex = 9;
            ViewRvmatBTN.Text = "View RVMAT";
            ViewRvmatBTN.UseVisualStyleBackColor = true;
            ViewRvmatBTN.Click += ViewRvmatBTN_Click;
            // 
            // VerisonText
            // 
            VerisonText.AutoSize = true;
            VerisonText.Location = new Point(65, 157);
            VerisonText.Name = "VerisonText";
            VerisonText.Size = new Size(51, 15);
            VerisonText.TabIndex = 10;
            VerisonText.Text = "version: ";
            VerisonText.Click += VerisonText_Click;
            // 
            // DiscordLink
            // 
            DiscordLink.AutoSize = true;
            DiscordLink.Location = new Point(12, 157);
            DiscordLink.Name = "DiscordLink";
            DiscordLink.Size = new Size(47, 15);
            DiscordLink.TabIndex = 11;
            DiscordLink.TabStop = true;
            DiscordLink.Text = "Discord";
            DiscordLink.LinkClicked += DiscordLink_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.MF_Logo;
            pictureBox1.InitialImage = Properties.Resources.MF_Logo;
            pictureBox1.Location = new Point(275, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(162, 162);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // RvmatCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 184);
            Controls.Add(DiscordLink);
            Controls.Add(VerisonText);
            Controls.Add(ViewRvmatBTN);
            Controls.Add(CreateDamageRvmat);
            Controls.Add(OrganizeIntoFolder);
            Controls.Add(RvmatManagerBTN);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(RvmatComboBox);
            Controls.Add(SelectPathBTN);
            Controls.Add(PathTextBox);
            Controls.Add(CreateRvmatBTN);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RvmatCreator";
            Text = "RvmatCreator";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CreateRvmatBTN;
        private TextBox PathTextBox;
        private Button SelectPathBTN;
        private ComboBox RvmatComboBox;
        private Label label1;
        private Label label2;
        private Button RvmatManagerBTN;
        private CheckBox OrganizeIntoFolder;
        private CheckBox CreateDamageRvmat;
        private Button ViewRvmatBTN;
        private Label VerisonText;
        private LinkLabel DiscordLink;
        private PictureBox pictureBox1;
    }
}
