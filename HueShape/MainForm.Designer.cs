using HueShape.CustomControls;

namespace HueShape
{
    partial class MainForm
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
            this.pnlShapeSelection = new System.Windows.Forms.Panel();
            this.rbRectangle = new System.Windows.Forms.RadioButton();
            this.rbCircle = new System.Windows.Forms.RadioButton();
            this.lblShapeSelection = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbFill = new System.Windows.Forms.RadioButton();
            this.rbOutlined = new System.Windows.Forms.RadioButton();
            this.lblEffect = new System.Windows.Forms.Label();
            this.msOptions = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pnlCanvas = new HueShape.CustomControls.DoubleBufferPanel();
            this.pnlBottomRightExtender = new System.Windows.Forms.Panel();
            this.lblColor = new System.Windows.Forms.Label();
            this.pnlShapeSelection.SuspendLayout();
            this.panel1.SuspendLayout();
            this.msOptions.SuspendLayout();
            this.pnlCanvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlShapeSelection
            // 
            this.pnlShapeSelection.Controls.Add(this.rbRectangle);
            this.pnlShapeSelection.Controls.Add(this.rbCircle);
            this.pnlShapeSelection.Controls.Add(this.lblShapeSelection);
            this.pnlShapeSelection.Location = new System.Drawing.Point(12, 33);
            this.pnlShapeSelection.Name = "pnlShapeSelection";
            this.pnlShapeSelection.Size = new System.Drawing.Size(249, 24);
            this.pnlShapeSelection.TabIndex = 4;
            // 
            // rbRectangle
            // 
            this.rbRectangle.AutoSize = true;
            this.rbRectangle.Location = new System.Drawing.Point(130, 1);
            this.rbRectangle.Name = "rbRectangle";
            this.rbRectangle.Size = new System.Drawing.Size(74, 17);
            this.rbRectangle.TabIndex = 2;
            this.rbRectangle.TabStop = true;
            this.rbRectangle.Text = "Rectangle";
            this.rbRectangle.UseVisualStyleBackColor = true;
            this.rbRectangle.CheckedChanged += new System.EventHandler(this.rbRectangle_CheckedChanged);
            // 
            // rbCircle
            // 
            this.rbCircle.AutoSize = true;
            this.rbCircle.Location = new System.Drawing.Point(57, 1);
            this.rbCircle.Name = "rbCircle";
            this.rbCircle.Size = new System.Drawing.Size(51, 17);
            this.rbCircle.TabIndex = 1;
            this.rbCircle.TabStop = true;
            this.rbCircle.Text = "Circle";
            this.rbCircle.UseVisualStyleBackColor = true;
            this.rbCircle.CheckedChanged += new System.EventHandler(this.rbCircle_CheckedChanged);
            // 
            // lblShapeSelection
            // 
            this.lblShapeSelection.AutoSize = true;
            this.lblShapeSelection.Location = new System.Drawing.Point(3, 3);
            this.lblShapeSelection.Name = "lblShapeSelection";
            this.lblShapeSelection.Size = new System.Drawing.Size(38, 13);
            this.lblShapeSelection.TabIndex = 0;
            this.lblShapeSelection.Text = "Shape";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(315, 33);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(35, 23);
            this.btnColor.TabIndex = 5;
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbFill);
            this.panel1.Controls.Add(this.rbOutlined);
            this.panel1.Controls.Add(this.lblEffect);
            this.panel1.Location = new System.Drawing.Point(390, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 24);
            this.panel1.TabIndex = 6;
            // 
            // rbFill
            // 
            this.rbFill.AutoSize = true;
            this.rbFill.Location = new System.Drawing.Point(145, 1);
            this.rbFill.Name = "rbFill";
            this.rbFill.Size = new System.Drawing.Size(37, 17);
            this.rbFill.TabIndex = 2;
            this.rbFill.TabStop = true;
            this.rbFill.Text = "Fill";
            this.rbFill.UseVisualStyleBackColor = true;
            this.rbFill.CheckedChanged += new System.EventHandler(this.rbFill_CheckedChanged);
            // 
            // rbOutlined
            // 
            this.rbOutlined.AutoSize = true;
            this.rbOutlined.Location = new System.Drawing.Point(56, 1);
            this.rbOutlined.Name = "rbOutlined";
            this.rbOutlined.Size = new System.Drawing.Size(64, 17);
            this.rbOutlined.TabIndex = 1;
            this.rbOutlined.TabStop = true;
            this.rbOutlined.Text = "Outlined";
            this.rbOutlined.UseVisualStyleBackColor = true;
            this.rbOutlined.CheckedChanged += new System.EventHandler(this.rbOutlined_CheckedChanged);
            // 
            // lblEffect
            // 
            this.lblEffect.AutoSize = true;
            this.lblEffect.Location = new System.Drawing.Point(3, 3);
            this.lblEffect.Name = "lblEffect";
            this.lblEffect.Size = new System.Drawing.Size(35, 13);
            this.lblEffect.TabIndex = 0;
            this.lblEffect.Text = "Effect";
            // 
            // msOptions
            // 
            this.msOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.msOptions.Location = new System.Drawing.Point(0, 0);
            this.msOptions.Name = "msOptions";
            this.msOptions.Size = new System.Drawing.Size(687, 24);
            this.msOptions.TabIndex = 7;
            this.msOptions.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.miOpen,
            this.miSave});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // miNew
            // 
            this.miNew.Name = "miNew";
            this.miNew.Size = new System.Drawing.Size(103, 22);
            this.miNew.Text = "New";
            this.miNew.Click += new System.EventHandler(this.miNew_Click);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.Size = new System.Drawing.Size(103, 22);
            this.miSave.Text = "Save";
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.Size = new System.Drawing.Size(103, 22);
            this.miOpen.Text = "Open";
            this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.CheckFileExists = false;
            this.fileDialog.DefaultExt = "xml";
            this.fileDialog.Filter = "Xml files (*.xml)|*.xml";
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.BackColor = System.Drawing.Color.White;
            this.pnlCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCanvas.Controls.Add(this.pnlBottomRightExtender);
            this.pnlCanvas.Location = new System.Drawing.Point(0, 70);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(687, 394);
            this.pnlCanvas.TabIndex = 3;
            this.pnlCanvas.Click += new System.EventHandler(this.pnlCanvas_Click);
            this.pnlCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCanvas_Paint);
            this.pnlCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCanvas_MouseDown);
            this.pnlCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlCanvas_MouseMove);
            this.pnlCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlCanvas_MouseUp);
            // 
            // pnlBottomRightExtender
            // 
            this.pnlBottomRightExtender.BackColor = System.Drawing.Color.Black;
            this.pnlBottomRightExtender.Location = new System.Drawing.Point(3, 3);
            this.pnlBottomRightExtender.Name = "pnlBottomRightExtender";
            this.pnlBottomRightExtender.Size = new System.Drawing.Size(10, 10);
            this.pnlBottomRightExtender.TabIndex = 2;
            this.pnlBottomRightExtender.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBottomRightExtender_MouseDown);
            this.pnlBottomRightExtender.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlBottomRightExtender_MouseMove);
            this.pnlBottomRightExtender.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlBottomRightExtender_MouseUp);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(277, 36);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 8;
            this.lblColor.Text = "Color";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 464);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.pnlShapeSelection);
            this.Controls.Add(this.pnlCanvas);
            this.Controls.Add(this.msOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.msOptions;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Hue Shape";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.pnlShapeSelection.ResumeLayout(false);
            this.pnlShapeSelection.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.msOptions.ResumeLayout(false);
            this.msOptions.PerformLayout();
            this.pnlCanvas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottomRightExtender;
        private DoubleBufferPanel pnlCanvas;
        private System.Windows.Forms.Panel pnlShapeSelection;
        private System.Windows.Forms.RadioButton rbRectangle;
        private System.Windows.Forms.RadioButton rbCircle;
        private System.Windows.Forms.Label lblShapeSelection;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbFill;
        private System.Windows.Forms.RadioButton rbOutlined;
        private System.Windows.Forms.Label lblEffect;
        private System.Windows.Forms.MenuStrip msOptions;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Label lblColor;


    }
}

