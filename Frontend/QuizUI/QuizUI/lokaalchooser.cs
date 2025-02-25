using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizUI
{
    public partial class lokaalchooser : Form
    {
        public lokaalchooser()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vul een klas is");
                return;
            }

            CodeForm codeform = new CodeForm();
            codeform.Show();
            this.Hide();



        }
    }
}
