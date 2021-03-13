using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UtilitiesMain.WinFormsApps.Paint.PaintObjects
{
    public class DrawingPoint
    {
        private int thickness;
        private Color color;
        private Point position;

        public DrawingPoint(int thickness, Color color, Point position)
        {
            this.thickness = thickness;
            this.color = color;
            this.position = position;
        }

        public int Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
