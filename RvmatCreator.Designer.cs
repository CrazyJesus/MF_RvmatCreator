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
            PathTextBox.Location = new Point(12, 12);
            PathTextBox.Name = "PathTextBox";
            PathTextBox.Size = new Size(345, 23);
            PathTextBox.TabIndex = 1;
            PathTextBox.Text = "Path";
            // 
            // SelectPathBTN
            // 
            SelectPathBTN.Location = new Point(403, 12);
            SelectPathBTN.Name = "SelectPathBTN";
            SelectPathBTN.Size = new Size(75, 23);
            SelectPathBTN.TabIndex = 2;
            SelectPathBTN.Text = "Select path";
            SelectPathBTN.UseVisualStyleBackColor = true;
            // 
            // RvmatCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SelectPathBTN);
            Controls.Add(PathTextBox);
            Controls.Add(CreateRvmatBTN);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RvmatCreator";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CreateRvmatBTN;
        private TextBox PathTextBox;
        private Button SelectPathBTN;
    }
}
