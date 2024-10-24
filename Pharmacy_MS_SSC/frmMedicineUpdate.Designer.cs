namespace Pharmacy_MS_SSC
{
    partial class frmMedicineUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicineUpdate));
            this.panelTitle = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.labelClose = new System.Windows.Forms.Label();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelSaleMrp = new System.Windows.Forms.Label();
            this.labelWsPrice = new System.Windows.Forms.Label();
            this.labelPurchasePrice = new System.Windows.Forms.Label();
            this.labelRunningStock = new System.Windows.Forms.Label();
            this.labelCompany = new System.Windows.Forms.Label();
            this.labelMedicineName = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.textBoxNewWsPrice = new System.Windows.Forms.TextBox();
            this.textBoxNewSaleMrp = new System.Windows.Forms.TextBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.listViewTrade = new System.Windows.Forms.ListView();
            this.columnHeaderSl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTradeCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTradeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelTrade = new System.Windows.Forms.Panel();
            this.pictureBoxHideTradePanel = new System.Windows.Forms.PictureBox();
            this.panelTitle.SuspendLayout();
            this.panelTrade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHideTradePanel)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTitle.BackgroundImage")));
            this.panelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTitle.Controls.Add(this.label19);
            this.panelTitle.Controls.Add(this.label21);
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Controls.Add(this.bunifuGradientPanel1);
            this.panelTitle.Controls.Add(this.labelClose);
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
            this.panelTitle.Size = new System.Drawing.Size(441, 37);
            this.panelTitle.TabIndex = 135;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label19.Location = new System.Drawing.Point(22, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(25, 15);
            this.label19.TabIndex = 145;
            this.label19.Text = "Pin";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Tomato;
            this.label21.Location = new System.Drawing.Point(4, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(27, 31);
            this.label21.TabIndex = 144;
            this.label21.Text = "^";
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(53, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(317, 22);
            this.labelTitle.TabIndex = 135;
            this.labelTitle.Text = "Medicine Update";
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
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(441, 6);
            this.bunifuGradientPanel1.TabIndex = 157;
            // 
            // labelClose
            // 
            this.labelClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClose.AutoSize = true;
            this.labelClose.BackColor = System.Drawing.Color.Transparent;
            this.labelClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.ForeColor = System.Drawing.Color.Tomato;
            this.labelClose.Location = new System.Drawing.Point(406, 9);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(23, 22);
            this.labelClose.TabIndex = 134;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // labelMinimize
            // 
            this.labelMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMinimize.AutoSize = true;
            this.labelMinimize.BackColor = System.Drawing.Color.Transparent;
            this.labelMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinimize.ForeColor = System.Drawing.Color.Tomato;
            this.labelMinimize.Location = new System.Drawing.Point(376, 3);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 136;
            this.label1.Text = "Search (Code, Name)";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(39, 63);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(334, 20);
            this.textBoxSearch.TabIndex = 137;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Enabled = false;
            this.buttonUpdate.Location = new System.Drawing.Point(339, 301);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 138;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Image = global::Pharmacy_MS_SSC.Properties.Resources.search;
            this.buttonSearch.Location = new System.Drawing.Point(379, 59);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(29, 27);
            this.buttonSearch.TabIndex = 140;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 142;
            this.label3.Text = "Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 143;
            this.label4.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 144;
            this.label5.Text = "Company";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 145;
            this.label6.Text = "Running Stock";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 146;
            this.label7.Text = "Purchase Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 150;
            this.label2.Text = "New Sale MRP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(240, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 149;
            this.label8.Text = "New WS Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 148;
            this.label9.Text = "Sale MRP";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 249);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 147;
            this.label10.Text = "WS Price";
            // 
            // labelSaleMrp
            // 
            this.labelSaleMrp.AutoSize = true;
            this.labelSaleMrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaleMrp.Location = new System.Drawing.Point(123, 272);
            this.labelSaleMrp.Name = "labelSaleMrp";
            this.labelSaleMrp.Size = new System.Drawing.Size(0, 13);
            this.labelSaleMrp.TabIndex = 157;
            // 
            // labelWsPrice
            // 
            this.labelWsPrice.AutoSize = true;
            this.labelWsPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWsPrice.Location = new System.Drawing.Point(123, 249);
            this.labelWsPrice.Name = "labelWsPrice";
            this.labelWsPrice.Size = new System.Drawing.Size(0, 13);
            this.labelWsPrice.TabIndex = 156;
            // 
            // labelPurchasePrice
            // 
            this.labelPurchasePrice.AutoSize = true;
            this.labelPurchasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPurchasePrice.Location = new System.Drawing.Point(123, 227);
            this.labelPurchasePrice.Name = "labelPurchasePrice";
            this.labelPurchasePrice.Size = new System.Drawing.Size(0, 13);
            this.labelPurchasePrice.TabIndex = 155;
            // 
            // labelRunningStock
            // 
            this.labelRunningStock.AutoSize = true;
            this.labelRunningStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRunningStock.Location = new System.Drawing.Point(123, 203);
            this.labelRunningStock.Name = "labelRunningStock";
            this.labelRunningStock.Size = new System.Drawing.Size(0, 13);
            this.labelRunningStock.TabIndex = 154;
            // 
            // labelCompany
            // 
            this.labelCompany.AutoSize = true;
            this.labelCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompany.Location = new System.Drawing.Point(123, 179);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(0, 13);
            this.labelCompany.TabIndex = 153;
            // 
            // labelMedicineName
            // 
            this.labelMedicineName.AutoSize = true;
            this.labelMedicineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMedicineName.Location = new System.Drawing.Point(123, 136);
            this.labelMedicineName.Name = "labelMedicineName";
            this.labelMedicineName.Size = new System.Drawing.Size(0, 13);
            this.labelMedicineName.TabIndex = 152;
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCode.Location = new System.Drawing.Point(123, 112);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(0, 13);
            this.labelCode.TabIndex = 151;
            // 
            // textBoxNewWsPrice
            // 
            this.textBoxNewWsPrice.Location = new System.Drawing.Point(324, 245);
            this.textBoxNewWsPrice.Name = "textBoxNewWsPrice";
            this.textBoxNewWsPrice.Size = new System.Drawing.Size(90, 20);
            this.textBoxNewWsPrice.TabIndex = 158;
            // 
            // textBoxNewSaleMrp
            // 
            this.textBoxNewSaleMrp.Location = new System.Drawing.Point(324, 268);
            this.textBoxNewSaleMrp.Name = "textBoxNewSaleMrp";
            this.textBoxNewSaleMrp.Size = new System.Drawing.Size(90, 20);
            this.textBoxNewSaleMrp.TabIndex = 159;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategory.Location = new System.Drawing.Point(123, 158);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(0, 13);
            this.labelCategory.TabIndex = 161;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 160;
            this.label12.Text = "Category";
            // 
            // listViewTrade
            // 
            this.listViewTrade.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSl,
            this.columnHeaderTradeCode,
            this.columnHeaderTradeName});
            this.listViewTrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTrade.FullRowSelect = true;
            this.listViewTrade.GridLines = true;
            this.listViewTrade.Location = new System.Drawing.Point(0, 0);
            this.listViewTrade.Name = "listViewTrade";
            this.listViewTrade.Size = new System.Drawing.Size(370, 136);
            this.listViewTrade.TabIndex = 162;
            this.listViewTrade.UseCompatibleStateImageBehavior = false;
            this.listViewTrade.View = System.Windows.Forms.View.Details;
            this.listViewTrade.DoubleClick += new System.EventHandler(this.listViewTrade_DoubleClick);
            this.listViewTrade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewTrade_KeyDown);
            // 
            // columnHeaderSl
            // 
            this.columnHeaderSl.Text = "#";
            this.columnHeaderSl.Width = 40;
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
            // panelTrade
            // 
            this.panelTrade.Controls.Add(this.pictureBoxHideTradePanel);
            this.panelTrade.Controls.Add(this.listViewTrade);
            this.panelTrade.Location = new System.Drawing.Point(35, 88);
            this.panelTrade.Name = "panelTrade";
            this.panelTrade.Size = new System.Drawing.Size(370, 136);
            this.panelTrade.TabIndex = 163;
            this.panelTrade.Visible = false;
            // 
            // pictureBoxHideTradePanel
            // 
            this.pictureBoxHideTradePanel.Image = global::Pharmacy_MS_SSC.Properties.Resources.Close;
            this.pictureBoxHideTradePanel.Location = new System.Drawing.Point(344, 1);
            this.pictureBoxHideTradePanel.Name = "pictureBoxHideTradePanel";
            this.pictureBoxHideTradePanel.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxHideTradePanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHideTradePanel.TabIndex = 164;
            this.pictureBoxHideTradePanel.TabStop = false;
            this.pictureBoxHideTradePanel.Click += new System.EventHandler(this.pictureBoxHideTradePanel_Click);
            // 
            // frmMedicineUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 346);
            this.Controls.Add(this.panelTrade);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxNewSaleMrp);
            this.Controls.Add(this.textBoxNewWsPrice);
            this.Controls.Add(this.labelSaleMrp);
            this.Controls.Add(this.labelWsPrice);
            this.Controls.Add(this.labelPurchasePrice);
            this.Controls.Add(this.labelRunningStock);
            this.Controls.Add(this.labelCompany);
            this.Controls.Add(this.labelMedicineName);
            this.Controls.Add(this.labelCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMedicineUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPurchaseReport";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelTrade.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHideTradePanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel panelTitle;
        private System.Windows.Forms.Label labelTitle;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label labelMinimize;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxNewSaleMrp;
        private System.Windows.Forms.TextBox textBoxNewWsPrice;
        private System.Windows.Forms.Label labelSaleMrp;
        private System.Windows.Forms.Label labelWsPrice;
        private System.Windows.Forms.Label labelPurchasePrice;
        private System.Windows.Forms.Label labelRunningStock;
        private System.Windows.Forms.Label labelCompany;
        private System.Windows.Forms.Label labelMedicineName;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView listViewTrade;
        private System.Windows.Forms.Panel panelTrade;
        private System.Windows.Forms.PictureBox pictureBoxHideTradePanel;
        private System.Windows.Forms.ColumnHeader columnHeaderSl;
        private System.Windows.Forms.ColumnHeader columnHeaderTradeCode;
        private System.Windows.Forms.ColumnHeader columnHeaderTradeName;
    }
}