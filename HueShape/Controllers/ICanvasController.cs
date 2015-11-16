using System;
using System.Drawing;
using System.Windows.Forms;
using HueShape.Data.Enums;
using HueShape.Interfaces;
using HueShape.Models;

namespace HueShape.Controllers
{
    internal interface ICanvasController
    {
        IShapeBuilder ShapeBuilder { get; }
        bool Editing { get; }
        void Draw(Graphics graphics, Point location, Panel bottomRightExtender);
        DrawState SelectShape(Point location);
        void EnableEditing();
        void DisableEditing();
        void SetShapeTypeSelection(ShapeType shapeType);
        void SetShapeColor(Color color);
        DrawState ResetSelectedShapeColor();
        DrawState DeleteShape();
        void SetShapeEffect(ShapeEffect effect);
        DrawState ResetSelectedShapeEffect();
        void Save(string fileName);
        bool NotSavedToFile();
        DrawState Open(string fileName);
        DrawState ClearDrawings();
        Action UpdateSelection { get; set; }
        DrawState DeselectShape();
        void CanvasMouseDown(Point location);
        DrawState CanvasMouseMove(Point location);
        void CanvasMouseUp();
    }
}