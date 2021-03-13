using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using UtilitiesMain.WinFormsApps.Paint.PaintObjects;

namespace UtilitiesMain.WinFormsApps.Paint
{
    public class PaintSaver //currently saves lines only
    {
        private string path;
        private List<Line> lines;
        private Color backgroundColor;
        
        public PaintSaver(string path, List<Line> lines, Color backgroundColor)
        {
            this.path = path;
            this.lines = lines;
            this.backgroundColor = backgroundColor;
        }

        public void SaveCSV(bool includeBrush)
        {
            StreamWriter sw = new StreamWriter(path);

            try
            {
                sw.WriteLine("ObjectType;PositionZ;BorderColor_R;BorderColor_G;BorderColor_B;BorderColor_A;BorderThickness;FillColor_R;FillColor_G;FillColor_B;FillColor_A;ObjectFillGroup;StartX;StartY;CenterX;CenterY;EndX;EndY");
                sw.WriteLine("Background;0;;;;;;{0};{1};{2};{3};;;;;;;", backgroundColor.R, backgroundColor.G, backgroundColor.B, backgroundColor.A);

                foreach (Line line in lines)
                {
                    sw.Write("Line;");
                    sw.Write(line.PositionZ + ";");
                    sw.Write(line.BorderColor.R + ";");
                    sw.Write(line.BorderColor.G + ";");
                    sw.Write(line.BorderColor.B + ";");
                    sw.Write(line.BorderColor.A + ";");
                    sw.Write(line.BorderThickness + ";");
                    sw.Write(line.FillColor.R + ";");
                    sw.Write(line.FillColor.G + ";");
                    sw.Write(line.FillColor.B + ";");
                    sw.Write(line.FillColor.A + ";");
                    sw.Write(line.FillGroup + ";");
                    sw.Write(line.StartPosition.X + ";");
                    sw.Write(line.StartPosition.Y + ";");
                    sw.Write(line.CenterPosition.X + ";");
                    sw.Write(line.CenterPosition.Y + ";");
                    sw.Write(line.EndPosition.X + ";");
                    sw.Write(line.EndPosition.Y);
                    sw.WriteLine();
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                sw.Close();
                sw.Dispose();
            }
        }
    }
}
