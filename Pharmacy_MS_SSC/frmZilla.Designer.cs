namespace Pharmacy_MS_SSC
{
    partial class frmZilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZilla));
            this.panelTitle = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelClose = new System.Windows.Forms.Label();
            this.labelPin = new System.Windows.Forms.Label();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxZillaName = new System.Windows.Forms.TextBox();
            this.dataGridViewZillaList = new System.Windows.Forms.DataGridView();
            this.sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZillaList)).BeginInit();
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
            this.panelTitle.Size = new System.Drawing.Size(334, 37);
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
            this.labelTitle.Size = new System.Drawing.Size(209, 22);
            this.labelTitle.TabIndex = 135;
            this.labelTitle.Text = "Add New Zilla";
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
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(334, 6);
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
            this.labelClose.Location = new System.Drawing.Point(299, 9);
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
            this.labelMinimize.Location = new System.Drawing.Point(269, 3);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 136;
            this.label2.Text = "Zilla Name";
            // 
            // textBoxZillaName
            // 
            this.textBoxZillaName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxZillaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxZillaName.Location = new System.Drawing.Point(16, 79);
            this.textBoxZillaName.Name = "textBoxZillaName";
            this.textBoxZillaName.Size = new System.Drawing.Size(300, 29);
            this.textBoxZillaName.TabIndex = 137;
            this.textBoxZillaName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxZillaName_KeyDown);
            // 
            // dataGridViewZillaList
            // 
            this.dataGridViewZillaList.AllowUserToAddRows = false;
            this.dataGridViewZillaList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewZillaList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sl,
            this.id,
            this.name});
            this.dataGridViewZillaList.Location = new System.Drawing.Point(16, 114);
            this.dataGridViewZillaList.Name = "dataGridViewZillaList";
            this.dataGridViewZillaList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewZillaList.Size = new System.Drawing.Size(300, 212);
            this.dataGridViewZillaList.TabIndex = 138;
            this.dataGridViewZillaList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewZillaList_CellDoubleClick);
            this.dataGridViewZillaList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewZillaList_RowPostPaint);
            // 
            // sl
            // 
            this.sl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sl.HeaderText = "#";
            this.sl.Name = "sl";
            this.sl.ReadOnly = true;
            this.sl.Width = 39;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "Name";
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(199, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 171;
            this.label3.Text = "Total";
            // 
            // labelTotal
            // 
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(244, 327);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(72, 16);
            this.labelTotal.TabIndex = 172;
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Teal;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(16, 358);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(300, 31);
            this.buttonSave.TabIndex = 173;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // frmZilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 401);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewZillaList);
            this.Controls.Add(this.textBoxZillaName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmZilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPurchaseReport";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZillaList)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxZillaName;
        private System.Windows.Forms.DataGridView dataGridViewZillaList;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button buttonSave;
    }
}