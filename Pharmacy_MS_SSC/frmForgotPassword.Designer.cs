namespace Pharmacy_MS_SSC
{
    partial class frmForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForgotPassword));
            this.panelTitle = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.labelClose = new System.Windows.Forms.Label();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelUserName = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSecurity = new System.Windows.Forms.Panel();
            this.buttonVerify = new System.Windows.Forms.Button();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSecurityQuestion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSetNewPassword = new System.Windows.Forms.Panel();
            this.buttonSetNewPassword = new System.Windows.Forms.Button();
            this.labelMatchPasswordMessage = new System.Windows.Forms.Label();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxUserNamePassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBoxShowPassword = new System.Windows.Forms.PictureBox();
            this.panelTitle.SuspendLayout();
            this.panelUserName.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSecurity.SuspendLayout();
            this.panelSetNewPassword.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowPassword)).BeginInit();
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
            this.panelTitle.Size = new System.Drawing.Size(529, 37);
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
            this.labelTitle.Size = new System.Drawing.Size(405, 22);
            this.labelTitle.TabIndex = 135;
            this.labelTitle.Text = "Forgot Password";
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
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(529, 6);
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
            this.labelClose.Location = new System.Drawing.Point(494, 9);
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
            this.labelMinimize.Location = new System.Drawing.Point(464, 3);
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
            // panelUserName
            // 
            this.panelUserName.BackColor = System.Drawing.Color.Green;
            this.panelUserName.Controls.Add(this.panel1);
            this.panelUserName.Controls.Add(this.textBoxUserName);
            this.panelUserName.Controls.Add(this.label2);
            this.panelUserName.Location = new System.Drawing.Point(89, 114);
            this.panelUserName.Name = "panelUserName";
            this.panelUserName.Size = new System.Drawing.Size(350, 121);
            this.panelUserName.TabIndex = 138;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 34);
            this.panel1.TabIndex = 141;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 142;
            this.label3.Text = "User Verification";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserName.Location = new System.Drawing.Point(124, 63);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(194, 22);
            this.textBoxUserName.TabIndex = 140;
            this.textBoxUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUserName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(32, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 139;
            this.label2.Text = "User Name";
            // 
            // panelSecurity
            // 
            this.panelSecurity.Controls.Add(this.buttonVerify);
            this.panelSecurity.Controls.Add(this.textBoxAnswer);
            this.panelSecurity.Controls.Add(this.label4);
            this.panelSecurity.Controls.Add(this.textBoxSecurityQuestion);
            this.panelSecurity.Controls.Add(this.label1);
            this.panelSecurity.Location = new System.Drawing.Point(23, 56);
            this.panelSecurity.Name = "panelSecurity";
            this.panelSecurity.Size = new System.Drawing.Size(483, 229);
            this.panelSecurity.TabIndex = 142;
            this.panelSecurity.Visible = false;
            // 
            // buttonVerify
            // 
            this.buttonVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVerify.ForeColor = System.Drawing.Color.Green;
            this.buttonVerify.Location = new System.Drawing.Point(275, 155);
            this.buttonVerify.Name = "buttonVerify";
            this.buttonVerify.Size = new System.Drawing.Size(123, 38);
            this.buttonVerify.TabIndex = 146;
            this.buttonVerify.Text = "Verify";
            this.buttonVerify.UseVisualStyleBackColor = true;
            this.buttonVerify.Click += new System.EventHandler(this.buttonVerify_Click);
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAnswer.Location = new System.Drawing.Point(85, 116);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(313, 22);
            this.textBoxAnswer.TabIndex = 145;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 144;
            this.label4.Text = "Answer";
            // 
            // textBoxSecurityQuestion
            // 
            this.textBoxSecurityQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSecurityQuestion.Location = new System.Drawing.Point(85, 54);
            this.textBoxSecurityQuestion.Name = "textBoxSecurityQuestion";
            this.textBoxSecurityQuestion.ReadOnly = true;
            this.textBoxSecurityQuestion.Size = new System.Drawing.Size(313, 22);
            this.textBoxSecurityQuestion.TabIndex = 143;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 142;
            this.label1.Text = "Security Question";
            // 
            // panelSetNewPassword
            // 
            this.panelSetNewPassword.BackColor = System.Drawing.Color.Navy;
            this.panelSetNewPassword.Controls.Add(this.pictureBoxShowPassword);
            this.panelSetNewPassword.Controls.Add(this.buttonSetNewPassword);
            this.panelSetNewPassword.Controls.Add(this.labelMatchPasswordMessage);
            this.panelSetNewPassword.Controls.Add(this.textBoxConfirmPassword);
            this.panelSetNewPassword.Controls.Add(this.label8);
            this.panelSetNewPassword.Controls.Add(this.textBoxUserNamePassword);
            this.panelSetNewPassword.Controls.Add(this.label7);
            this.panelSetNewPassword.Controls.Add(this.panel3);
            this.panelSetNewPassword.Controls.Add(this.textBoxNewPassword);
            this.panelSetNewPassword.Controls.Add(this.label6);
            this.panelSetNewPassword.Location = new System.Drawing.Point(65, 74);
            this.panelSetNewPassword.Name = "panelSetNewPassword";
            this.panelSetNewPassword.Size = new System.Drawing.Size(399, 189);
            this.panelSetNewPassword.TabIndex = 143;
            this.panelSetNewPassword.Visible = false;
            // 
            // buttonSetNewPassword
            // 
            this.buttonSetNewPassword.Enabled = false;
            this.buttonSetNewPassword.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSetNewPassword.FlatAppearance.BorderSize = 2;
            this.buttonSetNewPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetNewPassword.ForeColor = System.Drawing.Color.White;
            this.buttonSetNewPassword.Location = new System.Drawing.Point(209, 151);
            this.buttonSetNewPassword.Name = "buttonSetNewPassword";
            this.buttonSetNewPassword.Size = new System.Drawing.Size(148, 28);
            this.buttonSetNewPassword.TabIndex = 147;
            this.buttonSetNewPassword.Text = "Set New Password";
            this.buttonSetNewPassword.UseVisualStyleBackColor = true;
            this.buttonSetNewPassword.Click += new System.EventHandler(this.buttonSetNewPassword_Click);
            // 
            // labelMatchPasswordMessage
            // 
            this.labelMatchPasswordMessage.AutoSize = true;
            this.labelMatchPasswordMessage.BackColor = System.Drawing.Color.Transparent;
            this.labelMatchPasswordMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatchPasswordMessage.ForeColor = System.Drawing.Color.White;
            this.labelMatchPasswordMessage.Location = new System.Drawing.Point(152, 130);
            this.labelMatchPasswordMessage.Name = "labelMatchPasswordMessage";
            this.labelMatchPasswordMessage.Size = new System.Drawing.Size(0, 16);
            this.labelMatchPasswordMessage.TabIndex = 146;
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(155, 105);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(202, 22);
            this.textBoxConfirmPassword.TabIndex = 145;
            this.textBoxConfirmPassword.UseSystemPasswordChar = true;
            this.textBoxConfirmPassword.TextChanged += new System.EventHandler(this.textBoxConfirmPassword_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(20, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 16);
            this.label8.TabIndex = 144;
            this.label8.Text = "Confirm Password";
            // 
            // textBoxUserNamePassword
            // 
            this.textBoxUserNamePassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUserNamePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserNamePassword.Location = new System.Drawing.Point(155, 49);
            this.textBoxUserNamePassword.Name = "textBoxUserNamePassword";
            this.textBoxUserNamePassword.ReadOnly = true;
            this.textBoxUserNamePassword.Size = new System.Drawing.Size(202, 22);
            this.textBoxUserNamePassword.TabIndex = 143;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(20, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 142;
            this.label7.Text = "User Name";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MediumBlue;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(399, 34);
            this.panel3.TabIndex = 141;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(10, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 16);
            this.label5.TabIndex = 142;
            this.label5.Text = "Set New Password";
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewPassword.Location = new System.Drawing.Point(155, 77);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(202, 22);
            this.textBoxNewPassword.TabIndex = 140;
            this.textBoxNewPassword.UseSystemPasswordChar = true;
            this.textBoxNewPassword.TextChanged += new System.EventHandler(this.textBoxNewPassword_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(20, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 16);
            this.label6.TabIndex = 139;
            this.label6.Text = "New Password";
            // 
            // pictureBoxShowPassword
            // 
            this.pictureBoxShowPassword.BackColor = System.Drawing.Color.White;
            this.pictureBoxShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxShowPassword.Image = global::Pharmacy_MS_SSC.Properties.Resources.eye_invisible;
            this.pictureBoxShowPassword.Location = new System.Drawing.Point(336, 78);
            this.pictureBoxShowPassword.Name = "pictureBoxShowPassword";
            this.pictureBoxShowPassword.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxShowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxShowPassword.TabIndex = 148;
            this.pictureBoxShowPassword.TabStop = false;
            this.pictureBoxShowPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxShowPassword_MouseDown);
            this.pictureBoxShowPassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxShowPassword_MouseUp);
            // 
            // frmForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 307);
            this.Controls.Add(this.panelUserName);
            this.Controls.Add(this.panelSetNewPassword);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelSecurity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPurchaseReport";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelUserName.ResumeLayout(false);
            this.panelUserName.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSecurity.ResumeLayout(false);
            this.panelSecurity.PerformLayout();
            this.panelSetNewPassword.ResumeLayout(false);
            this.panelSetNewPassword.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowPassword)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panelUserName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelSecurity;
        private System.Windows.Forms.Button buttonVerify;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSecurityQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSetNewPassword;
        private System.Windows.Forms.Button buttonSetNewPassword;
        private System.Windows.Forms.Label labelMatchPasswordMessage;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxUserNamePassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBoxShowPassword;
    }
}