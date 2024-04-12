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
        RvmatCreator m_rvmatCreator;

        private System.Windows.Forms.Timer timer1;

        public RvmatManagerForm()
        {
            InitializeComponent();
        }

        public void SetRvmatCreator(RvmatCreator rvmatCreator)
        {
            m_rvmatCreator = rvmatCreator;
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
            if (File.Exists(SelectRvmatTextBox.Text) && RvmatTypeTextBox.Text != String.Empty)
            {
                AddRvmatBTN.Enabled = true;
                return;
            }
            else
            {
                AddRvmatBTN.Enabled = false;
            }

            if (rvmatCheckListBox.SelectedIndex == -1)
            {
                DeleteRvmatBTN.Enabled = false;
            }
            else
            {
                DeleteRvmatBTN.Enabled = true;
            }
        }

        public void RefreshRvmatsList()
        {
            rvmatCheckListBox.Items.Clear();
            List<string> rvmats = RvmatManager.GetRvmatTypes();
            foreach (string s in rvmats)
            {
                rvmatCheckListBox.Items.Add(s);
            }
            m_rvmatCreator.RefreshComboBox();
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
            ClearChecked();
        }

        private void ClearChecked()
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

        private void AddRvmatBTN_Click(object sender, EventArgs e)
        {
            string path = SelectRvmatTextBox.Text;
            Debug.WriteLine(path);
            if (File.Exists(path))
            {
                RvmatManager.AddRvmat(RvmatTypeTextBox.Text, path);
                RefreshRvmatsList();
            }
        }

        private void RvmatTypeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteRvmatBTN_Click(object sender, EventArgs e)
        {
            if (rvmatCheckListBox != null)
            {
                int index = rvmatCheckListBox.SelectedIndex;
                string type;
                if (index != -1)
                {
                    type = rvmatCheckListBox.Items[index].ToString();
                    RvmatManager.RemoveRvmat(type);
                    RefreshRvmatsList();
                }
            }
        }

        private void InstructionBTN_Click(object sender, EventArgs e)
        {
            string text = "To add a new rvmat, you must select the .rvmat file to serve as a template. The paths of the rvmat will need to be replaced with\n%Path%, so that the program will substitute there the paths to textures.  An example of a correct rvmat is below: \n\n\n\n";
            text += "ambient[]={0.5,0.5,0.5,1};\r\ndiffuse[]={0.5,0.5,0.5,1};\r\nforcedDiffuse[]={0.5,0.5,0.5,1};\r\nemmisive[]={0,0,0,1};\r\nspecular[]={0.32941177,0.32941177,0.32156864,1};\r\nspecularPower=90;\r\nPixelShaderID=\"Super\";\r\nVertexShaderID=\"Super\";\r\nclass Stage1\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage2\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage3\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage4\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage5\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage6\r\n{\r\n\ttexture=\"#(ai,64,64,1)fresnel(1,0.7)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage7\r\n{\r\n\ttexture=\"dz\\data\\data\\env_land_co.paa\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,1};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\n";
            RvmatManager.Message(text);
        }

        private void ResetRvmatsBTN_Click(object sender, EventArgs e)
        {
            RvmatManager.ResetRvmats();
            RefreshRvmatsList();
        }
    }
}
