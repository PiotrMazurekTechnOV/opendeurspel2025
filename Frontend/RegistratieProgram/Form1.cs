using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace RegistratieProgram
{
    public partial class Form : System.Windows.Forms.Form
    {
        static HttpClient client;

        public Form()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void Form_Load(object sender, EventArgs e)
        {
            voornaam_label.Location = new Point(630, 140);
        }

        private async void registratie_btn_Click(object sender, EventArgs e)
        {
            var response = await AddUser("test", "test2", 20, true, "testtest", "test@test.com");

            MessageBox.Show(response);


            if (string.IsNullOrEmpty(voornaam_textbox.Text) || string.IsNullOrEmpty(achternaam_textbox.Text) || string.IsNullOrEmpty(leeftijd_textbox.Text))
            {

                MessageBox.Show("Vul alle velden in");
            }
            else if (voornaam_textbox.Text.Any(ch => !char.IsLetterOrDigit(ch)) || achternaam_textbox.Text.Any(ch => !char.IsLetterOrDigit(ch))|| leeftijd_textbox.Text.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Niet hacken aub", "danku");
            }
            else if(leeftijd_textbox.Text.Any(ch => char.IsLetter(ch)))
            {
                MessageBox.Show("Niet volluit schrijven, dit programma begrijpt getallen wel", "Leeftijd");
            }
            else
            {
                MessageBox.Show("lesgoo", "you didit!!!");



            }

        
        
        
        }

        static async Task<string> AddUser(string firstNameN, string lastNameN, int ageN, bool consentN, string interestN, string emailN)
        {
            User user = new User
            {
                firstName = firstNameN,
                lastName = lastNameN,
                age = ageN,
                consent = consentN,
                interest = interestN,
                email = emailN
            };

            StringContent json = new StringContent(JsonConvert.SerializeObject(user, Formatting.Indented), Encoding.UTF8,
        "application/json");

            var response = await client.PostAsync("user/add",json);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }


        public class User
        {
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public int age { get; set; }
            public bool consent { get; set; }
            public string email { get; set; }
            public string interest { get; set; }

        }


    }



}
