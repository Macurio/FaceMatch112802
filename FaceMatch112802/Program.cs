using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Baidu.Aip.Face;

namespace FaceMatch112802
{
    static class Program
    {
        

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); 
        }
        public static double age,beauty;
        public static void FaceDetect()
        {
            var APP_ID = "10447843";
            var API_KEY = "bHnKHuGkpQEaSU5k68F5MGen";
            var SECRET_KEY = "EojiKc7KgHF6FySfgp9lZYPynjAonRp6 ";
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var image = File.ReadAllBytes("C:/Users/Administrator/Pictures/yangmi (3).jpg");
            var options = new Dictionary<string, object>()
    {
        {"face_fields", "beauty,age"}
    };
            age = double.Parse(client.FaceDetect(image, options)["result"][0]["age"].ToString());
            beauty = double.Parse(client.FaceDetect(image, options)["result"][0]["beauty"].ToString());

        }
    }
}
//有待添加的功能
//上人脸库 人脸查找功能 
//基本的体验优化 将每次的结果输入到txt文件或数据库中在本地保存 在窗体中打开图片