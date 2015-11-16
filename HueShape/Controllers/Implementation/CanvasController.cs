using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HueShape.Data;
using HueShape.Data.Enums;
using HueShape.Interfaces;
using HueShape.Logic;
using HueShape.Models;

namespace HueShape.Controllers.Implementation
{
    internal class CanvasController : ICanvasController
    {
        private readonly IDocumentLogic _documentLogic;
        private readonly IShapeBuilder _shapeBuilder;
        private string _fileName;
        private IShape _selectedShape;
        private bool _shapeMoving;
        private IList<IShape> _shapes;
        private int _startMovingLocationX;
        private int _startMovingLocationY;
        private int _startShapeMovingLocationX;
        private int _startShapeMovingLocationY;

        public CanvasController(IShapeBuilder shapeBuilder, IDocumentLogic documentLogic)
        {
            _shapes = new List<IShape>();

            IsNewShape = false;
            EnableCreateShape = false;
            _shapeBuilder = shapeBuilder;
            _documentLogic = documentLogic;
            _shapeMoving = false;
            _startMovingLocationX = 0;
            _startMovingLocationY = 0;
            _startShapeMovingLocationX = 0;
            _startShapeMovingLocationY = 0;
        }

        public bool IsNewShape { get; private set; }
        public bool EnableCreateShape { get; private set; }

        public Color CurrentColor
        {
            get { return _shapeBuilder.Color; }
        }

        public DrawState ClearDrawings()
        {
            _shapes = new List<IShape>();

            IsNewShape = false;
            EnableCreateShape = false;
            _selectedShape = null;
            _fileName = string.Empty;
            return DrawState.Redraw;
        }

        public Action UpdateSelection { get; set; }

        public IShapeBuilder ShapeBuilder
        {
            get { return _shapeBuilder; }
        }

        public bool Editing { get; private set; }


        public void Draw(Graphics graphics, Point location, Panel bottomRightExtender)
        {
            foreach (var shape in _shapes)
            {
                if (shape == _selectedShape)
                {
                    shape.DrawEdit(graphics, location, Editing, _shapeMoving, bottomRightExtender);
                }
                else
                {
                    shape.Draw(graphics);
                }
            }
        }

        public DrawState SelectShape(Point location)
        {
            var previousSelectedShape = _selectedShape;
            _selectedShape = GetShapeInLocation(location);

            if (_selectedShape != null)
            {
                _shapeBuilder.Color = _selectedShape.Color;
                _shapeBuilder.Effect = _selectedShape.Effect;
                _shapeBuilder.ShapeType = _selectedShape.ShapeType;
            }

            if (UpdateSelection != null)
            {
                UpdateSelection();
            }

            return _selectedShape != previousSelectedShape ? DrawState.Redraw : DrawState.None;
        }

        public DrawState DeselectShape()
        {
            _selectedShape = null;
            return DrawState.Redraw;
        }

        public void EnableEditing()
        {
            Editing = true;
        }

        public void DisableEditing()
        {
            Editing = false;
        }

        public void SetShapeTypeSelection(ShapeType shapeType)
        {
            _shapeBuilder.ShapeType = shapeType;
        }

        public void SetShapeColor(Color color)
        {
            _shapeBuilder.Color = color;
        }

        public DrawState ResetSelectedShapeColor()
        {
            if (NoSelectedShape() || _selectedShape.Color == _shapeBuilder.Color)
                return DrawState.None;
            _selectedShape.Color = _shapeBuilder.Color;
            return DrawState.Redraw;
        }

        public DrawState DeleteShape()
        {
            if (NoSelectedShape())
                return DrawState.None;

            _shapes.Remove(_selectedShape);
            _selectedShape = null;
            return DrawState.Redraw;
        }

        public void SetShapeEffect(ShapeEffect effect)
        {
            _shapeBuilder.Effect = effect;
        }

        public DrawState ResetSelectedShapeEffect()
        {
            if (NoSelectedShape() || _selectedShape.Effect == _shapeBuilder.Effect)
                return DrawState.None;
            _selectedShape.Effect = _shapeBuilder.Effect;
            return DrawState.Redraw;
        }

