using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UtilitiesMain.WinFormsApps.Paint.PaintObjects
{
    public class Line
    {       
        private int borderThickness;
        private Color borderColor;
        private int fillGroup;
        private Color fillColor;
        private Point startPosition;
        private Point endPosition;
        private Point centerPosition;
        private int positionZ;

        public Line(int borderThickness, Color borderColor, Point startPosition, Point endPosition, Point centerPosition, int positionZ, int fillGroup = 0, Color? fillColor = null)
        {
            this.borderThickness = borderThickness;
            this.borderColor = borderColor;
            this.startPosition = startPosition;
            this.endPosition = endPosition;
            this.centerPosition = centerPosition;
            this.positionZ = positionZ;
            this.fillGroup = fillGroup;
            
            if(fillColor == null)
            {
                this.fillColor = Color.Transparent;
            }
            else
            {
                this.fillColor = (Color)fillColor;
            }
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

        public int FillGroup
        {
            get { return fillGroup; }
            set { fillGroup = value; }
        }

        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        public Point CenterPosition
        {
            get { return centerPosition; }
            set { centerPosition = value; }
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
