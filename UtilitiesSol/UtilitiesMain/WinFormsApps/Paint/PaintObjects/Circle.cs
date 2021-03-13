using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UtilitiesMain.WinFormsApps.Paint.PaintObjects
{
    public class Circle
    {
        private int borderThickness;
        private Color borderColor;
        private bool filled = false;
        private Color fillColor;
        private Point startPosition;
        private Point endPosition;
        private int positionZ;

        public Circle(int borderThickness, Color borderColor, Color fillColor, Point startPosition, Point endPosition, int positionZ)
        {
            this.borderThickness = borderThickness;
            this.borderColor = borderColor;
            this.fillColor = fillColor;
            this.startPosition = startPosition;
            this.endPosition = endPosition;
            this.positionZ = positionZ;
        }

        public int BorderThickness
        {
            get { return borderThickness; }
            set { borderThickness = value; }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        public bool Filled
        {
            get { return filled; }
            set { filled = value; }
        }

        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        public Point EndPosition
        {
            get { return endPosition; }
            set { endPosition = value; }
        }

        public Point StartPosition
        {
            get { return startPosition; }
            set { startPosition = value; }
        }

        public int PositionZ
        {
            get { return positionZ; }
            set { positionZ = value; }
        }
    }
}
