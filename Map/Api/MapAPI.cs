using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Api
{
    public class MapAPI
    {
        public MapAPI()
        { 
        } 
        public int Init(int sacle,string center)
        {
            var s = 9;
            return s;
        }
        /// <summary>
        /// 获取地图坐标点数据
        /// </summary>
        /// <returns></returns>
 
        public string GetMapPoints()
        {
            var list = new List<MapPoint>();
            list.Add(new MapPoint() { X = 104.056, Y = 30.68,Lable="A",Name="川A4436" });
            list.Add(new MapPoint() { X = 104.156, Y = 30.78, Lable = "B", Name = "川A5236" });
            return Newtonsoft.Json.JsonConvert.SerializeObject(list);
        }
    }

 
}
