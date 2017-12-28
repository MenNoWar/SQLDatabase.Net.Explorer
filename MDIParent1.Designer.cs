namespace SQLDatabase.Net.Explorer
{
    partial class MDIParent1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Table1", 6, 6);
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Table2", 6, 6);
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Table3", 6, 6);
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Tables", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("View1");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("View2");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Views", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Connection", 16, 19, new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7});
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.registerNewDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.tsbSql = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.imageListTreeviewDefault = new System.Windows.Forms.ImageList(this.components);
			this.panelLeftMain = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tvMain = new System.Windows.Forms.TreeView();
			this.tvSchema = new System.Windows.Forms.TreeView();
			this.cmsSchema = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiCopyFields = new System.Windows.Forms.ToolStripMenuItem();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.cmsTables = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsiCreateTable = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsTable = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsiEditTableData = new System.Windows.Forms.ToolStripMenuItem();
			this.createIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.codeGenerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dDLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyValuesAsCListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsiCreateTable2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsiDropTable = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.cmsView = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsiViewShowData = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsConnection = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsiUnregister = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsIndizes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsIndex = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.dropIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.extractDDLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.dropViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.panelLeftMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.cmsSchema.SuspendLayout();
			this.cmsTables.SuspendLayout();
			this.cmsTable.SuspendLayout();
			this.cmsView.SuspendLayout();
			this.cmsConnection.SuspendLayout();
			this.cmsIndizes.SuspendLayout();
			this.cmsIndex.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.viewMenu,
            this.windowsMenu,
            this.helpMenu});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.MdiWindowListItem = this.windowsMenu;
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(924, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "MenuStrip";
			// 
			// fileMenu
			// 
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerNewDatabaseToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
			this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(37, 20);
			this.fileMenu.Text = "&File";
			// 
			// registerNewDatabaseToolStripMenuItem
			// 
			this.registerNewDatabaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("registerNewDatabaseToolStripMenuItem.Image")));
			this.registerNewDatabaseToolStripMenuItem.Name = "registerNewDatabaseToolStripMenuItem";
			this.registerNewDatabaseToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.registerNewDatabaseToolStripMenuItem.Text = "&Register new Database";
			this.registerNewDatabaseToolStripMenuItem.Click += new System.EventHandler(this.registerNewDatabaseToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.exitToolStripMenuItem.Text = "&Quit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
			// 
			// viewMenu
			// 
			this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.statusBarToolStripMenuItem});
			this.viewMenu.Name = "viewMenu";
			this.viewMenu.Size = new System.Drawing.Size(44, 20);
			this.viewMenu.Text = "&View";
			// 
			// toolBarToolStripMenuItem
			// 
			this.toolBarToolStripMenuItem.Checked = true;
			this.toolBarToolStripMenuItem.CheckOnClick = true;
			this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
			this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.toolBarToolStripMenuItem.Text = "&Toolbar";
			this.toolBarToolStripMenuItem.Click += new System.EventHandler(this.ToolBarToolStripMenuItem_Click);
			// 
			// statusBarToolStripMenuItem
			// 
			this.statusBarToolStripMenuItem.Checked = true;
			this.statusBarToolStripMenuItem.CheckOnClick = true;
			this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
			this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.statusBarToolStripMenuItem.Text = "Status&bar";
			this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
			// 
			// windowsMenu
			// 
			this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem,
            this.toolStripSeparator5,
            this.closeAllToolStripMenuItem});
			this.windowsMenu.Name = "windowsMenu";
			this.windowsMenu.Size = new System.Drawing.Size(68, 20);
			this.windowsMenu.Text = "&Windows";
			// 
			// cascadeToolStripMenuItem
			// 
			this.cascadeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cascadeToolStripMenuItem.Image")));
			this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
			this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.cascadeToolStripMenuItem.Text = "Over&lapping";
			this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
			// 
			// tileVerticalToolStripMenuItem
			// 
			this.tileVerticalToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tileVerticalToolStripMenuItem.Image")));
			this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
			this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.tileVerticalToolStripMenuItem.Text = "Side by &Side";
			this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
			// 
			// tileHorizontalToolStripMenuItem
			// 
			this.tileHorizontalToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tileHorizontalToolStripMenuItem.Image")));
			this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
			this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.tileHorizontalToolStripMenuItem.Text = "&Stacked";
			this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
			// 
			// arrangeIconsToolStripMenuItem
			// 
			this.arrangeIconsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("arrangeIconsToolStripMenuItem.Image")));
			this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
			this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.arrangeIconsToolStripMenuItem.Text = "&Arrange Symbols";
			this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(161, 6);
			// 
			// closeAllToolStripMenuItem
			// 
			this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
			this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.closeAllToolStripMenuItem.Text = "&Close all";
			this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
			// 
			// helpMenu
			// 
			this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpMenu.Name = "helpMenu";
			this.helpMenu.Size = new System.Drawing.Size(44, 20);
			this.helpMenu.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.aboutToolStripMenuItem.Text = "&Info... ...";
			// 
			// toolStrip
			// 
			this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.tsbSql,
            this.toolStripButton1});
			this.toolStrip.Location = new System.Drawing.Point(0, 24);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(924, 31);
			this.toolStrip.TabIndex = 1;
			this.toolStrip.Text = "ToolStrip";
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(28, 28);
			this.openToolStripButton.Text = "Öffnen";
			this.openToolStripButton.Click += new System.EventHandler(this.registerNewDatabaseToolStripMenuItem_Click);
			// 
			// tsbSql
			// 
			this.tsbSql.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSql.Image = ((System.Drawing.Image)(resources.GetObject("tsbSql.Image")));
			this.tsbSql.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSql.Name = "tsbSql";
			this.tsbSql.Size = new System.Drawing.Size(28, 28);
			this.tsbSql.Text = "toolStripButton1";
			this.tsbSql.Click += new System.EventHandler(this.tsbSql_Click);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
			this.toolStripButton1.Text = "toolStripButton1";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 526);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(924, 22);
			this.statusStrip.TabIndex = 2;
			this.statusStrip.Text = "StatusStrip";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel.Text = "Status";
			// 
			// imageListTreeviewDefault
			// 
			this.imageListTreeviewDefault.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeviewDefault.ImageStream")));
			this.imageListTreeviewDefault.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListTreeviewDefault.Images.SetKeyName(0, "folderGrey.png");
			this.imageListTreeviewDefault.Images.SetKeyName(1, "folderGreyOpen.png");
			this.imageListTreeviewDefault.Images.SetKeyName(2, "folderRed.png");
			this.imageListTreeviewDefault.Images.SetKeyName(3, "folderRedOpen.png");
			this.imageListTreeviewDefault.Images.SetKeyName(4, "addUser.png");
			this.imageListTreeviewDefault.Images.SetKeyName(5, "column");
			this.imageListTreeviewDefault.Images.SetKeyName(6, "DBTable");
			this.imageListTreeviewDefault.Images.SetKeyName(7, "deleteUser.png");
			this.imageListTreeviewDefault.Images.SetKeyName(8, "edit.png");
			this.imageListTreeviewDefault.Images.SetKeyName(9, "editUser.png");
			this.imageListTreeviewDefault.Images.SetKeyName(10, "key_Blue");
			this.imageListTreeviewDefault.Images.SetKeyName(11, "keyTransp.png");
			this.imageListTreeviewDefault.Images.SetKeyName(12, "Refresh.png");
			this.imageListTreeviewDefault.Images.SetKeyName(13, "Search.png");
			this.imageListTreeviewDefault.Images.SetKeyName(14, "tableGreen.png");
			this.imageListTreeviewDefault.Images.SetKeyName(15, "Trash.png");
			this.imageListTreeviewDefault.Images.SetKeyName(16, "database_blue");
			this.imageListTreeviewDefault.Images.SetKeyName(17, "database_green");
			this.imageListTreeviewDefault.Images.SetKeyName(18, "database_orange");
			this.imageListTreeviewDefault.Images.SetKeyName(19, "database_red");
			this.imageListTreeviewDefault.Images.SetKeyName(20, "View");
			this.imageListTreeviewDefault.Images.SetKeyName(21, "keyring");
			// 
			// panelLeftMain
			// 
			this.panelLeftMain.Controls.Add(this.splitContainer1);
			this.panelLeftMain.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeftMain.Location = new System.Drawing.Point(0, 55);
			this.panelLeftMain.Name = "panelLeftMain";
			this.panelLeftMain.Size = new System.Drawing.Size(261, 471);
			this.panelLeftMain.TabIndex = 6;
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tvMain);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tvSchema);
			this.splitContainer1.Size = new System.Drawing.Size(261, 471);
			this.splitContainer1.SplitterDistance = 241;
			this.splitContainer1.TabIndex = 6;
			// 
			// tvMain
			// 
			this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvMain.FullRowSelect = true;
			this.tvMain.HideSelection = false;
			this.tvMain.HotTracking = true;
			this.tvMain.ImageKey = "folderGrey.png";
			this.tvMain.ImageList = this.imageListTreeviewDefault;
			this.tvMain.Location = new System.Drawing.Point(0, 0);
			this.tvMain.Name = "tvMain";
			treeNode1.ImageIndex = 6;
			treeNode1.Name = "Knoten1";
			treeNode1.SelectedImageIndex = 6;
			treeNode1.Text = "Table1";
			treeNode2.ImageIndex = 6;
			treeNode2.Name = "Knoten3";
			treeNode2.SelectedImageIndex = 6;
			treeNode2.Text = "Table2";
			treeNode3.ImageIndex = 6;
			treeNode3.Name = "Knoten4";
			treeNode3.SelectedImageIndex = 6;
			treeNode3.Text = "Table3";
			treeNode4.Name = "tnTables";
			treeNode4.Text = "Tables";
			treeNode5.Name = "Knoten5";
			treeNode5.SelectedImageIndex = 6;
			treeNode5.Text = "View1";
			treeNode6.Name = "Knoten6";
			treeNode6.Text = "View2";
			treeNode7.Name = "tnViews";
			treeNode7.Text = "Views";
			treeNode8.ImageIndex = 16;
			treeNode8.Name = "TnConnections";
			treeNode8.SelectedImageIndex = 19;
			treeNode8.Text = "Connection";
			this.tvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8});
			this.tvMain.SelectedImageKey = "folderRed.png";
			this.tvMain.Size = new System.Drawing.Size(259, 239);
			this.tvMain.TabIndex = 5;
			this.tvMain.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvMain_AfterCollapse);
			this.tvMain.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvMain_AfterExpand);
			this.tvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMain_AfterSelect);
			this.tvMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tvMain_MouseDoubleClick);
			this.tvMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvMain_MouseDown);
			// 
			// tvSchema
			// 
			this.tvSchema.ContextMenuStrip = this.cmsSchema;
			this.tvSchema.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvSchema.ImageIndex = 0;
			this.tvSchema.ImageList = this.imageListTreeviewDefault;
			this.tvSchema.Location = new System.Drawing.Point(0, 0);
			this.tvSchema.Name = "tvSchema";
			this.tvSchema.SelectedImageIndex = 0;
			this.tvSchema.Size = new System.Drawing.Size(259, 224);
			this.tvSchema.TabIndex = 0;
			// 
			// cmsSchema
			// 
			this.cmsSchema.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopyFields});
			this.cmsSchema.Name = "cmsSchema";
			this.cmsSchema.Size = new System.Drawing.Size(215, 26);
			// 
			// tsmiCopyFields
			// 
			this.tsmiCopyFields.Image = ((System.Drawing.Image)(resources.GetObject("tsmiCopyFields.Image")));
			this.tsmiCopyFields.Name = "tsmiCopyFields";
			this.tsmiCopyFields.Size = new System.Drawing.Size(214, 22);
			this.tsmiCopyFields.Text = "Copy Fieldlist to Clipboard";
			this.tsmiCopyFields.Click += new System.EventHandler(this.tsmiCopyFields_Click);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(261, 55);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 471);
			this.splitter1.TabIndex = 8;
			this.splitter1.TabStop = false;
			// 
			// cmsTables
			// 
			this.cmsTables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiCreateTable});
			this.cmsTables.Name = "cmsTables";
			this.cmsTables.Size = new System.Drawing.Size(137, 26);
			this.cmsTables.Text = "Create Table";
			// 
			// tsiCreateTable
			// 
			this.tsiCreateTable.Image = ((System.Drawing.Image)(resources.GetObject("tsiCreateTable.Image")));
			this.tsiCreateTable.Name = "tsiCreateTable";
			this.tsiCreateTable.Size = new System.Drawing.Size(136, 22);
			this.tsiCreateTable.Text = "CreateTable";
			this.tsiCreateTable.Click += new System.EventHandler(this.tsiCreateTable_Click);
			// 
			// cmsTable
			// 
			this.cmsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiEditTableData,
            this.createIndexToolStripMenuItem,
            this.codeGenerationToolStripMenuItem,
            this.toolStripSeparator1,
            this.tsiCreateTable2,
            this.toolStripSeparator2,
            this.tsiDropTable,
            this.toolStripSeparator4});
			this.cmsTable.Name = "cmsTables";
			this.cmsTable.Size = new System.Drawing.Size(163, 132);
			this.cmsTable.Text = "Create Table";
			// 
			// tsiEditTableData
			// 
			this.tsiEditTableData.Image = ((System.Drawing.Image)(resources.GetObject("tsiEditTableData.Image")));
			this.tsiEditTableData.Name = "tsiEditTableData";
			this.tsiEditTableData.Size = new System.Drawing.Size(162, 22);
			this.tsiEditTableData.Text = "Edit Table Data";
			this.tsiEditTableData.Click += new System.EventHandler(this.tsiEditTableData_Click);
			// 
			// createIndexToolStripMenuItem
			// 
			this.createIndexToolStripMenuItem.Name = "createIndexToolStripMenuItem";
			this.createIndexToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.createIndexToolStripMenuItem.Text = "Create Index";
			this.createIndexToolStripMenuItem.Click += new System.EventHandler(this.createIndexToolStripMenuItem_Click);
			// 
			// codeGenerationToolStripMenuItem
			// 
			this.codeGenerationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDLToolStripMenuItem,
            this.cToolStripMenuItem,
            this.copyValuesAsCListToolStripMenuItem});
			this.codeGenerationToolStripMenuItem.Name = "codeGenerationToolStripMenuItem";
			this.codeGenerationToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.codeGenerationToolStripMenuItem.Text = "Code generation";
			// 
			// dDLToolStripMenuItem
			// 
			this.dDLToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dDLToolStripMenuItem.Image")));
			this.dDLToolStripMenuItem.Name = "dDLToolStripMenuItem";
			this.dDLToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.dDLToolStripMenuItem.Text = "Extract DDL";
			this.dDLToolStripMenuItem.Click += new System.EventHandler(this.extractDDLToolStripMenuItem_Click);
			// 
			// cToolStripMenuItem
			// 
			this.cToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cToolStripMenuItem.Image")));
			this.cToolStripMenuItem.Name = "cToolStripMenuItem";
			this.cToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.cToolStripMenuItem.Text = "Generate a C# definition";
			this.cToolStripMenuItem.Click += new System.EventHandler(this.copyAsCDefinitionToClipbrdToolStripMenuItem_Click);
			// 
			// copyValuesAsCListToolStripMenuItem
			// 
			this.copyValuesAsCListToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyValuesAsCListToolStripMenuItem.Image")));
			this.copyValuesAsCListToolStripMenuItem.Name = "copyValuesAsCListToolStripMenuItem";
			this.copyValuesAsCListToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.copyValuesAsCListToolStripMenuItem.Text = "Generate C# List of values";
			this.copyValuesAsCListToolStripMenuItem.Click += new System.EventHandler(this.copyValuesAsCListToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
			// 
			// tsiCreateTable2
			// 
			this.tsiCreateTable2.Image = ((System.Drawing.Image)(resources.GetObject("tsiCreateTable2.Image")));
			this.tsiCreateTable2.Name = "tsiCreateTable2";
			this.tsiCreateTable2.Size = new System.Drawing.Size(162, 22);
			this.tsiCreateTable2.Text = "CreateTable";
			this.tsiCreateTable2.Click += new System.EventHandler(this.tsiCreateTable_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
			// 
			// tsiDropTable
			// 
			this.tsiDropTable.Image = ((System.Drawing.Image)(resources.GetObject("tsiDropTable.Image")));
			this.tsiDropTable.Name = "tsiDropTable";
			this.tsiDropTable.Size = new System.Drawing.Size(162, 22);
			this.tsiDropTable.Text = "Drop Table";
			this.tsiDropTable.Click += new System.EventHandler(this.tsiDropTable_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(159, 6);
			// 
			// cmsView
			// 
			this.cmsView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiViewShowData,
            this.extractDDLToolStripMenuItem,
            this.toolStripMenuItem2,
            this.dropViewToolStripMenuItem});
			this.cmsView.Name = "cmsView";
			this.cmsView.Size = new System.Drawing.Size(153, 98);
			// 
			// tsiViewShowData
			// 
			this.tsiViewShowData.Image = ((System.Drawing.Image)(resources.GetObject("tsiViewShowData.Image")));
			this.tsiViewShowData.Name = "tsiViewShowData";
			this.tsiViewShowData.Size = new System.Drawing.Size(152, 22);
			this.tsiViewShowData.Text = "Show Data";
			this.tsiViewShowData.Click += new System.EventHandler(this.tsiViewShowData_Click);
			// 
			// cmsConnection
			// 
			this.cmsConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiUnregister});
			this.cmsConnection.Name = "cmsConnection";
			this.cmsConnection.Size = new System.Drawing.Size(129, 26);
			// 
			// tsiUnregister
			// 
			this.tsiUnregister.Image = ((System.Drawing.Image)(resources.GetObject("tsiUnregister.Image")));
			this.tsiUnregister.Name = "tsiUnregister";
			this.tsiUnregister.Size = new System.Drawing.Size(128, 22);
			this.tsiUnregister.Text = "Unregister";
			this.tsiUnregister.Click += new System.EventHandler(this.tsiUnregister_Click);
			// 
			// cmsIndizes
			// 
			this.cmsIndizes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.cmsIndizes.Name = "cmsIndizes";
			this.cmsIndizes.Size = new System.Drawing.Size(140, 26);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
			this.toolStripMenuItem1.Text = "Create Index";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// cmsIndex
			// 
			this.cmsIndex.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dropIndexToolStripMenuItem});
			this.cmsIndex.Name = "cmsIndex";
			this.cmsIndex.Size = new System.Drawing.Size(132, 26);
			// 
			// dropIndexToolStripMenuItem
			// 
			this.dropIndexToolStripMenuItem.Name = "dropIndexToolStripMenuItem";
			this.dropIndexToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.dropIndexToolStripMenuItem.Text = "Drop index";
			this.dropIndexToolStripMenuItem.Click += new System.EventHandler(this.dropIndexToolStripMenuItem_Click);
			// 
			// extractDDLToolStripMenuItem
			// 
			this.extractDDLToolStripMenuItem.Name = "extractDDLToolStripMenuItem";
			this.extractDDLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.extractDDLToolStripMenuItem.Text = "Extract DDL";
			this.extractDDLToolStripMenuItem.Click += new System.EventHandler(this.extractDDLToolStripMenuItem_Click_1);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
			// 
			// dropViewToolStripMenuItem
			// 
			this.dropViewToolStripMenuItem.Name = "dropViewToolStripMenuItem";
			this.dropViewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.dropViewToolStripMenuItem.Text = "Drop View";
			this.dropViewToolStripMenuItem.Click += new System.EventHandler(this.dropViewToolStripMenuItem_Click);
			// 
			// MDIParent1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(924, 548);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panelLeftMain);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MDIParent1";
			this.Text = "MDIParent1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.panelLeftMain.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.cmsSchema.ResumeLayout(false);
			this.cmsTables.ResumeLayout(false);
			this.cmsTable.ResumeLayout(false);
			this.cmsView.ResumeLayout(false);
			this.cmsConnection.ResumeLayout(false);
			this.cmsIndizes.ResumeLayout(false);
			this.cmsIndex.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ImageList imageListTreeviewDefault;
        private System.Windows.Forms.ToolStripMenuItem registerNewDatabaseToolStripMenuItem;
        private System.Windows.Forms.Panel panelLeftMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.TreeView tvSchema;
        private System.Windows.Forms.ToolStripButton tsbSql;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ContextMenuStrip cmsTables;
        private System.Windows.Forms.ToolStripMenuItem tsiCreateTable;
        private System.Windows.Forms.ContextMenuStrip cmsTable;
        private System.Windows.Forms.ToolStripMenuItem tsiEditTableData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsiCreateTable2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsiDropTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ContextMenuStrip cmsView;
        private System.Windows.Forms.ToolStripMenuItem tsiViewShowData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ContextMenuStrip cmsConnection;
        private System.Windows.Forms.ToolStripMenuItem tsiUnregister;
        private System.Windows.Forms.ContextMenuStrip cmsIndizes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createIndexToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsIndex;
        private System.Windows.Forms.ToolStripMenuItem dropIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ContextMenuStrip cmsSchema;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyFields;
        private System.Windows.Forms.ToolStripMenuItem codeGenerationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyValuesAsCListToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem extractDDLToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem dropViewToolStripMenuItem;
	}
}



