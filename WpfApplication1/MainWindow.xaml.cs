using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPFMediaKit.DirectShow.Controls;
using Baidu.Aip.Face;
using System.Collections.Generic;


namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MultimediaUtil.VideoInputNames.Length > 0)
                vce.VideoCaptureSource = MultimediaUtil.VideoInputNames[0];
            else
                MessageBox.Show("没有检测到任何摄像头");
        }
        public static void SaveControlImage(FrameworkElement ui, string fileName)
        {
            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
            RenderTargetBitmap bmp = new RenderTargetBitmap(200, 150, 0, 0, PixelFormats.Pbgra32);
            bmp.Render(ui);
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            encoder.Save(fs);
            fs.Close();
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            vce.Play();
            SaveControlImage(b, "C:/Users/Administrator/b.png");
            vce.Stop();
            //var client = new Baidu.Aip.Face.Face("bHnKHuGkpQEaSU5k68F5MGen", "EojiKc7KgHF6FySfgp9lZYPynjAonRp6");
            //var image = File.ReadAllBytes("C:/Users/Administrator/b.png");
            //var options = new Dictionary<string, object>(){
            //    {"face_fields","beauty,age"}
            //};
            //var result = client.FaceDetect(image, options)["result"];
            //Title = result.ToString();
            //MessageBox.Show(Title);
            this.Close();
        }
    }
}
