using Map.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Map.Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            mapControl.OnLoadComplete += OnLoadComplete;//注册地图UI加载完成事件
        }

        private void OnLoadComplete()
        {
            //获取数据集合添加点位
           // mapControl.AddMapPoint(null);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void ShowTools_Click(object sender, RoutedEventArgs e)
        {
            mapControl.ShowDevTools();
        }

        private void DelPoint_Click(object sender, RoutedEventArgs e)
        {
           var x = 104.102225;
            var y = 30.160002;
            //获取数据集合添加点位
            mapControl.DeleteMapPoint("川A6689警");
        }

        private void UpdatePoint_Click(object sender, RoutedEventArgs e)
        {
            var point = new MapPoint();
            point.Lable = "A";
            point.Name = "川A6689警";
            point.X = 104.052225;
            point.Y = 30.634445;
            point.PointColor = "red";
            point.ImgSource = "http://vdata.amap.com/icons/b18/1/2.png";
            //获取数据集合添加点位
            mapControl.UpdateMapPoint(point);
        }

        private void AddPoint_Click(object sender, RoutedEventArgs e)
        {
            var point = new MapPoint();
            point.Lable = "A";
            point.Name = "川A6689警";
            point.X = 104.062225;
            point.Y = 30.580002;
            point.PointColor = "black";
            //获取数据集合添加点位
            mapControl.AddMapPoint(point);
        }
    }
}
