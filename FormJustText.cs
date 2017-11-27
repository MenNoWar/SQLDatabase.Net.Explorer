using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDatabase.Net.Explorer
{
    public partial class FormJustText : Form
    {
        public FormJustText()
        {
            InitializeComponent();
        }

        public string[] Value
        {
            get
            {
                return textBox1.Lines;
            }

            set
            {
                textBox1.Lines = value;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.SelectedText);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var txt = textBox1.SelectedText.Replace("\r\n", "\n").Replace("\n\n", "\n");
            Clipboard.SetText(txt);
        }
    }
}
