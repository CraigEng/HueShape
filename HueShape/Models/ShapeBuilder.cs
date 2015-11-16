
using System.Drawing;
using HueShape.Core;
using HueShape.Data.Enums;
using HueShape.Interfaces;

namespace HueShape.Models
{
    internal class ShapeBuilder : IShapeBuilder
    {
        public ShapeType ShapeType { get; set; }
        public Color Color { get; set; }
        public ShapeEffect Effect { get; set; }


        public ShapeBuilder()
        {
            ShapeType = ShapeType.Circle;
  
            Color = Color.Green;
            Effect = ShapeEffect.Outlined;
        }

        public IShape Build(int width, int height, int locationX, int locationY)
        {
            var shape = IocContainer.GetInstance<IShape>(ShapeType);
            shape.Width = width;
            shape.Height = height;
            shape.LocationX = locationX;
            shape.LocationY = locationY;
            shape.Color = Color;
            shape.Effect = Effect;
            return shape;
        }
    }
}
