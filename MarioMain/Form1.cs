using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MarioMain
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            load.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process LevelEditor = Process.Start("MarioLevelEditor");
            this.Hide();
            while (true)
            {
                if (LevelEditor.HasExited)
                {
                    this.Show();
                    break;
                }
            }
        }

        private void gameLauncher_Click(object sender, EventArgs e)
        {
            Process Game = Process.Start("MarioObjects");
            this.Hide();
            while (true)
            {
                if (Game.HasExited)
                {
                    this.Show();
                    break;
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            this.Hide();
            Saver Saver = new Saver();
            Saver.Show();
        }

        private void load_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loader Loader = new Loader();
            Loader.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
