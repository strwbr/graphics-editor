namespace graphics_editor
{
    partial class Form1
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
            this.drawSegmentBtn = new System.Windows.Forms.Button();
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
            this.colorDialogBtn.Location = new System.Drawing.Point(160, 24);
            this.colorDialogBtn.Name = "colorDialogBtn";
            this.colorDialogBtn.Size = new System.Drawing.Size(75, 23);
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
            this.settingColorBox.Location = new System.Drawing.Point(12, 641);
            this.settingColorBox.Name = "settingColorBox";
            this.settingColorBox.Size = new System.Drawing.Size(251, 141);
            this.settingColorBox.TabIndex = 1;
            this.settingColorBox.TabStop = false;
            this.settingColorBox.Text = "Цвет";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
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
            this.standartColorsPanel.Location = new System.Drawing.Point(6, 22);
            this.standartColorsPanel.Name = "standartColorsPanel";
            this.standartColorsPanel.Size = new System.Drawing.Size(136, 27);
            this.standartColorsPanel.TabIndex = 1;
            // 
            // redBtn
            // 
            this.redBtn.BackColor = System.Drawing.Color.Red;
            this.redBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.redBtn.Location = new System.Drawing.Point(3, 3);
            this.redBtn.Name = "redBtn";
            this.redBtn.Size = new System.Drawing.Size(20, 20);
            this.redBtn.TabIndex = 0;
            this.redBtn.UseVisualStyleBackColor = false;
            this.redBtn.Click += new System.EventHandler(this.RedBtn_Click);
            // 
            // yellowBtn
            // 
            this.yellowBtn.BackColor = System.Drawing.Color.Yellow;
            this.yellowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yellowBtn.Location = new System.Drawing.Point(29, 3);
            this.yellowBtn.Name = "yellowBtn";
            this.yellowBtn.Size = new System.Drawing.Size(20, 20);
            this.yellowBtn.TabIndex = 1;
            this.yellowBtn.UseVisualStyleBackColor = false;
            this.yellowBtn.Click += new System.EventHandler(this.YellowBtn_Click);
            // 
            // greenBtn
            // 
            this.greenBtn.BackColor = System.Drawing.Color.Green;
            this.greenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.greenBtn.Location = new System.Drawing.Point(55, 3);
            this.greenBtn.Name = "greenBtn";
            this.greenBtn.Size = new System.Drawing.Size(20, 20);
            this.greenBtn.TabIndex = 2;
            this.greenBtn.UseVisualStyleBackColor = false;
            this.greenBtn.Click += new System.EventHandler(this.GreenBtn_Click);
            // 
            // blueBtn
            // 
            this.blueBtn.BackColor = System.Drawing.Color.Blue;
            this.blueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blueBtn.Location = new System.Drawing.Point(81, 3);
            this.blueBtn.Name = "blueBtn";
            this.blueBtn.Size = new System.Drawing.Size(20, 20);
            this.blueBtn.TabIndex = 3;
            this.blueBtn.UseVisualStyleBackColor = false;
            this.blueBtn.Click += new System.EventHandler(this.BlueBtn_Click);
            // 
            // whiteBtn
            // 
            this.whiteBtn.BackColor = System.Drawing.Color.White;
            this.whiteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.whiteBtn.Location = new System.Drawing.Point(107, 3);
            this.whiteBtn.Name = "whiteBtn";
            this.whiteBtn.Size = new System.Drawing.Size(20, 20);
            this.whiteBtn.TabIndex = 4;
            this.whiteBtn.UseVisualStyleBackColor = false;
            this.whiteBtn.Click += new System.EventHandler(this.WhiteBtn_Click);
            // 
            // currentColorPanel
            // 
            this.currentColorPanel.Location = new System.Drawing.Point(6, 87);
            this.currentColorPanel.Name = "currentColorPanel";
            this.currentColorPanel.Size = new System.Drawing.Size(136, 35);
            this.currentColorPanel.TabIndex = 5;
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingPanel.Location = new System.Drawing.Point(395, 34);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(1362, 748);
            this.drawingPanel.TabIndex = 2;
            this.drawingPanel.TabStop = false;
            this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseDown);
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
            // 
            // drawSegmentBtn
            // 
            this.drawSegmentBtn.Location = new System.Drawing.Point(12, 34);
            this.drawSegmentBtn.Name = "drawSegmentBtn";
            this.drawSegmentBtn.Size = new System.Drawing.Size(75, 23);
            this.drawSegmentBtn.TabIndex = 3;
            this.drawSegmentBtn.Text = "Отрезок";
            this.drawSegmentBtn.UseVisualStyleBackColor = true;
            this.drawSegmentBtn.Click += new System.EventHandler(this.DrawSegmentBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1784, 811);
            this.Controls.Add(this.drawSegmentBtn);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.settingColorBox);
            this.Name = "Form1";
            this.Text = "Графический редактор | Вариант 7";
            this.settingColorBox.ResumeLayout(false);
            this.settingColorBox.PerformLayout();
            this.standartColorsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawingPanel)).EndInit();
            this.ResumeLayout(false);

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
        private Button drawSegmentBtn;
    }
}