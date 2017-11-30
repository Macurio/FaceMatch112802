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
        const string APP_ID = "10447843";
        const string API_KEY = "bHnKHuGkpQEaSU5k68F5MGen";
        const string SECRET_KEY = "EojiKc7KgHF6FySfgp9lZYPynjAonRp6 ";
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
        public static string log_id, FaceIdentify_scores,user_ifo,group_list,group_users,face_verify;
        //人脸检测
        public static void FaceDetect()
        {
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            //var image = File.ReadAllBytes("C:/Users/Administrator/Pictures/yangmi1.png");
            var image = File.ReadAllBytes(Form1.filename1);
            var options = new Dictionary<string, object>(){
                //为什么face_fields参数采取这种形式实例化呢？beauty age应该是face_fields的实例化的值
                {"face_fields","beauty,age"}
            };
            //第一级和第二季json数据需要以[0]分隔开才行//client.FaceMatch(images)已经是一个Newtonsoft.Json.Linq.JObject
            age = double.Parse(client.FaceDetect(image, options)["result"][0]["age"].ToString());
            beauty = double.Parse(client.FaceDetect(image, options)["result"][0]["beauty"].ToString());
        }
        //人脸注册
        public static void FaceRegister()
        {
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var image1 = File.ReadAllBytes(Form1.filename1);
            var result = client.User.Register(image1, "wangluodan", "wangluodan actress", new[] { "StarFace" })["log_id"];
            log_id = result.ToString();
        }
        //人脸识别
        public static void FaceIdentify()
        {
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var image1 = File.ReadAllBytes(Form1.filename1);
            //,1,1什么作用？
            var result = client.User.Identify(image1, new[] { "StarFace" }, 1, 1)["result"][0]["scores"][0];
            FaceIdentify_scores = result.ToString();
        }
        ////人脸更新
        //public static void FaceUpdate()
        //{
        //    var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
        //    var image1 = File.ReadAllBytes(Form1.filename1);

        //    var result = client.User.Update(image1, "wangluodan", "StarFace", "wangluodan actress");
        //}
        ////人脸删除 如果没有指定group_id则会删除该用户的所有图像和身份信息
        //public static void FaceDelete()
        //{
        //    var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
        //    var result = client.User.Delete("uid");
        //    result = client.User.Delete("uid", new[] { "group1" });
        //}
        //用户信息查询
        public static void UserInfo()
        {
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var result = client.User.GetInfo("wangluodan")["result"];
            user_ifo = result.ToString();
        }
        //组列表查询
        public static void GroupList()
        {
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var result = client.Group.GetAllGroups(0, 100);
            group_list = result.ToString();
        }
        //组内用户列表查询
        public static void GroupUsers()
        {
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var result = client.Group.GetUsers("StarFace", 0, 100);
            group_users = result.ToString();
        }
        //人脸认证
        public static void FaceVerify()
        {
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var image1 = File.ReadAllBytes(Form1.filename1);

            var result = client.User.Verify(image1, Form3.face_verify_uid, new[] { "StarFace" }, 1)["result"][0];
            face_verify = result.ToString();
        }
    }
}
//有待添加的功能:
//更新 删除
//基本的体验优化 将每次的结果输入到txt文件或数据库中在本地保存