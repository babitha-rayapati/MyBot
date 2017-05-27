using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    public partial class add_commands : Form
    {
        public add_commands()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sr = new StreamWriter(@"commands.txt", true);
            sr.WriteLine(textBox1.Text);
            sr.Close();
            textBox1.Clear();
        }
    }
}
