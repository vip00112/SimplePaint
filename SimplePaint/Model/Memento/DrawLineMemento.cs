using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SimplePaint
{
    public class DrawLineMemento : IMemento
    {
        public enum LineType { Normal, Diagonal };

        #region Constructor
        public DrawLineMemento(Color color, int size, LineType type)
        {
            Color = color;
            LineSize = size;
            Type = type;
            Locations = new List<Point>();
        }
        #endregion

        #region Properties
        public Color Color { get; }

        public int LineSize { get; }

        public LineType Type { get; }

        public List<Point> Locations { get; private set; }
        #endregion

        #region Public Method
        public void AddLocation(Point loc)
        {
            Locations.Add(loc);
        }
        #endregion

        #region IMemento Method
        public bool CanDraw()
        {
            return Locations.Count > 1;
        }

        public IMemento Clone()
        {
            var clone = new DrawLineMemento(Color, LineSize, Type);
            foreach (var loc in Locations)
            {
                clone.Locations.Add(loc);
            }
            return clone;
        }

        public void Draw(Graphics g)
        {
            if (!CanDraw()) return;

            switch(Type)
            {
                case LineType.Normal:
                    using (Pen pen = new Pen(Color, LineSize))
                    {
                        pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                        pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                        pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                        g.DrawCurve(pen, Locations.ToArray());
                    }
                    break;
                case LineType.Diagonal:
                    using (Pen pen = new Pen(Color, 1))
                    {
                        pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                        pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                        pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                        List<Point> diagonalLocations = new List<Point>();
                        for (int idx = 0; idx < Locations.Count; idx++)
                        {
                            var loc = Locations[idx];
                            diagonalLocations.Add(new Point(loc.X + LineSize, loc.Y));
                            diagonalLocations.Add(new Point(loc.X, loc.Y + LineSize));

                            //if (idx < Locations.Count - 1)
                            //{
                            //    var next = Locations[idx + 1];
                            //    int diffX = next.X - loc.X;
                            //    int diffY = next.Y - loc.Y;
                            //    int diff = Math.Max(Math.Abs(diffX), Math.Abs(diffY));
                            //    while(diff > 0)
                            //    {
                            //        int addX = diffX / Math.Abs(diffX);
                            //        int addY = diffY / Math.Abs(diffY);
                            //        diff--;
                            //    }
                            //}
                        }
                        g.DrawCurve(pen, diagonalLocations.ToArray());
                    }
                    break;
            }
        }
        #endregion
    }
}
