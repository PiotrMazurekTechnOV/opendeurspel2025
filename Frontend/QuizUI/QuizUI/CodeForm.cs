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
    public partial class CodeForm : Form
    {
        public CodeForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void CodeForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
           if(string.IsNullOrEmpty(LoginTxtBox.Text))
            {
                MessageBox.Show("error, vul in of foute code.");

                return;
            }

           Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void LoginTxtBox_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
