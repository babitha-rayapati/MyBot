using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Bot
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Set the size of the PictureBox control.
            this.pictureBox1.Size = new System.Drawing.Size(1400, 450);
            //Set the SizeMode to center the image.
            this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            // Set the border style to a three-dimensional border.
            this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            textBox1.Location = new Point(700, 480);
            label1.Location = new Point(600, 480);
            textBox2.Location = new Point(700, 530);
            label2.Location = new Point(600, 530);
            button1.Location = new Point(650, 580);
            WindowState = FormWindowState.Maximized;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string un, pwd;
            un = textBox1.Text;
            pwd = textBox2.Text;
            if(un.Equals("babitha")&&pwd.Equals("babitha"))
            {
                this.Hide();
                first f1 = new first();
                f1.ShowDialog();
                this.Close();
                f1.Show();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("login incorrect. try again");
            }*/

            String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\\projects\\Bot\\login.accdb";
            OleDbConnection conn = new OleDbConnection(cs);
            conn.Open();
            string un, pwd;
            un = textBox1.Text;
            pwd = textBox2.Text;
            string sql = "select * from users";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader r = cmd.ExecuteReader();
            string un1, pwd1;
            while (r.Read())
            {
                un1 =  r.GetValue(0).ToString() + "\t";
                pwd1= r.GetString(1).ToString() + "\t";
                //MessageBox.Show(un1 + ""+pwd1);
                un1 = un1.Trim();
                pwd1 = pwd1.Trim();
                if(un.Equals(un1)&&pwd.Equals(pwd1))
                {
                    this.Hide();
                    first f1 = new first();
                    f1.ShowDialog();
                    this.Close();
                    f1.Show();
                    break;
                }
            }
        }
    }
}
