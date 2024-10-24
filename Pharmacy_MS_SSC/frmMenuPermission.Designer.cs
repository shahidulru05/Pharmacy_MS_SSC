namespace Pharmacy_MS_SSC
{
    partial class frmMenuPermission
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
            this.treeViewMenuList = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.pictureBoxAddUser = new System.Windows.Forms.PictureBox();
            this.comboBoxRoleList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRole = new System.Windows.Forms.TextBox();
            this.buttonAddRole = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddUser)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewMenuList
            // 
            this.treeViewMenuList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewMenuList.CheckBoxes = true;
            this.treeViewMenuList.Location = new System.Drawing.Point(29, 98);
            this.treeViewMenuList.Name = "treeViewMenuList";
            this.treeViewMenuList.Size = new System.Drawing.Size(716, 355);
            this.treeViewMenuList.TabIndex = 2;
            this.treeViewMenuList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMenuList_AfterCheck);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.buttonUpdate);
            this.panel1.Controls.Add(this.pictureBoxAddUser);
            this.panel1.Controls.Add(this.comboBoxRoleList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxRole);
            this.panel1.Controls.Add(this.buttonAddRole);
            this.panel1.Location = new System.Drawing.Point(29, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 80);
            this.panel1.TabIndex = 145;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(617, 8);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(96, 69);
            this.buttonUpdate.TabIndex = 146;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // pictureBoxAddUser
            // 
            this.pictureBoxAddUser.Image = global::Pharmacy_MS_SSC.Properties.Resources.Add;
            this.pictureBoxAddUser.Location = new System.Drawing.Point(519, 16);
            this.pictureBoxAddUser.Name = "pictureBoxAddUser";
            this.pictureBoxAddUser.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxAddUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAddUser.TabIndex = 141;
            this.pictureBoxAddUser.TabStop = false;
            this.pictureBoxAddUser.Click += new System.EventHandler(this.pictureBoxAddUser_Click);
            // 
            // comboBoxRoleList
            // 
            this.comboBoxRoleList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoleList.FormattingEnabled = true;
            this.comboBoxRoleList.Location = new System.Drawing.Point(274, 16);
            this.comboBoxRoleList.Name = "comboBoxRoleList";
            this.comboBoxRoleList.Size = new System.Drawing.Size(239, 21);
            this.comboBoxRoleList.TabIndex = 136;
            this.comboBoxRoleList.SelectedIndexChanged += new System.EventHandler(this.comboBoxRoleList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 22);
            this.label1.TabIndex = 135;
            this.label1.Text = "User Role";
            // 
            // textBoxRole
            // 
            this.textBoxRole.Location = new System.Drawing.Point(274, 43);
            this.textBoxRole.Name = "textBoxRole";
            this.textBoxRole.Size = new System.Drawing.Size(157, 20);
            this.textBoxRole.TabIndex = 138;
            this.textBoxRole.Visible = false;
            // 
            // buttonAddRole
            // 
            this.buttonAddRole.Location = new System.Drawing.Point(438, 43);
            this.buttonAddRole.Name = "buttonAddRole";
            this.buttonAddRole.Size = new System.Drawing.Size(75, 23);
            this.buttonAddRole.TabIndex = 139;
            this.buttonAddRole.Text = "ADD ROLE";
            this.buttonAddRole.UseVisualStyleBackColor = true;
            this.buttonAddRole.Visible = false;
            this.buttonAddRole.Click += new System.EventHandler(this.buttonAddRole_Click);
            // 
            // frmMenuPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 481);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeViewMenuList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMenuPermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add User and Permission";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewMenuList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxRoleList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRole;
        private System.Windows.Forms.Button buttonAddRole;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.PictureBox pictureBoxAddUser;
    }
}