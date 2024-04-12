namespace MF_RvmatCreator
{
    
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using static System.Net.Mime.MediaTypeNames;



    public partial class RvmatCreator : Form
    {
        public RvmatManagerForm m_rvmatManagerForm;
        public RvmatMessageBox m_MessageBox;

        public RvmatCreator()
        {

            InitializeComponent();
            PathTextBox.Text = RvmatManager.GetDefultPath();
            RefreshComboBox();
            VerisonText.Text += RvmatManager.GetVersion();
            CreateDamageRvmat.Checked = RvmatManager.IsCreateDamage();
            OrganizeIntoFolder.Checked = RvmatManager.IsOrganizeFolder();
            //Debug.WriteLine("1111111111111");
            //ReadJsonFile();
        }



        public void RefreshComboBox()
        {
            RvmatComboBox.Items.Clear();
            foreach (var type in RvmatManager.GetRvmatTypes())
            {
                RvmatComboBox.Items.Add(type);
            }
            RvmatComboBox.SelectedIndex = 0;
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
            m_rvmatManagerForm.SetRvmatCreator(this);
            m_rvmatManagerForm.ShowDialog();
        }

        private void CreateRvmatBTN_Click(object sender, EventArgs e)
        {
            string path = PathTextBox.Text;
            string? _nohq = string.Empty;
            string? _as = string.Empty;
            string? _smdi = string.Empty;
            RvmatManager.GetTexturePaths(path, out _nohq, out _as, out _smdi);
            string? type = RvmatComboBox.Items[RvmatComboBox.SelectedIndex].ToString();
            if (type != null)
            {
                string rvmat = RvmatManager.GetRVMAT(type);
                if (rvmat != null)
                {
                    if (OrganizeIntoFolder.Checked)
                    {
                        path = path + "\\" + type;
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                    }
                    string filename = path + "\\" + type + ".rvmat";
                    List<string> textures = new List<string>();
                    textures.Add(_nohq);
                    textures.Add(_as);
                    textures.Add(_smdi);
                    RvmatManager.CreateRvmatFile(filename, rvmat, textures);
                    if (CreateDamageRvmat.Checked)
                    {
                        filename = path + "\\" + type + "_damage.rvmat";
                        RvmatManager.CreateRvmatFile(filename, rvmat, textures, DamageType.Damage);
                        filename = path + "\\" + type + "_destruct.rvmat";
                        RvmatManager.CreateRvmatFile(filename, rvmat, textures, DamageType.Destruct);
                    }
                }
            }
        }

        

        private void ViewRvmatBTN_Click(object sender, EventArgs e)
        {
            string? type = RvmatComboBox.Items[RvmatComboBox.SelectedIndex].ToString();
            string rvmat = RvmatManager.GetRVMAT(type);
            RvmatManager.Message(rvmat);
        }

        private void DiscordLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DiscordLink.LinkVisited = true;

            // Navigate to a URL.
            string url = "https://discord.gg/Zmhp7J9y59";
            try
            {
                using (Process process = new())
                {
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.FileName = url;
                    process.Start();
                }
            }
            catch (Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                {
                    MessageBox.Show(noBrowser.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerisonText_Click(object sender, EventArgs e)
        {

        }

        private void CreateDamageRvmat_CheckedChanged(object sender, EventArgs e)
        {
            bool state = CreateDamageRvmat.Checked;
            RvmatManager.SetCreateDamage(state);
        }

        private void OrganizeIntoFolder_CheckedChanged(object sender, EventArgs e)
        {
            bool state = OrganizeIntoFolder.Checked;
            RvmatManager.SetOrganizeFoldere(state);
        }
    }
}
