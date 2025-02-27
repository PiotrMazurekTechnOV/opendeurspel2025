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
using static QuizUI.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuizUI
{
    public partial class lokaalchooser : Form
    {
        static HttpClient client;
        
        public lokaalchooser()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        

        static async Task<string> ReadQuestions(int locationIDN)
        {
            Question Questions = new Question
            {
                location_id = locationIDN
            };

            StringContent json = new StringContent(JsonConvert.SerializeObject(Questions, Formatting.Indented), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/question/read/:id", json);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }
        private async void EnterBtn_Click(object sender, EventArgs e)
        {
            int TextVal;
            TextVal = int.Parse(textBox1.Text);

            var response = await ReadQuestions(TextVal);

            MessageBox.Show(response);

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vul een klas is");
                return;
            }

            CodeForm codeform = new CodeForm();
            codeform.Show();
            this.Hide();

        }

        public class Question
        {
            public int id { get; }
            public string text { get; }
            public int location_id { get; set; }
        }
    }
}
