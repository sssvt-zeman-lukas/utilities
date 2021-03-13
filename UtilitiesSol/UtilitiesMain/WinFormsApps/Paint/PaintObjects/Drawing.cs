using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UtilitiesMain.WinFormsApps.Paint.PaintObjects
{
    public class Drawing
    {
        private int borderThickness;
        private Color borderColor;
        private bool filled = false;
        private Color fillColor;
        private List<DrawingPoint> points;
        private int positionZ;

        public Drawing(int borderThickness, Color borderColor, Color fillColor, List<DrawingPoint> points, int positionZ)
        {
            this.borderThickness = borderThickness;
            this.borderColor = borderColor;
            this.fillColor = fillColor;
            this.points = points;
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

        public List<DrawingPoint> Points
        {
            get { return points; }
            set { points = value; }
        }

        public int PositionZ
        {
            get { return positionZ; }
            set { positionZ = value; }
        }
    }
}
