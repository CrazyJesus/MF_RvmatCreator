using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MF_RvmatCreator
{
    public partial class RvmatManagerForm : Form
    {
        private System.Windows.Forms.Timer timer1;

        public RvmatManagerForm()
        {
            InitializeComponent();
        }

        public void InitTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 200; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool BtnState;
            if (File.Exists(SelectRvmatTextBox.Text) && RvmatTypeTextBox.Text != String.Empty)
            {
                AddRvmatBTN.Enabled = true;
                return;
            }
            AddRvmatBTN.Enabled = false;
        }

        public void RefreshRvmatsList()
        {
            rvmatCheckListBox.ClearSelected();
            List<string> rvmats = RvmatManager.GetRvmatTypes();
            foreach (string s in rvmats)
            {
                rvmatCheckListBox.Items.Add(s);
            }

        }

        private void RvmatsList_TextChanged(object sender, EventArgs e)
        {

        }

        private void SelectRvmatTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(SelectRvmatTextBox.Text))
            {
                RvmatManager.ChangeDefultExampleRvmatPath(SelectRvmatTextBox.Text);
            }
        }

        private void SelectRvmatBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "RVMAT files(*.rvmat)|*.rvmat|All files(*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog.FileName;

            if (File.Exists(filename))
            {
                SelectRvmatTextBox.Text = filename;
            }

        }

        private void rvmatCheckListBox_Click(object sender, EventArgs e)
        {
            int index = rvmatCheckListBox.SelectedIndex;
            for (int i = 0; i < rvmatCheckListBox.Items.Count; i++)
            {
                if (i != rvmatCheckListBox.SelectedIndex)
                {

                    rvmatCheckListBox.SetItemChecked(i, false);
                }

            }
        }

        private void RvmatManagerForm_Load(object sender, EventArgs e)
        {
            InitTimer();

            RefreshRvmatsList();
            SelectRvmatTextBox.Text = RvmatManager.GetDefultExampleRvmatPath();
        }

        private void RvmatManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }
    }
}
