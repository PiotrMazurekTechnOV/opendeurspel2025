using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            
        }

        private void registratie_btn_Click(object sender, EventArgs e)
        {
            if(Convert.ToString(voornaam_textbox) != null)
            {
                MessageBox.Show("lesgoo");
            }
            else
            {
                MessageBox.Show("noooo");
            }
        }
    }
}
