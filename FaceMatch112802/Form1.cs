using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace FaceMatch112802
{
    public partial class Form1 : Form
    {
        public static string filename1;
        public static string filename2;
        
        public static void read_filename1()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename1 = openFileDialog1.FileName;
                //MessageBox.Show(filename1);
            }
           
        }
        public static void read_filename2()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename2 = openFileDialog1.FileName;
                //MessageBox.Show(filename1);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            read_filename1();
            Program.FaceDetect();
            textBox1.Text = "age:"+Program.age.ToString() + "\nbeauty:"+Program.beauty.ToString()+"\n(beauty满分100，分数越高越美)";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            read_filename1();
            Program.FaceRegister();
            textBox1.Text = "log_id:" + Program.log_id;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            read_filename1();
            Program.FaceIdentify();
            textBox1.Text = "FaceIdentify_scores=" + Program.FaceIdentify_scores;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Program.FaceDelete();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Program.UserInfo();
            textBox1.Text = Program.user_ifo;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Program.GroupList();
            textBox1.Text = Program.group_list;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Program.GroupUsers();
            textBox1.Text = Program.group_users;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            read_filename1();
            new Form3().ShowDialog();
            Program.FaceVerify();
            textBox1.Text = Program.face_verify;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
