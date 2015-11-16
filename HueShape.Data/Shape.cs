using HueShape.Data.Enums;

namespace HueShape.Data
{
    public class Shape
    {
        public ShapeType ShapeType { get; set; }
        public ShapeEffect ShapeEffect { get; set; }
        public int ColorR { get; set; }
        public int ColorG { get; set; }
        public int ColorB { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}