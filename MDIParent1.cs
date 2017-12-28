using SQLDatabase.Net.SQLDatabaseClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDatabase.Net.Explorer
{
	public partial class MDIParent1 : Form
	{
		private static object lockObject = new object();

		public MDIParent1()
		{
			InitializeComponent();
			this.Text = Application.ProductName + " " + Application.ProductVersion;
			this.DoubleBuffered = true;
			Connections = GetConnectionList();
			InititalizeTreeview();
		}

		private void CreateTableNodes(TreeNode parentNode, IEnumerable<ISqlDataObject> viewsOrTables)
		{
			lock (lockObject)
			{
				var indexNames = new List<string>();
				parentNode.Nodes.Clear();

				foreach (var t in viewsOrTables.OrderBy(o => o.Name))
				{
					ContextMenuStrip cms = null;
					if (t.GetType() == typeof(SqlDataTable))
					{
						cms = cmsTable;

						using (var con = new SqlDatabaseConnection(t.ConnectionString))
						{
							try
							{
								var sql = string.Format("SYSCMD Index_List('{0}');", t.Name);

								con.Open();
								var dt = new DataTable("Indexes_" + t.Name);
								using (var da = new SqlDatabaseDataAdapter(sql, con))
								{
									da.Fill(dt);
									indexNames.Clear();
									foreach (DataRow row in dt.Rows)
									{
										var name = Convert.ToString(row["Name"]);
										if (!string.IsNullOrEmpty(name))
										{
											indexNames.Add(name);
										}
									}
								}
							}
							catch
							{
								throw;
							}
							finally
							{
								con.Close();
							}
						}
					}

					else if (t.GetType() == typeof(SqlDataView)) cms = cmsView;
					else if (t.GetType() == typeof(SqlDataIndex)) cms = cmsIndex;

					var tnTable = new TreeNode
					{
						Text = t.Name,
						Tag = t,
						ImageKey = "DbTable",
						SelectedImageKey = "DbTable",
						ContextMenuStrip = cms
					};

					if (t.Name.StartsWith("sys_"))
					{
						tnTable.Text = "$" + t.Name;
						tnTable.ContextMenuStrip = null;
						tnTable.ForeColor = SystemColors.GrayText;
					}

					if (indexNames.Any())
					{
						indexNames.Reverse();
						foreach (var s in indexNames)
						{
							var isSysIndex = s.StartsWith("sys_");
							var cap = isSysIndex ? "$" + s : s;

							var tnTableIndex = new TreeNode(cap)
							{
								ImageKey = isSysIndex ? "Key_Blue" : "keyTransp.png",
								SelectedImageKey = isSysIndex ? "Key_Blue" : "keyTransp.png",
								Tag = new SqlDataIndex
								{
									ConnectionString = t.ConnectionString,
									Name = s
								},
								ForeColor = isSysIndex ? SystemColors.GrayText : SystemColors.ControlText,
								ContextMenuStrip = isSysIndex ? null : cmsIndex
							};

							tnTable.Nodes.Add(tnTableIndex);
						}
					}

					parentNode.Nodes.Add(tnTable);
				}
			}
		}

		private void AddConnectionNode(DbSettingItem item)
		{
			lock (lockObject)
			{
				if (item.Tables == null)
				{
					item.ReadObjects();
				}

				var tn = new TreeNode
				{
					Text = item.Name,
					Tag = item,
					ImageKey = "Database_Blue",
					SelectedImageKey = "Database_Red",
					ContextMenuStrip = cmsConnection
				};

				var tnTables = new TreeNode
				{
					Text = "Tables",
					Tag = item,
					ContextMenuStrip = cmsTables
				};
				item.TnTables = tnTables;

				CreateTableNodes(tnTables, item.Tables);

				var tnViews = new TreeNode
				{
					Text = "Views",
					Tag = item
				};
				item.TnViews = tnViews;

				CreateTableNodes(tnViews, item.Views);

				var tnIndizes = new TreeNode
				{
					Text = "Indizes",
					Tag = item
				};

				CreateTableNodes(tnIndizes, item.Indizes);

				item.TnIndizes = tnIndizes;

				tn.Nodes.Add(tnTables);
				tn.Nodes.Add(tnViews);

				tnIndizes.ContextMenuStrip = cmsIndizes;
				tn.Nodes.Add(tnIndizes);

				tvMain.Nodes.Add(tn);
			}
		}

		private void InititalizeTreeview()
		{
			tvMain.Nodes.Clear();
			foreach (var con in Connections)
			{
				AddConnectionNode(con);
			}
		}

		public List<DbSettingItem> Connections
		{
			get; private set;
		}

		private string SettingsFile
		{
			get
			{
				return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.db");
			}
		}

		private void CreateSettingsTables(SqlDatabaseConnection con)
		{
			const string sql = "CREATE TABLE IF NOT EXISTS CONNECTIONS ( " +
									"Id TEXT NOT NULL,\n" +
									"Name TEXT NOT NULL,\n" +
									"DbFile TEXT NOT NULL,\n" +
									"Schema TEXT NOT NULL DEFAULT 'dbo',\n" +
									"Key TEXT\n" +
									")";

			using (var cmd = new SqlDatabaseCommand(sql, con))
			{
				cmd.ExecuteNonQuery();
			}
		}

		private SqlDatabaseConnection GetSettingsConnection()
		{
			var file = SettingsFile;
			var createTables = !File.Exists(file);
			var csb = string.Format("Schema=dbo;DataSource=file://{0}", SettingsFile);
			var con = new SqlDatabaseConnection(csb);
			con.Open();

			CreateSettingsTables(con);

			return con;
		}

		private List<DbSettingItem> GetConnectionList()
		{
			using (var con = GetSettingsConnection())
			{
				var list = DbSettingItem.List(con);
				if (list.Count == 0)
				{
					var db = new DbSettingItem
					{
						DbFile = SettingsFile,
						Key = string.Empty,
						Name = "Settings",
						Schema = "dbo"
					};

					list.Add(db);
				}

				return list;
			}
		}

		private void OpenFile(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			toolStrip.Visible = toolBarToolStripMenuItem.Checked;
		}

		private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			statusStrip.Visible = statusBarToolStripMenuItem.Checked;
		}

		private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.ArrangeIcons);
		}

		private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Form childForm in MdiChildren)
			{
				childForm.Close();
			}
		}

		private string[] SwitchingNames = new string[] { "Tables", "Views" };

		private void tvMain_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			if (SwitchingNames.Contains(e.Node.Text))
			{
				e.Node.ImageIndex = 0;
				e.Node.SelectedImageIndex = 2;
			}
		}

		private void tvMain_AfterExpand(object sender, TreeViewEventArgs e)
		{
			if (SwitchingNames.Contains(e.Node.Text))
			{
				e.Node.ImageIndex = 1;
				e.Node.SelectedImageIndex = 3;
			}
		}

		private void registerNewDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var frm = new RegisterDbForm() { Text = "Add new Connection" })
			{
				if (frm.ShowDialog() == DialogResult.OK)
				{
					var item = new DbSettingItem
					{
						DbFile = frm.DbFile,
						Key = frm.Key,
						Name = frm.DisplayName,
						Schema = frm.Schema
					};

					using (var con = GetSettingsConnection())
					{
						DbSettingItem.Insert(con, item);
					}

					Connections.Add(item);
					AddConnectionNode(item);
				}
			}
		}

		private void DataViewFromTreeNode(TreeNode node)
		{
			if (node == null || node.Tag == null) return;
			var typ = node.Tag.GetType();

			if (typ != typeof(SqlDataTable) && typ != typeof(SqlDataView)) return;

			var frm = new DataViewForm();
			frm.MdiParent = this;
			var source = node.Tag as ISqlDataObject;
			if (source.Columns.Count == 0)
			{
				using (var con = new SqlDatabaseConnection(source.ConnectionString))
				{
					con.Open();
					try
					{
						source.GetColumns(con);
					}
					catch
					{
						throw;
					}
					finally
					{
						con.Close();
					}
				}
			}

			frm.InitializeData(source);

			var connection = this.Connections.FirstOrDefault(o => o.ConnectionString == source.ConnectionString);
			if (connection != null)
			{
				frm.Text = string.Format("{0} [{1}]", source.Name, connection.Name);
			}

			frm.Visible = true;
		}

		private void tvMain_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var node = tvMain.GetNodeAt(e.X, e.Y);
			DataViewFromTreeNode(node);
		}

		private TreeNode TablesParent = null;

		private void tvMain_AfterSelect(object sender, TreeViewEventArgs e)
		{
			tvSchema.Nodes.Clear();
			SelectedConnectionString = string.Empty;

			if (e.Node == null || e.Node.Tag == null) return;

			if (e.Node.Tag.GetType().GetInterface("ISqlDataObject", true) != null)
			{
				var table = e.Node.Tag as ISqlDataObject;
				if (table.Columns == null || table.Columns.Count == 0)
				{
					using (var con = new SqlDatabaseConnection(table.ConnectionString))
					{
						try
						{
							con.Open();
							table.GetColumns(con);
						}
						catch
						{
							// NOOP
						}
						finally
						{
							con.Close();
						}
					}
				}

				foreach (var col in table.Columns)
				{
					var tnCol = new TreeNode
					{
						Text = string.Format("{0} [{1}]", col.Name, col.Type),
						ImageKey = "Column",
						SelectedImageKey = "Column",
						Tag = col
					};

					if (col.IsPKey)
					{
						tnCol.ImageKey = "key_Blue";
						tnCol.SelectedImageKey = "key_Blue";
					}

					tvSchema.Nodes.Add(tnCol);
				}

				SelectedConnectionString = table.ConnectionString;
				TablesParent = e.Node.Parent;
			}
			else if (e.Node.Tag.GetType() == typeof(DbSettingItem))
			{
				var setting = e.Node.Tag as DbSettingItem;
				SelectedConnectionString = setting.ConnectionString;
			}
		}

		private void tsbSql_Click(object sender, EventArgs e)
		{
			var sqlForm = new SqlForm();
			sqlForm.Connections = Connections;
			sqlForm.MdiParent = this;

			sqlForm.SelectedConnection = Connections.FirstOrDefault(o => o.ConnectionString == SelectedConnectionString);
			sqlForm.Visible = true;
		}

		private string _selectedConnectionString = string.Empty;
		public string SelectedConnectionString
		{
			get { return _selectedConnectionString; }
			set
			{
				_selectedConnectionString = value;
				toolStripStatusLabel.Text = value;
			}
		}

		private void tsiCreateTable_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(SelectedConnectionString)) return;

			var frm = new CreateTableForm() { ConnectionString = SelectedConnectionString };
			if (frm.ShowDialog() == DialogResult.OK)
			{
				var setting = CurrentSettingItem;
				if (setting != null)
				{
					setting.ReadObjects();
					CreateTableNodes(setting.TnTables, setting.Tables);
				}
			}
		}

		private void tvMain_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				var node = tvMain.GetNodeAt(e.X, e.Y);
				if (node != null)
				{
					tvMain.SelectedNode = node;
				}
			}
		}

		private void tsiEditTableData_Click(object sender, EventArgs e)
		{
			DataViewFromTreeNode(tvMain.SelectedNode);
		}

		private void tsiViewShowData_Click(object sender, EventArgs e)
		{
			DataViewFromTreeNode(tvMain.SelectedNode);
		}

		private void tsiUnregister_Click(object sender, EventArgs e)
		{
			var node = tvMain.SelectedNode;
			if (node == null || node.Tag == null || node.Tag.GetType() != typeof(DbSettingItem)) return;
			var item = node.Tag as DbSettingItem;
			if (item == null) return;

			if (MessageBox.Show("Really unregister this Connection?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				using (var con = GetSettingsConnection())
				{
					DbSettingItem.Delete(con, item);
					tvMain.Nodes.Remove(node);
				}
			}
		}

		private void tsiDropTable_Click(object sender, EventArgs e)
		{
			var node = tvMain.SelectedNode;
			if (node == null || node.Tag == null) return;
			var newNode = node.PrevVisibleNode;

			if (node.Tag.GetType() == typeof(SqlDataTable))
			{
				var table = node.Tag as SqlDataTable;
				if (table == null) return;

				if (MessageBox.Show("Are you sure to drop table '" + table.Name + "'?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					var sql = "DROP TABLE " + table.Name;
					using (var con = new SqlDatabaseConnection(table.ConnectionString))
					{
						con.Open();
						new SqlDatabaseCommand(sql, con).ExecuteNonQuery();
						con.Close();
						tvMain.Nodes.Remove(node);
						tvMain.SelectedNode = newNode;
					}
				}
			}
		}

		private DbSettingItem CurrentSettingItem
		{
			get
			{
				if (string.IsNullOrEmpty(SelectedConnectionString)) return null;
				return Connections.FirstOrDefault(o => o.ConnectionString == SelectedConnectionString);
			}
		}

		private void showCreateIndexForm(IEnumerable<ISqlDataObject> tables)
		{
			var node = tvMain.SelectedNode;
			if (node == null || node.Tag == null) return;
			using (var form = new CreateIndexForm(tables))
			{
				if (form.ShowDialog() == DialogResult.OK)
				{
					var setting = CurrentSettingItem;
					if (setting == null) return;

					setting.ReadObjects();
					CreateTableNodes(setting.TnIndizes, setting.Indizes);
				}
			}
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var node = tvMain.SelectedNode;
			if (node == null || node.Tag == null) return;
			var db = node.Tag as DbSettingItem;
			if (db == null) return;
			showCreateIndexForm(db.Tables);
		}

		private void createIndexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var node = tvMain.SelectedNode;
			if (node == null || node.Tag == null) return;
			var newNode = node.PrevVisibleNode;

			if (node.Tag.GetType() == typeof(SqlDataTable))
			{
				var table = node.Tag as SqlDataTable;
				if (table == null) return;
				showCreateIndexForm(new List<ISqlDataObject> { table });
			}
		}

		private void dropIndexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var node = tvMain.SelectedNode;
			if (node == null || node.Tag == null || node.Tag.GetType() != typeof(SqlDataIndex)) return;
			var idx = node.Tag as SqlDataIndex;
			if (idx == null) return;

			if (MessageBox.Show("Really drop Index '" + idx.Name + "'?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				string sql = "DROP INDEX " + idx.Name;
				using (var con = new SqlDatabaseConnection(idx.ConnectionString))
				{
					try
					{
						con.Open();
						using (var cmd = new SqlDatabaseCommand(sql, con))
						{
							cmd.ExecuteNonQuery();
							tvMain.Nodes.Remove(node);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					finally
					{
						con.Close();
					}
				}
			}
		}

		private void extractDDLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var node = tvMain.SelectedNode;
			if (node == null || node.Tag == null || node.Tag.GetType() != typeof(SqlDataTable)) return;
			var table = node.Tag as SqlDataTable;
			if (table == null) return;

			var frm = new SqlForm();
			frm.Sql = Utils.GetCreateSql(table);
			frm.MdiParent = this;
			frm.Connections = Connections;
			frm.Show();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			tvMain.Nodes.Clear();
			tvSchema.Nodes.Clear();

			Connections = GetConnectionList();
			InititalizeTreeview();
		}

		private void tsmiCopyFields_Click(object sender, EventArgs e)
		{
			var txt = string.Empty;
			foreach (TreeNode tn in tvSchema.Nodes)
			{
				txt += tn.Text.Split('[')[0] + "\n";
			}

			txt = txt.Trim();
			Clipboard.SetText(txt);
		}


		private void copyAsCDefinitionToClipbrdToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var node = tvMain.SelectedNode;
			if (node == null || node.Tag == null || node.Tag.GetType() != typeof(SqlDataTable)) return;
			var table = node.Tag as SqlDataTable;
			using (var tw = new StreamWriter(new MemoryStream()))
			{
				tw.WriteLine(string.Format("[Table(\"{0}\")]", table.Name));
				tw.WriteLine("public class " + table.Name);
				tw.WriteLine("{");
				tw.WriteLine("");

				foreach (var c in table.Columns)
				{
					tw.WriteLine("\t/// <summary>");
					tw.WriteLine("\t/// Gets or sets the " + c.Name);
					tw.WriteLine("\t/// </summary>");

					if (c.IsPKey)
					{
						tw.WriteLine("\t[Key]");
					}

					if (!c.Nullable)
					{
						tw.WriteLine("\t[Required]");
					}

					var tName = SqlDataColumn.SqlTypeToType(c.Type).Name;
					if (tName == "Int32")
					{
						tName = "int";
					}

					tw.WriteLine(string.Format("\t[Column(\"{0}\")]", c.Name));
					tw.WriteLine(string.Format("\tpublic {0} {1} {{ get; set; }}", tName, c.Name));
					tw.WriteLine("");
				}

				tw.WriteLine("}");
				tw.Flush();

				using (var sr = new StreamReader(tw.BaseStream))
				{
					sr.BaseStream.Seek(0, 0);
					var txt = sr.ReadToEnd();
					var frm = new FormJustText { Text = "C# Class " + table.Name, Value = txt.Split('\n') };
					frm.MdiParent = this;
					frm.Visible = true;
				}
			}

		}

		private void copyValuesAsCListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var node = tvMain.SelectedNode;
			if (node == null || node.Tag == null || node.Tag.GetType() != typeof(SqlDataTable)) return;
			var table = node.Tag as SqlDataTable;

			var dt = new DataTable(table.Name);
			using (var con = new SqlDatabaseConnection(table.ConnectionString))
			{
				con.Open();
				using (SqlDatabaseDataAdapter da = new SqlDatabaseDataAdapter("select * FROM " + table.Name, con))
				{
					da.Fill(dt);
				}

				con.Close();
			}


			if (dt.Rows.Count == 0)
			{
				MessageBox.Show("No data to generate from in table " + table.Name, "Information");
				return;
			}

			using (var ms = new MemoryStream())
			{
				using (var tw = new StreamWriter(ms))
				{
					tw.WriteLine("return new List<" + table.Name + "> {");
					var valueLines = new List<string>();

					foreach (DataRow row in dt.Rows)
					{
						var propVals = new List<string>();
						foreach (DataColumn col in dt.Columns)
						{
							var stringVal = Convert.ToString(row[col]);
							if (col.DataType == typeof(string))
							{
								stringVal = "\"" + stringVal.Replace("\"", "\\\"") + "\"";
							}

							stringVal = col.ColumnName + " = " + stringVal;
							propVals.Add(stringVal);
						}

						var colTxt = "\tnew " + table.Name + " { ";
						colTxt += string.Join(", ", propVals);
						colTxt += " }";
						valueLines.Add(colTxt);
					}

					tw.WriteLine(string.Join(",\n", valueLines));

					tw.WriteLine("}");
					tw.Flush();


					using (var sr = new StreamReader(ms))
					{
						ms.Seek(0, 0);
						var txt = sr.ReadToEnd();

						var frm = new FormJustText { Text = "C# List<" + table.Name + ">", Value = txt.Split('\n') };
						frm.MdiParent = this;
						frm.Visible = true;
					}
				}
			}
		}

		private void extractDDLToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			var node = tvMain.SelectedNode;
			if (node == null || node.Tag == null || node.Tag.GetType() != typeof(SqlDataView)) return;
			var view = node.Tag as SqlDataView;
			if (view == null) return;

			var frm = new SqlForm();
			frm.Sql = Utils.GetCreateSql(view);
			frm.MdiParent = this;
			frm.Connections = Connections;
			frm.Show();
		}

		private void dropViewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var node = tvMain.SelectedNode;
			if (node == null || node.Tag == null || node.Tag.GetType() != typeof(SqlDataView)) return;
			var view = node.Tag as SqlDataView;
			if (view == null) return;
			var newNode = node.PrevVisibleNode;

			if (MessageBox.Show("Are you sure to drop view '" + view.Name + "'?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				var sql = "DROP VIEW " + view.Name;
				using (var con = new SqlDatabaseConnection(view.ConnectionString))
				{
					try
					{
						con.Open();
						new SqlDatabaseCommand(sql, con).ExecuteNonQuery();
						tvMain.Nodes.Remove(node);
						tvMain.SelectedNode = newNode;
					}
					catch
					{
						throw;
					}
					finally
					{
						con.Close();
					}
				}
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("SqlDatabase.Net.Explorer by mennowar\n" + 
							"This Software is 'as is' without any warranties.\n" + 
							"Use at your own risk.", "Information");
		}
	}
}
