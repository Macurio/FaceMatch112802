﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WpfApplication1;

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            read_filename1();
            new Form4().ShowDialog();
            Program.FaceRegister();
            textBox1.Text = "log_id:" + Program.log_id;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            read_filename1();
            new Form3().ShowDialog();
            Program.FaceIdentify();
            textBox1.Text = "FaceIdentify_scores=" + Program.FaceIdentify_scores;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Program.FaceDelete();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
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
            new Form3().ShowDialog();
            Program.GroupUsers();
            textBox1.Text = Program.group_users;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            read_filename1();
            new Form5().ShowDialog();
            Program.FaceVerify();
            textBox1.Text = Program.face_verify;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form5().ShowDialog();
            Program.FaceDelete();
            textBox1.Text = Program.face_delete;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            read_filename1();
            new Form4().ShowDialog();
            Program.FaceUpdate();
            
            textBox1.Text = Program.face_update;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new Form_camera().ShowDialog();
            if (!Form_camera.is_camera)
            {
                read_filename1();
            }
            else
            {
                new MainWindow().ShowDialog();
                filename1 = "b.png";
            }
            new Form_camera().ShowDialog();
            if (!Form_camera.is_camera)
            {
                read_filename2();
            }
            else
            {
                new MainWindow().ShowDialog();
                filename2 = "b.png";
            }
            //read_filename1();
            //read_filename2();
            Program.FaceMatch();
            textBox1.Text = Program.face_match;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            WpfApplication1.MainWindow wpfwindow = new WpfApplication1.MainWindow();
            wpfwindow.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            new Form_camera().ShowDialog();
            if (!Form_camera.is_camera)
            {
                read_filename1();
                Program.FaceDetect();
            }
            else
            {
                new MainWindow().ShowDialog();
                filename1 = "C:/Users/Administrator/b.png";
            }
            Program.FaceDetect();
            textBox1.Text = Program.text;
            MessageBox.Show(filename1);
        }
    }
}
