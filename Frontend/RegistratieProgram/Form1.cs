﻿using System;
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
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            voornaam_label.Location = new Point(Form, 140);
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
            }
        }
    }
}
