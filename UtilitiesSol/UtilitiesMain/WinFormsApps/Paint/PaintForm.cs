using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilitiesMain.WinFormsApps.Paint
{
    public partial class PaintForm : Form
    {
        private PaintMain PaintApp = new PaintMain(PaintMain.SelectedTool.Line, Color.White, Color.Black, 1, false);
        private bool DrawWireframe = false;
        private int mouseX;
        private int mouseY;
        
        public PaintForm()
        {
            InitializeComponent();
        }

        private void PaintForm_Load(object sender, EventArgs e)
        {
            string[] enumerators = Enum.GetNames(typeof(PaintMain.SelectedTool));

            for (int i = 0; i < enumerators.Length; i++)
            {
                if (enumerators[i] == PaintApp.Tool.ToString())
                {
                    string name = enumerators[i] + "Button";
                    
                    RadioButton button = Controls.Find(name, true).FirstOrDefault() as RadioButton;
                    button.Checked = true;
                }
            }
            
            buttonBackgroundColor.BackColor = PaintApp.BackgroundColor;
            buttonForegroundColor.BackColor = PaintApp.ToolColor;
            ThicknessNumeric.Value = PaintApp.ToolThickness;
            checkboxLockObjects.Checked = PaintApp.ObjectsLock;
        }

        private void PaintBox_Paint(object sender, PaintEventArgs e)
        {
            PaintApp.Draw(e.Graphics, DrawWireframe, mouseX, mouseY);
        }

        private void buttonForegroundColor_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                PaintApp.ToolColor = colorDialog.Color;
                buttonForegroundColor.BackColor = colorDialog.Color;
            }
        }

        private void buttonBackgroundColor_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                PaintApp.BackgroundColor = colorDialog.Color;
                PaintBox.BackColor = colorDialog.Color;
                buttonBackgroundColor.BackColor = colorDialog.Color;
            }           
        }
        
        private void ThicknessNumeric_ValueChanged(object sender, EventArgs e)
        {
            PaintApp.ToolThickness = Convert.ToInt32(ThicknessNumeric.Value);
        }

        private void PaintBox_MouseDown(object sender, MouseEventArgs e)
        {
            PaintApp.StartMousePos = new Point(e.X, e.Y);
            DrawWireframe = true;
        }

        private void PaintBox_MouseMove(object sender, MouseEventArgs e)
        {
            mousePosX.Text = "X: " + Convert.ToString(e.X) + " px";
            mousePosY.Text = "Y: " + Convert.ToString(e.Y) + " px";

            if(DrawWireframe)
            {
                mouseX = e.X;
                mouseY = e.Y;
            }
        }

        private void PaintBox_MouseUp(object sender, MouseEventArgs e)
        {
            PaintApp.EndMousePos = new Point(e.X, e.Y);
            DrawWireframe = false;
            PaintApp.SaveObject();
        }

        private void EraserButton_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                RadioButton button = (RadioButton)sender;

                string name = button.Name.Substring(0, button.Name.Length - 6);

                if(Enum.TryParse(name, out PaintMain.SelectedTool tool))
                    PaintApp.Tool = tool;
            }
        }

        private void checkboxLockObjects_CheckedChanged(object sender, EventArgs e)
        {
            PaintApp.ObjectsLock = checkboxLockObjects.Checked;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            PaintBox.Refresh();
        }
        
        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "CSV Drawing (*.csv)|*.csv";
            saveFileDialog.FilterIndex = 2;

            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                PaintApp.ExportCSV(saveFileDialog.FileName, CheckBoxInclBrush.Checked, PaintBox.BackColor);
            }
        }

        private void buttonLoadCSV_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "CSV Drawing (*.csv)|*.csv";
            openFileDialog.FilterIndex = 2;

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                if(!PaintApp.LoadCSV(openFileDialog.FileName))
                {

                }
                else
                {
                    PaintBox.BackColor = PaintApp.BackgroundColor;
                    buttonBackgroundColor.BackColor = PaintApp.BackgroundColor;
                }
            }
        }
    }
}
