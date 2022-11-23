using System.Windows.Forms;

namespace graphics_editor_cgs
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.colorDialogBtn = new System.Windows.Forms.Button();
            this.settingColorBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.standartColorsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.redBtn = new System.Windows.Forms.Button();
            this.yellowBtn = new System.Windows.Forms.Button();
            this.greenBtn = new System.Windows.Forms.Button();
            this.blueBtn = new System.Windows.Forms.Button();
            this.whiteBtn = new System.Windows.Forms.Button();
            this.currentColorPanel = new System.Windows.Forms.Panel();
            this.drawingPanel = new System.Windows.Forms.PictureBox();
            this.segmentBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bezierBtn = new System.Windows.Forms.Button();
            this.arrow1Btn = new System.Windows.Forms.Button();
            this.arrow2Btn = new System.Windows.Forms.Button();
            this.selectFigureBtn = new System.Windows.Forms.Button();
            this.deleteFigureBtn = new System.Windows.Forms.Button();
            this.clearPanelBtn = new System.Windows.Forms.Button();
            this.tmoCb = new System.Windows.Forms.ComboBox();
            this.tmoBtn = new System.Windows.Forms.Button();
            this.debugLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.settingColorBox.SuspendLayout();
            this.standartColorsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // colorDialogBtn
            // 
            this.colorDialogBtn.Location = new System.Drawing.Point(183, 26);
            this.colorDialogBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.colorDialogBtn.Name = "colorDialogBtn";
            this.colorDialogBtn.Size = new System.Drawing.Size(85, 25);
            this.colorDialogBtn.TabIndex = 0;
            this.colorDialogBtn.Text = "Больше";
            this.colorDialogBtn.UseVisualStyleBackColor = true;
            this.colorDialogBtn.Click += new System.EventHandler(this.ColorDialogBtn_Click);
            // 
            // settingColorBox
            // 
            this.settingColorBox.Controls.Add(this.label1);
            this.settingColorBox.Controls.Add(this.standartColorsPanel);
            this.settingColorBox.Controls.Add(this.colorDialogBtn);
            this.settingColorBox.Controls.Add(this.currentColorPanel);
            this.settingColorBox.Location = new System.Drawing.Point(16, 510);
            this.settingColorBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.settingColorBox.Name = "settingColorBox";
            this.settingColorBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.settingColorBox.Size = new System.Drawing.Size(287, 150);
            this.settingColorBox.TabIndex = 1;
            this.settingColorBox.TabStop = false;
            this.settingColorBox.Text = "Цвет";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выбранный цвет";
            // 
            // standartColorsPanel
            // 
            this.standartColorsPanel.Controls.Add(this.redBtn);
            this.standartColorsPanel.Controls.Add(this.yellowBtn);
            this.standartColorsPanel.Controls.Add(this.greenBtn);
            this.standartColorsPanel.Controls.Add(this.blueBtn);
            this.standartColorsPanel.Controls.Add(this.whiteBtn);
            this.standartColorsPanel.Location = new System.Drawing.Point(7, 23);
            this.standartColorsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.standartColorsPanel.Name = "standartColorsPanel";
            this.standartColorsPanel.Size = new System.Drawing.Size(156, 28);
            this.standartColorsPanel.TabIndex = 1;
            // 
            // redBtn
            // 
            this.redBtn.BackColor = System.Drawing.Color.Red;
            this.redBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.redBtn.Location = new System.Drawing.Point(4, 4);
            this.redBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.redBtn.Name = "redBtn";
            this.redBtn.Size = new System.Drawing.Size(23, 21);
            this.redBtn.TabIndex = 0;
            this.redBtn.UseVisualStyleBackColor = false;
            this.redBtn.Click += new System.EventHandler(this.RedBtn_Click);
            // 
            // yellowBtn
            // 
            this.yellowBtn.BackColor = System.Drawing.Color.Yellow;
            this.yellowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yellowBtn.Location = new System.Drawing.Point(35, 4);
            this.yellowBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.yellowBtn.Name = "yellowBtn";
            this.yellowBtn.Size = new System.Drawing.Size(23, 21);
            this.yellowBtn.TabIndex = 1;
            this.yellowBtn.UseVisualStyleBackColor = false;
            this.yellowBtn.Click += new System.EventHandler(this.YellowBtn_Click);
            // 
            // greenBtn
            // 
            this.greenBtn.BackColor = System.Drawing.Color.Green;
            this.greenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.greenBtn.Location = new System.Drawing.Point(66, 4);
            this.greenBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.greenBtn.Name = "greenBtn";
            this.greenBtn.Size = new System.Drawing.Size(23, 21);
            this.greenBtn.TabIndex = 2;
            this.greenBtn.UseVisualStyleBackColor = false;
            this.greenBtn.Click += new System.EventHandler(this.GreenBtn_Click);
            // 
            // blueBtn
            // 
            this.blueBtn.BackColor = System.Drawing.Color.Blue;
            this.blueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blueBtn.Location = new System.Drawing.Point(97, 4);
            this.blueBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.blueBtn.Name = "blueBtn";
            this.blueBtn.Size = new System.Drawing.Size(23, 21);
            this.blueBtn.TabIndex = 3;
            this.blueBtn.UseVisualStyleBackColor = false;
            this.blueBtn.Click += new System.EventHandler(this.BlueBtn_Click);
            // 
            // whiteBtn
            // 
            this.whiteBtn.BackColor = System.Drawing.Color.White;
            this.whiteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.whiteBtn.Location = new System.Drawing.Point(128, 4);
            this.whiteBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.whiteBtn.Name = "whiteBtn";
            this.whiteBtn.Size = new System.Drawing.Size(23, 21);
            this.whiteBtn.TabIndex = 4;
            this.whiteBtn.UseVisualStyleBackColor = false;
            this.whiteBtn.Click += new System.EventHandler(this.WhiteBtn_Click);
            // 
            // currentColorPanel
            // 
            this.currentColorPanel.Location = new System.Drawing.Point(7, 92);
            this.currentColorPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.currentColorPanel.Name = "currentColorPanel";
            this.currentColorPanel.Size = new System.Drawing.Size(156, 37);
            this.currentColorPanel.TabIndex = 5;
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingPanel.Location = new System.Drawing.Point(352, 15);
            this.drawingPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(939, 454);
            this.drawingPanel.TabIndex = 2;
            this.drawingPanel.TabStop = false;
            this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseDown);
            // 
            // segmentBtn
            // 
            this.segmentBtn.Location = new System.Drawing.Point(13, 12);
            this.segmentBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.segmentBtn.Name = "segmentBtn";
            this.segmentBtn.Size = new System.Drawing.Size(107, 25);
            this.segmentBtn.TabIndex = 3;
            this.segmentBtn.Text = "Отрезок";
            this.segmentBtn.UseVisualStyleBackColor = true;
            this.segmentBtn.Click += new System.EventHandler(this.SegmentBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 510);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Безье, стрелка1, стрелка2, отрезок";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(363, 537);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 79);
            this.label3.TabIndex = 5;
            this.label3.Text = "Поворот вокруг з.ц. на произвольный угол, на 30 гр., масштабирование относительно" +
    " ц.ф. по Х, перемещение";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 615);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(375, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "ТМО: симметрическая разность, разность А/В и В/А (?)";
            // 
            // bezierBtn
            // 
            this.bezierBtn.AutoSize = true;
            this.bezierBtn.Location = new System.Drawing.Point(13, 42);
            this.bezierBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bezierBtn.Name = "bezierBtn";
            this.bezierBtn.Size = new System.Drawing.Size(121, 28);
            this.bezierBtn.TabIndex = 7;
            this.bezierBtn.Text = "Прямая Безье";
            this.bezierBtn.UseVisualStyleBackColor = true;
            this.bezierBtn.Click += new System.EventHandler(this.BezierBtn_Click);
            // 
            // arrow1Btn
            // 
            this.arrow1Btn.AutoSize = true;
            this.arrow1Btn.Location = new System.Drawing.Point(13, 76);
            this.arrow1Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.arrow1Btn.Name = "arrow1Btn";
            this.arrow1Btn.Size = new System.Drawing.Size(107, 28);
            this.arrow1Btn.TabIndex = 8;
            this.arrow1Btn.Text = "Стрелка 1";
            this.arrow1Btn.UseVisualStyleBackColor = true;
            this.arrow1Btn.Click += new System.EventHandler(this.Arrow1Btn_Click);
            // 
            // arrow2Btn
            // 
            this.arrow2Btn.AutoSize = true;
            this.arrow2Btn.Location = new System.Drawing.Point(13, 110);
            this.arrow2Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.arrow2Btn.Name = "arrow2Btn";
            this.arrow2Btn.Size = new System.Drawing.Size(107, 28);
            this.arrow2Btn.TabIndex = 9;
            this.arrow2Btn.Text = "Стрелка 2";
            this.arrow2Btn.UseVisualStyleBackColor = true;
            this.arrow2Btn.Click += new System.EventHandler(this.Arrow2Btn_Click);
            // 
            // selectFigureBtn
            // 
            this.selectFigureBtn.AutoSize = true;
            this.selectFigureBtn.Location = new System.Drawing.Point(13, 176);
            this.selectFigureBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectFigureBtn.Name = "selectFigureBtn";
            this.selectFigureBtn.Size = new System.Drawing.Size(107, 28);
            this.selectFigureBtn.TabIndex = 10;
            this.selectFigureBtn.Text = "Выделить";
            this.selectFigureBtn.UseVisualStyleBackColor = true;
            this.selectFigureBtn.Click += new System.EventHandler(this.SelectFigureBtn_Click);
            // 
            // deleteFigureBtn
            // 
            this.deleteFigureBtn.AutoSize = true;
            this.deleteFigureBtn.Location = new System.Drawing.Point(13, 209);
            this.deleteFigureBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteFigureBtn.Name = "deleteFigureBtn";
            this.deleteFigureBtn.Size = new System.Drawing.Size(107, 28);
            this.deleteFigureBtn.TabIndex = 11;
            this.deleteFigureBtn.Text = "Удалить";
            this.deleteFigureBtn.UseVisualStyleBackColor = true;
            this.deleteFigureBtn.Click += new System.EventHandler(this.DeleteFigureBtn_Click);
            // 
            // clearPanelBtn
            // 
            this.clearPanelBtn.AutoSize = true;
            this.clearPanelBtn.Location = new System.Drawing.Point(13, 242);
            this.clearPanelBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearPanelBtn.Name = "clearPanelBtn";
            this.clearPanelBtn.Size = new System.Drawing.Size(107, 28);
            this.clearPanelBtn.TabIndex = 12;
            this.clearPanelBtn.Text = "Очистить";
            this.clearPanelBtn.UseVisualStyleBackColor = true;
            this.clearPanelBtn.Click += new System.EventHandler(this.ClearPanelBtn_Click);
            // 
            // tmoCb
            // 
            this.tmoCb.Enabled = false;
            this.tmoCb.FormattingEnabled = true;
            this.tmoCb.Items.AddRange(new object[] {
            "Симметрическая разность",
            "Разность А/В",
            "Разность В/А"});
            this.tmoCb.Location = new System.Drawing.Point(13, 332);
            this.tmoCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tmoCb.Name = "tmoCb";
            this.tmoCb.Size = new System.Drawing.Size(207, 24);
            this.tmoCb.TabIndex = 13;
            this.tmoCb.Text = "Выберите ТМО";
            this.tmoCb.SelectedIndexChanged += new System.EventHandler(this.TmoCb_SelectedIndexChanged);
            // 
            // tmoBtn
            // 
            this.tmoBtn.AutoSize = true;
            this.tmoBtn.Location = new System.Drawing.Point(13, 300);
            this.tmoBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tmoBtn.Name = "tmoBtn";
            this.tmoBtn.Size = new System.Drawing.Size(107, 28);
            this.tmoBtn.TabIndex = 14;
            this.tmoBtn.Text = "ТМО";
            this.tmoBtn.UseVisualStyleBackColor = true;
            this.tmoBtn.Click += new System.EventHandler(this.TmoBtn_Click);
            // 
            // debugLabel
            // 
            this.debugLabel.AutoSize = true;
            this.debugLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.debugLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.debugLabel.Location = new System.Drawing.Point(771, 537);
            this.debugLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(115, 28);
            this.debugLabel.TabIndex = 15;
            this.debugLabel.Text = "debugLabel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(993, 510);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 28);
            this.label5.TabIndex = 16;
            this.label5.Text = "label5";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 678);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.debugLabel);
            this.Controls.Add(this.tmoBtn);
            this.Controls.Add(this.tmoCb);
            this.Controls.Add(this.clearPanelBtn);
            this.Controls.Add(this.deleteFigureBtn);
            this.Controls.Add(this.selectFigureBtn);
            this.Controls.Add(this.arrow2Btn);
            this.Controls.Add(this.arrow1Btn);
            this.Controls.Add(this.bezierBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.segmentBtn);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.settingColorBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Графический редактор | Вариант 7";
            this.settingColorBox.ResumeLayout(false);
            this.settingColorBox.PerformLayout();
            this.standartColorsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawingPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorDialog colorDialog;
        private Button colorDialogBtn;
        private GroupBox settingColorBox;
        private Label label1;
        private FlowLayoutPanel standartColorsPanel;
        private Button redBtn;
        private Button yellowBtn;
        private Button greenBtn;
        private Button blueBtn;
        private Button whiteBtn;
        private Panel currentColorPanel;
        private PictureBox drawingPanel;
        private Button segmentBtn;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button bezierBtn;
        private Button arrow1Btn;
        private Button arrow2Btn;
        private Button selectFigureBtn;
        private Button deleteFigureBtn;
        private Button clearPanelBtn;
        private ComboBox tmoCb;
        private Button tmoBtn;
        private Label debugLabel;
        private Label label5;
    }
}