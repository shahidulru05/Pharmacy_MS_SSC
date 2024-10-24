namespace Pharmacy_MS_SSC
{
    partial class frmDueCollection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDueCollection));
            this.panelTitle = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelClose = new System.Windows.Forms.Label();
            this.labelPin = new System.Windows.Forms.Label();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.textBoxSaleInvoice1 = new System.Windows.Forms.TextBox();
            this.textBoxSaleInvoice2 = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewDue = new System.Windows.Forms.ListView();
            this.columnHeaderSl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSlaeInvoice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMobileNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelTotalDue = new System.Windows.Forms.Label();
            this.labelDueCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSaleInv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSaleAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPayment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxDue = new System.Windows.Forms.TextBox();
            this.buttonPayment = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxDuePay = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxCurrentDue = new System.Windows.Forms.TextBox();
            this.listViewDuePayment = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxTotalDuePay = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.labelDueCollectionInvoice = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labelTotalDueThisCustomer = new System.Windows.Forms.Label();
            this.panelTitle.SuspendLayout();
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
            this.panelTitle.Size = new System.Drawing.Size(828, 37);
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
            this.labelTitle.Size = new System.Drawing.Size(703, 22);
            this.labelTitle.TabIndex = 135;
            this.labelTitle.Text = "Due Collection";
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
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(828, 6);
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
            this.labelClose.Location = new System.Drawing.Point(793, 9);
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
            this.labelMinimize.Location = new System.Drawing.Point(763, 3);
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
            // textBoxSaleInvoice1
            // 
            this.textBoxSaleInvoice1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxSaleInvoice1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSaleInvoice1.Location = new System.Drawing.Point(347, 48);
            this.textBoxSaleInvoice1.Name = "textBoxSaleInvoice1";
            this.textBoxSaleInvoice1.ReadOnly = true;
            this.textBoxSaleInvoice1.Size = new System.Drawing.Size(46, 22);
            this.textBoxSaleInvoice1.TabIndex = 186;
            this.textBoxSaleInvoice1.Text = "SINV-";
            // 
            // textBoxSaleInvoice2
            // 
            this.textBoxSaleInvoice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSaleInvoice2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxSaleInvoice2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSaleInvoice2.Location = new System.Drawing.Point(392, 48);
            this.textBoxSaleInvoice2.Name = "textBoxSaleInvoice2";
            this.textBoxSaleInvoice2.Size = new System.Drawing.Size(341, 22);
            this.textBoxSaleInvoice2.TabIndex = 185;
            this.textBoxSaleInvoice2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSaleInvoice2_KeyDown);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Image = global::Pharmacy_MS_SSC.Properties.Resources.search;
            this.buttonSearch.Location = new System.Drawing.Point(739, 47);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(25, 25);
            this.buttonSearch.TabIndex = 187;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 189;
            this.label2.Text = "Due Invoice List";
            // 
            // listViewDue
            // 
            this.listViewDue.AutoArrange = false;
            this.listViewDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewDue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSl,
            this.columnHeaderSlaeInvoice,
            this.columnHeaderDue,
            this.columnHeaderMobileNo,
            this.columnHeaderName});
            this.listViewDue.FullRowSelect = true;
            this.listViewDue.GridLines = true;
            this.listViewDue.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDue.LabelWrap = false;
            this.listViewDue.Location = new System.Drawing.Point(15, 105);
            this.listViewDue.MultiSelect = false;
            this.listViewDue.Name = "listViewDue";
            this.listViewDue.Size = new System.Drawing.Size(437, 327);
            this.listViewDue.TabIndex = 190;
            this.listViewDue.UseCompatibleStateImageBehavior = false;
            this.listViewDue.View = System.Windows.Forms.View.Details;
            this.listViewDue.DoubleClick += new System.EventHandler(this.listViewDue_DoubleClick);
            this.listViewDue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewDue_KeyDown);
            // 
            // columnHeaderSl
            // 
            this.columnHeaderSl.Text = "#";
            this.columnHeaderSl.Width = 35;
            // 
            // columnHeaderSlaeInvoice
            // 
            this.columnHeaderSlaeInvoice.Text = "Sale Invoice";
            this.columnHeaderSlaeInvoice.Width = 100;
            // 
            // columnHeaderDue
            // 
            this.columnHeaderDue.Text = "Due (tk)";
            this.columnHeaderDue.Width = 70;
            // 
            // columnHeaderMobileNo
            // 
            this.columnHeaderMobileNo.Text = "Mobile No";
            this.columnHeaderMobileNo.Width = 80;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 130;
            // 
            // labelTotalDue
            // 
            this.labelTotalDue.AutoSize = true;
            this.labelTotalDue.Location = new System.Drawing.Point(46, 435);
            this.labelTotalDue.Name = "labelTotalDue";
            this.labelTotalDue.Size = new System.Drawing.Size(0, 13);
            this.labelTotalDue.TabIndex = 191;
            // 
            // labelDueCount
            // 
            this.labelDueCount.AutoSize = true;
            this.labelDueCount.Location = new System.Drawing.Point(102, 89);
            this.labelDueCount.Name = "labelDueCount";
            this.labelDueCount.Size = new System.Drawing.Size(0, 13);
            this.labelDueCount.TabIndex = 192;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 195;
            this.label4.Text = "Total";
            // 
            // textBoxSaleInv
            // 
            this.textBoxSaleInv.Location = new System.Drawing.Point(539, 286);
            this.textBoxSaleInv.Name = "textBoxSaleInv";
            this.textBoxSaleInv.ReadOnly = true;
            this.textBoxSaleInv.Size = new System.Drawing.Size(273, 20);
            this.textBoxSaleInv.TabIndex = 196;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 197;
            this.label3.Text = "Sale Invoice";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(467, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 199;
            this.label5.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(539, 312);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(273, 20);
            this.textBoxName.TabIndex = 198;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(467, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 201;
            this.label6.Text = "Phone";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(539, 338);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.ReadOnly = true;
            this.textBoxPhone.Size = new System.Drawing.Size(273, 20);
            this.textBoxPhone.TabIndex = 200;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(467, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 203;
            this.label7.Text = "Total Amount";
            // 
            // textBoxSaleAmount
            // 
            this.textBoxSaleAmount.Location = new System.Drawing.Point(539, 364);
            this.textBoxSaleAmount.Name = "textBoxSaleAmount";
            this.textBoxSaleAmount.ReadOnly = true;
            this.textBoxSaleAmount.Size = new System.Drawing.Size(71, 20);
            this.textBoxSaleAmount.TabIndex = 202;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(614, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 205;
            this.label8.Text = "Pay";
            // 
            // textBoxPayment
            // 
            this.textBoxPayment.Location = new System.Drawing.Point(639, 364);
            this.textBoxPayment.Name = "textBoxPayment";
            this.textBoxPayment.ReadOnly = true;
            this.textBoxPayment.Size = new System.Drawing.Size(71, 20);
            this.textBoxPayment.TabIndex = 204;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(714, 367);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 207;
            this.label9.Text = "Due";
            // 
            // textBoxDue
            // 
            this.textBoxDue.Location = new System.Drawing.Point(741, 364);
            this.textBoxDue.Name = "textBoxDue";
            this.textBoxDue.ReadOnly = true;
            this.textBoxDue.Size = new System.Drawing.Size(71, 20);
            this.textBoxDue.TabIndex = 206;
            // 
            // buttonPayment
            // 
            this.buttonPayment.Enabled = false;
            this.buttonPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPayment.Location = new System.Drawing.Point(729, 416);
            this.buttonPayment.Name = "buttonPayment";
            this.buttonPayment.Size = new System.Drawing.Size(83, 32);
            this.buttonPayment.TabIndex = 208;
            this.buttonPayment.Text = "Payment";
            this.buttonPayment.UseVisualStyleBackColor = true;
            this.buttonPayment.Click += new System.EventHandler(this.buttonPayment_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(467, 393);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 210;
            this.label10.Text = "Payment";
            // 
            // textBoxDuePay
            // 
            this.textBoxDuePay.Location = new System.Drawing.Point(539, 390);
            this.textBoxDuePay.Name = "textBoxDuePay";
            this.textBoxDuePay.Size = new System.Drawing.Size(100, 20);
            this.textBoxDuePay.TabIndex = 209;
            this.textBoxDuePay.TextChanged += new System.EventHandler(this.textBoxDuePay_TextChanged);
            this.textBoxDuePay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDuePay_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(653, 393);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 212;
            this.label11.Text = "Current Due";
            // 
            // textBoxCurrentDue
            // 
            this.textBoxCurrentDue.Location = new System.Drawing.Point(717, 390);
            this.textBoxCurrentDue.Name = "textBoxCurrentDue";
            this.textBoxCurrentDue.ReadOnly = true;
            this.textBoxCurrentDue.Size = new System.Drawing.Size(95, 20);
            this.textBoxCurrentDue.TabIndex = 211;
            // 
            // listViewDuePayment
            // 
            this.listViewDuePayment.AutoArrange = false;
            this.listViewDuePayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewDuePayment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewDuePayment.FullRowSelect = true;
            this.listViewDuePayment.GridLines = true;
            this.listViewDuePayment.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDuePayment.LabelWrap = false;
            this.listViewDuePayment.Location = new System.Drawing.Point(458, 105);
            this.listViewDuePayment.MultiSelect = false;
            this.listViewDuePayment.Name = "listViewDuePayment";
            this.listViewDuePayment.Size = new System.Drawing.Size(271, 175);
            this.listViewDuePayment.TabIndex = 213;
            this.listViewDuePayment.UseCompatibleStateImageBehavior = false;
            this.listViewDuePayment.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Due Pay Invoice";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Pay Amount";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date";
            this.columnHeader4.Width = 70;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(455, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 13);
            this.label12.TabIndex = 214;
            this.label12.Text = "Due Payment Invoice List";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(737, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 216;
            this.label13.Text = "Total Due Pay";
            // 
            // textBoxTotalDuePay
            // 
            this.textBoxTotalDuePay.Location = new System.Drawing.Point(741, 132);
            this.textBoxTotalDuePay.Name = "textBoxTotalDuePay";
            this.textBoxTotalDuePay.ReadOnly = true;
            this.textBoxTotalDuePay.Size = new System.Drawing.Size(71, 20);
            this.textBoxTotalDuePay.TabIndex = 215;
            this.textBoxTotalDuePay.Text = "0.00";
            this.textBoxTotalDuePay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 217;
            this.label14.Text = "Invoice :";
            // 
            // labelDueCollectionInvoice
            // 
            this.labelDueCollectionInvoice.AutoSize = true;
            this.labelDueCollectionInvoice.Location = new System.Drawing.Point(75, 53);
            this.labelDueCollectionInvoice.Name = "labelDueCollectionInvoice";
            this.labelDueCollectionInvoice.Size = new System.Drawing.Size(0, 13);
            this.labelDueCollectionInvoice.TabIndex = 218;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(245, 435);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 219;
            this.label15.Text = "Total Due";
            // 
            // labelTotalDueThisCustomer
            // 
            this.labelTotalDueThisCustomer.AutoSize = true;
            this.labelTotalDueThisCustomer.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalDueThisCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalDueThisCustomer.ForeColor = System.Drawing.Color.Red;
            this.labelTotalDueThisCustomer.Location = new System.Drawing.Point(299, 435);
            this.labelTotalDueThisCustomer.Name = "labelTotalDueThisCustomer";
            this.labelTotalDueThisCustomer.Size = new System.Drawing.Size(21, 13);
            this.labelTotalDueThisCustomer.TabIndex = 220;
            this.labelTotalDueThisCustomer.Text = "00";
            // 
            // frmDueCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 464);
            this.Controls.Add(this.labelTotalDueThisCustomer);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.labelDueCollectionInvoice);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxTotalDuePay);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.listViewDuePayment);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxCurrentDue);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxDuePay);
            this.Controls.Add(this.buttonPayment);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxDue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxPayment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxSaleAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSaleInv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelDueCount);
            this.Controls.Add(this.labelTotalDue);
            this.Controls.Add(this.listViewDue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSaleInvoice1);
            this.Controls.Add(this.textBoxSaleInvoice2);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDueCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPurchaseReport";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxSaleInvoice1;
        private System.Windows.Forms.TextBox textBoxSaleInvoice2;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewDue;
        private System.Windows.Forms.ColumnHeader columnHeaderSl;
        private System.Windows.Forms.ColumnHeader columnHeaderSlaeInvoice;
        private System.Windows.Forms.ColumnHeader columnHeaderDue;
        private System.Windows.Forms.Label labelDueCount;
        private System.Windows.Forms.Label labelTotalDue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSaleInv;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxCurrentDue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxDuePay;
        private System.Windows.Forms.Button buttonPayment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxDue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPayment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSaleAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView listViewDuePayment;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxTotalDuePay;
        private System.Windows.Forms.Label labelDueCollectionInvoice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeaderMobileNo;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.Label labelTotalDueThisCustomer;
        private System.Windows.Forms.Label label15;
    }
}