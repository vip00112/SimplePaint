using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SimplePaint
{
    public interface IMemento
    {
        bool CanDraw();

        IMemento Clone();

        void Draw(Graphics g);
    }
}
