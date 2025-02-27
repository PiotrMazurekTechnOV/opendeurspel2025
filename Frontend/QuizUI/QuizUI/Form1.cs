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
        private Question currentQuestion;
        private List<Answer> currentAnswers = new List<Answer>();
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadNewQuestion();
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



        }


        private async Task LoadNewQuestion()
        {
            try
            {
                List<Question> questions = await GetQuestions();
                if (questions.Count == 0)
                {
                    MessageBox.Show("Geen vragen beschikbaar.");
                    return;
                }

                Random rnd = new Random();
                currentQuestion = questions[rnd.Next(questions.Count)];

                QuizTxt.Text = currentQuestion.text;
                await LoadAnswers(currentQuestion.id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij laden van de vraag: " + ex.Message);
            }
        }


        private async Task LoadAnswers(int questionId)
        {
            try
            {
                currentAnswers = await GetAnswersForQuestion(questionId);
                if (currentAnswers.Count < 4)
                {
                    MessageBox.Show("Niet genoeg antwoorden beschikbaar.");
                    return;
                }


                button1.Text = currentAnswers[0].text;
                button2.Text = currentAnswers[1].text;
                button3.Text = currentAnswers[2].text;
                button3.Text = currentAnswers[3].text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij laden van antwoorden: " + ex.Message);
            }
        }





        private static async Task<List<Question>> GetQuestions()
        {
            HttpResponseMessage response = await client.GetAsync("questions");
            response.EnsureSuccessStatusCode();
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Question>>(jsonResponse) ?? new List<Question>();
        }

        private static async Task<List<Answer>> GetAnswersForQuestion(int questionId)
        {
            HttpResponseMessage response = await client.GetAsync($"answers/{questionId}");
            response.EnsureSuccessStatusCode();
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Answer>>(jsonResponse) ?? new List<Answer>();
        }



        public class Question
        {
            public int id { get; set; }
            public string text { get; set; }
        }

        public class Answer
        {
            public int id { get; set; }
            public string text { get; set; }
            public int question_id { get; set; }
            public bool correct { get; set; }
        }
    }
}
    

