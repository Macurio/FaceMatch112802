using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceMatch112802
{
    public partial class Form5 : Form
    {
        public static string str1, str2;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            str1 = textBox1.Text;
            str2 = textBox2.Text;
            this.Close();
        }
    }
}
