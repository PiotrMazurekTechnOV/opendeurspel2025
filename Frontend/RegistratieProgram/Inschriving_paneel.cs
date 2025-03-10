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

namespace RegistratieProgram
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form_Load(object sender, EventArgs e)
        {
<<<<<<< Updated upstream:Frontend/RegistratieProgram/Form1.cs
            voornaam_label.Location = new Point(Form, 140);
=======

            voornaam_label.Location = new Point(630, 135);
            achternaam_label.Location = new Point(630, 220);
            leeftijd_label.Location = new Point(630, 305);
            email_label.Location = new Point(630, 390);
            gsm_label.Location = new Point(630, 475);
            gsm_pakker_als_er_mooie_mamas_zijn.Location = new Point(630, 560);

            voornaam_textbox.Location = new Point(850, 135);
            achternaam_textbox.Location = new Point(850, 220);
            leeftijd_textbox.Location = new Point(850, 305);
            email_textbox.Location = new Point(850, 390);
            gsm_textbox.Location = new Point(850, 475);
            registratie_btn.Location = new Point(1000, 655);
>>>>>>> Stashed changes:Frontend/RegistratieProgram/Inschriving_paneel.cs
        }

        private void registratie_btn_Click(object sender, EventArgs e)
        {
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
                Verwelkom_paneel Check = new Verwelkom_paneel();
                Check.Show();
                Hide();
            }
        }
    }
}
