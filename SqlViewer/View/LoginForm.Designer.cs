namespace SqlViewer.View
{
    partial class LoginForm
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
            label1 = new Label();
            tbServer = new TextBox();
            btnLogIn = new Button();
            tbUserName = new TextBox();
            label2 = new Label();
            tbPassword = new TextBox();
            label3 = new Label();
            lbError = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 64);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Server";
            // 
            // tbServer
            // 
            tbServer.Location = new Point(161, 61);
            tbServer.Name = "tbServer";
            tbServer.Size = new Size(198, 23);
            tbServer.TabIndex = 1;
            // 
            // btnLogIn
            // 
            btnLogIn.Location = new Point(161, 200);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(198, 35);
            btnLogIn.TabIndex = 4;
            btnLogIn.Text = "Log In";
            btnLogIn.UseVisualStyleBackColor = true;
            btnLogIn.Click += BtnLogIn_Click;
            // 
            // tbUserName
            // 
            tbUserName.Location = new Point(161, 107);
            tbUserName.Name = "tbUserName";
            tbUserName.Size = new Size(198, 23);
            tbUserName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 110);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 3;
            label2.Text = "UserName";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(161, 153);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(198, 23);
            tbPassword.TabIndex = 3;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 156);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // lbError
            // 
            lbError.AutoSize = true;
            lbError.ForeColor = Color.FromArgb(192, 0, 0);
            lbError.Location = new Point(161, 247);
            lbError.Name = "lbError";
            lbError.Size = new Size(103, 15);
            lbError.TabIndex = 7;
            lbError.Text = "Wrong credentials";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 337);
            Controls.Add(lbError);
            Controls.Add(tbPassword);
            Controls.Add(label3);
            Controls.Add(tbUserName);
            Controls.Add(label2);
            Controls.Add(btnLogIn);
            Controls.Add(tbServer);
            Controls.Add(label1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SSMS Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbServer;
        private Button btnLogIn;
        private TextBox tbUserName;
        private Label label2;
        private TextBox tbPassword;
        private Label label3;
        private Label lbError;
    }
}