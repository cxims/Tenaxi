namespace MarioMain
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.levelEditor = new System.Windows.Forms.Button();
            this.gameLauncher = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.load = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // levelEditor
            // 
            this.levelEditor.BackColor = System.Drawing.Color.Beige;
            this.levelEditor.Location = new System.Drawing.Point(220, 138);
            this.levelEditor.Name = "levelEditor";
            this.levelEditor.Size = new System.Drawing.Size(330, 40);
            this.levelEditor.TabIndex = 0;
            this.levelEditor.Text = "Level Editor";
            this.levelEditor.UseVisualStyleBackColor = false;
            this.levelEditor.Click += new System.EventHandler(this.button1_Click);
            // 
            // gameLauncher
            // 
            this.gameLauncher.BackColor = System.Drawing.Color.Beige;
            this.gameLauncher.Location = new System.Drawing.Point(220, 184);
            this.gameLauncher.Name = "gameLauncher";
            this.gameLauncher.Size = new System.Drawing.Size(330, 40);
            this.gameLauncher.TabIndex = 1;
            this.gameLauncher.Text = "Game";
            this.gameLauncher.UseVisualStyleBackColor = false;
            this.gameLauncher.Click += new System.EventHandler(this.gameLauncher_Click);
            // 
            // load
            // 
            this.load.BackColor = System.Drawing.Color.Beige;
            this.load.Location = new System.Drawing.Point(220, 276);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(330, 40);
            this.load.TabIndex = 2;
            this.load.Text = "Load Level";
            this.load.UseVisualStyleBackColor = false;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.Beige;
            this.save.Location = new System.Drawing.Point(220, 230);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(330, 40);
            this.save.TabIndex = 3;
            this.save.Text = "Save level";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MarioMain.Properties.Resources.bgblock;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.save);
            this.Controls.Add(this.load);
            this.Controls.Add(this.gameLauncher);
            this.Controls.Add(this.levelEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button levelEditor;
        private System.Windows.Forms.Button gameLauncher;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button save;
    }
}

