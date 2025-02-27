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
using System.Drawing.Printing;
using System.Runtime.InteropServices;


namespace QuizUI
{
    public partial class Form1 : Form
    {
        static HttpClient client;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        static async Task<string> AddUser(string nameN, int ageN, bool consentN, int gsm_numberN, string emailN)
        {
            User user = new User
            {
                name = nameN,
                age = ageN,
                consent = consentN,
                gsm_number = gsm_numberN,
                email = emailN
            };

            StringContent json = new StringContent(JsonConvert.SerializeObject(user, Formatting.Indented), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/user/create", json);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
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

        private async void button3_Click(object sender, EventArgs e)
        {
            var response = await AddUser("test2", 21, true, 1233676454, "test666@test.test");

            MessageBox.Show(response);
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var response = await AddUser("test", 20, true, 12323454, "test@test.test");

            MessageBox.Show(response);
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

        private void QuizTxt_Click(object sender, EventArgs e)
        {

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            
        }



        

        public class Answer
        {
            public int id { get; set; }
            public string text { get; set; }

            public int question_id { get; set; }
            public bool correct { get; set; }
        }

        public class Location
        {
            public int id { get; set; }
            public string name { get; set; }

            public string room { get; set; }
        }

        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public int age { get; set; }
            public string email { get; set; }
            public int gsm_number { get; set; }
            public int code { get; set; }
            public bool consent { get; set; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
