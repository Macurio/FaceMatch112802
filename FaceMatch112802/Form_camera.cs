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
    public partial class Form_camera : Form
    {
        public static bool is_camera=false;
        public Form_camera()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            is_camera = false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            is_camera = true;
            this.Close();
        }
    }
}
