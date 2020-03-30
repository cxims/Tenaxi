namespace MarioMain
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
            this.signin = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.Offline = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // signin
            // 
            this.signin.BackColor = System.Drawing.Color.Beige;
            this.signin.Location = new System.Drawing.Point(230, 228);
            this.signin.Name = "signin";
            this.signin.Size = new System.Drawing.Size(330, 40);
            this.signin.TabIndex = 3;
            this.signin.Text = "Sign In";
            this.signin.UseVisualStyleBackColor = false;
            this.signin.Click += new System.EventHandler(this.signin_Click);
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.Beige;
            this.login.Location = new System.Drawing.Point(230, 182);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(330, 40);
            this.login.TabIndex = 2;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = false;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // Offline
            // 
            this.Offline.BackColor = System.Drawing.Color.Beige;
            this.Offline.Location = new System.Drawing.Point(230, 274);
            this.Offline.Name = "Offline";
            this.Offline.Size = new System.Drawing.Size(330, 40);
            this.Offline.TabIndex = 4;
            this.Offline.Text = "Offline";
            this.Offline.UseVisualStyleBackColor = false;
            this.Offline.Click += new System.EventHandler(this.Offline_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Beige;
            this.exit.Location = new System.Drawing.Point(230, 320);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(330, 40);
            this.exit.TabIndex = 5;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MarioMain.Properties.Resources.bgblock;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.Offline);
            this.Controls.Add(this.signin);
            this.Controls.Add(this.login);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button signin;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button Offline;
        private System.Windows.Forms.Button exit;
    }
}