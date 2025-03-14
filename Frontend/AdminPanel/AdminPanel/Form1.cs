﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;  

namespace AdminPanel
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
            client.BaseAddress = new Uri("http://localhost:8081/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.CheckedChanged += checkBox1_CheckedChanged;
                }
            }

            comboBox_Lokalen.Items.Add("112");
            comboBox_Lokalen.Items.Add("115");
            comboBox_Lokalen.Items.Add("204");
            comboBox_Player.Items.Add("Jon");
            comboBox_Player.Items.Add("denis");
            comboBox_Player.Items.Add("Talha");
            


        }

        private void comboBox_Lokalen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Question_txtbox.Hide();
            Question_txtbox.Text = "";
            Antwd1_txtbox.Hide();
            Antwd1_txtbox.Text = "";
            Antwd2_txtbox.Hide();
            Antwd2_txtbox.Text = "";
            Antwd3_txtbox.Hide();
            Antwd3_txtbox.Text = "";
            Antwd4_txtbox.Hide();
            Antwd4_txtbox.Text = "";



            if (comboBox_Lokalen.SelectedItem != null && comboBox_Lokalen.SelectedItem.ToString() == "112")
              {
                Question_txtbox.Show();
                Question_txtbox.Text = "vraag?";
                Antwd1_txtbox.Show();
                Antwd1_txtbox.Text = "eerste antwd";
                Antwd2_txtbox.Show();
                Antwd2_txtbox.Text = "tweede antwd";
                Antwd3_txtbox.Show();
                Antwd3_txtbox.Text = "derde antwd";
                Antwd4_txtbox.Show();
                Antwd4_txtbox.Text = "vierde antwd";
              }
              else if(comboBox_Lokalen.SelectedItem != null && comboBox_Lokalen.SelectedItem.ToString() == "115")
              {
                Question_txtbox.Show();
                Question_txtbox.Text = "vraag2?";
                Antwd1_txtbox.Show();
                Antwd1_txtbox.Text = "eerste antwd2";
                Antwd2_txtbox.Show();
                Antwd2_txtbox.Text = "tweede antwd2";
                Antwd3_txtbox.Show();
                Antwd3_txtbox.Text = "derde antwd2";
                Antwd4_txtbox.Show();
                Antwd4_txtbox.Text = "vierde antwd2";
              }
              else if (comboBox_Lokalen.SelectedItem != null && comboBox_Lokalen.SelectedItem.ToString() == "204")
              {
                Question_txtbox.Show();
                Question_txtbox.Text = "vraag3?";
                Antwd1_txtbox.Show();
                Antwd1_txtbox.Text = "eerste antwd3";
                Antwd2_txtbox.Show();
                Antwd2_txtbox.Text = "";
                Antwd3_txtbox.Show();
                Antwd3_txtbox.Text = "derde antwd2";
                Antwd4_txtbox.Show();
                Antwd4_txtbox.Text = "";
              }



        }
        private void ConfirmbtnCR_Click(object sender, EventArgs e)
        {
           
        }




        private void Question_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Player_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                
            UUC_txtbox.Text = "";
            UUC_txtbox.Hide();
            Number_txtbox.Text = "";
            Number_txtbox.Hide();
            Name_txtbox.Text = "";
            Name_txtbox.Hide();
            Email_txtbox.Text = "";
            Email_txtbox.Hide();
            Age_txtbox.Text = "";
            Age_txtbox.Hide();
            






            if (comboBox_Player.SelectedItem != null && comboBox_Player.SelectedItem.ToString() == "denis")
            {
                UUC_txtbox.Show();
                UUC_txtbox.Text = "69";
                Number_txtbox.Show();
                Number_txtbox.Text = "0468045463";
                Age_txtbox.Show();
                Age_txtbox.Text = "18";
                Email_txtbox.Show();
                Email_txtbox.Text = "";
                Name_txtbox.Show();
                Name_txtbox.Text = "";
             
            }
            else if (comboBox_Player.SelectedItem != null && comboBox_Player.SelectedItem.ToString() == "Jon")
            {
                UUC_txtbox.Show();
                UUC_txtbox.Text = "21";
                Number_txtbox.Show();
                Number_txtbox.Text = "0493996761";
                Age_txtbox.Show();
                Age_txtbox.Text = "17";
                Email_txtbox.Show();
                Email_txtbox.Text = "";
                Name_txtbox.Show();
                Name_txtbox.Text = "";
               


            }
            else if (comboBox_Player.SelectedItem != null && comboBox_Player.SelectedItem.ToString() == "Talha")
            {
                UUC_txtbox.Show();
                UUC_txtbox.Text = "50";
                Number_txtbox.Show();
                Number_txtbox.Text = "0487999926";
                Age_txtbox.Show();
                Age_txtbox.Text = "19";
                Email_txtbox.Show();
                Email_txtbox.Text = "Talha.muhammad@leerling.kov.be";
                Name_txtbox.Show();
                Name_txtbox.Text = "Talha";
                
               

            }

        }


        static async Task<string> AddUser(string nameN,int ageN, bool consentN, int gsm_numberN, string emailN)
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
        


        private async void ConfirmbtnPLR_Click(object sender, EventArgs e)
        {
            var response = await AddUser(Name_txtbox.Text, Convert.ToInt32(Age_txtbox.Text), ConsenctCheckBx.Checked, Convert.ToInt32(Number_txtbox.Text), Email_txtbox.Text);

            MessageBox.Show(response);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (sender is CheckBox selectedCheckBox && selectedCheckBox.Checked)
            {
                // Loop door alle checkboxes
                foreach (Control control in this.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        // Zoek de gekoppelde TextBox (zelfde nummer als checkbox)
                        string textBoxName = "textBox" + checkBox.Name[1]; // Haalt laatste teken van de naam
                        TextBox linkedTextBox = this.Controls.Find(textBoxName, true).FirstOrDefault() as TextBox;

                        // Zet de geselecteerde TextBox op "True" en de rest op "False"
                        if (linkedTextBox != null)
                        {
                            linkedTextBox.Text = (checkBox == selectedCheckBox) ? "True" : "False";
                        }

                        // Zorg dat alleen de aangeklikte checkbox geselecteerd blijft
                        checkBox.Checked = (checkBox == selectedCheckBox);
                    }
                }
            }

        }

        private void Antwd1_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Antwd2_txtbox_TextChanged(object sender, EventArgs e)
        {


        }

        private void Antwd3_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Antwd4_txtbox_TextChanged(object sender, EventArgs e)
        {
          
        }
    }



  

   
}   








public class User
    {
            public int code { get; set; }
            public string name { get; set; }
            public int age { get; set; }
            public bool consent { get; set; }
            public string email { get; set; }
            public int gsm_number { get; set; }

    }


public class Question
{
    public int id { get; set; }
    public string text { get; set; }

    public int location_id { get; set; }

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






