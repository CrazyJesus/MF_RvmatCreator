using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MF_RvmatCreator
{
    public partial class RvmatMessageBox : Form
    {
        public RvmatMessageBox(string msg)
        {
            InitializeComponent();
            SetText(msg);
        }

        private void SetText(string text)
        {
            richTextBox1.Text = text;
        }
    }
}
