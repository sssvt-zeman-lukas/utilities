
namespace UtilitiesMain.WinFormsApps.Paint
{
    partial class PaintForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.GroupBox();
            this.saveAs = new System.Windows.Forms.GroupBox();
            this.CheckBoxInclBrush = new System.Windows.Forms.CheckBox();
            this.buttonLoadCSV = new System.Windows.Forms.Button();
            this.buttonExportJPG = new System.Windows.Forms.Button();
            this.buttonExportCSV = new System.Windows.Forms.Button();
            this.otherSettings = new System.Windows.Forms.GroupBox();
            this.positionZNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.degreesNumeric = new System.Windows.Forms.NumericUpDown();
            this.buttonRotate = new System.Windows.Forms.Button();
            this.checkboxLockObjects = new System.Windows.Forms.CheckBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.colorsThickness = new System.Windows.Forms.GroupBox();
            this.tipThickness = new System.Windows.Forms.Label();
            this.ThicknessNumeric = new System.Windows.Forms.NumericUpDown();
            this.labelThickness = new System.Windows.Forms.Label();
            this.buttonBackgroundColor = new System.Windows.Forms.Button();
            this.buttonForegroundColor = new System.Windows.Forms.Button();
            this.labelForegroundColor = new System.Windows.Forms.Label();
            this.labelBackgrColor = new System.Windows.Forms.Label();
            this.paintTools = new System.Windows.Forms.GroupBox();
            this.EraserButton = new System.Windows.Forms.RadioButton();
            this.BucketButton = new System.Windows.Forms.RadioButton();
            this.CircleButton = new System.Windows.Forms.RadioButton();
            this.BoxButton = new System.Windows.Forms.RadioButton();
            this.BrushButton = new System.Windows.Forms.RadioButton();
            this.LineButton = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.selectedObject = new System.Windows.Forms.ToolStripStatusLabel();
            this.mousePosX = new System.Windows.Forms.ToolStripStatusLabel();
            this.mousePosY = new System.Windows.Forms.ToolStripStatusLabel();
            this.PaintBox = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.controlPanel.SuspendLayout();
            this.saveAs.SuspendLayout();
            this.otherSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionZNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.degreesNumeric)).BeginInit();
            this.colorsThickness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThicknessNumeric)).BeginInit();
            this.paintTools.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaintBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1601, 81);
            this.label1.TabIndex = 0;
            this.label1.Text = "Basic Paint";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.saveAs);
            this.controlPanel.Controls.Add(this.otherSettings);
            this.controlPanel.Controls.Add(this.colorsThickness);
            this.controlPanel.Controls.Add(this.paintTools);
            this.controlPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.controlPanel.Location = new System.Drawing.Point(12, 93);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(1601, 203);
            this.controlPanel.TabIndex = 1;
            this.controlPanel.TabStop = false;
            this.controlPanel.Text = "Control Panel";
            // 
            // saveAs
            // 
            this.saveAs.Controls.Add(this.CheckBoxInclBrush);
            this.saveAs.Controls.Add(this.buttonLoadCSV);
            this.saveAs.Controls.Add(this.buttonExportJPG);
            this.saveAs.Controls.Add(this.buttonExportCSV);
            this.saveAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveAs.Location = new System.Drawing.Point(1232, 36);
            this.saveAs.Name = "saveAs";
            this.saveAs.Size = new System.Drawing.Size(357, 154);
            this.saveAs.TabIndex = 4;
            this.saveAs.TabStop = false;
            this.saveAs.Text = "Save / Open";
            // 
            // CheckBoxInclBrush
            // 
            this.CheckBoxInclBrush.Checked = true;
            this.CheckBoxInclBrush.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxInclBrush.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CheckBoxInclBrush.Location = new System.Drawing.Point(10, 89);
            this.CheckBoxInclBrush.Name = "CheckBoxInclBrush";
            this.CheckBoxInclBrush.Size = new System.Drawing.Size(174, 54);
            this.CheckBoxInclBrush.TabIndex = 10;
            this.CheckBoxInclBrush.Text = "Include brush in CSV file";
            this.toolTip.SetToolTip(this.CheckBoxInclBrush, "If checked, drawings with brush will be exported.\r\nBut remember, brush drawings r" +
        "equire much more lines in your CSV file, so it may be bigger.");
            this.CheckBoxInclBrush.UseVisualStyleBackColor = true;
            // 
            // buttonLoadCSV
            // 
            this.buttonLoadCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLoadCSV.Location = new System.Drawing.Point(190, 31);
            this.buttonLoadCSV.Name = "buttonLoadCSV";
            this.buttonLoadCSV.Size = new System.Drawing.Size(157, 52);
            this.buttonLoadCSV.TabIndex = 2;
            this.buttonLoadCSV.Text = "Load CSV";
            this.toolTip.SetToolTip(this.buttonLoadCSV, "Loads image from CSV file.\r\nOnly CSV files made with this application will work.");
            this.buttonLoadCSV.UseVisualStyleBackColor = true;
            this.buttonLoadCSV.Click += new System.EventHandler(this.buttonLoadCSV_Click);
            // 
            // buttonExportJPG
            // 
            this.buttonExportJPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonExportJPG.Location = new System.Drawing.Point(190, 91);
            this.buttonExportJPG.Name = "buttonExportJPG";
            this.buttonExportJPG.Size = new System.Drawing.Size(157, 52);
            this.buttonExportJPG.TabIndex = 1;
            this.buttonExportJPG.Text = "Export to JPEG";
            this.toolTip.SetToolTip(this.buttonExportJPG, "Exports the current image to JPEG.\r\nBe aware that JPEG can\'t be edited afterwards" +
        ".");
            this.buttonExportJPG.UseVisualStyleBackColor = true;
            // 
            // buttonExportCSV
            // 
            this.buttonExportCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonExportCSV.Location = new System.Drawing.Point(10, 31);
            this.buttonExportCSV.Name = "buttonExportCSV";
            this.buttonExportCSV.Size = new System.Drawing.Size(174, 52);
            this.buttonExportCSV.TabIndex = 0;
            this.buttonExportCSV.Text = "Export to CSV";
            this.toolTip.SetToolTip(this.buttonExportCSV, "Exports the current image to a CSV file.");
            this.buttonExportCSV.UseVisualStyleBackColor = true;
            this.buttonExportCSV.Click += new System.EventHandler(this.buttonExportCSV_Click);
            // 
            // otherSettings
            // 
            this.otherSettings.Controls.Add(this.positionZNumeric);
            this.otherSettings.Controls.Add(this.label2);
            this.otherSettings.Controls.Add(this.buttonDelete);
            this.otherSettings.Controls.Add(this.degreesNumeric);
            this.otherSettings.Controls.Add(this.buttonRotate);
            this.otherSettings.Controls.Add(this.checkboxLockObjects);
            this.otherSettings.Controls.Add(this.buttonClear);
            this.otherSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.otherSettings.Location = new System.Drawing.Point(731, 36);
            this.otherSettings.Name = "otherSettings";
            this.otherSettings.Size = new System.Drawing.Size(486, 154);
            this.otherSettings.TabIndex = 3;
            this.otherSettings.TabStop = false;
            this.otherSettings.Text = "Other Tools";
            // 
            // positionZNumeric
            // 
            this.positionZNumeric.Location = new System.Drawing.Point(305, 70);
            this.positionZNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.positionZNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.positionZNumeric.Name = "positionZNumeric";
            this.positionZNumeric.Size = new System.Drawing.Size(163, 31);
            this.positionZNumeric.TabIndex = 11;
            this.positionZNumeric.Tag = "";
            this.positionZNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.positionZNumeric, "Specifies the object position on the Z axis.\r\nIt can be useful when you want some" +
        " object to be drawn over the other.");
            this.positionZNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Position - Z axis";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(10, 96);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(125, 47);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Delete";
            this.toolTip.SetToolTip(this.buttonDelete, "Deletes currently selected object.");
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // degreesNumeric
            // 
            this.degreesNumeric.Location = new System.Drawing.Point(152, 110);
            this.degreesNumeric.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.degreesNumeric.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.degreesNumeric.Name = "degreesNumeric";
            this.degreesNumeric.Size = new System.Drawing.Size(125, 31);
            this.degreesNumeric.TabIndex = 8;
            this.degreesNumeric.Tag = "";
            this.degreesNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.degreesNumeric, "Here you can specify by how many degrees the selected object will rotate. \r\nIncre" +
        "ments can be both negative and positive. \r\nThe range is from -90° to 90°.");
            // 
            // buttonRotate
            // 
            this.buttonRotate.Location = new System.Drawing.Point(152, 34);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(125, 67);
            this.buttonRotate.TabIndex = 2;
            this.buttonRotate.Text = "Rotate";
            this.toolTip.SetToolTip(this.buttonRotate, "Rotates currently selected object by specified increments in the control below.");
            this.buttonRotate.UseVisualStyleBackColor = true;
            // 
            // checkboxLockObjects
            // 
            this.checkboxLockObjects.AutoSize = true;
            this.checkboxLockObjects.Location = new System.Drawing.Point(305, 110);
            this.checkboxLockObjects.Name = "checkboxLockObjects";
            this.checkboxLockObjects.Size = new System.Drawing.Size(163, 29);
            this.checkboxLockObjects.TabIndex = 1;
            this.checkboxLockObjects.Text = "Lock Objects";
            this.toolTip.SetToolTip(this.checkboxLockObjects, "Locks all objects in the picture.\r\nThis means that you won\'t be able to select no" +
        "r edit any object in the picture.");
            this.checkboxLockObjects.UseVisualStyleBackColor = true;
            this.checkboxLockObjects.CheckedChanged += new System.EventHandler(this.checkboxLockObjects_CheckedChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(10, 34);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(125, 49);
            this.buttonClear.TabIndex = 0;
            this.buttonClear.Text = "Clear!";
            this.toolTip.SetToolTip(this.buttonClear, "Deletes every object in the picture and resets colors to defaults.");
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // colorsThickness
            // 
            this.colorsThickness.Controls.Add(this.tipThickness);
            this.colorsThickness.Controls.Add(this.ThicknessNumeric);
            this.colorsThickness.Controls.Add(this.labelThickness);
            this.colorsThickness.Controls.Add(this.buttonBackgroundColor);
            this.colorsThickness.Controls.Add(this.buttonForegroundColor);
            this.colorsThickness.Controls.Add(this.labelForegroundColor);
            this.colorsThickness.Controls.Add(this.labelBackgrColor);
            this.colorsThickness.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.colorsThickness.Location = new System.Drawing.Point(319, 36);
            this.colorsThickness.Name = "colorsThickness";
            this.colorsThickness.Size = new System.Drawing.Size(395, 154);
            this.colorsThickness.TabIndex = 2;
            this.colorsThickness.TabStop = false;
            this.colorsThickness.Text = "Colors and Thickness";
            // 
            // tipThickness
            // 
            this.tipThickness.AutoSize = true;
            this.tipThickness.Location = new System.Drawing.Point(283, 114);
            this.tipThickness.Name = "tipThickness";
            this.tipThickness.Size = new System.Drawing.Size(67, 25);
            this.tipThickness.TabIndex = 7;
            this.tipThickness.Text = "1-100";
            // 
            // ThicknessNumeric
            // 
            this.ThicknessNumeric.Location = new System.Drawing.Point(266, 72);
            this.ThicknessNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThicknessNumeric.Name = "ThicknessNumeric";
            this.ThicknessNumeric.Size = new System.Drawing.Size(108, 31);
            this.ThicknessNumeric.TabIndex = 6;
            this.ThicknessNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.ThicknessNumeric, "Thickness of the object border ranging from 1px to 100pxs.");
            this.ThicknessNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThicknessNumeric.ValueChanged += new System.EventHandler(this.ThicknessNumeric_ValueChanged);
            // 
            // labelThickness
            // 
            this.labelThickness.AutoSize = true;
            this.labelThickness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelThickness.Location = new System.Drawing.Point(261, 34);
            this.labelThickness.Name = "labelThickness";
            this.labelThickness.Size = new System.Drawing.Size(102, 25);
            this.labelThickness.TabIndex = 5;
            this.labelThickness.Text = "Thickness";
            this.labelThickness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonBackgroundColor
            // 
            this.buttonBackgroundColor.BackColor = System.Drawing.Color.White;
            this.buttonBackgroundColor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonBackgroundColor.FlatAppearance.BorderSize = 0;
            this.buttonBackgroundColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonBackgroundColor.Location = new System.Drawing.Point(10, 70);
            this.buttonBackgroundColor.Name = "buttonBackgroundColor";
            this.buttonBackgroundColor.Size = new System.Drawing.Size(108, 71);
            this.buttonBackgroundColor.TabIndex = 4;
            this.toolTip.SetToolTip(this.buttonBackgroundColor, "Shows currently selected background color.\r\nWhen clicked, you will be able to cha" +
        "nge it.\r\n");
            this.buttonBackgroundColor.UseVisualStyleBackColor = false;
            this.buttonBackgroundColor.Click += new System.EventHandler(this.buttonBackgroundColor_Click);
            // 
            // buttonForegroundColor
            // 
            this.buttonForegroundColor.BackColor = System.Drawing.Color.Black;
            this.buttonForegroundColor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonForegroundColor.FlatAppearance.BorderSize = 0;
            this.buttonForegroundColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonForegroundColor.Location = new System.Drawing.Point(136, 70);
            this.buttonForegroundColor.Name = "buttonForegroundColor";
            this.buttonForegroundColor.Size = new System.Drawing.Size(108, 71);
            this.buttonForegroundColor.TabIndex = 3;
            this.toolTip.SetToolTip(this.buttonForegroundColor, "Shows currently selected foreground (tool) color.\r\nWhen clicked, you will be able" +
        " to change it.");
            this.buttonForegroundColor.UseVisualStyleBackColor = false;
            this.buttonForegroundColor.Click += new System.EventHandler(this.buttonForegroundColor_Click);
            // 
            // labelForegroundColor
            // 
            this.labelForegroundColor.AutoSize = true;
            this.labelForegroundColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelForegroundColor.Location = new System.Drawing.Point(135, 34);
            this.labelForegroundColor.Name = "labelForegroundColor";
            this.labelForegroundColor.Size = new System.Drawing.Size(113, 25);
            this.labelForegroundColor.TabIndex = 2;
            this.labelForegroundColor.Text = "Foreground";
            this.labelForegroundColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBackgrColor
            // 
            this.labelBackgrColor.AutoSize = true;
            this.labelBackgrColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBackgrColor.Location = new System.Drawing.Point(6, 34);
            this.labelBackgrColor.Name = "labelBackgrColor";
            this.labelBackgrColor.Size = new System.Drawing.Size(117, 25);
            this.labelBackgrColor.TabIndex = 0;
            this.labelBackgrColor.Text = "Background";
            this.labelBackgrColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paintTools
            // 
            this.paintTools.Controls.Add(this.EraserButton);
            this.paintTools.Controls.Add(this.BucketButton);
            this.paintTools.Controls.Add(this.CircleButton);
            this.paintTools.Controls.Add(this.BoxButton);
            this.paintTools.Controls.Add(this.BrushButton);
            this.paintTools.Controls.Add(this.LineButton);
            this.paintTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.paintTools.Location = new System.Drawing.Point(13, 36);
            this.paintTools.Name = "paintTools";
            this.paintTools.Size = new System.Drawing.Size(292, 154);
            this.paintTools.TabIndex = 1;
            this.paintTools.TabStop = false;
            this.paintTools.Text = "Paint tools";
            // 
            // EraserButton
            // 
            this.EraserButton.AutoSize = true;
            this.EraserButton.Location = new System.Drawing.Point(159, 112);
            this.EraserButton.Name = "EraserButton";
            this.EraserButton.Size = new System.Drawing.Size(100, 29);
            this.EraserButton.TabIndex = 5;
            this.EraserButton.Text = "Eraser";
            this.toolTip.SetToolTip(this.EraserButton, "Erases whole objects, or part of a drawing.");
            this.EraserButton.UseVisualStyleBackColor = true;
            this.EraserButton.CheckedChanged += new System.EventHandler(this.EraserButton_CheckedChanged);
            // 
            // BucketButton
            // 
            this.BucketButton.AutoSize = true;
            this.BucketButton.Location = new System.Drawing.Point(159, 72);
            this.BucketButton.Name = "BucketButton";
            this.BucketButton.Size = new System.Drawing.Size(103, 29);
            this.BucketButton.TabIndex = 4;
            this.BucketButton.Text = "Bucket";
            this.toolTip.SetToolTip(this.BucketButton, "Fills closed object with specified (foreground) color.");
            this.BucketButton.UseVisualStyleBackColor = true;
            this.BucketButton.CheckedChanged += new System.EventHandler(this.EraserButton_CheckedChanged);
            // 
            // CircleButton
            // 
            this.CircleButton.AutoSize = true;
            this.CircleButton.Location = new System.Drawing.Point(159, 30);
            this.CircleButton.Name = "CircleButton";
            this.CircleButton.Size = new System.Drawing.Size(92, 29);
            this.CircleButton.TabIndex = 3;
            this.CircleButton.Text = "Circle";
            this.toolTip.SetToolTip(this.CircleButton, "Draws a circle in the picture. \r\nYou can also edit the circle and get an Ellipse." +
        "");
            this.CircleButton.UseVisualStyleBackColor = true;
            this.CircleButton.CheckedChanged += new System.EventHandler(this.EraserButton_CheckedChanged);
            // 
            // BoxButton
            // 
            this.BoxButton.AutoSize = true;
            this.BoxButton.Location = new System.Drawing.Point(12, 112);
            this.BoxButton.Name = "BoxButton";
            this.BoxButton.Size = new System.Drawing.Size(74, 29);
            this.BoxButton.TabIndex = 2;
            this.BoxButton.Text = "Box";
            this.toolTip.SetToolTip(this.BoxButton, "Creates a box.");
            this.BoxButton.UseVisualStyleBackColor = true;
            this.BoxButton.CheckedChanged += new System.EventHandler(this.EraserButton_CheckedChanged);
            // 
            // BrushButton
            // 
            this.BrushButton.AutoSize = true;
            this.BrushButton.Location = new System.Drawing.Point(12, 72);
            this.BrushButton.Name = "BrushButton";
            this.BrushButton.Size = new System.Drawing.Size(93, 29);
            this.BrushButton.TabIndex = 1;
            this.BrushButton.Text = "Brush";
            this.toolTip.SetToolTip(this.BrushButton, "Creates a freehand drawing.");
            this.BrushButton.UseVisualStyleBackColor = true;
            this.BrushButton.CheckedChanged += new System.EventHandler(this.EraserButton_CheckedChanged);
            // 
            // LineButton
            // 
            this.LineButton.AutoSize = true;
            this.LineButton.Checked = true;
            this.LineButton.Location = new System.Drawing.Point(12, 30);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(141, 29);
            this.LineButton.TabIndex = 0;
            this.LineButton.TabStop = true;
            this.LineButton.Text = "Line/Curve";
            this.toolTip.SetToolTip(this.LineButton, "Creates a line.\r\nWhen you edit the line, you can create a curve.");
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.CheckedChanged += new System.EventHandler(this.EraserButton_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedObject,
            this.mousePosX,
            this.mousePosY});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1213);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1628, 50);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // selectedObject
            // 
            this.selectedObject.Name = "selectedObject";
            this.selectedObject.Size = new System.Drawing.Size(152, 41);
            this.selectedObject.Text = "SelectedObject";
            // 
            // mousePosX
            // 
            this.mousePosX.Name = "mousePosX";
            this.mousePosX.Size = new System.Drawing.Size(57, 41);
            this.mousePosX.Text = "PosX";
            // 
            // mousePosY
            // 
            this.mousePosY.Name = "mousePosY";
            this.mousePosY.Size = new System.Drawing.Size(57, 41);
            this.mousePosY.Text = "PosY";
            // 
            // PaintBox
            // 
            this.PaintBox.BackColor = System.Drawing.Color.White;
            this.PaintBox.Location = new System.Drawing.Point(13, 310);
            this.PaintBox.Name = "PaintBox";
            this.PaintBox.Size = new System.Drawing.Size(1600, 900);
            this.PaintBox.TabIndex = 4;
            this.PaintBox.TabStop = false;
            this.PaintBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBox_Paint);
            this.PaintBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PaintBox_MouseDown);
            this.PaintBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PaintBox_MouseMove);
            this.PaintBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PaintBox_MouseUp);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 5;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Title = "Save your CSV drawing";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "drawing.csv";
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1628, 1263);
            this.Controls.Add(this.PaintBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PaintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaintForm";
            this.Load += new System.EventHandler(this.PaintForm_Load);
            this.controlPanel.ResumeLayout(false);
            this.saveAs.ResumeLayout(false);
            this.otherSettings.ResumeLayout(false);
            this.otherSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionZNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.degreesNumeric)).EndInit();
            this.colorsThickness.ResumeLayout(false);
            this.colorsThickness.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThicknessNumeric)).EndInit();
            this.paintTools.ResumeLayout(false);
            this.paintTools.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaintBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox controlPanel;
        private System.Windows.Forms.GroupBox paintTools;
        private System.Windows.Forms.RadioButton LineButton;
        private System.Windows.Forms.GroupBox saveAs;
        private System.Windows.Forms.GroupBox otherSettings;
        private System.Windows.Forms.GroupBox colorsThickness;
        private System.Windows.Forms.RadioButton EraserButton;
        private System.Windows.Forms.RadioButton BucketButton;
        private System.Windows.Forms.RadioButton CircleButton;
        private System.Windows.Forms.RadioButton BoxButton;
        private System.Windows.Forms.RadioButton BrushButton;
        private System.Windows.Forms.Button buttonLoadCSV;
        private System.Windows.Forms.Button buttonExportJPG;
        private System.Windows.Forms.Button buttonExportCSV;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox PaintBox;
        private System.Windows.Forms.Button buttonForegroundColor;
        private System.Windows.Forms.Label labelForegroundColor;
        private System.Windows.Forms.Label labelBackgrColor;
        private System.Windows.Forms.NumericUpDown ThicknessNumeric;
        private System.Windows.Forms.Label labelThickness;
        private System.Windows.Forms.Button buttonBackgroundColor;
        private System.Windows.Forms.Label tipThickness;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.NumericUpDown degreesNumeric;
        private System.Windows.Forms.Button buttonRotate;
        private System.Windows.Forms.CheckBox checkboxLockObjects;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ToolStripStatusLabel selectedObject;
        private System.Windows.Forms.CheckBox CheckBoxInclBrush;
        private System.Windows.Forms.ToolStripStatusLabel mousePosX;
        private System.Windows.Forms.ToolStripStatusLabel mousePosY;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NumericUpDown positionZNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}