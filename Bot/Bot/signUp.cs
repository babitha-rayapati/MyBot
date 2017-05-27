using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Bot
{
    public partial class signUp : Form
    {
        public signUp()
        {
            InitializeComponent();
        }

        private void signUp_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.pictureBox1.Size = new System.Drawing.Size(1400, 450);
            //Set the SizeMode to center the image.
            this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            // Set the border style to a three-dimensional border.
            this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            textBox1.Location = new Point(700, 480);
            label1.Location = new Point(600, 480);
            textBox2.Location = new Point(700, 530);
            label2.Location = new Point(600, 530);
            textBox3.Location = new Point(700, 580);
            label3.Location = new Point(600, 580);
            button1.Location = new Point(650, 630);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String pwd1, pwd2, un;
            un = textBox1.Text.Trim();
            pwd1 = textBox2.Text.Trim();
            pwd2 = textBox3.Text.Trim();
            if(pwd1.Equals(pwd2))
            {
                String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\\projects\\Bot\\login.accdb";
                OleDbConnection conn = new OleDbConnection(cs);
                conn.Open();
                string sql = "INSERT INTO users values('" + un + "','" + pwd1 + "')";
                OleDbCommand cmd1 = new OleDbCommand(sql, conn);
                int i = cmd1.ExecuteNonQuery();
                MessageBox.Show("registered successfully! You may now log in");

                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("retype passwords.");
               
                textBox2.Clear();
                
                textBox3.Clear();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
