namespace Pharmacy_MS_SSC
{
    partial class frmStockRemainder
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
            this.listViewRemainderList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.labelReaminderQty = new System.Windows.Forms.Label();
            this.saTextBoxSearch = new ShakikulFramework.Toolbox.SATextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewRemainderList
            // 
            this.listViewRemainderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewRemainderList.FullRowSelect = true;
            this.listViewRemainderList.GridLines = true;
            this.listViewRemainderList.Location = new System.Drawing.Point(13, 51);
            this.listViewRemainderList.MultiSelect = false;
            this.listViewRemainderList.Name = "listViewRemainderList";
            this.listViewRemainderList.Size = new System.Drawing.Size(764, 350);
            this.listViewRemainderList.TabIndex = 0;
            this.listViewRemainderList.UseCompatibleStateImageBehavior = false;
            this.listViewRemainderList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Trade Code";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Trade Name";
            this.columnHeader3.Width = 180;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Qty";
            this.columnHeader4.Width = 40;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Remainder Qty";
            this.columnHeader7.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Generic Name";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Company Name";
            this.columnHeader6.Width = 180;
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.Image = global::Pharmacy_MS_SSC.Properties.Resources.search;
            this.pictureBoxSearch.Location = new System.Drawing.Point(270, 13);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSearch.TabIndex = 4;
            this.pictureBoxSearch.TabStop = false;
            this.pictureBoxSearch.Click += new System.EventHandler(this.pictureBoxSearch_Click);
            // 
            // labelReaminderQty
            // 
            this.labelReaminderQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReaminderQty.Location = new System.Drawing.Point(553, 21);
            this.labelReaminderQty.Name = "labelReaminderQty";
            this.labelReaminderQty.Size = new System.Drawing.Size(224, 23);
            this.labelReaminderQty.TabIndex = 2;
            this.labelReaminderQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // saTextBoxSearch
            // 
            this.saTextBoxSearch.BackColor = System.Drawing.SystemColors.Window;
            this.saTextBoxSearch.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.saTextBoxSearch.BorderFocusColor = System.Drawing.Color.Red;
            this.saTextBoxSearch.BorderRadius = 5;
            this.saTextBoxSearch.BorderSize = 2;
            this.saTextBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saTextBoxSearch.ForeColor = System.Drawing.Color.Black;
            this.saTextBoxSearch.Location = new System.Drawing.Point(13, 13);
            this.saTextBoxSearch.Margin = new System.Windows.Forms.Padding(4);
            this.saTextBoxSearch.Multiline = false;
            this.saTextBoxSearch.Name = "saTextBoxSearch";
            this.saTextBoxSearch.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.saTextBoxSearch.PasswordChar = false;
            this.saTextBoxSearch.PlaceholderColor = System.Drawing.Color.Silver;
            this.saTextBoxSearch.PlaceholderText = "Search Reaminder Items";
            this.saTextBoxSearch.Size = new System.Drawing.Size(250, 31);
            this.saTextBoxSearch.TabIndex = 1;
            this.saTextBoxSearch.UnderlineStyle = false;
            this.saTextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.saTextBoxSearch_KeyDown);
            // 
            // frmStockRemainder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 413);
            this.Controls.Add(this.labelReaminderQty);
            this.Controls.Add(this.pictureBoxSearch);
            this.Controls.Add(this.saTextBoxSearch);
            this.Controls.Add(this.listViewRemainderList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockRemainder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Remainder Items";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewRemainderList;
        private ShakikulFramework.Toolbox.SATextBox saTextBoxSearch;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.Label labelReaminderQty;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;

    }
}