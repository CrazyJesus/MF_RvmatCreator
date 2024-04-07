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
            SuspendLayout();
            // 
            // CreateRvmatBTN
            // 
            CreateRvmatBTN.Location = new Point(677, 415);
            CreateRvmatBTN.Name = "CreateRvmatBTN";
            CreateRvmatBTN.Size = new Size(111, 23);
            CreateRvmatBTN.TabIndex = 0;
            CreateRvmatBTN.Text = "Create RVMAT";
            CreateRvmatBTN.UseVisualStyleBackColor = true;
            CreateRvmatBTN.Click += CreateRvmatBTN_Click;
            // 
            // PathTextBox
            // 
            PathTextBox.Location = new Point(362, 40);
            PathTextBox.Name = "PathTextBox";
            PathTextBox.Size = new Size(345, 23);
            PathTextBox.TabIndex = 1;
            PathTextBox.Text = "Path";
            PathTextBox.TextChanged += PathTextBox_TextChanged;
            // 
            // SelectPathBTN
            // 
            SelectPathBTN.Location = new Point(713, 39);
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
            RvmatComboBox.Location = new Point(12, 39);
            RvmatComboBox.Name = "RvmatComboBox";
            RvmatComboBox.Size = new Size(204, 23);
            RvmatComboBox.TabIndex = 3;
            RvmatComboBox.SelectedIndexChanged += RvmatComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 4;
            label1.Text = "Rvmat Types";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(362, 21);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 5;
            label2.Text = "Path to textures";
            // 
            // RvmatManagerBTN
            // 
            RvmatManagerBTN.Location = new Point(677, 386);
            RvmatManagerBTN.Name = "RvmatManagerBTN";
            RvmatManagerBTN.Size = new Size(111, 23);
            RvmatManagerBTN.TabIndex = 6;
            RvmatManagerBTN.Text = "RVMAT Manager";
            RvmatManagerBTN.UseVisualStyleBackColor = true;
            RvmatManagerBTN.Click += RvmatManagerBTN_Click;
            // 
            // RvmatCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RvmatManagerBTN);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(RvmatComboBox);
            Controls.Add(SelectPathBTN);
            Controls.Add(PathTextBox);
            Controls.Add(CreateRvmatBTN);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RvmatCreator";
            Text = "RvmatCreator";
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
    }
}
