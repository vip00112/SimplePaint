using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimplePaint
{
    public class Canvas : PictureBox
    {
        private Image _img;
        private DrawCommand _command;
        private DrawLineMemento _drawLine;
        private DrawSquareMemento _drawSquare;
        private DrawCircleMemento _drawCircle;

        #region Constructor
        private Canvas()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.ContainerControl, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SizeMode = PictureBoxSizeMode.Zoom;
            BackgroundImage = Properties.Resources.cellbackground;

            _command = new DrawCommand();
            ZoomRatio = 1.0F;
        }

        public Canvas(int width, int height) : this()
        {
            _img = ImageUtil.CreateImage(width, height, Color.Transparent);
            Width = width;
            Height = height;
            Image = _img;
        }

        public Canvas(Image img) : this()
        {
            _img = img;
            Width = img.Width;
            Height = img.Height;
            Image = img;
        }
        #endregion

        #region Event
        public event EventHandler Painted;
        #endregion

        #region Properties
        public Color Color { get; set; }

        public Color HighlightColor { get { return Color.FromArgb(70, Color); } }

        public int LineSize { get; set; }

        public DrawMode Mode { get; set; }

        public bool IsSaved { get; set; }

        public bool CanUndo { get { return _command.CanUndo; } }

        public bool CanRedo { get { return _command.CanRedo; } }

        public float ZoomRatio { get; private set; }
        #endregion

        #region Protected Method
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button != MouseButtons.Left) return;
            switch(Mode)
            {
                case DrawMode.Pen:
                    _drawLine = new DrawLineMemento(Color, LineSize);
                    break;
                case DrawMode.Highlighter:
                    _drawLine = new DrawLineMemento(HighlightColor, LineSize);
                    break;
                case DrawMode.Square:
                    _drawSquare = new DrawSquareMemento(Color, LineSize, CalcScalePoint(e.Location));
                    break;
                case DrawMode.Circle:
                    _drawCircle = new DrawCircleMemento(Color, LineSize, CalcScalePoint(e.Location));
                    break;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button != MouseButtons.Left) return;
            switch (Mode)
            {
                case DrawMode.Pen:
                case DrawMode.Highlighter:
                    if (_drawLine != null)
                    {
                        _drawLine.AddLocation(CalcScalePoint(e.Location));
                    }
                    break;
                case DrawMode.Square:
                    if (_drawSquare != null)
                    {
                        _drawSquare.SetEndLocation(CalcScalePoint(e.Location));
                    }
                    break;
                case DrawMode.Circle:
                    if (_drawCircle != null)
                    {
                        _drawCircle.SetEndLocation(CalcScalePoint(e.Location));
                    }
                    break;
            }
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button != MouseButtons.Left) return;
            switch (Mode)
            {
                case DrawMode.Pen:
                case DrawMode.Highlighter:
                    if (_drawLine != null && _drawLine.CanDraw())
                    {
                        AddMemento(_drawLine);
                        _drawLine = null;
                    }
                    break;
                case DrawMode.Square:
                    if (_drawSquare != null && _drawSquare.CanDraw())
                    {
                        AddMemento(_drawSquare);
                        _drawSquare = null;
                    }
                    break;
                case DrawMode.Circle:
                    if (_drawCircle != null && _drawCircle.CanDraw())
                    {
                        AddMemento(_drawCircle);
                        _drawCircle = null;
                    }
                    break;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (ZoomRatio != 1.0F)
            {
                e.Graphics.ScaleTransform(ZoomRatio, ZoomRatio);
            }

            _command.Draw(e.Graphics);

            if (_drawLine != null && _drawLine.CanDraw())
            {
                _drawLine.Draw(e.Graphics);
            }
            if (_drawSquare != null && _drawSquare.CanDraw())
            {
                _drawSquare.Draw(e.Graphics);
            }
            if (_drawCircle != null && _drawCircle.CanDraw())
            {
                _drawCircle.Draw(e.Graphics);
            }

            if (Painted != null)
            {
                Painted(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Private Method
        private void AddMemento(IMemento memento)
        {
            _command.AddMemento(memento.Clone());
            IsSaved = false;
        }

        private Point CalcScalePoint(Point point)
        {
            if (ZoomRatio == 1.0F) return point;

            int x = (int) (point.X / ZoomRatio);
            int y = (int) (point.Y / ZoomRatio);
            return new Point(x, y);
        }
        #endregion

        #region Public Method
        public void Undo()
        {
            if (_command.Undo())
            {
                IsSaved = false;
            }
            Invalidate();
        }

        public void Redo()
        {
            if (_command.Redo())
            {
                IsSaved = false;
            }
            Invalidate();
        }

        public void Save(string savePath, ImageFormat saveFormat)
        {
            var bitmap = new Bitmap(Width, Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(Image, 0, 0);
                _command.Draw(g);
            }
            bitmap.Save(savePath, saveFormat);
            IsSaved = true;
        }

        public void Zoom(float zoomRatio)
        {
            ZoomRatio = zoomRatio;

            Width = (int) (_img.Width * zoomRatio);
            Height = (int) (_img.Height * zoomRatio);
            Invalidate();
        }
        #endregion
    }
}