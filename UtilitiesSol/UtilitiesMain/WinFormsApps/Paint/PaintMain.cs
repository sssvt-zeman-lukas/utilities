using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using UtilitiesMain.WinFormsApps.Paint.PaintObjects;

namespace UtilitiesMain.WinFormsApps.Paint
{
    public class PaintMain
    {
        public enum SelectedTool
        {
            Line,
            Brush,
            Box,
            Circle,
            Bucket,
            Eraser
        }

        private SelectedTool tool;
        private Color backgroundColor;
        private Color toolColor;
        private int toolThickness;
        private bool objectsLock;
        private Point startMousePos;
        private Point endMousePos;

        private int positionZ = 1;
        private bool firstPoint = true;
        private int objectsCount = 0;

        private List<Box> boxes = new List<Box>();
        private List<Circle> circles = new List<Circle>();
        private List<Line> lines = new List<Line>();
        private List<Drawing> drawings = new List<Drawing>();
        private List<DrawingPoint> drawingPoints = new List<DrawingPoint>();

        public PaintMain(SelectedTool tool, Color backgroundColor, Color toolColor, int toolThickness, bool objectsLock)
        {
            this.tool = tool;
            this.backgroundColor = backgroundColor;
            this.toolColor = toolColor;
            this.toolThickness = toolThickness;
            this.objectsLock = objectsLock;
        }

        public void Draw(Graphics g, bool preview, int mouseX, int mouseY)
        {            
            for (int z = 0; z + 1 <= objectsCount; z++)
            {
                if (z < boxes.Count && boxes[z].PositionZ == z + 1)
                {

                }
                else if (z < lines.Count && lines[z].PositionZ == z + 1)
                {
                    Pen pen = new Pen(lines[z].BorderColor, lines[z].BorderThickness);
                    g.DrawLine(pen, lines[z].StartPosition, lines[z].EndPosition);
                }
                else if (z < circles.Count && circles[z].PositionZ == z + 1)
                {

                }
                else if (z < drawings.Count && drawings[z].PositionZ == z + 1)
                {

                }
            }

            if (preview)
                DrawPreview(mouseX, mouseY, g);
        }

        private void DrawPreview(int mouseX, int mouseY, Graphics g)
        {
            switch(tool)
            {
                case SelectedTool.Line:
                    Pen pen = new Pen(toolColor, toolThickness);
                    g.DrawLine(pen, startMousePos, new Point(mouseX, mouseY));
                    break;

                case SelectedTool.Box:
                    break;

                case SelectedTool.Circle:
                    break;

                case SelectedTool.Brush:
                    break;
            }
        }

        public void DrawWireframe(int mouseX, int mouseY)
        {

        }

        public void SaveObject()
        {            
            switch(tool)
            {
                case SelectedTool.Line:
                    Point middlePos = new Point((startMousePos.X + endMousePos.X) / 2, (startMousePos.Y + endMousePos.Y) / 2);
                    lines.Add(new Line(toolThickness, toolColor, startMousePos, endMousePos, middlePos, positionZ));
                    objectsCount++;
                    positionZ++;
                    break;

                case SelectedTool.Box:
                    break;

                case SelectedTool.Circle:
                    break;

                case SelectedTool.Brush:
                    break;

                case SelectedTool.Bucket:
                    break;

                case SelectedTool.Eraser:
                    break;
            }

            firstPoint = true;
        }

        public void ExportCSV(string path, bool includeBrush, Color backgroundColor)
        {
            PaintSaver ps = new PaintSaver(path, lines, backgroundColor);
            ps.SaveCSV(includeBrush);
        }

        public bool LoadCSV(string path)
        {
            PaintOpener po = new PaintOpener(path);
            
            if(!po.LoadCSV())
            {
                return false;
            }

            backgroundColor = po.GetBackgroundColor();
            lines = po.FindLines();
            objectsCount = po.Data.Count - 1;
            positionZ = po.Data.Count;

            return true;
        }

        public SelectedTool Tool
        {
            get { return tool; }
            set { tool = value; }
        }

        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        public Color ToolColor
        {
            get { return toolColor; }
            set { toolColor = value; }
        }

        public int ToolThickness
        {
            get { return toolThickness; }
            set { toolThickness = value; }
        }

        public bool ObjectsLock
        {
            get { return objectsLock; }
            set { objectsLock = value; }
        }

        public Point StartMousePos
        {
            get { return startMousePos; }
            set { startMousePos = value; }
        }

        public Point EndMousePos
        {
            get { return endMousePos; }
            set { endMousePos = value; }
        }
    }
}
