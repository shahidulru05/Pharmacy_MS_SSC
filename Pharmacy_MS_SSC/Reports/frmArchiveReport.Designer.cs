namespace Pharmacy_MS_SSC.Reports
{
    partial class frmArchiveReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArchiveReport));
            this.labelMinimize = new System.Windows.Forms.Label();
            this.labelPin = new System.Windows.Forms.Label();
            this.labelClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelTitle = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.saDragControl = new ShakikulFramework.Toolbox.SADragControl();
            this.listViewArchiveList = new System.Windows.Forms.ListView();
            this.columnHeaderSl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelCompany = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewCompany = new System.Windows.Forms.DataGridView();
            this.vSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.panelTradeName = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewTradeList = new System.Windows.Forms.DataGridView();
            this.tSl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTradeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTradeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTradeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTradeName = new System.Windows.Forms.TextBox();
            this.labelTotalItems = new System.Windows.Forms.Label();
            this.columnHeaderTradeCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTradeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBatchNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPurchaseDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderManufactureDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderExpiryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVendorName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAllArchive = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            this.panelCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompany)).BeginInit();
            this.panelTradeName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTradeList)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMinimize
            // 
            this.labelMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMinimize.AutoSize = true;
            this.labelMinimize.BackColor = System.Drawing.Color.Transparent;
            this.labelMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinimize.ForeColor = System.Drawing.Color.Tomato;
            this.labelMinimize.Location = new System.Drawing.Point(979, 3);
            this.labelMinimize.Name = "labelMinimize";
            this.labelMinimize.Size = new System.Drawing.Size(24, 31);
            this.labelMinimize.TabIndex = 135;
            this.labelMinimize.Text = "-";
            this.labelMinimize.Click += new System.EventHandler(this.labelMinimize_Click);
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
            // labelClose
            // 
            this.labelClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClose.AutoSize = true;
            this.labelClose.BackColor = System.Drawing.Color.Transparent;
            this.labelClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.ForeColor = System.Drawing.Color.Tomato;
            this.labelClose.Location = new System.Drawing.Point(1009, 9);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(23, 22);
            this.labelClose.TabIndex = 134;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
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
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(54, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(912, 22);
            this.labelTitle.TabIndex = 135;
            this.labelTitle.Text = "Archive Report";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelTitle
            // 
            this.panelTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTitle.BackgroundImage")));
            this.panelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTitle.Controls.Add(this.panel2);
            this.panelTitle.Controls.Add(this.labelTitle);
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
            this.panelTitle.Size = new System.Drawing.Size(1037, 37);
            this.panelTitle.TabIndex = 136;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1037, 6);
            this.panel2.TabIndex = 144;
            // 
            // saDragControl
            // 
            this.saDragControl.SelectControl = this.labelTitle;
            this.saDragControl.SelectMoveable = null;
            // 
            // listViewArchiveList
            // 
            this.listViewArchiveList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewArchiveList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSl,
            this.columnHeaderTradeCode,
            this.columnHeaderTradeName,
            this.columnHeaderBatchNo,
            this.columnHeaderPurchaseDate,
            this.columnHeaderManufactureDate,
            this.columnHeaderExpiryDate,
            this.columnHeaderVendorName});
            this.listViewArchiveList.FullRowSelect = true;
            this.listViewArchiveList.GridLines = true;
            this.listViewArchiveList.Location = new System.Drawing.Point(12, 104);
            this.listViewArchiveList.MultiSelect = false;
            this.listViewArchiveList.Name = "listViewArchiveList";
            this.listViewArchiveList.Size = new System.Drawing.Size(1013, 524);
            this.listViewArchiveList.TabIndex = 137;
            this.listViewArchiveList.UseCompatibleStateImageBehavior = false;
            this.listViewArchiveList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSl
            // 
            this.columnHeaderSl.Text = "#";
            this.columnHeaderSl.Width = 50;
            // 
            // panelCompany
            // 
            this.panelCompany.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelCompany.BackColor = System.Drawing.Color.Transparent;
            this.panelCompany.Controls.Add(this.label7);
            this.panelCompany.Controls.Add(this.dataGridViewCompany);
            this.panelCompany.Location = new System.Drawing.Point(95, 87);
            this.panelCompany.Name = "panelCompany";
            this.panelCompany.Size = new System.Drawing.Size(318, 236);
            this.panelCompany.TabIndex = 200;
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
            this.label7.Location = new System.Drawing.Point(292, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 22);
            this.label7.TabIndex = 197;
            this.label7.Text = "X";
            this.label7.Click += new System.EventHandler(this.label7_Click);
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
            this.dataGridViewCompany.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewCompany.Name = "dataGridViewCompany";
            this.dataGridViewCompany.ReadOnly = true;
            this.dataGridViewCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCompany.Size = new System.Drawing.Size(312, 217);
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
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 199;
            this.label3.Text = "Company";
            // 
            // textBoxCompany
            // 
            this.textBoxCompany.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCompany.Location = new System.Drawing.Point(95, 60);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.Size = new System.Drawing.Size(315, 26);
            this.textBoxCompany.TabIndex = 198;
            this.textBoxCompany.Click += new System.EventHandler(this.textBoxCompany_Click);
            this.textBoxCompany.TextChanged += new System.EventHandler(this.textBoxCompany_TextChanged);
            // 
            // panelTradeName
            // 
            this.panelTradeName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelTradeName.BackColor = System.Drawing.Color.Transparent;
            this.panelTradeName.Controls.Add(this.label8);
            this.panelTradeName.Controls.Add(this.dataGridViewTradeList);
            this.panelTradeName.Location = new System.Drawing.Point(626, 87);
            this.panelTradeName.Name = "panelTradeName";
            this.panelTradeName.Size = new System.Drawing.Size(377, 236);
            this.panelTradeName.TabIndex = 203;
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
            this.label8.Location = new System.Drawing.Point(351, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 22);
            this.label8.TabIndex = 197;
            this.label8.Text = "X";
            this.label8.Click += new System.EventHandler(this.label8_Click);
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
            this.dataGridViewTradeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTradeList.Size = new System.Drawing.Size(371, 216);
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
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(647, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 202;
            this.label5.Text = "Trade Name";
            // 
            // textBoxTradeName
            // 
            this.textBoxTradeName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxTradeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTradeName.Location = new System.Drawing.Point(749, 59);
            this.textBoxTradeName.Name = "textBoxTradeName";
            this.textBoxTradeName.Size = new System.Drawing.Size(253, 26);
            this.textBoxTradeName.TabIndex = 201;
            this.textBoxTradeName.Click += new System.EventHandler(this.textBoxTradeName_Click);
            this.textBoxTradeName.TextChanged += new System.EventHandler(this.textBoxTradeName_TextChanged);
            // 
            // labelTotalItems
            // 
            this.labelTotalItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalItems.AutoSize = true;
            this.labelTotalItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalItems.ForeColor = System.Drawing.Color.Red;
            this.labelTotalItems.Location = new System.Drawing.Point(14, 636);
            this.labelTotalItems.Name = "labelTotalItems";
            this.labelTotalItems.Size = new System.Drawing.Size(19, 20);
            this.labelTotalItems.TabIndex = 204;
            this.labelTotalItems.Text = "0";
            this.labelTotalItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // columnHeaderTradeCode
            // 
            this.columnHeaderTradeCode.Text = "Trade Code";
            this.columnHeaderTradeCode.Width = 100;
            // 
            // columnHeaderTradeName
            // 
            this.columnHeaderTradeName.Text = "Trade Name";
            this.columnHeaderTradeName.Width = 200;
            // 
            // columnHeaderBatchNo
            // 
            this.columnHeaderBatchNo.Text = "Batch No";
            this.columnHeaderBatchNo.Width = 100;
            // 
            // columnHeaderPurchaseDate
            // 
            this.columnHeaderPurchaseDate.Text = "Purchase Date";
            this.columnHeaderPurchaseDate.Width = 100;
            // 
            // columnHeaderManufactureDate
            // 
            this.columnHeaderManufactureDate.Text = "Manufacture Date";
            this.columnHeaderManufactureDate.Width = 100;
            // 
            // columnHeaderExpiryDate
            // 
            this.columnHeaderExpiryDate.Text = "Expiry Date";
            this.columnHeaderExpiryDate.Width = 100;
            // 
            // columnHeaderVendorName
            // 
            this.columnHeaderVendorName.Text = "Vendor Name";
            this.columnHeaderVendorName.Width = 250;
            // 
            // buttonAllArchive
            // 
            this.buttonAllArchive.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonAllArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAllArchive.Location = new System.Drawing.Point(442, 59);
            this.buttonAllArchive.Name = "buttonAllArchive";
            this.buttonAllArchive.Size = new System.Drawing.Size(152, 27);
            this.buttonAllArchive.TabIndex = 205;
            this.buttonAllArchive.Text = "All Archive";
            this.buttonAllArchive.UseVisualStyleBackColor = true;
            this.buttonAllArchive.Click += new System.EventHandler(this.buttonAllArchive_Click);
            // 
            // frmArchiveReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 665);
            this.Controls.Add(this.buttonAllArchive);
            this.Controls.Add(this.labelTotalItems);
            this.Controls.Add(this.panelTradeName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxTradeName);
            this.Controls.Add(this.panelCompany);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCompany);
            this.Controls.Add(this.listViewArchiveList);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(240, 170);
            this.Name = "frmArchiveReport";
            this.Text = "frm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelCompany.ResumeLayout(false);
            this.panelCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompany)).EndInit();
            this.panelTradeName.ResumeLayout(false);
            this.panelTradeName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTradeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMinimize;
        private System.Windows.Forms.Label labelPin;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTitle;
        private Bunifu.Framework.UI.BunifuGradientPanel panelTitle;
        private System.Windows.Forms.Panel panel2;
        private ShakikulFramework.Toolbox.SADragControl saDragControl;
        private System.Windows.Forms.ListView listViewArchiveList;
        private System.Windows.Forms.ColumnHeader columnHeaderSl;
        private System.Windows.Forms.Panel panelCompany;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn vSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCompany;
        private System.Windows.Forms.Panel panelTradeName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewTradeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn tSl;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTradeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTradeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTradeName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTradeName;
        private System.Windows.Forms.Label labelTotalItems;
        private System.Windows.Forms.ColumnHeader columnHeaderTradeCode;
        private System.Windows.Forms.ColumnHeader columnHeaderTradeName;
        private System.Windows.Forms.ColumnHeader columnHeaderBatchNo;
        private System.Windows.Forms.ColumnHeader columnHeaderPurchaseDate;
        private System.Windows.Forms.ColumnHeader columnHeaderManufactureDate;
        private System.Windows.Forms.ColumnHeader columnHeaderExpiryDate;
        private System.Windows.Forms.ColumnHeader columnHeaderVendorName;
        private System.Windows.Forms.Button buttonAllArchive;


    }
}