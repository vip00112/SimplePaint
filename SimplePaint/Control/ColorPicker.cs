using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class ColorPicker : UserControl
    {
        private Color _selectedColor;

        #region Constructor
        public ColorPicker()
        {
            InitializeComponent();
        }
        #endregion

        #region Event
        [Browsable(true)]
        public event EventHandler ChangedColor;
        #endregion

        #region Properties
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                ChangeColor();
            }
        }
        #endregion

        #region Control Event
        private void label_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.Color = SelectedColor;
                if (cd.ShowDialog() != DialogResult.OK) return;

                SelectedColor = cd.Color;
                ChangeColor();
            }
        }
        #endregion

        #region Private Method
        private void ChangeColor()
        {
            label.Text = (SelectedColor == Color.Empty) ? "" : SelectedColor.Name;
            pictureBox.Image = ImageUtil.CreateImage(pictureBox.Width, pictureBox.Height, SelectedColor);

            if (ChangedColor != null)
            {
                ChangedColor(this, EventArgs.Empty);
            }
        }
        #endregion
    }
}
