namespace MarioObjects
{
    partial class frmMain
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
            this.timerPaint = new System.Windows.Forms.Timer(this.components);
            this.timerBack = new System.Windows.Forms.Timer(this.components);
            this.pMain = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pMain)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPaint
            // 
            this.timerPaint.Enabled = true;
            this.timerPaint.Interval = 30;
            this.timerPaint.Tick += new System.EventHandler(this.timerPaint_Tick);
            // 
            // timerBack
            // 
            this.timerBack.Interval = 500;
            this.timerBack.Tick += new System.EventHandler(this.timerBack_Tick);
            // 
            // pMain
            // 
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1083, 400);
            this.pMain.TabIndex = 0;
            this.pMain.TabStop = false;
            this.pMain.Click += new System.EventHandler(this.pMain_Click);
            this.pMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pMain_Paint);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 400);
            this.Controls.Add(this.pMain);
            this.DoubleBuffered = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mario By Jazzy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerBack;
        private System.Windows.Forms.Timer timerPaint;
        private System.Windows.Forms.PictureBox pMain;
    }
}

