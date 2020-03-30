using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarioMain.Models;


namespace MarioMain
{
    public partial class Login : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private const string URL = "http://localhost:8080/User/login";

        public Login()
        {
            InitializeComponent();
            password.PasswordChar = '*';
        }

        private async void log_Click(object sender, EventArgs e)
        {

            User newUser = new User(username.Text, password.Text);

            var response = await client.PostAsJsonAsync(URL, newUser);

            if (response.IsSuccessStatusCode)
            {
                this.Hide();
                Form1 Form1 = new Form1();
                Form1.Show();
            }
            else
            {
                MessageBox.Show(await response.Content.ReadAsStringAsync());
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm LoginForm = new LoginForm();
            LoginForm.Show();
        }
    }
}
