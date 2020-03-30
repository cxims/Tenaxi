namespace MarioMain
{
    partial class Signin
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.TextBox();
            this.password2 = new System.Windows.Forms.TextBox();
            this.log = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lastname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.firstname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(181, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(181, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Username";
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.Beige;
            this.back.Location = new System.Drawing.Point(242, 295);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(330, 40);
            this.back.TabIndex = 8;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(242, 93);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(330, 20);
            this.username.TabIndex = 1;
            // 
            // password2
            // 
            this.password2.Location = new System.Drawing.Point(242, 223);
            this.password2.Name = "password2";
            this.password2.Size = new System.Drawing.Size(330, 20);
            this.password2.TabIndex = 6;
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.Color.Beige;
            this.log.Location = new System.Drawing.Point(242, 249);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(330, 40);
            this.log.TabIndex = 7;
            this.log.Text = "Sign up";
            this.log.UseVisualStyleBackColor = false;
            this.log.Click += new System.EventHandler(this.log_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(181, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Password";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(242, 197);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(330, 20);
            this.password.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(181, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "LastName";
            // 
            // lastname
            // 
            this.lastname.Location = new System.Drawing.Point(242, 171);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(330, 20);
            this.lastname.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(181, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "FirstName";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // firstname
            // 
            this.firstname.Location = new System.Drawing.Point(242, 145);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(330, 20);
            this.firstname.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(181, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Email";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(242, 119);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(330, 20);
            this.email.TabIndex = 2;
            // 
            // Signin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MarioMain.Properties.Resources.bgblock;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.firstname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.username);
            this.Controls.Add(this.password2);
            this.Controls.Add(this.log);
            this.Name = "Signin";
            this.Text = "Signin";
            this.Load += new System.EventHandler(this.Signin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password2;
        private System.Windows.Forms.Button log;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lastname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox firstname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox email;
    }
}