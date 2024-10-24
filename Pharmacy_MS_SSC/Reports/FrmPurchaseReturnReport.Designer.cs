namespace Pharmacy_MS_SSC.Reports
{
    partial class FrmPurchaseReturnReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPurchaseReturnReport));
            this.panelTitle = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.labelClose = new System.Windows.Forms.Label();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.buttonView = new System.Windows.Forms.Button();
            this.checkBoxCompany = new System.Windows.Forms.CheckBox();
            this.checkBoxTradeName = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBoxCompany = new System.Windows.Forms.ComboBox();
            this.comboBoxTradeName = new System.Windows.Forms.ComboBox();
            this.panelTitle.SuspendLayout();
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
            this.panelTitle.Size = new System.Drawing.Size(449, 37);
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
            this.labelTitle.Size = new System.Drawing.Size(333, 22);
            this.labelTitle.TabIndex = 135;
            this.labelTitle.Text = "Purchase Return Report";
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
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(449, 6);
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
            this.labelClose.Location = new System.Drawing.Point(422, 9);
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
            this.labelMinimize.Location = new System.Drawing.Point(392, 3);
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
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTo.Location = new System.Drawing.Point(268, 63);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerTo.TabIndex = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 137;
            this.label1.Text = "to";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(124, 63);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerFrom.TabIndex = 138;
            // 
            // buttonView
            // 
            this.buttonView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonView.Location = new System.Drawing.Point(294, 171);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(94, 36);
            this.buttonView.TabIndex = 139;
            this.buttonView.Text = "View";
            this.buttonView.UseVisualStyleBackColor = true;
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // checkBoxCompany
            // 
            this.checkBoxCompany.AutoSize = true;
            this.checkBoxCompany.Location = new System.Drawing.Point(394, 139);
            this.checkBoxCompany.Name = "checkBoxCompany";
            this.checkBoxCompany.Size = new System.Drawing.Size(15, 14);
            this.checkBoxCompany.TabIndex = 174;
            this.checkBoxCompany.UseVisualStyleBackColor = true;
            // 
            // checkBoxTradeName
            // 
            this.checkBoxTradeName.AutoSize = true;
            this.checkBoxTradeName.Location = new System.Drawing.Point(394, 107);
            this.checkBoxTradeName.Name = "checkBoxTradeName";
            this.checkBoxTradeName.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTradeName.TabIndex = 172;
            this.checkBoxTradeName.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(59, 138);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 16);
            this.label18.TabIndex = 176;
            this.label18.Text = "Company";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(40, 106);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 16);
            this.label17.TabIndex = 175;
            this.label17.Text = "Trade Name";
            // 
            // comboBoxCompany
            // 
            this.comboBoxCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCompany.FormattingEnabled = true;
            this.comboBoxCompany.Location = new System.Drawing.Point(128, 134);
            this.comboBoxCompany.Name = "comboBoxCompany";
            this.comboBoxCompany.Size = new System.Drawing.Size(260, 24);
            this.comboBoxCompany.TabIndex = 173;
            // 
            // comboBoxTradeName
            // 
            this.comboBoxTradeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxTradeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTradeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTradeName.FormattingEnabled = true;
            this.comboBoxTradeName.Location = new System.Drawing.Point(128, 102);
            this.comboBoxTradeName.Name = "comboBoxTradeName";
            this.comboBoxTradeName.Size = new System.Drawing.Size(260, 24);
            this.comboBoxTradeName.TabIndex = 171;
            // 
            // FrmPurchaseReturnReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 241);
            this.Controls.Add(this.checkBoxCompany);
            this.Controls.Add(this.checkBoxTradeName);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.comboBoxCompany);
            this.Controls.Add(this.comboBoxTradeName);
            this.Controls.Add(this.buttonView);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPurchaseReturnReport";
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
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label labelMinimize;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.CheckBox checkBoxCompany;
        private System.Windows.Forms.CheckBox checkBoxTradeName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBoxCompany;
        private System.Windows.Forms.ComboBox comboBoxTradeName;
    }
}