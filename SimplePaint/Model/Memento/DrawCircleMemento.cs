using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SimplePaint
{
    public class DrawCircleMemento : IMemento
    {
        #region Constructor
        public DrawCircleMemento(Color color, int size, Point start)
        {
            Color = color;
            LineSize = size;
            Start = start;
        }
        #endregion

        #region Properties
        public Color Color { get; }

        public int LineSize { get; }

        public Point Start { get; }

        public Point End { get; private set; }
        #endregion

        #region Public Method
        public void SetEndLocation(Point loc)
        {
            End = loc;
        }
        #endregion

        #region IMemento Method
        public bool CanDraw()
        {
            return Start != Point.Empty && End != Point.Empty && Start != End;
        }

        public IMemento Clone()
        {
            var clone = new DrawCircleMemento(Color, LineSize, Start)
            {
                End = End
            };
            return clone;
        }

        public void Draw(Graphics g)
        {
            if (!CanDraw()) return;

            using (Pen pen = new Pen(Color, LineSize))
            {
                pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                var rec = new Rectangle(Math.Min(Start.X, End.X),
                                        Math.Min(Start.Y, End.Y),
                                        Math.Abs(Start.X - End.X),
                                        Math.Abs(Start.Y - End.Y));
                g.DrawEllipse(pen, rec);
            }
        }
        #endregion
    }
}
