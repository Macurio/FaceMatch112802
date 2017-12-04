using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WPFMediaKit.DirectShow.Controls;

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
        public static string text;
        //public static double age,beauty;
        public static string log_id, FaceIdentify_scores, user_ifo, group_list, group_users, face_verify, face_delete, face_update, face_match;
        public static string face_verify_uid, face_register_uid, face_register_uifo, face_register_gid, face_delete_uid, face_delete_gid,
            group_users_gid, user_ifo_uid, face_identify_gid, face_verify_gid,face_update_uid,face_update_gid,face_update_uifo;
        //人脸检测
        public static void FaceMatch()
        {
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var image1 = File.ReadAllBytes(Form1.filename1);
            var image2 = File.ReadAllBytes(Form1.filename2);
            var images = new byte[][] { image1, image2 };
            var result = client.FaceMatch(images);
            face_match = result.ToString();
        }
        public static void FaceDetect()
        {
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var image = File.ReadAllBytes(Form1.filename1);
            var options = new Dictionary<string, object>(){
                {"face_fields","beauty,age"}
            };
            var result = client.FaceDetect(image, options)["result"];
            text = result.ToString();
            MessageBox.Show(text);
        }
        //人脸注册
        public static void FaceRegister()
        {
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var image1 = File.ReadAllBytes(Form1.filename1);
            face_register_uid = Form4.str1;
            face_register_uifo = Form4.str2;
            face_register_gid = Form4.str3;
            var result = client.User.Register(image1, face_register_uid, face_register_uifo, new[] { face_register_gid })["log_id"];
            log_id = result.ToString();
        }
        //人脸识别
        public static void FaceIdentify()
        {
            face_identify_gid = Form3.str;
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var image1 = File.ReadAllBytes(Form1.filename1);
            //,1,1什么作用？
            var result = client.User.Identify(image1, new[] { face_identify_gid }, 1, 1);
            FaceIdentify_scores = result.ToString();
        }
        //人脸更新
        public static void FaceUpdate()
        {
            face_update_uid = Form4.str1;
            face_update_gid = Form4.str3;
            face_update_uifo = Form4.str2;
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var image1 = File.ReadAllBytes(Form1.filename1);
            var result = client.User.Update(image1, face_update_uid, face_update_gid, face_update_uifo);
            face_update = result.ToString();
        }
        //人脸删除 如果没有指定group_id则会删除该用户的所有图像和身份信息
        public static void FaceDelete()
        {
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            face_delete_uid = Form5.str1;
            face_delete_gid = Form5.str2;
            var result = client.User.Delete(face_delete_uid);

            result = client.User.Delete(face_delete_uid, new[] { face_delete_gid });
            face_delete = result.ToString();
        }
        //用户信息查询
        public static void UserInfo()
        {
            user_ifo_uid = Form3.str;
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var result = client.User.GetInfo(user_ifo_uid);
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
            group_users_gid = Form3.str;
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var result = client.Group.GetUsers(group_users_gid, 0, 100);
            group_users = result.ToString();
        }
        //人脸认证
        public static void FaceVerify()
        {
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            //MessageBox.Show(Form1.filename1);
            var image1 = File.ReadAllBytes(Form1.filename1);

            face_verify_uid = Form5.str1;
            face_verify_gid = Form5.str2;
            var result = client.User.Verify(image1, face_verify_uid, new[] { face_verify_gid }, 1)["result"][0];
            face_verify = result.ToString();
        }
    }
}
//有待添加的功能:
//调用摄像头采集人脸
//图片和摄像头人脸来源质量检测信息反馈
//基本的体验优化 将每次的结果输入到txt文件或数据库中在本地保存
//需要打开文件未打开取消或关闭文件打开界面 输入组名等未输入或关闭界面 输入错误等错误的处理

//