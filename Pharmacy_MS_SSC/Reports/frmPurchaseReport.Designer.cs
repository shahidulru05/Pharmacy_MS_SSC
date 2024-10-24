namespace Pharmacy_MS_SSC.Reports
{
    partial class frmPurchaseReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseReport));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.HospitalInformationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelTitle = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelClose = new System.Windows.Forms.Label();
            this.labelPin = new System.Windows.Forms.Label();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.reportViewerPurchaseReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxPurchaseType = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HospitalInformationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseBindingSource)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // PurchaseBindingSource
            // 
            this.PurchaseBindingSource.DataMember = "Purchase";
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
            this.panelTitle.Size = new System.Drawing.Size(949, 37);
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
            this.labelTitle.Size = new System.Drawing.Size(824, 22);
            this.labelTitle.TabIndex = 135;
            this.labelTitle.Text = "Purchase Report";
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
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(949, 6);
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
            this.labelClose.Location = new System.Drawing.Point(914, 9);
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
            this.labelMinimize.Location = new System.Drawing.Point(884, 3);
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
            // reportViewerPurchaseReport
            // 
            this.reportViewerPurchaseReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource5.Name = "HospitalDetails";
            reportDataSource5.Value = this.HospitalInformationBindingSource;
            reportDataSource6.Name = "PurchaseInformation";
            reportDataSource6.Value = this.PurchaseBindingSource;
            this.reportViewerPurchaseReport.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewerPurchaseReport.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewerPurchaseReport.LocalReport.ReportEmbeddedResource = "Pharmacy_MS_SSC.Reports.rptPurchase.rdlc";
            this.reportViewerPurchaseReport.Location = new System.Drawing.Point(12, 94);
            this.reportViewerPurchaseReport.Name = "reportViewerPurchaseReport";
            this.reportViewerPurchaseReport.ServerReport.BearerToken = null;
            this.reportViewerPurchaseReport.Size = new System.Drawing.Size(925, 338);
            this.reportViewerPurchaseReport.TabIndex = 136;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.AllowDrop = true;
            this.dateTimePickerFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerFrom.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerFrom.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(582, 44);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(140, 26);
            this.dateTimePickerFrom.TabIndex = 194;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Image = global::Pharmacy_MS_SSC.Properties.Resources.search;
            this.buttonSearch.Location = new System.Drawing.Point(907, 42);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(30, 30);
            this.buttonSearch.TabIndex = 198;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.AllowDrop = true;
            this.dateTimePickerTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerTo.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerTo.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTo.Location = new System.Drawing.Point(761, 44);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(140, 26);
            this.dateTimePickerTo.TabIndex = 195;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(728, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 197;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(530, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 196;
            this.label2.Text = "From";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(72, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 13);
            this.label9.TabIndex = 201;
            this.label9.Text = "By TradeCode /TradeName /Vendor ";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(68, 47);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(188, 20);
            this.textBoxSearch.TabIndex = 200;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 199;
            this.label8.Text = "Search :";
            // 
            // comboBoxPurchaseType
            // 
            this.comboBoxPurchaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPurchaseType.FormattingEnabled = true;
            this.comboBoxPurchaseType.Items.AddRange(new object[] {
            "All",
            "General",
            "Sample",
            "Local"});
            this.comboBoxPurchaseType.Location = new System.Drawing.Point(360, 47);
            this.comboBoxPurchaseType.Name = "comboBoxPurchaseType";
            this.comboBoxPurchaseType.Size = new System.Drawing.Size(150, 21);
            this.comboBoxPurchaseType.TabIndex = 202;
            this.comboBoxPurchaseType.SelectedIndexChanged += new System.EventHandler(this.comboBoxPurchaseType_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(272, 51);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(82, 13);
            this.label23.TabIndex = 203;
            this.label23.Text = "Purchase Type:";
            // 
            // frmPurchaseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 444);
            this.Controls.Add(this.comboBoxPurchaseType);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reportViewerPurchaseReport);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPurchaseReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPurchaseReport";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPurchaseReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HospitalInformationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseBindingSource)).EndInit();
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
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPurchaseReport;
        private System.Windows.Forms.BindingSource HospitalInformationBindingSource;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource PurchaseBindingSource;
        private System.Windows.Forms.ComboBox comboBoxPurchaseType;
        private System.Windows.Forms.Label label23;
    }
}