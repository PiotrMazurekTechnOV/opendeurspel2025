using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace QuizUI
{
    public partial class Form1 : Form
    {

        static HttpClient client;
        public Form1()
        {

            

            InitializeComponent();

            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            
            
            
            
            MessageBox.Show("Button 1 werkt.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 2 werkt.");
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 3 werkt.");
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 4 werkt.");
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {

        }

        private async void apitestBtn_Click(object sender, EventArgs e)
        {
            var response = await AddUser("testname", 21, 99, "testmail@mail.com", "1", 0432817232);

            MessageBox.Show(response);


        }

        static async Task<string> AddUser(string NameN, int ageN, int codeN, string emailN, string consentN, int gsm_numberN)
        {
            User user = new User
            {
                name = NameN,
                age = ageN,
                code = codeN,
                consent = consentN,
                email = emailN,
                gsm_number = gsm_numberN
            };

            StringContent json = new StringContent(JsonConvert.SerializeObject(user, Formatting.Indented), Encoding.UTF8,
        "application/json");

            var response = await client.PostAsync(
                "user/create",
                json);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }


        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public int age { get; set; }
            public string email { get; set; }
            public int gsm_number { get; set; }
            public int code { get; set; }
            public string consent { get; set; }

        }

    }
}
