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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.FaceDetect();
            textBox1.Text = "age:"+Program.age.ToString() + "\nbeauty:"+Program.beauty.ToString()+"\n(beauty满分100，分数越高越美)";
        }
    }
}
