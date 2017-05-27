using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           /* this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            var size = this.Size;
            var screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;*/
            WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            signUp sp = new signUp();
            sp.ShowDialog();
            this.Close();
        }
    }
}
