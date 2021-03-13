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
    public class PaintOpener
    {
        private List<string> data = new List<string>();
        private string path;

        public PaintOpener(string path)
        {
            this.path = path;
        }

        public bool LoadCSV()
        {
            StreamReader sr = new StreamReader(path);
            bool firstLine = true;
            bool valid = false;
            string firstLineText = "ObjectType;PositionZ;BorderColor_R;BorderColor_G;BorderColor_B;BorderColor_A;BorderThickness;FillColor_R;FillColor_G;FillColor_B;FillColor_A;ObjectFillGroup;StartX;StartY;CenterX;CenterY;EndX;EndY";

            try
            {
                while (!sr.EndOfStream)
                {
                    if(firstLine)
                    {
                        if (sr.ReadLine() == firstLineText)
                        {
                            firstLine = false;
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        data.Add(sr.ReadLine());
                    }
                }

                valid = ValidateCSV();
            }
            catch (Exception)
            {

            }
            finally
            {
                sr.Close();
            }

            return valid;
        }

        private bool ValidateCSV()
        {
            bool valid = true;
            
            foreach(string data in data)
            {
                string[] separatedData = data.Split(';');

                if (separatedData.Length != 18)
                {
                    valid = false;
                    break;
                }

                switch(separatedData[0])
                {
                    case string objectType when (objectType == "Line"):
                        valid = ValidateLine(separatedData);
                        break;

                    case string objectType when (objectType == "Background"):
                        valid = ValidateBackground(separatedData);
                        break;

                    case string objectType when (objectType == "Box"):
                        break;

                    case string objectType when (objectType == "Circle"):
                        break;

                    case string objectType when (objectType == "Drawing"):
                        break;

                    case string objectType when (objectType == "DrawingPoint"):
                        break;
                }

                if(!valid)
                    break;
            }

            return valid;
        }
        
        private static bool ValidateLine(string[] line)
        {
            bool valid = true;
            
            if (!int.TryParse(line[1], out int positionZ) || positionZ < 1)
            {
                valid = false;
            }

            if (!int.TryParse(line[2], out int BorderColorR) || BorderColorR < 0 || BorderColorR > 255)
            {
                valid = false;
            }

            if (!int.TryParse(line[3], out int BorderColorG) || BorderColorG < 0 || BorderColorG > 255)
            {
                valid = false;
            }

            if (!int.TryParse(line[4], out int BorderColorB) || BorderColorB < 0 || BorderColorB > 255)
            {
                valid = false;
            }

            if (!int.TryParse(line[5], out int BorderColorA) || BorderColorA < 0 || BorderColorA > 255)
            {
                valid = false;
            }

            if (!int.TryParse(line[6], out int BorderThickness) || BorderThickness < 0 || BorderThickness > 100)
            {
                valid = false;
            }

            if (!int.TryParse(line[7], out int FillColorR) || FillColorR < 0 || FillColorR > 255)
            {
                valid = false;
            }

            if (!int.TryParse(line[8], out int FillColorG) || FillColorG < 0 || FillColorG > 255)
            {
                valid = false;
            }

            if (!int.TryParse(line[9], out int FillColorB) || FillColorB < 0 || FillColorB > 255)
            {
                valid = false;
            }

            if (!int.TryParse(line[10], out int FillColorA) || FillColorA < 0 || FillColorA > 255)
            {
                valid = false;
            }

            if (!int.TryParse(line[11], out int FillGroup) && !string.IsNullOrEmpty(line[11]) || FillGroup < 0)
            {
                valid = false;
            }

            if (!int.TryParse(line[12], out int startX) || startX < 0 || startX > 1600)
            {
                valid = false;
            }

            if (!int.TryParse(line[13], out int startY) || startY < 0 || startY > 900)
            {
                valid = false;
            }

            if (!int.TryParse(line[14], out int centerX) || centerX < 0 || centerX > 1600)
            {
                valid = false;
            }

            if (!int.TryParse(line[15], out int centerY) || centerY < 0 || centerY > 900)
            {
                valid = false;
            }

            if (!int.TryParse(line[16], out int endX) || endX < 0 || endX > 1600)
            {
                valid = false;
            }

            if (!int.TryParse(line[17], out int endY) || endY < 0 || endY > 900)
            {
                valid = false;
            }

            return valid;
        }

        private static bool ValidateBackground(string[] background)
        {
            bool valid = true;

            if (!int.TryParse(background[1], out int positionZ) || positionZ != 0)
            {
                valid = false;
            }

            if (!int.TryParse(background[7], out int FillColorR) || FillColorR < 0 || FillColorR > 255)
            {
                valid = false;
            }

            if (!int.TryParse(background[8], out int FillColorG) || FillColorG < 0 || FillColorG > 255)
            {
                valid = false;
            }

            if (!int.TryParse(background[9], out int FillColorB) || FillColorB < 0 || FillColorB > 255)
            {
                valid = false;
            }

            if (!int.TryParse(background[10], out int FillColorA) || FillColorA < 0 || FillColorA > 255)
            {
                valid = false;
            }

            return valid;
        }

        public Color GetBackgroundColor()
        {
            string[] backgroundData = data[0].Split(';');

            return Color.FromArgb(
                Convert.ToInt32(backgroundData[10]), 
                Convert.ToInt32(backgroundData[7]), 
                Convert.ToInt32(backgroundData[8]), 
                Convert.ToInt32(backgroundData[9]));
        }

        public List<Line> FindLines()
        {
            List<Line> lines = new List<Line>();

            foreach(string data in data)
            {
                string[] separatedData = data.Split(';');

                if(separatedData[0] == "Line")
                {
                    Color borderColor = Color.FromArgb(
                        Convert.ToInt32(separatedData[5]),
                        Convert.ToInt32(separatedData[2]),
                        Convert.ToInt32(separatedData[3]),
                        Convert.ToInt32(separatedData[4]));

                    Color fillColor = Color.FromArgb(
                        Convert.ToInt32(separatedData[10]),
                        Convert.ToInt32(separatedData[7]),
                        Convert.ToInt32(separatedData[8]),
                        Convert.ToInt32(separatedData[9]));

                    Point startPoint = new Point(Convert.ToInt32(separatedData[12]), Convert.ToInt32(separatedData[13]));
                    Point centerPoint = new Point(Convert.ToInt32(separatedData[14]), Convert.ToInt32(separatedData[15]));
                    Point endPoint = new Point(Convert.ToInt32(separatedData[16]), Convert.ToInt32(separatedData[17]));

                    lines.Add(new Line(
                        Convert.ToInt32(separatedData[6]), 
                        borderColor, startPoint, endPoint, centerPoint, 
                        Convert.ToInt32(separatedData[1]),
                        Convert.ToInt32(separatedData[11]), fillColor));
                }
            }

            return lines;
        }

        public List<string> Data
        {
            get { return data; }
        }
    }
}
