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
            this.blackBtn = new System.Windows.Forms.Button();
            this.currentColorPanel = new System.Windows.Forms.Panel();
            this.clearPanelBtn = new System.Windows.Forms.Button();
            this.tmoCb = new System.Windows.Forms.ComboBox();
            this.tmoBtn = new System.Windows.Forms.Button();
            this.debugLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rotationTb = new System.Windows.Forms.TrackBar();
            this.rotationAngleMode = new System.Windows.Forms.CheckBox();
            this.deleteFigureBtn = new System.Windows.Forms.Button();
            this.selectFigureBtn = new System.Windows.Forms.Button();
            this.arrow2Btn = new System.Windows.Forms.Button();
            this.arrow1Btn = new System.Windows.Forms.Button();
            this.bezierBtn = new System.Windows.Forms.Button();
            this.segmentBtn = new System.Windows.Forms.Button();
            this.drawingPanel = new System.Windows.Forms.PictureBox();
            this.rotatoinControlsPanel = new System.Windows.Forms.Panel();
            this.settingColorBox.SuspendLayout();
            this.standartColorsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotationTb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawingPanel)).BeginInit();
            this.rotatoinControlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // colorDialogBtn
            // 
            this.colorDialogBtn.AutoSize = true;
            this.colorDialogBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorDialogBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colorDialogBtn.Location = new System.Drawing.Point(204, 29);
            this.colorDialogBtn.Name = "colorDialogBtn";
            this.colorDialogBtn.Size = new System.Drawing.Size(90, 30);
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
            this.settingColorBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingColorBox.Location = new System.Drawing.Point(10, 473);
            this.settingColorBox.Name = "settingColorBox";
            this.settingColorBox.Size = new System.Drawing.Size(309, 149);
            this.settingColorBox.TabIndex = 1;
            this.settingColorBox.TabStop = false;
            this.settingColorBox.Text = "Цвет";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выбранный цвет";
            // 
            // standartColorsPanel
            // 
            this.standartColorsPanel.AutoSize = true;
            this.standartColorsPanel.Controls.Add(this.redBtn);
            this.standartColorsPanel.Controls.Add(this.yellowBtn);
            this.standartColorsPanel.Controls.Add(this.greenBtn);
            this.standartColorsPanel.Controls.Add(this.blueBtn);
            this.standartColorsPanel.Controls.Add(this.blackBtn);
            this.standartColorsPanel.Location = new System.Drawing.Point(5, 26);
            this.standartColorsPanel.Name = "standartColorsPanel";
            this.standartColorsPanel.Size = new System.Drawing.Size(185, 42);
            this.standartColorsPanel.TabIndex = 1;
            // 
            // redBtn
            // 
            this.redBtn.BackColor = System.Drawing.Color.Red;
            this.redBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.redBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.redBtn.Location = new System.Drawing.Point(3, 3);
            this.redBtn.Name = "redBtn";
            this.redBtn.Size = new System.Drawing.Size(30, 30);
            this.redBtn.TabIndex = 0;
            this.redBtn.UseVisualStyleBackColor = false;
            this.redBtn.Click += new System.EventHandler(this.RedBtn_Click);
            // 
            // yellowBtn
            // 
            this.yellowBtn.BackColor = System.Drawing.Color.Yellow;
            this.yellowBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yellowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yellowBtn.Location = new System.Drawing.Point(39, 3);
            this.yellowBtn.Name = "yellowBtn";
            this.yellowBtn.Size = new System.Drawing.Size(30, 30);
            this.yellowBtn.TabIndex = 1;
            this.yellowBtn.UseVisualStyleBackColor = false;
            this.yellowBtn.Click += new System.EventHandler(this.YellowBtn_Click);
            // 
            // greenBtn
            // 
            this.greenBtn.BackColor = System.Drawing.Color.Green;
            this.greenBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.greenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.greenBtn.Location = new System.Drawing.Point(75, 3);
            this.greenBtn.Name = "greenBtn";
            this.greenBtn.Size = new System.Drawing.Size(30, 30);
            this.greenBtn.TabIndex = 2;
            this.greenBtn.UseVisualStyleBackColor = false;
            this.greenBtn.Click += new System.EventHandler(this.GreenBtn_Click);
            // 
            // blueBtn
            // 
            this.blueBtn.BackColor = System.Drawing.Color.Blue;
            this.blueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.blueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blueBtn.Location = new System.Drawing.Point(111, 3);
            this.blueBtn.Name = "blueBtn";
            this.blueBtn.Size = new System.Drawing.Size(30, 30);
            this.blueBtn.TabIndex = 3;
            this.blueBtn.UseVisualStyleBackColor = false;
            this.blueBtn.Click += new System.EventHandler(this.BlueBtn_Click);
            // 
            // blackBtn
            // 
            this.blackBtn.BackColor = System.Drawing.Color.Black;
            this.blackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.blackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blackBtn.Location = new System.Drawing.Point(147, 3);
            this.blackBtn.Name = "blackBtn";
            this.blackBtn.Size = new System.Drawing.Size(30, 30);
            this.blackBtn.TabIndex = 4;
            this.blackBtn.UseVisualStyleBackColor = false;
            this.blackBtn.Click += new System.EventHandler(this.BlackBtn_Click);
            // 
            // currentColorPanel
            // 
            this.currentColorPanel.Location = new System.Drawing.Point(6, 94);
            this.currentColorPanel.Name = "currentColorPanel";
            this.currentColorPanel.Size = new System.Drawing.Size(184, 40);
            this.currentColorPanel.TabIndex = 5;
            // 
            // clearPanelBtn
            // 
            this.clearPanelBtn.AutoSize = true;
            this.clearPanelBtn.BackColor = System.Drawing.Color.Transparent;
            this.clearPanelBtn.BackgroundImage = global::graphics_editor_cgs.Properties.Resources.clean;
            this.clearPanelBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.clearPanelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearPanelBtn.Location = new System.Drawing.Point(122, 141);
            this.clearPanelBtn.Name = "clearPanelBtn";
            this.clearPanelBtn.Size = new System.Drawing.Size(50, 50);
            this.clearPanelBtn.TabIndex = 12;
            this.clearPanelBtn.UseVisualStyleBackColor = false;
            this.clearPanelBtn.Click += new System.EventHandler(this.ClearPanelBtn_Click);
            this.clearPanelBtn.MouseEnter += new System.EventHandler(this.ClearPanelBtn_MouseEnter);
            // 
            // tmoCb
            // 
            this.tmoCb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmoCb.FormattingEnabled = true;
            this.tmoCb.Items.AddRange(new object[] {
            "Симметрическая разность",
            "Разность А/В",
            "Разность В/А"});
            this.tmoCb.Location = new System.Drawing.Point(10, 270);
            this.tmoCb.Name = "tmoCb";
            this.tmoCb.Size = new System.Drawing.Size(231, 28);
            this.tmoCb.TabIndex = 13;
            this.tmoCb.Text = "Выберите ТМО";
            this.tmoCb.Visible = false;
            this.tmoCb.SelectedIndexChanged += new System.EventHandler(this.TmoCb_SelectedIndexChanged);
            // 
            // tmoBtn
            // 
            this.tmoBtn.AutoSize = true;
            this.tmoBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tmoBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmoBtn.Location = new System.Drawing.Point(10, 234);
            this.tmoBtn.Name = "tmoBtn";
            this.tmoBtn.Size = new System.Drawing.Size(80, 30);
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
            this.debugLabel.Location = new System.Drawing.Point(783, 511);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(91, 21);
            this.debugLabel.TabIndex = 15;
            this.debugLabel.Text = "debugLabel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(979, 544);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 21);
            this.label5.TabIndex = 16;
            this.label5.Text = "label5";
            // 
            // rotationTb
            // 
            this.rotationTb.Location = new System.Drawing.Point(5, 3);
            this.rotationTb.Maximum = 360;
            this.rotationTb.Name = "rotationTb";
            this.rotationTb.Size = new System.Drawing.Size(231, 45);
            this.rotationTb.TabIndex = 17;
            this.rotationTb.Scroll += new System.EventHandler(this.RotationTb_Scroll);
            // 
            // rotationAngleMode
            // 
            this.rotationAngleMode.AutoSize = true;
            this.rotationAngleMode.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotationAngleMode.Location = new System.Drawing.Point(12, 54);
            this.rotationAngleMode.Name = "rotationAngleMode";
            this.rotationAngleMode.Size = new System.Drawing.Size(236, 24);
            this.rotationAngleMode.TabIndex = 18;
            this.rotationAngleMode.Text = "Поворачивать на 30 градусов";
            this.rotationAngleMode.UseVisualStyleBackColor = true;
            // 
            // deleteFigureBtn
            // 
            this.deleteFigureBtn.AutoSize = true;
            this.deleteFigureBtn.BackColor = System.Drawing.Color.Transparent;
            this.deleteFigureBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deleteFigureBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteFigureBtn.Image = global::graphics_editor_cgs.Properties.Resources.delete;
            this.deleteFigureBtn.Location = new System.Drawing.Point(66, 141);
            this.deleteFigureBtn.Name = "deleteFigureBtn";
            this.deleteFigureBtn.Size = new System.Drawing.Size(50, 50);
            this.deleteFigureBtn.TabIndex = 11;
            this.deleteFigureBtn.UseVisualStyleBackColor = false;
            this.deleteFigureBtn.Click += new System.EventHandler(this.DeleteFigureBtn_Click);
            this.deleteFigureBtn.MouseEnter += new System.EventHandler(this.DeleteFigureBtn_MouseEnter);
            // 
            // selectFigureBtn
            // 
            this.selectFigureBtn.AutoSize = true;
            this.selectFigureBtn.BackColor = System.Drawing.Color.Transparent;
            this.selectFigureBtn.BackgroundImage = global::graphics_editor_cgs.Properties.Resources.selection;
            this.selectFigureBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.selectFigureBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectFigureBtn.Location = new System.Drawing.Point(10, 141);
            this.selectFigureBtn.Name = "selectFigureBtn";
            this.selectFigureBtn.Size = new System.Drawing.Size(50, 50);
            this.selectFigureBtn.TabIndex = 10;
            this.selectFigureBtn.UseVisualStyleBackColor = false;
            this.selectFigureBtn.Click += new System.EventHandler(this.SelectFigureBtn_Click);
            this.selectFigureBtn.MouseEnter += new System.EventHandler(this.SelectFigureBtn_MouseEnter);
            // 
            // arrow2Btn
            // 
            this.arrow2Btn.AutoSize = true;
            this.arrow2Btn.BackColor = System.Drawing.Color.White;
            this.arrow2Btn.BackgroundImage = global::graphics_editor_cgs.Properties.Resources.arrow_left_right;
            this.arrow2Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.arrow2Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arrow2Btn.Location = new System.Drawing.Point(66, 69);
            this.arrow2Btn.Name = "arrow2Btn";
            this.arrow2Btn.Size = new System.Drawing.Size(50, 50);
            this.arrow2Btn.TabIndex = 9;
            this.arrow2Btn.UseVisualStyleBackColor = false;
            this.arrow2Btn.Click += new System.EventHandler(this.Arrow2Btn_Click);
            this.arrow2Btn.MouseEnter += new System.EventHandler(this.Arrow2Btn_MouseEnter);
            // 
            // arrow1Btn
            // 
            this.arrow1Btn.AutoSize = true;
            this.arrow1Btn.BackColor = System.Drawing.Color.White;
            this.arrow1Btn.BackgroundImage = global::graphics_editor_cgs.Properties.Resources.arrow_right;
            this.arrow1Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.arrow1Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arrow1Btn.Location = new System.Drawing.Point(10, 69);
            this.arrow1Btn.Name = "arrow1Btn";
            this.arrow1Btn.Size = new System.Drawing.Size(50, 50);
            this.arrow1Btn.TabIndex = 8;
            this.arrow1Btn.UseVisualStyleBackColor = false;
            this.arrow1Btn.Click += new System.EventHandler(this.Arrow1Btn_Click);
            this.arrow1Btn.MouseEnter += new System.EventHandler(this.Arrow1Btn_MouseEnter);
            // 
            // bezierBtn
            // 
            this.bezierBtn.AutoSize = true;
            this.bezierBtn.BackColor = System.Drawing.Color.White;
            this.bezierBtn.BackgroundImage = global::graphics_editor_cgs.Properties.Resources.line;
            this.bezierBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bezierBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bezierBtn.Location = new System.Drawing.Point(66, 12);
            this.bezierBtn.Name = "bezierBtn";
            this.bezierBtn.Size = new System.Drawing.Size(50, 50);
            this.bezierBtn.TabIndex = 7;
            this.bezierBtn.UseVisualStyleBackColor = false;
            this.bezierBtn.Click += new System.EventHandler(this.BezierBtn_Click);
            this.bezierBtn.MouseEnter += new System.EventHandler(this.BezierBtn_MouseEnter);
            // 
            // segmentBtn
            // 
            this.segmentBtn.BackColor = System.Drawing.Color.White;
            this.segmentBtn.BackgroundImage = global::graphics_editor_cgs.Properties.Resources.diagonal_line;
            this.segmentBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.segmentBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.segmentBtn.Location = new System.Drawing.Point(10, 12);
            this.segmentBtn.Name = "segmentBtn";
            this.segmentBtn.Size = new System.Drawing.Size(50, 50);
            this.segmentBtn.TabIndex = 3;
            this.segmentBtn.UseVisualStyleBackColor = false;
            this.segmentBtn.Click += new System.EventHandler(this.SegmentBtn_Click);
            this.segmentBtn.MouseEnter += new System.EventHandler(this.SegmentBtn_MouseEnter);
            // 
            // drawingPanel
            // 
            this.drawingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingPanel.Location = new System.Drawing.Point(284, 12);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(799, 455);
            this.drawingPanel.TabIndex = 2;
            this.drawingPanel.TabStop = false;
            this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseDown);
            this.drawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseMove);
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseUp);
            // 
            // rotatoinControlsPanel
            // 
            this.rotatoinControlsPanel.Controls.Add(this.rotationTb);
            this.rotatoinControlsPanel.Controls.Add(this.rotationAngleMode);
            this.rotatoinControlsPanel.Location = new System.Drawing.Point(10, 320);
            this.rotatoinControlsPanel.Name = "rotatoinControlsPanel";
            this.rotatoinControlsPanel.Size = new System.Drawing.Size(257, 93);
            this.rotatoinControlsPanel.TabIndex = 19;
            this.rotatoinControlsPanel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 637);
            this.Controls.Add(this.rotatoinControlsPanel);
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
            this.Controls.Add(this.segmentBtn);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.settingColorBox);
            this.Name = "MainForm";
            this.Text = "Графический редактор | Вариант 7";
            this.settingColorBox.ResumeLayout(false);
            this.settingColorBox.PerformLayout();
            this.standartColorsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rotationTb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawingPanel)).EndInit();
            this.rotatoinControlsPanel.ResumeLayout(false);
            this.rotatoinControlsPanel.PerformLayout();
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
        private Button blackBtn;
        private Panel currentColorPanel;
        private PictureBox drawingPanel;
        private Button segmentBtn;
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
        private TrackBar rotationTb;
        private CheckBox rotationAngleMode;
        private Panel rotatoinControlsPanel;
    }
}