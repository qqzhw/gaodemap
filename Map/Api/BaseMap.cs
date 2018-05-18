using CefSharp;
using CefSharp.SchemeHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace  Map
{
   public  class BaseMap
    {
        public  static string BaseUrl = "local://cefsharp/";
        private const int scale = 12;
        public const string center = "[104.109428, 30.63923]";
        public static string DefaultUrl = BaseUrl + "index.html";
        /// <summary>
        /// 初始化设置
        /// </summary>
        public static void InitSetting()
        {
            var settings = new CefSettings();
            // settings.RemoteDebuggingPort = 8088;   
            var basePath = AppDomain.CurrentDomain.BaseDirectory+"Resources";
            settings.CachePath = AppDomain.CurrentDomain.BaseDirectory+"Cache";
            settings.RegisterScheme(new CefCustomScheme
            {
                SchemeName = "local",
                SchemeHandlerFactory = new FolderSchemeHandlerFactory(rootFolder: basePath,
                                                                    schemeName: "local", //Optional param no schemename checking if null
                                                                    hostName: "cefsharp", //Optional param no hostname checking if null
                                                                    defaultPage: "index.html"), //Optional param will default to index.html
                                                      
            });
             
            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);          
        }

        /// <summary>
        /// 加载地图
        /// </summary>
        /// <returns></returns>
        public static string  LoadMap()
        {
            return "LoadMap("+scale+"," + center + ");";
        }
    }
}
