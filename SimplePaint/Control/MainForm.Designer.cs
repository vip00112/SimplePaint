namespace SimplePaint
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItem_file = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_save = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_saveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_tool = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_redo = new System.Windows.Forms.Button();
            this.button_undo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colorPicker = new SimplePaint.ColorPicker();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_size = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton_pen = new System.Windows.Forms.RadioButton();
            this.radioButton_higlighter = new System.Windows.Forms.RadioButton();
            this.radioButton_square = new System.Windows.Forms.RadioButton();
            this.radioButton_circle = new System.Windows.Forms.RadioButton();
            this.panel_canvas = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.trackBar_zoom = new System.Windows.Forms.TrackBar();
            this.label_zoom = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.panel_tool.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_zoom)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_file});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(584, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuItem_file
            // 
            this.menuItem_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_new,
            this.menuItem_save,
            this.menuItem_saveAs,
            this.menuItem_exit});
            this.menuItem_file.Name = "menuItem_file";
            this.menuItem_file.Size = new System.Drawing.Size(37, 20);
            this.menuItem_file.Text = "File";
            // 
            // menuItem_new
            // 
            this.menuItem_new.Name = "menuItem_new";
            this.menuItem_new.Size = new System.Drawing.Size(114, 22);
            this.menuItem_new.Text = "New";
            this.menuItem_new.Click += new System.EventHandler(this.menuItem_new_Click);
            // 
            // menuItem_save
            // 
            this.menuItem_save.Enabled = false;
            this.menuItem_save.Name = "menuItem_save";
            this.menuItem_save.Size = new System.Drawing.Size(114, 22);
            this.menuItem_save.Text = "Save";
            this.menuItem_save.Click += new System.EventHandler(this.menuItem_save_Click);
            // 
            // menuItem_saveAs
            // 
            this.menuItem_saveAs.Enabled = false;
            this.menuItem_saveAs.Name = "menuItem_saveAs";
            this.menuItem_saveAs.Size = new System.Drawing.Size(114, 22);
            this.menuItem_saveAs.Text = "Save as";
            this.menuItem_saveAs.Click += new System.EventHandler(this.menuItem_saveAs_Click);
            // 
            // menuItem_exit
            // 
            this.menuItem_exit.Name = "menuItem_exit";
            this.menuItem_exit.Size = new System.Drawing.Size(114, 22);
            this.menuItem_exit.Text = "Exit";
            this.menuItem_exit.Click += new System.EventHandler(this.menuItem_exit_Click);
            // 
            // panel_tool
            // 
            this.panel_tool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_tool.Controls.Add(this.panel1);
            this.panel_tool.Controls.Add(this.label1);
            this.panel_tool.Controls.Add(this.colorPicker);
            this.panel_tool.Controls.Add(this.label2);
            this.panel_tool.Controls.Add(this.numericUpDown_size);
            this.panel_tool.Controls.Add(this.label3);
            this.panel_tool.Controls.Add(this.radioButton_pen);
            this.panel_tool.Controls.Add(this.radioButton_higlighter);
            this.panel_tool.Controls.Add(this.radioButton_square);
            this.panel_tool.Controls.Add(this.radioButton_circle);
            this.panel_tool.Controls.Add(this.label_zoom);
            this.panel_tool.Controls.Add(this.trackBar_zoom);
            this.panel_tool.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_tool.Location = new System.Drawing.Point(0, 24);
            this.panel_tool.Name = "panel_tool";
            this.panel_tool.Size = new System.Drawing.Size(109, 365);
            this.panel_tool.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_redo);
            this.panel1.Controls.Add(this.button_undo);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(99, 23);
            this.panel1.TabIndex = 6;
            // 
            // button_redo
            // 
            this.button_redo.Enabled = false;
            this.button_redo.Location = new System.Drawing.Point(50, 0);
            this.button_redo.Margin = new System.Windows.Forms.Padding(0);
            this.button_redo.Name = "button_redo";
            this.button_redo.Size = new System.Drawing.Size(49, 23);
            this.button_redo.TabIndex = 0;
            this.button_redo.Text = "▶";
            this.button_redo.UseVisualStyleBackColor = true;
            this.button_redo.Click += new System.EventHandler(this.button_redo_Click);
            // 
            // button_undo
            // 
            this.button_undo.Enabled = false;
            this.button_undo.Location = new System.Drawing.Point(0, 0);
            this.button_undo.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.button_undo.Name = "button_undo";
            this.button_undo.Size = new System.Drawing.Size(49, 23);
            this.button_undo.TabIndex = 0;
            this.button_undo.Text = "◀";
            this.button_undo.UseVisualStyleBackColor = true;
            this.button_undo.Click += new System.EventHandler(this.button_undo_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Color";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorPicker
            // 
            this.colorPicker.BackColor = System.Drawing.SystemColors.Control;
            this.colorPicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPicker.Location = new System.Drawing.Point(3, 58);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.SelectedColor = System.Drawing.Color.Black;
            this.colorPicker.Size = new System.Drawing.Size(99, 25);
            this.colorPicker.TabIndex = 0;
            this.colorPicker.ChangedColor += new System.EventHandler(this.colorPicker_ChangedColor);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(3, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Size";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_size
            // 
            this.numericUpDown_size.Location = new System.Drawing.Point(3, 115);
            this.numericUpDown_size.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_size.Name = "numericUpDown_size";
            this.numericUpDown_size.Size = new System.Drawing.Size(99, 21);
            this.numericUpDown_size.TabIndex = 1;
            this.numericUpDown_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_size.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_size.ValueChanged += new System.EventHandler(this.numericUpDown_size_ValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(3, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mode";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton_pen
            // 
            this.radioButton_pen.Checked = true;
            this.radioButton_pen.Location = new System.Drawing.Point(3, 168);
            this.radioButton_pen.Name = "radioButton_pen";
            this.radioButton_pen.Size = new System.Drawing.Size(104, 25);
            this.radioButton_pen.TabIndex = 2;
            this.radioButton_pen.TabStop = true;
            this.radioButton_pen.Text = "Pen";
            this.radioButton_pen.UseVisualStyleBackColor = true;
            this.radioButton_pen.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_higlighter
            // 
            this.radioButton_higlighter.Location = new System.Drawing.Point(3, 199);
            this.radioButton_higlighter.Name = "radioButton_higlighter";
            this.radioButton_higlighter.Size = new System.Drawing.Size(104, 25);
            this.radioButton_higlighter.TabIndex = 3;
            this.radioButton_higlighter.TabStop = true;
            this.radioButton_higlighter.Text = "Highlighter";
            this.radioButton_higlighter.UseVisualStyleBackColor = true;
            this.radioButton_higlighter.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_square
            // 
            this.radioButton_square.Location = new System.Drawing.Point(3, 230);
            this.radioButton_square.Name = "radioButton_square";
            this.radioButton_square.Size = new System.Drawing.Size(104, 25);
            this.radioButton_square.TabIndex = 4;
            this.radioButton_square.TabStop = true;
            this.radioButton_square.Text = "Square";
            this.radioButton_square.UseVisualStyleBackColor = true;
            this.radioButton_square.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_circle
            // 
            this.radioButton_circle.Location = new System.Drawing.Point(3, 261);
            this.radioButton_circle.Name = "radioButton_circle";
            this.radioButton_circle.Size = new System.Drawing.Size(104, 25);
            this.radioButton_circle.TabIndex = 5;
            this.radioButton_circle.TabStop = true;
            this.radioButton_circle.Text = "Circle";
            this.radioButton_circle.UseVisualStyleBackColor = true;
            this.radioButton_circle.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // panel_canvas
            // 
            this.panel_canvas.AutoScroll = true;
            this.panel_canvas.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel_canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_canvas.Location = new System.Drawing.Point(109, 24);
            this.panel_canvas.Name = "panel_canvas";
            this.panel_canvas.Size = new System.Drawing.Size(475, 365);
            this.panel_canvas.TabIndex = 2;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 389);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(584, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // trackBar_zoom
            // 
            this.trackBar_zoom.AutoSize = false;
            this.trackBar_zoom.Location = new System.Drawing.Point(3, 318);
            this.trackBar_zoom.Minimum = 1;
            this.trackBar_zoom.Name = "trackBar_zoom";
            this.trackBar_zoom.Size = new System.Drawing.Size(99, 22);
            this.trackBar_zoom.TabIndex = 3;
            this.trackBar_zoom.TabStop = false;
            this.trackBar_zoom.Value = 4;
            this.trackBar_zoom.ValueChanged += new System.EventHandler(this.trackBar_zoom_ValueChanged);
            // 
            // label_zoom
            // 
            this.label_zoom.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_zoom.Location = new System.Drawing.Point(0, 299);
            this.label_zoom.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label_zoom.Name = "label_zoom";
            this.label_zoom.Size = new System.Drawing.Size(99, 16);
            this.label_zoom.TabIndex = 4;
            this.label_zoom.Text = "Zoom 100%";
            this.label_zoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.panel_canvas);
            this.Controls.Add(this.panel_tool);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Paint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel_tool.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_zoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItem_file;
        private System.Windows.Forms.ToolStripMenuItem menuItem_new;
        private System.Windows.Forms.ToolStripMenuItem menuItem_save;
        private System.Windows.Forms.ToolStripMenuItem menuItem_saveAs;
        private System.Windows.Forms.ToolStripMenuItem menuItem_exit;
        private System.Windows.Forms.FlowLayoutPanel panel_tool;
        private System.Windows.Forms.Panel panel_canvas;
        private ColorPicker colorPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_size;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton_pen;
        private System.Windows.Forms.RadioButton radioButton_higlighter;
        private System.Windows.Forms.RadioButton radioButton_square;
        private System.Windows.Forms.RadioButton radioButton_circle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_redo;
        private System.Windows.Forms.Button button_undo;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TrackBar trackBar_zoom;
        private System.Windows.Forms.Label label_zoom;
    }
}

