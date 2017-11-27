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
    }
}
