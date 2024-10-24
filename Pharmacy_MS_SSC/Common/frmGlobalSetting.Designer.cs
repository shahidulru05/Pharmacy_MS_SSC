namespace Pharmacy_MS_SSC.Common
{
    partial class frmGlobalSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSaleMemoInch = new System.Windows.Forms.ComboBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.checkBoxInputSample = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sale Memo (inch)";
            // 
            // comboBoxSaleMemoInch
            // 
            this.comboBoxSaleMemoInch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSaleMemoInch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSaleMemoInch.FormattingEnabled = true;
            this.comboBoxSaleMemoInch.Items.AddRange(new object[] {
            "2",
            "3"});
            this.comboBoxSaleMemoInch.Location = new System.Drawing.Point(142, 24);
            this.comboBoxSaleMemoInch.Name = "comboBoxSaleMemoInch";
            this.comboBoxSaleMemoInch.Size = new System.Drawing.Size(76, 24);
            this.comboBoxSaleMemoInch.TabIndex = 1;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(551, 393);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(131, 43);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // checkBoxInputSample
            // 
            this.checkBoxInputSample.AutoSize = true;
            this.checkBoxInputSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxInputSample.Location = new System.Drawing.Point(241, 26);
            this.checkBoxInputSample.Name = "checkBoxInputSample";
            this.checkBoxInputSample.Size = new System.Drawing.Size(139, 20);
            this.checkBoxInputSample.TabIndex = 4;
            this.checkBoxInputSample.Text = "Input Sample Price";
            this.checkBoxInputSample.UseVisualStyleBackColor = true;
            // 
            // frmGlobalSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 448);
            this.Controls.Add(this.comboBoxSaleMemoInch);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.checkBoxInputSample);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGlobalSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Global Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSaleMemoInch;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.CheckBox checkBoxInputSample;
    }
}