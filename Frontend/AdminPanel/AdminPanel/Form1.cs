using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_Lokalen.Items.Add("112");
            comboBox_Lokalen.Items.Add("115");
            comboBox_Lokalen.Items.Add("204");
            comboBox_Player.Items.Add("Jon");
            comboBox_Player.Items.Add("denis");
            comboBox_Player.Items.Add("Talha");
            

        }

        private void comboBox_Lokalen_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            
                if (comboBox_Lokalen.SelectedItem != null && comboBox_Lokalen.SelectedItem.ToString() == "112")
                {
                    Question_txtbox.Show();
                    Question_txtbox.Text = "vraag?";
                }
            


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
            }
            else if (comboBox_Player.SelectedItem != null && comboBox_Player.SelectedItem.ToString() == "Jon")
            {
                UUC_txtbox.Show();
                UUC_txtbox.Text = "21";
                Number_txtbox.Show();
                Number_txtbox.Text = "0493996761";
                Age_txtbox.Show();
                Age_txtbox.Text = "17";
            }
            else if (comboBox_Player.SelectedItem != null && comboBox_Player.SelectedItem.ToString() == "Talha")
            {
                UUC_txtbox.Show();
                UUC_txtbox.Text = "50";
                Number_txtbox.Show();
                Number_txtbox.Text = "";
                Age_txtbox.Show();
                Age_txtbox.Text = "19";
            }



        }
    }
}
