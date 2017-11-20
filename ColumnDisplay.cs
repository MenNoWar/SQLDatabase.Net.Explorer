using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDatabase.Net.Explorer
{
    public partial class ColumnDisplay : UserControl
    {
        public delegate void OnPrimaryKeyCheckedEvent(object sender);
        public event OnPrimaryKeyCheckedEvent OnPrimaryKeyChecked = null;

        public ColumnDisplay()
        {
            InitializeComponent();
            Column = new SqlDataColumn();
        }

        private SqlDataColumn _column = new SqlDataColumn();
        public SqlDataColumn Column
        {
            get
            {
                UpdateColumnValues();
                return _column;
            }
            set {                
                _column = value;
                UpdateDisplayValuesFromColumn();
            }
        }

        public void UpdateDisplayValuesFromColumn()
        {
            if (_column == null) return;
            ColumnName = _column.Name;
            IsNullable = _column.Nullable;
            IsPKey = _column.IsPKey;
            DefaultValue = Convert.ToString(_column.DefaultValue);
            DataType = _column.Type;
            AutoInc = _column.AutoInc;
            UpdateCheckboxState();
        }

        public void UpdateColumnValues()
        {
            if (_column == null) return;
            _column.Name = ColumnName;
            _column.Nullable = IsNullable;
            _column.IsPKey = IsPKey;
            _column.DefaultValue = DefaultValue;
            _column.Type = DataType;
            _column.AutoInc = AutoInc;
        }

        public ColumnDisplay(SqlDataColumn column) : this()
        {
            this.Column = column;            
        }

        public bool AutoInc
        {
            get
            {
                return cbAutoInc.Checked;
            }
            set
            {
                cbAutoInc.Checked = value;
            }
        }

        public string ColumnName
        {
            get
            {
                return tbColumnName.Text;
            }

            set
            {
                if (value == null)
                {
                    tbColumnName.Text = string.Empty;
                }
                else
                {
                    tbColumnName.Text = value;
                }
            }
        }

        public bool IsNullable
        {
            get
            {
                return cbNullable.Checked;
            }

            set
            {
                cbNullable.Checked = value;
            }
        }

        public bool IsPKey
        {
            get
            {
                return cbPrimaryKey.Checked;
            }
            set
            {
                cbPrimaryKey.Checked = value;
                pictureBox1.Visible = value;
            }
        }

        public string DefaultValue
        {
            get
            {
                return tbDefaultValue.Text;
            }

            set
            {
                tbDefaultValue.Text = value;
            }
        }

        private void UpdateCheckboxState()
        {
            if (IsPKey)
            {
                cbAutoInc.Enabled = true;
                IsNullable = false;
                cbNullable.Enabled = false;
            }
            else
            {
                AutoInc = false;
                cbAutoInc.Enabled = false;
                cbNullable.Enabled = true;
            }

            pictureBox1.Visible = IsPKey;
        }

        public string DataType
        {
            get
            {
                return cbDataType.Text;
            }
            set
            {
                cbDataType.SelectedIndex = -1;
                if (string.IsNullOrEmpty(value)) return;
                for (var i = 0; i < cbDataType.Items.Count; i++)
                {
                    if (cbDataType.Items[i].ToString().ToUpper() == value.ToUpper())
                    {
                        cbDataType.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void cbPrimaryKey_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCheckboxState();
        }

        private void cbPrimaryKey_Click(object sender, EventArgs e)
        {
            if (cbPrimaryKey.Checked) OnPrimaryKeyChecked?.Invoke(this);
        }

        private void ColumnDisplay_Leave(object sender, EventArgs e)
        {
            UpdateColumnValues();
            pictureBox1.Visible = Column.IsPKey;
        }

        private void cbAutoInc_Click(object sender, EventArgs e)
        {
            if (cbAutoInc.Checked)
            {
                tbDefaultValue.Text = string.Empty;
                Column.DefaultValue = string.Empty;
                tbDefaultValue.Enabled = false;
                DataType = "Integer";
            } else
            {
                tbDefaultValue.Enabled = true;
            }
        }
    }
}
