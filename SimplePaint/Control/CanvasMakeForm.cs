using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class CanvasMakeForm : Form
    {
        #region Constructor
        public CanvasMakeForm()
        {
            InitializeComponent();

            CanvasWidth = (int) numericUpDown_width.Value;
            CanvasHeight = (int) numericUpDown_height.Value;
        }
        #endregion

        #region Properties
        public int CanvasWidth { get; private set; }

        public int CanvasHeight { get; private set; }

        public Image CanvasImage { get; private set; }
        #endregion

        #region Control Event
        private void numericUpDown_width_ValueChanged(object sender, EventArgs e)
        {
            CanvasWidth = (int) numericUpDown_width.Value;
        }

        private void numericUpDown_height_ValueChanged(object sender, EventArgs e)
        {
            CanvasHeight = (int) numericUpDown_height.Value;
        }

        private void button_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (of.ShowDialog() != DialogResult.OK) return;

            string filePath = of.FileName;
            Image img = ImageUtil.ToImage(filePath);
            if (img == null) return;

            CanvasImage = img;
            numericUpDown_width.Value = img.Width;
            numericUpDown_height.Value = img.Height;

            label_path.Text = filePath;
            numericUpDown_width.Enabled = false;
            numericUpDown_height.Enabled = false;
            button_delete.Enabled = true;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            CanvasImage = null;
            numericUpDown_width.Value = 500;
            numericUpDown_height.Value = 500;

            label_path.Text = null;
            numericUpDown_width.Enabled = true;
            numericUpDown_height.Enabled = true;
            button_delete.Enabled = false;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion
    }
}
