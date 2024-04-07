namespace MF_RvmatCreator
{
    partial class RvmatManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RvmatManagerForm));
            label1 = new Label();
            SelectRvmatTextBox = new TextBox();
            SelectRvmatBTN = new Button();
            label2 = new Label();
            RvmatTypeTextBox = new TextBox();
            label3 = new Label();
            rvmatCheckListBox = new CheckedListBox();
            DeleteRvmatBTN = new Button();
            AddRvmatBTN = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 4);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 1;
            label1.Text = "Rvmat list ";
            // 
            // SelectRvmatTextBox
            // 
            SelectRvmatTextBox.Location = new Point(146, 25);
            SelectRvmatTextBox.Name = "SelectRvmatTextBox";
            SelectRvmatTextBox.Size = new Size(149, 23);
            SelectRvmatTextBox.TabIndex = 2;
            SelectRvmatTextBox.TextChanged += SelectRvmatTextBox_TextChanged;
            // 
            // SelectRvmatBTN
            // 
            SelectRvmatBTN.Location = new Point(359, 25);
            SelectRvmatBTN.Name = "SelectRvmatBTN";
            SelectRvmatBTN.Size = new Size(104, 23);
            SelectRvmatBTN.TabIndex = 3;
            SelectRvmatBTN.Text = "Select RVMAT";
            SelectRvmatBTN.UseVisualStyleBackColor = true;
            SelectRvmatBTN.Click += SelectRvmatBTN_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 9);
            label2.Name = "label2";
            label2.Size = new Size(166, 15);
            label2.TabIndex = 4;
            label2.Text = "Select an example of a RVMAT";
            // 
            // RvmatTypeTextBox
            // 
            RvmatTypeTextBox.Location = new Point(146, 77);
            RvmatTypeTextBox.Name = "RvmatTypeTextBox";
            RvmatTypeTextBox.Size = new Size(149, 23);
            RvmatTypeTextBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(146, 59);
            label3.Name = "label3";
            label3.Size = new Size(116, 15);
            label3.TabIndex = 7;
            label3.Text = "Type name for rvmat";
            // 
            // rvmatCheckListBox
            // 
            rvmatCheckListBox.FormattingEnabled = true;
            rvmatCheckListBox.Location = new Point(14, 25);
            rvmatCheckListBox.Name = "rvmatCheckListBox";
            rvmatCheckListBox.Size = new Size(126, 184);
            rvmatCheckListBox.TabIndex = 8;
            rvmatCheckListBox.ItemCheck += rvmatCheckListBox_ItemCheck;
            rvmatCheckListBox.Click += rvmatCheckListBox_Click;
            rvmatCheckListBox.SelectedIndexChanged += rvmatCheckListBox_SelectedIndexChanged;
            // 
            // DeleteRvmatBTN
            // 
            DeleteRvmatBTN.Location = new Point(80, 215);
            DeleteRvmatBTN.Name = "DeleteRvmatBTN";
            DeleteRvmatBTN.Size = new Size(60, 23);
            DeleteRvmatBTN.TabIndex = 9;
            DeleteRvmatBTN.Text = "Delete";
            DeleteRvmatBTN.UseVisualStyleBackColor = true;
            // 
            // AddRvmatBTN
            // 
            AddRvmatBTN.Location = new Point(14, 215);
            AddRvmatBTN.Name = "AddRvmatBTN";
            AddRvmatBTN.Size = new Size(60, 23);
            AddRvmatBTN.TabIndex = 10;
            AddRvmatBTN.Text = "Add rvmat";
            AddRvmatBTN.UseVisualStyleBackColor = true;
            // 
            // RvmatManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 251);
            Controls.Add(AddRvmatBTN);
            Controls.Add(DeleteRvmatBTN);
            Controls.Add(rvmatCheckListBox);
            Controls.Add(label3);
            Controls.Add(RvmatTypeTextBox);
            Controls.Add(label2);
            Controls.Add(SelectRvmatBTN);
            Controls.Add(SelectRvmatTextBox);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RvmatManagerForm";
            Text = "RvmatManager";
            FormClosed += RvmatManagerForm_FormClosed;
            Load += RvmatManagerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox SelectRvmatTextBox;
        private Button SelectRvmatBTN;
        private Label label2;
        private TextBox RvmatTypeTextBox;
        private Label label3;
        private CheckedListBox rvmatCheckListBox;
        private Button DeleteRvmatBTN;
        private Button AddRvmatBTN;
    }
}