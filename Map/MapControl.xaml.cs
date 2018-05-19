using CefSharp;
using Map.Api;
using Map.Handlers;
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

namespace Map
{
    /// <summary>
    /// MapControl.xaml 的交互逻辑
    /// </summary>
    public partial class MapControl : UserControl
    {
        public Action OnLoadComplete;
        public MapControl()
        {
            InitializeComponent();
            browser.Address = BaseMap.DefaultUrl;
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            browser.RenderProcessMessageHandler = new RenderProcessMessageHandler();
            // browser.LifeSpanHandler = new LifespanHandler();
            //  browser.MenuHandler = new MenuHandler();
            RegisterJsObject();
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
        }



        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.Url == BaseMap.DefaultUrl)
            {
                OnLoadComplete?.Invoke();//通知地图UI加载完成事件
                // browser.ExecuteScriptAsync("AddMapPoint();");
            }

        }

        /// <summary>
        /// 注册Js对象，用于JS调用后台代码
        /// </summary>
        private void RegisterJsObject()
        {
            //var bindingOptions = new BindingOptions()
            //{
            //    Binder = BindingOptions.DefaultBinder.Binder,
            //    MethodInterceptor = new MethodInterceptorLogger() // intercept .net methods calls from js and log it
            //};
            browser.JavascriptObjectRepository.Register("mapApi", new MapAPI(), isAsync: false, options: BindingOptions.DefaultBinder);

        }

        public async Task<object> EvaluateJavaScript(string script)
        {
            try
            {
                var response = await browser.EvaluateScriptAsync(script);
                if (response.Success && response.Result is IJavascriptCallback)
                {
                    response = await ((IJavascriptCallback)response.Result).ExecuteAsync("This is a callback from EvaluateJavaScript");
                }

                var jsResult = response.Success ? (response.Result ?? "null") : response.Message;
                return jsResult;
            }
            catch (Exception e)
            {
                MessageBox.Show("执行Js出错: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }

        public void ExecuteJavaScript(string script)
        {
            try
            {
                browser.ExecuteScriptAsync(script);
            }
            catch (Exception e)
            {
                MessageBox.Show("执行Js出错: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 显示开发调试工具
        /// </summary>
        public void ShowDevTools()
        {
            browser.ShowDevTools(); //显示调试工具
        }
        /// <summary>
        /// 标记单个点位
        /// </summary>
        /// <param name="mapPoint"></param>
        public void AddMapPoint(MapPoint mapPoint)
        {
            if (mapPoint == null)
                return;
            string method=string.Format("AddMapPoint('{0}','{1}',[{2},{3}],'{4}');",mapPoint.Lable,mapPoint.Name,mapPoint.X,mapPoint.Y, mapPoint.PointColor);
            browser.ExecuteScriptAsync(method);
        }
        /// <summary>
        /// 标记多个点位
        /// </summary>
        /// <param name="mapPoints"></param>
        public void AddMapPoints(List<MapPoint> mapPoints)
        {
            if (mapPoints == null)
                return;
            foreach (var item in mapPoints)
            {
                AddMapPoint(item);
            }
        }
        /// <summary>
        /// 删除单个点位
        /// </summary>
        /// <param name="mapPoint"></param>
        public void DeleteMapPoint(string name)
        {
            if (string.IsNullOrEmpty(name))
                return;
            string method = string.Format("DelMapPoint('{0}');", name);
            browser.ExecuteScriptAsync(method);
        }

        /// <summary>
        /// 更新标记单个点位
        /// </summary>
        /// <param name="mapPoint"></param>
        public void UpdateMapPoint(MapPoint mapPoint)
        {
            if (mapPoint == null)
                return;
            string method = string.Format("UpdateMapPoint('{0}','{1}',[{2},{3}],'{4}');", mapPoint.ImgSource, mapPoint.Name, mapPoint.X, mapPoint.Y,mapPoint.PointColor);
            browser.ExecuteScriptAsync(method);
        }
    }
}
 
