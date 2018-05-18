namespace Map.Api
{
    /// <summary>
    /// 坐标点类
    /// </summary>
    public class MapPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        /// <summary>
        /// lable标签 A,B,C
        /// </summary>
        public string Lable { get; set; }
        /// <summary>
        /// title 标注名称显示
        /// </summary>
        public string Name { get; set; }
        public string ImgSource { get; set; }
        public string PointColor { get; set; }
        public string Theme { get; set; }
    }
}