using System;
using System.Drawing;
using System.Windows.Forms;
using HueShape.Controllers;
using HueShape.Core;
using HueShape.Data.Enums;
using HueShape.Models;

namespace HueShape
{
    public partial class MainForm : Form
    {
        private readonly ICanvasController _canvasController;

        public MainForm()
        {
            InitializeComponent();
            _canvasController = IocContainer.GetInstance<ICanvasController>();
            OnUpdateSelection();
            _canvasController.UpdateSelection = OnUpdateSelection;
        }


        public void OnUpdateSelection()
        {
            var shapeBuilder = _canvasController.ShapeBuilder;

            btnColor.BackColor = shapeBuilder.Color;
            if (shapeBuilder.Effect == ShapeEffect.Outlined)
            {
                rbOutlined.Select();
            }
            else
            {
                rbFill.Select();
            }

            if (shapeBuilder.ShapeType == ShapeType.Circle)
            {
                rbCircle.Select();
            }
            else
            {
                rbRectangle.Select();
            }
        }

        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            var location = GetLocation();
            pnlBottomRightExtender.Visible = false;
            _canvasController.Draw(e.Graphics, location, pnlBottomRightExtender);
        }

        private void pnlCanvas_Click(object sender, EventArgs e)
        {
            if (_canvasController.SelectShape( GetLocation()) == DrawState.Redraw)
            {
                RedrawCanvas();
            }
        }

        private void pnlBottomRightExtender_MouseDown(object sender, MouseEventArgs e)
        {
            _canvasController.EnableEditing();
        }

        private void pnlBottomRightExtender_MouseUp(object sender, MouseEventArgs e)
        {
            _canvasController.DisableEditing();
        }

        private void pnlBottomRightExtender_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_canvasController.Editing)
                return;

            RedrawCanvas();
        }

        private void pnlCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            _canvasController.CanvasMouseDown(GetLocation());
        }

        private void pnlCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_canvasController.CanvasMouseMove(GetLocation()) == DrawState.Redraw)
            {
                RedrawCanvas();
            }
        }

        private void pnlCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            _canvasController.CanvasMouseUp();
        }

        private Point GetLocation()
        {
            var location = PointToClient(Cursor.Position);
            return new Point(location.X, location.Y - pnlCanvas.Top);
        }

        private void rbCircle_CheckedChanged(object sender, EventArgs e)
        {
            _canvasController.SetShapeTypeSelection(ShapeType.Circle);
        }

        private void rbRectangle_CheckedChanged(object sender, EventArgs e)
        {
            _canvasController.SetShapeTypeSelection(ShapeType.Rectangle);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog {AllowFullOpen = false, ShowHelp = true, Color = btnColor.BackColor};

            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;

            btnColor.BackColor = colorDialog.Color;
            _canvasController.SetShapeColor(colorDialog.Color);
            if (_canvasController.ResetSelectedShapeColor() == DrawState.Redraw)
            {
                RedrawCanvas();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            if (_canvasController.DeleteShape() == DrawState.Redraw)
                RedrawCanvas();
        }

        private void rbOutlined_CheckedChanged(object sender, EventArgs e)
        {
            _canvasController.SetShapeEffect(ShapeEffect.Outlined);
            ResetSelectedShapeEffect();
        }

        private void ResetSelectedShapeEffect()
        {
            if (_canvasController.ResetSelectedShapeEffect() == DrawState.Redraw)
            {
                RedrawCanvas();
            }
        }

        private void rbFill_CheckedChanged(object sender, EventArgs e)
        {
            _canvasController.SetShapeEffect(ShapeEffect.Fill);
            ResetSelectedShapeEffect();
        }

        private void miNew_Click(object sender, EventArgs e)
        {
            if (_canvasController.ClearDrawings() == DrawState.Redraw)
            {
                RedrawCanvas();
            }
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            fileDialog.FileName = string.Empty;

            var result = fileDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;
            DrawState drawState;
            try
            {
                drawState = _canvasController.Open(fileDialog.FileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error occured: {0}", exception.Message), "Open File Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (drawState == DrawState.Redraw)
            {
                RedrawCanvas();
            }
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            string fileName = null;
            if (_canvasController.NotSavedToFile())
            {
                fileDialog.FileName = string.Empty;
                var result = fileDialog.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                fileName = fileDialog.FileName;
            }
           

            try
            {
                _canvasController.Save(fileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error occured: {0}", exception.Message), "Save Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (_canvasController.DeselectShape() == DrawState.Redraw)
            {
                RedrawCanvas();
            }
        }

        private void RedrawCanvas()
        {
            pnlCanvas.Invalidate();
        }
    }
}