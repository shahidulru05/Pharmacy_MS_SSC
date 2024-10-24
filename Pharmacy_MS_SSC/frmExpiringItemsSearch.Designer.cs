namespace Pharmacy_MS_SSC
{
    partial class frmExpiringItemsSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpiringItemsSearch));
            this.panelTitle = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelClose = new System.Windows.Forms.Label();
            this.labelPin = new System.Windows.Forms.Label();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTradeName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxBatchNo = new System.Windows.Forms.TextBox();
            this.buttonBatchNoSearch = new System.Windows.Forms.Button();
            this.dataGridViewCompany = new System.Windows.Forms.DataGridView();
            this.vSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelCompany = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewTradeList = new System.Windows.Forms.DataGridView();
            this.tSl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTradeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTradeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTradeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTradeName = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxExpiryDay = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.labelTotalItems = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.listViewExpiringItems = new System.Windows.Forms.ListView();
            this.columnHeaderSl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBatchNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTradeCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTradeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVendorName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPurchaseQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStockQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderManufactureDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderExpiryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderExpiryDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelExpiryQuantity = new System.Windows.Forms.Label();
            this.labelCheckedItems = new System.Windows.Forms.Label();
            this.checkBoxViewOnlyExpiry = new System.Windows.Forms.CheckBox();
            this.buttonAllStock = new System.Windows.Forms.Button();
            this.checkBoxCompany = new System.Windows.Forms.CheckBox();
            this.checkBoxTradeName = new System.Windows.Forms.CheckBox();
            this.groupBoxDateToDate = new System.Windows.Forms.GroupBox();
            this.groupBoxExpiryItems = new System.Windows.Forms.GroupBox();
            this.buttonSearchDateToDate = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompany)).BeginInit();
            this.panelCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTradeList)).BeginInit();
            this.panelTradeName.SuspendLayout();
            this.groupBoxDateToDate.SuspendLayout();
            this.groupBoxExpiryItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTitle.BackgroundImage")));
            this.panelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Controls.Add(this.bunifuGradientPanel1);
            this.panelTitle.Controls.Add(this.label1);
            this.panelTitle.Controls.Add(this.labelClose);
            this.panelTitle.Controls.Add(this.labelPin);
            this.panelTitle.Controls.Add(this.labelMinimize);
            this.panelTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.GradientBottomLeft = System.Drawing.Color.White;
            this.panelTitle.GradientBottomRight = System.Drawing.Color.White;
            this.panelTitle.GradientTopLeft = System.Drawing.Color.White;
            this.panelTitle.GradientTopRight = System.Drawing.Color.White;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Quality = 10;
            this.panelTitle.Size = new System.Drawing.Size(969, 37);
            this.panelTitle.TabIndex = 135;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(54, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(844, 22);
            this.labelTitle.TabIndex = 135;
            this.labelTitle.Text = "Expiring Items Search";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(969, 6);
            this.bunifuGradientPanel1.TabIndex = 157;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(23, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 143;
            this.label1.Text = "Pin";
            // 
            // labelClose
            // 
            this.labelClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClose.AutoSize = true;
            this.labelClose.BackColor = System.Drawing.Color.Transparent;
            this.labelClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.ForeColor = System.Drawing.Color.Tomato;
            this.labelClose.Location = new System.Drawing.Point(934, 9);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(23, 22);
            this.labelClose.TabIndex = 134;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // labelPin
            // 
            this.labelPin.AutoSize = true;
            this.labelPin.BackColor = System.Drawing.Color.Transparent;
            this.labelPin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPin.ForeColor = System.Drawing.Color.Tomato;
            this.labelPin.Location = new System.Drawing.Point(5, 3);
            this.labelPin.Name = "labelPin";
            this.labelPin.Size = new System.Drawing.Size(27, 31);
            this.labelPin.TabIndex = 142;
            this.labelPin.Text = "^";
            this.labelPin.Click += new System.EventHandler(this.labelPin_Click);
            // 
            // labelMinimize
            // 
            this.labelMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMinimize.AutoSize = true;
            this.labelMinimize.BackColor = System.Drawing.Color.Transparent;
            this.labelMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinimize.ForeColor = System.Drawing.Color.Tomato;
            this.labelMinimize.Location = new System.Drawing.Point(904, 3);
            this.labelMinimize.Name = "labelMinimize";
            this.labelMinimize.Size = new System.Drawing.Size(24, 31);
            this.labelMinimize.TabIndex = 135;
            this.labelMinimize.Text = "-";
            this.labelMinimize.Click += new System.EventHandler(this.labelMinimize_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.labelTitle;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(6, 19);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(130, 24);
            this.dateTimePickerStart.TabIndex = 137;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(161, 19);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(130, 24);
            this.dateTimePickerEnd.TabIndex = 138;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(137, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 139;
            this.label2.Text = "to";
            // 
            // textBoxCompany
            // 
            this.textBoxCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCompany.Location = new System.Drawing.Point(26, 71);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.Size = new System.Drawing.Size(268, 26);
            this.textBoxCompany.TabIndex = 140;
            this.textBoxCompany.Click += new System.EventHandler(this.textBoxCompany_Click);
            this.textBoxCompany.TextChanged += new System.EventHandler(this.textBoxCompany_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 141;
            this.label3.Text = "Company";
            // 
            // textBoxTradeName
            // 
            this.textBoxTradeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTradeName.Location = new System.Drawing.Point(26, 120);
            this.textBoxTradeName.Name = "textBoxTradeName";
            this.textBoxTradeName.Size = new System.Drawing.Size(268, 26);
            this.textBoxTradeName.TabIndex = 188;
            this.textBoxTradeName.Click += new System.EventHandler(this.textBoxTradeName_Click);
            this.textBoxTradeName.TextChanged += new System.EventHandler(this.textBoxTradeName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 191;
            this.label5.Text = "Trade Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(318, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 193;
            this.label6.Text = "Batch No";
            // 
            // textBoxBatchNo
            // 
            this.textBoxBatchNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBatchNo.Location = new System.Drawing.Point(318, 120);
            this.textBoxBatchNo.Name = "textBoxBatchNo";
            this.textBoxBatchNo.Size = new System.Drawing.Size(178, 26);
            this.textBoxBatchNo.TabIndex = 192;
            this.textBoxBatchNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxBatchNo_KeyDown);
            // 
            // buttonBatchNoSearch
            // 
            this.buttonBatchNoSearch.FlatAppearance.BorderSize = 0;
            this.buttonBatchNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBatchNoSearch.Image = global::Pharmacy_MS_SSC.Properties.Resources.search;
            this.buttonBatchNoSearch.Location = new System.Drawing.Point(498, 121);
            this.buttonBatchNoSearch.Name = "buttonBatchNoSearch";
            this.buttonBatchNoSearch.Size = new System.Drawing.Size(25, 25);
            this.buttonBatchNoSearch.TabIndex = 194;
            this.buttonBatchNoSearch.UseVisualStyleBackColor = true;
            this.buttonBatchNoSearch.Click += new System.EventHandler(this.buttonBatchNoSearch_Click);
            // 
            // dataGridViewCompany
            // 
            this.dataGridViewCompany.AllowUserToAddRows = false;
            this.dataGridViewCompany.AllowUserToDeleteRows = false;
            this.dataGridViewCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompany.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vSL,
            this.id,
            this.VendorName});
            this.dataGridViewCompany.Location = new System.Drawing.Point(-1, 3);
            this.dataGridViewCompany.Name = "dataGridViewCompany";
            this.dataGridViewCompany.ReadOnly = true;
            this.dataGridViewCompany.RowHeadersVisible = false;
            this.dataGridViewCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCompany.Size = new System.Drawing.Size(316, 213);
            this.dataGridViewCompany.TabIndex = 196;
            this.dataGridViewCompany.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCompany_CellClick);
            this.dataGridViewCompany.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewCompany_RowPostPaint);
            // 
            // vSL
            // 
            this.vSL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vSL.HeaderText = "#";
            this.vSL.Name = "vSL";
            this.vSL.ReadOnly = true;
            this.vSL.Width = 39;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 50;
            // 
            // VendorName
            // 
            this.VendorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VendorName.DataPropertyName = "VendorName";
            this.VendorName.HeaderText = "Vendor\'s Name";
            this.VendorName.Name = "VendorName";
            this.VendorName.ReadOnly = true;
            // 
            // panelCompany
            // 
            this.panelCompany.BackColor = System.Drawing.Color.Transparent;
            this.panelCompany.Controls.Add(this.label7);
            this.panelCompany.Controls.Add(this.dataGridViewCompany);
            this.panelCompany.Location = new System.Drawing.Point(26, 98);
            this.panelCompany.Name = "panelCompany";
            this.panelCompany.Size = new System.Drawing.Size(305, 219);
            this.panelCompany.TabIndex = 197;
            this.panelCompany.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Tomato;
            this.label7.Location = new System.Drawing.Point(279, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 22);
            this.label7.TabIndex = 197;
            this.label7.Text = "X";
            this.toolTip1.SetToolTip(this.label7, "Close");
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // dataGridViewTradeList
            // 
            this.dataGridViewTradeList.AllowUserToAddRows = false;
            this.dataGridViewTradeList.AllowUserToDeleteRows = false;
            this.dataGridViewTradeList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTradeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTradeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tSl,
            this.tTradeId,
            this.tTradeCode,
            this.tTradeName});
            this.dataGridViewTradeList.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTradeList.Name = "dataGridViewTradeList";
            this.dataGridViewTradeList.ReadOnly = true;
            this.dataGridViewTradeList.RowHeadersVisible = false;
            this.dataGridViewTradeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTradeList.Size = new System.Drawing.Size(299, 213);
            this.dataGridViewTradeList.TabIndex = 198;
            this.dataGridViewTradeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTradeList_CellClick);
            this.dataGridViewTradeList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewTradeList_RowPostPaint);
            // 
            // tSl
            // 
            this.tSl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tSl.HeaderText = "#";
            this.tSl.Name = "tSl";
            this.tSl.ReadOnly = true;
            this.tSl.Width = 39;
            // 
            // tTradeId
            // 
            this.tTradeId.DataPropertyName = "id";
            this.tTradeId.HeaderText = "TradeID";
            this.tTradeId.Name = "tTradeId";
            this.tTradeId.ReadOnly = true;
            this.tTradeId.Visible = false;
            // 
            // tTradeCode
            // 
            this.tTradeCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tTradeCode.DataPropertyName = "TradeCode";
            this.tTradeCode.HeaderText = "TradeCode";
            this.tTradeCode.Name = "tTradeCode";
            this.tTradeCode.ReadOnly = true;
            this.tTradeCode.Width = 85;
            // 
            // tTradeName
            // 
            this.tTradeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tTradeName.DataPropertyName = "TradeName";
            this.tTradeName.HeaderText = "TradeName";
            this.tTradeName.Name = "tTradeName";
            this.tTradeName.ReadOnly = true;
            // 
            // panelTradeName
            // 
            this.panelTradeName.BackColor = System.Drawing.Color.Transparent;
            this.panelTradeName.Controls.Add(this.label8);
            this.panelTradeName.Controls.Add(this.dataGridViewTradeList);
            this.panelTradeName.Location = new System.Drawing.Point(26, 126);
            this.panelTradeName.Name = "panelTradeName";
            this.panelTradeName.Size = new System.Drawing.Size(305, 219);
            this.panelTradeName.TabIndex = 199;
            this.panelTradeName.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Tomato;
            this.label8.Location = new System.Drawing.Point(279, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 22);
            this.label8.TabIndex = 197;
            this.label8.Text = "X";
            this.toolTip1.SetToolTip(this.label8, "Close");
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // comboBoxExpiryDay
            // 
            this.comboBoxExpiryDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExpiryDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxExpiryDay.FormattingEnabled = true;
            this.comboBoxExpiryDay.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "50",
            "100",
            "150",
            "200",
            "500",
            "1200"});
            this.comboBoxExpiryDay.Location = new System.Drawing.Point(6, 72);
            this.comboBoxExpiryDay.Name = "comboBoxExpiryDay";
            this.comboBoxExpiryDay.Size = new System.Drawing.Size(103, 24);
            this.comboBoxExpiryDay.TabIndex = 201;
            this.comboBoxExpiryDay.SelectedIndexChanged += new System.EventHandler(this.comboBoxExpiryDay_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(6, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 17);
            this.label9.TabIndex = 202;
            this.label9.Text = "Expity Days <=";
            // 
            // labelTotalItems
            // 
            this.labelTotalItems.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelTotalItems.AutoSize = true;
            this.labelTotalItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalItems.ForeColor = System.Drawing.Color.Red;
            this.labelTotalItems.Location = new System.Drawing.Point(38, 563);
            this.labelTotalItems.Name = "labelTotalItems";
            this.labelTotalItems.Size = new System.Drawing.Size(19, 20);
            this.labelTotalItems.TabIndex = 203;
            this.labelTotalItems.Text = "0";
            this.labelTotalItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listViewExpiringItems
            // 
            this.listViewExpiringItems.CheckBoxes = true;
            this.listViewExpiringItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSl,
            this.columnHeaderId,
            this.columnHeaderBatchNo,
            this.columnHeaderTradeCode,
            this.columnHeaderTradeName,
            this.columnHeaderVendorName,
            this.columnHeaderPurchaseQty,
            this.columnHeaderStockQty,
            this.columnHeaderManufactureDate,
            this.columnHeaderExpiryDate,
            this.columnHeaderExpiryDay});
            this.listViewExpiringItems.FullRowSelect = true;
            this.listViewExpiringItems.GridLines = true;
            this.listViewExpiringItems.Location = new System.Drawing.Point(16, 153);
            this.listViewExpiringItems.MultiSelect = false;
            this.listViewExpiringItems.Name = "listViewExpiringItems";
            this.listViewExpiringItems.Size = new System.Drawing.Size(938, 395);
            this.listViewExpiringItems.TabIndex = 208;
            this.listViewExpiringItems.UseCompatibleStateImageBehavior = false;
            this.listViewExpiringItems.View = System.Windows.Forms.View.Details;
            this.listViewExpiringItems.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewExpiringItems_ItemChecked);
            // 
            // columnHeaderSl
            // 
            this.columnHeaderSl.Text = "#";
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "ID";
            this.columnHeaderId.Width = 0;
            // 
            // columnHeaderBatchNo
            // 
            this.columnHeaderBatchNo.Text = "Batch No";
            this.columnHeaderBatchNo.Width = 80;
            // 
            // columnHeaderTradeCode
            // 
            this.columnHeaderTradeCode.Text = "Trade Code";
            this.columnHeaderTradeCode.Width = 80;
            // 
            // columnHeaderTradeName
            // 
            this.columnHeaderTradeName.Text = "Trade Name";
            this.columnHeaderTradeName.Width = 150;
            // 
            // columnHeaderVendorName
            // 
            this.columnHeaderVendorName.Text = "Company Name";
            this.columnHeaderVendorName.Width = 150;
            // 
            // columnHeaderPurchaseQty
            // 
            this.columnHeaderPurchaseQty.Text = "Purchase Qty";
            this.columnHeaderPurchaseQty.Width = 80;
            // 
            // columnHeaderStockQty
            // 
            this.columnHeaderStockQty.Text = "Stock Qty";
            // 
            // columnHeaderManufactureDate
            // 
            this.columnHeaderManufactureDate.Text = "Manufacture Date";
            this.columnHeaderManufactureDate.Width = 100;
            // 
            // columnHeaderExpiryDate
            // 
            this.columnHeaderExpiryDate.Text = "Expiry Date";
            this.columnHeaderExpiryDate.Width = 80;
            // 
            // columnHeaderExpiryDay
            // 
            this.columnHeaderExpiryDay.Text = "Expiry Day";
            this.columnHeaderExpiryDay.Width = 70;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonUpdate.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonUpdate.Enabled = false;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Location = new System.Drawing.Point(796, 554);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(135, 36);
            this.buttonUpdate.TabIndex = 209;
            this.buttonUpdate.Text = "Add To Archive";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // labelExpiryQuantity
            // 
            this.labelExpiryQuantity.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelExpiryQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExpiryQuantity.ForeColor = System.Drawing.Color.Red;
            this.labelExpiryQuantity.Location = new System.Drawing.Point(216, 560);
            this.labelExpiryQuantity.Name = "labelExpiryQuantity";
            this.labelExpiryQuantity.Size = new System.Drawing.Size(280, 23);
            this.labelExpiryQuantity.TabIndex = 200;
            this.labelExpiryQuantity.Text = "0";
            this.labelExpiryQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCheckedItems
            // 
            this.labelCheckedItems.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelCheckedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckedItems.ForeColor = System.Drawing.Color.Red;
            this.labelCheckedItems.Location = new System.Drawing.Point(510, 560);
            this.labelCheckedItems.Name = "labelCheckedItems";
            this.labelCheckedItems.Size = new System.Drawing.Size(280, 23);
            this.labelCheckedItems.TabIndex = 210;
            this.labelCheckedItems.Text = "0";
            this.labelCheckedItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxViewOnlyExpiry
            // 
            this.checkBoxViewOnlyExpiry.AutoSize = true;
            this.checkBoxViewOnlyExpiry.Checked = true;
            this.checkBoxViewOnlyExpiry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxViewOnlyExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxViewOnlyExpiry.ForeColor = System.Drawing.Color.Red;
            this.checkBoxViewOnlyExpiry.Location = new System.Drawing.Point(684, 125);
            this.checkBoxViewOnlyExpiry.Name = "checkBoxViewOnlyExpiry";
            this.checkBoxViewOnlyExpiry.Size = new System.Drawing.Size(161, 21);
            this.checkBoxViewOnlyExpiry.TabIndex = 211;
            this.checkBoxViewOnlyExpiry.Text = "View Only Expiry Item";
            this.checkBoxViewOnlyExpiry.UseVisualStyleBackColor = true;
            // 
            // buttonAllStock
            // 
            this.buttonAllStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAllStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAllStock.ForeColor = System.Drawing.Color.Green;
            this.buttonAllStock.Location = new System.Drawing.Point(859, 123);
            this.buttonAllStock.Name = "buttonAllStock";
            this.buttonAllStock.Size = new System.Drawing.Size(95, 25);
            this.buttonAllStock.TabIndex = 212;
            this.buttonAllStock.Text = "All Stock";
            this.buttonAllStock.UseVisualStyleBackColor = true;
            this.buttonAllStock.Click += new System.EventHandler(this.buttonAllStock_Click);
            // 
            // checkBoxCompany
            // 
            this.checkBoxCompany.AutoSize = true;
            this.checkBoxCompany.Location = new System.Drawing.Point(129, 53);
            this.checkBoxCompany.Name = "checkBoxCompany";
            this.checkBoxCompany.Size = new System.Drawing.Size(95, 17);
            this.checkBoxCompany.TabIndex = 213;
            this.checkBoxCompany.Text = "With Company";
            this.checkBoxCompany.UseVisualStyleBackColor = true;
            // 
            // checkBoxTradeName
            // 
            this.checkBoxTradeName.AutoSize = true;
            this.checkBoxTradeName.Location = new System.Drawing.Point(6, 53);
            this.checkBoxTradeName.Name = "checkBoxTradeName";
            this.checkBoxTradeName.Size = new System.Drawing.Size(110, 17);
            this.checkBoxTradeName.TabIndex = 214;
            this.checkBoxTradeName.Text = "With Trade Name";
            this.checkBoxTradeName.UseVisualStyleBackColor = true;
            // 
            // groupBoxDateToDate
            // 
            this.groupBoxDateToDate.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBoxDateToDate.Controls.Add(this.buttonSearchDateToDate);
            this.groupBoxDateToDate.Controls.Add(this.checkBoxCompany);
            this.groupBoxDateToDate.Controls.Add(this.checkBoxTradeName);
            this.groupBoxDateToDate.Controls.Add(this.dateTimePickerStart);
            this.groupBoxDateToDate.Controls.Add(this.label2);
            this.groupBoxDateToDate.Controls.Add(this.dateTimePickerEnd);
            this.groupBoxDateToDate.Location = new System.Drawing.Point(657, 43);
            this.groupBoxDateToDate.Name = "groupBoxDateToDate";
            this.groupBoxDateToDate.Size = new System.Drawing.Size(297, 77);
            this.groupBoxDateToDate.TabIndex = 216;
            this.groupBoxDateToDate.TabStop = false;
            this.groupBoxDateToDate.Text = "Date to Date (expiry)";
            // 
            // groupBoxExpiryItems
            // 
            this.groupBoxExpiryItems.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBoxExpiryItems.Controls.Add(this.comboBoxExpiryDay);
            this.groupBoxExpiryItems.Controls.Add(this.label9);
            this.groupBoxExpiryItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxExpiryItems.Location = new System.Drawing.Point(536, 43);
            this.groupBoxExpiryItems.Name = "groupBoxExpiryItems";
            this.groupBoxExpiryItems.Size = new System.Drawing.Size(115, 105);
            this.groupBoxExpiryItems.TabIndex = 217;
            this.groupBoxExpiryItems.TabStop = false;
            this.groupBoxExpiryItems.Text = "Expiry Days (only color)";
            // 
            // buttonSearchDateToDate
            // 
            this.buttonSearchDateToDate.BackColor = System.Drawing.Color.White;
            this.buttonSearchDateToDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchDateToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchDateToDate.Location = new System.Drawing.Point(230, 49);
            this.buttonSearchDateToDate.Name = "buttonSearchDateToDate";
            this.buttonSearchDateToDate.Size = new System.Drawing.Size(61, 23);
            this.buttonSearchDateToDate.TabIndex = 218;
            this.buttonSearchDateToDate.Text = "Search";
            this.buttonSearchDateToDate.UseVisualStyleBackColor = false;
            this.buttonSearchDateToDate.Click += new System.EventHandler(this.buttonSearchDateToDate_Click);
            // 
            // frmExpiringItemsSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 598);
            this.Controls.Add(this.groupBoxExpiryItems);
            this.Controls.Add(this.panelTradeName);
            this.Controls.Add(this.panelCompany);
            this.Controls.Add(this.groupBoxDateToDate);
            this.Controls.Add(this.buttonAllStock);
            this.Controls.Add(this.checkBoxViewOnlyExpiry);
            this.Controls.Add(this.labelCheckedItems);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.labelTotalItems);
            this.Controls.Add(this.labelExpiryQuantity);
            this.Controls.Add(this.buttonBatchNoSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxBatchNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxTradeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCompany);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.listViewExpiringItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmExpiringItemsSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPurchaseReport";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompany)).EndInit();
            this.panelCompany.ResumeLayout(false);
            this.panelCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTradeList)).EndInit();
            this.panelTradeName.ResumeLayout(false);
            this.panelTradeName.PerformLayout();
            this.groupBoxDateToDate.ResumeLayout(false);
            this.groupBoxDateToDate.PerformLayout();
            this.groupBoxExpiryItems.ResumeLayout(false);
            this.groupBoxExpiryItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel panelTitle;
        private System.Windows.Forms.Label labelTitle;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label labelPin;
        private System.Windows.Forms.Label labelMinimize;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCompany;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxTradeName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonBatchNoSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxBatchNo;
        private System.Windows.Forms.Panel panelCompany;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewCompany;
        private System.Windows.Forms.Panel panelTradeName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewTradeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn vSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tSl;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTradeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTradeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTradeName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxExpiryDay;
        private System.Windows.Forms.Label labelTotalItems;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListView listViewExpiringItems;
        private System.Windows.Forms.ColumnHeader columnHeaderSl;
        private System.Windows.Forms.ColumnHeader columnHeaderBatchNo;
        private System.Windows.Forms.ColumnHeader columnHeaderTradeCode;
        private System.Windows.Forms.ColumnHeader columnHeaderTradeName;
        private System.Windows.Forms.ColumnHeader columnHeaderPurchaseQty;
        private System.Windows.Forms.ColumnHeader columnHeaderManufactureDate;
        private System.Windows.Forms.ColumnHeader columnHeaderExpiryDate;
        private System.Windows.Forms.ColumnHeader columnHeaderExpiryDay;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelExpiryQuantity;
        private System.Windows.Forms.Label labelCheckedItems;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.CheckBox checkBoxViewOnlyExpiry;
        private System.Windows.Forms.Button buttonAllStock;
        private System.Windows.Forms.ColumnHeader columnHeaderStockQty;
        private System.Windows.Forms.CheckBox checkBoxCompany;
        private System.Windows.Forms.CheckBox checkBoxTradeName;
        private System.Windows.Forms.GroupBox groupBoxDateToDate;
        private System.Windows.Forms.ColumnHeader columnHeaderVendorName;
        private System.Windows.Forms.GroupBox groupBoxExpiryItems;
        private System.Windows.Forms.Button buttonSearchDateToDate;
    }
}