        public void Save(string fileName)
        {
            if (fileName == null)
                fileName = _fileName;
            var savingShapes = new List<Shape>();
            foreach (var shape in _shapes)
            {
                var savingShape = new Shape
                    {
                        ShapeType = shape.ShapeType,
                        ShapeEffect = shape.Effect,
                        ColorR = shape.Color.R,
                        ColorG = shape.Color.G,
                        ColorB = shape.Color.B,
                        LocationX = shape.LocationX,
                        LocationY = shape.LocationY,
                        Width = shape.Width,
                        Height = shape.Height
                    };

                savingShapes.Add(savingShape);
            }

            _documentLogic.SaveFile(fileName, savingShapes);
            _fileName = fileName;
        }

        public bool NotSavedToFile()
        {
            return string.IsNullOrEmpty(_fileName);
        }

        public DrawState Open(string fileName)
        {
            var openedShapes = _documentLogic.OpenFile(fileName);
            ClearDrawings();
            foreach (var openedShape in openedShapes)
            {
                _shapeBuilder.Color = Color.FromArgb(openedShape.ColorR, openedShape.ColorG, openedShape.ColorB);
                _shapeBuilder.Effect = openedShape.ShapeEffect;
                _shapeBuilder.ShapeType = openedShape.ShapeType;

                var shape = _shapeBuilder.Build(openedShape.Width, openedShape.Height, openedShape.LocationX,
                                                openedShape.LocationY);
                _shapes.Add(shape);
            }
            if (UpdateSelection != null)
            {
                UpdateSelection();
            }
            _fileName = fileName;
            return DrawState.Redraw;
        }

        public void CanvasMouseDown(Point location)
        {
            EnableEditing();

            if (NoSelectedShape() && NoShapeInLocation(location))
            {
                SetupCreateShape(location);
                return;
            }

            if (HasSelectedShape())
            {
                EnableMoveShape(location);
            }
        }

        public DrawState CanvasMouseMove(Point location)
        {
            if (!IsNewShape && !EnableCreateShape && !ShapeIsMoving())
                return DrawState.None;

            if (ShapeIsMoving())
            {
                MoveShape(location);
            }
            else if (EnableCreateShape)
            {
                AttachedShape(location);
            }
            return DrawState.Redraw;
        }

        public void CanvasMouseUp()
        {
            CompleteCreateNewShape();
            DisableEditing();
            CompleteShapeMoving();
        }

        private bool HasSelectedShape()
        {
            return !NoSelectedShape();
        }

        private bool NoSelectedShape()
        {
            return _selectedShape == null;
        }

        private void SetupCreateShape(Point location)
        {
            EnableCreateShape = true;
            _selectedShape = _shapeBuilder.Build(2, 2, location.X, location.Y);
        }

        private void AttachedShape(Point location)
        {
            if (_selectedShape == null || !EnableCreateShape)
                return;

            if (_selectedShape.LocationX + 2 > location.X && _selectedShape.LocationY + 2 > location.Y)
                return;

            _shapes.Add(_selectedShape);
            IsNewShape = true;
            EnableCreateShape = false;
        }


        private bool NoShapeInLocation(Point location)
        {
            return GetShapeInLocation(location) == null;
        }

        private IShape GetShapeInLocation(Point location)
        {
            return
                _shapes.FirstOrDefault(
                    shape =>
                    location.X >= shape.LocationX && location.X <= (shape.Width + shape.LocationX) &&
                    location.Y >= shape.LocationY && location.Y <= (shape.Height + shape.LocationY));
        }

        private void EnableMoveShape(Point location)
        {
            _shapeMoving = true;
            _startMovingLocationX = location.X;
            _startMovingLocationY = location.Y;
            _startShapeMovingLocationX = _selectedShape.LocationX;
            _startShapeMovingLocationY = _selectedShape.LocationY;
        }

        private bool ShapeIsMoving()
        {
            return _shapeMoving;
        }

        private void MoveShape(Point location)
        {
            _selectedShape.LocationX = _startShapeMovingLocationX + (location.X - _startMovingLocationX);
            _selectedShape.LocationY = _startShapeMovingLocationY + (location.Y - _startMovingLocationY);
        }

        private void CompleteShapeMoving()
        {
            _shapeMoving = false;
            _startMovingLocationX = 0;
            _startMovingLocationY = 0;
            _startShapeMovingLocationX = 0;
            _startShapeMovingLocationY = 0;
        }

        private void CompleteCreateNewShape()
        {
            IsNewShape = false;
        }
    }
}