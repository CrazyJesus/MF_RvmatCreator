namespace MF_RvmatCreator
{
    
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    public partial class RvmatCreator : Form
    {
        public RvmatManagerForm m_rvmatManagerForm;

        public RvmatCreator()
        {

            InitializeComponent();
            PathTextBox.Text = RvmatManager.GetDefultPath();
            RefreshComboBox();
            //Debug.WriteLine("1111111111111");
            //ReadJsonFile();
        }

        void RefreshComboBox()
        {
            RvmatComboBox.Items.Clear();
            foreach (var type in RvmatManager.GetRvmatTypes())
            {
                RvmatComboBox.Items.Add(type);
            }
            RvmatComboBox.SelectedIndex = 0;
        }

        private void CreateRvmatBTN_Click(object sender, EventArgs e)
        {

        }

        private void PathTextBox_TextChanged(object sender, EventArgs e)
        {
            RvmatManager.ChangeDefultPath(PathTextBox.Text);
        }

        private void SelectPathBTN_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog directchoosedlg = new FolderBrowserDialog();
            if (Directory.Exists(PathTextBox.Text))
            {
                directchoosedlg.SelectedPath = PathTextBox.Text + "\\";
            }

            if (directchoosedlg.ShowDialog() != DialogResult.OK) return;

            PathTextBox.Text = directchoosedlg.SelectedPath;
        }

        private void RvmatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RvmatManagerBTN_Click(object sender, EventArgs e)
        {
            m_rvmatManagerForm = new RvmatManagerForm();
            m_rvmatManagerForm.ShowDialog();
        }
    }


}
