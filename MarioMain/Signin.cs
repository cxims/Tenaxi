using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarioMain.Models;
using MarioMain.Utils;
using System.Net.Http;
using System.Net.Http.Headers;
using Flurl.Http;
using System.Text.RegularExpressions;

namespace MarioMain
{
    public partial class Signin : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private const string URL = "http://localhost:8080/User";

        public Signin()
        {
            InitializeComponent();
            password.PasswordChar = '*';
            password2.PasswordChar = '*';
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void log_Click(object sender, EventArgs e)
        {
            if (firstname.Text != null && lastname.Text != null && username.Text != null && email.Text != null && password.Text != null && password2.Text != null)
            {
                Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase); ///Object initialization for Regex 
                if (!reg.IsMatch(email.Text))
                {
                    MessageBox.Show("Email invalide");
                }
                else if (password.Text != "" && password.Text == password2.Text)
                {
                    User newUser = new User(firstname.Text, lastname.Text, username.Text, email.Text, password.Text);

                    var response = await client.PostAsJsonAsync(URL, newUser);

                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        this.Hide();
                        LoginForm LoginForm = new LoginForm();
                        LoginForm.Show();
                    }
                    else
                    {
                        MessageBox.Show(await response.Content.ReadAsStringAsync());
                    }
                }
                else
                {
                    MessageBox.Show("Mot de passe différent");
                }
            }
            else
            {
                MessageBox.Show("Merci de remplir tous les champs");
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm LoginForm = new LoginForm();
            LoginForm.Show();
        }

        private void Signin_Load(object sender, EventArgs e)
        {

        }
    }
}
