using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Map.Handlers
{
   
    public class RenderProcessMessageHandler : IRenderProcessMessageHandler
    {
         
        void IRenderProcessMessageHandler.OnFocusedNodeChanged(IWebBrowser browserControl, IBrowser browser, IFrame frame, IDomNode node)
        {
            var message = node == null ? "lost focus" : node.ToString();

            Console.WriteLine("OnFocusedNodeChanged() - " + message);
        }

        void IRenderProcessMessageHandler.OnContextCreated(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            if (frame.Url==BaseMap.DefaultUrl)
            { 
                string script = "document.addEventListener('DOMContentLoaded', function(){ "+BaseMap.LoadMap()+" });";

                frame.ExecuteJavaScriptAsync(script);                
            }
             
        }

        void IRenderProcessMessageHandler.OnContextReleased(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            //The V8Context is about to be released, use this notification to cancel any long running tasks your might have
           
        }

        //void IRenderProcessMessageHandler.OnUncaughtException(IWebBrowser browserControl, IBrowser browser, IFrame frame, JavascriptException exception)
        //{
        //    Console.WriteLine("OnUncaughtException() - " + exception.Message);
        //}
    }
}
