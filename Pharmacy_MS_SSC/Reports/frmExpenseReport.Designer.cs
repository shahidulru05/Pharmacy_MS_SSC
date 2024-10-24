namespace Pharmacy_MS_SSC.Reports
{
    partial class frmExpenseReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpenseReport));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Handle = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.contextMenuStripShortcut = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DailyExpenseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HospitalInformationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Handle.SuspendLayout();
            this.contextMenuStripShortcut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DailyExpenseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HospitalInformationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.Handle;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Handle
            // 
            this.Handle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Handle.BackgroundImage")));
            this.Handle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Handle.Controls.Add(this.bunifuGradientPanel1);
            this.Handle.Controls.Add(this.label1);
            this.Handle.Controls.Add(this.label19);
            this.Handle.Controls.Add(this.label20);
            this.Handle.Controls.Add(this.label21);
            this.Handle.Controls.Add(this.label22);
            this.Handle.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Handle.Dock = System.Windows.Forms.DockStyle.Top;
            this.Handle.GradientBottomLeft = System.Drawing.Color.White;
            this.Handle.GradientBottomRight = System.Drawing.Color.White;
            this.Handle.GradientTopLeft = System.Drawing.Color.White;
            this.Handle.GradientTopRight = System.Drawing.Color.White;
            this.Handle.Location = new System.Drawing.Point(0, 0);
            this.Handle.Name = "Handle";
            this.Handle.Quality = 10;
            this.Handle.Size = new System.Drawing.Size(771, 37);
            this.Handle.TabIndex = 135;
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
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(771, 6);
            this.bunifuGradientPanel1.TabIndex = 157;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 136;
            this.label1.Text = "Expense Report";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label19.Location = new System.Drawing.Point(23, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(25, 15);
            this.label19.TabIndex = 143;
            this.label19.Text = "Pin";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Tomato;
            this.label20.Location = new System.Drawing.Point(736, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 22);
            this.label20.TabIndex = 134;
            this.label20.Text = "X";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Tomato;
            this.label21.Location = new System.Drawing.Point(5, 3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(27, 31);
            this.label21.TabIndex = 142;
            this.label21.Text = "^";
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Tomato;
            this.label22.Location = new System.Drawing.Point(705, 4);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 31);
            this.label22.TabIndex = 135;
            this.label22.Text = "-";
            this.label22.Click += new System.EventHandler(this.label22_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DailyExpense";
            reportDataSource1.Value = this.DailyExpenseBindingSource;
            reportDataSource2.Name = "HospitalDetails";
            reportDataSource2.Value = this.HospitalInformationBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy_MS_SSC.Reports.rptExpenseReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(11, 72);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(747, 350);
            this.reportViewer1.TabIndex = 136;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(684, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 147;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerEnd.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(573, 44);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerEnd.TabIndex = 146;
            this.dateTimePickerEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePickerEnd_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(532, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 145;
            this.label2.Text = "TO";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerStart.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(417, 44);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerStart.TabIndex = 144;
            this.dateTimePickerStart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePickerStart_KeyDown);
            // 
            // contextMenuStripShortcut
            // 
            this.contextMenuStripShortcut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem});
            this.contextMenuStripShortcut.Name = "contextMenuStripShortcut";
            this.contextMenuStripShortcut.Size = new System.Drawing.Size(141, 26);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = global::Pharmacy_MS_SSC.Properties.Resources.print_black;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // DailyExpenseBindingSource
            // 
            this.DailyExpenseBindingSource.DataMember = "DailyExpense";
            // 
            // HospitalInformationBindingSource
            // 
            this.HospitalInformationBindingSource.DataMember = "HospitalInformation";
            // 
            // frmExpenseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 434);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.Handle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmExpenseReport";
            this.Text = "frmExpenseReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmExpenseReport_Load);
            this.Handle.ResumeLayout(false);
            this.Handle.PerformLayout();
            this.contextMenuStripShortcut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DailyExpenseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HospitalInformationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel Handle;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripShortcut;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.BindingSource DailyExpenseBindingSource;
        private System.Windows.Forms.BindingSource HospitalInformationBindingSource;
    }
}