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
    public partial class RegisterDbForm : Form
    {
        public RegisterDbForm()
        {
            InitializeComponent();
        }

        public string DisplayName
        {
            get
            {
                return tbDisplay.Text;
            }

            set
            {
                tbDisplay.Text = value;
            }
        }

        public string Key
        {
            get
            {
                return tbKey.Text;
            }

            set
            {
                tbKey.Text = value;
            }
        }

        public string Schema
        {
            get
            {
                return tbSchema.Text;
            }

            set
            {
                tbSchema.Text = value;
            }
        }

        public string DbFile
        {
            get
            {
                return tbFile.Text;
            }
            set
            {
                tbFile.Text = value;
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            using (var of = new OpenFileDialog
            {
                Title = "Select Database File",
                Multiselect = false,
                CheckPathExists = true,
                ShowReadOnly = false,
                DefaultExt = ".db",
                CheckFileExists = true,
                AutoUpgradeEnabled = true,
                DereferenceLinks = true,
                RestoreDirectory = true
            })
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    DbFile = of.FileName;
                }
            }
        }

        private void RegisterDbForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
