using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarioMain.Models;
using System.Xml;
using MarioMain.models;
using MarioMain.Utils;

namespace MarioMain
{
    public partial class Saver : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private const string URL = "http://localhost:8080/Stage";

        public Saver()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();
        }

        private async void save_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("lev1.xml");

            Stage newStage = new Stage(title.Text, doc.OuterXml, Globals.IdUser);

            var response = await client.PostAsJsonAsync(URL, newStage);

            if (response.IsSuccessStatusCode)
            {
                //this.Hide();
                //Form1 Form1 = new Form1();
                //Form1.Show();
            }
            else
            {
                MessageBox.Show(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
