using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class MainForm : Form
    {
        private Canvas _canvas;
        private string _savePath;
        private ImageFormat _saveFormat;

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Control Event
        private void menuItem_new_Click(object sender, EventArgs e)
        {
            if (_canvas != null && !_canvas.IsSaved)
            {
                string msg = "You don't saved file.\r\nAre you save file before create new file?";
                var result = MessageBoxUtil.YesNoCancel(msg);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    SaveAs();
                }
            }

            CreateCanvas();
        }

        private void menuItem_save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void menuItem_saveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void menuItem_exit_Click(object sender, EventArgs e)
        {
            if (_canvas != null && !_canvas.IsSaved)
            {
                string msg = "You don't saved file.\r\nAre you save file before Exit?";
                var result = MessageBoxUtil.YesNoCancel(msg);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    SaveAs();
                }
            }

            Application.Exit();
        }

        private void button_undo_Click(object sender, EventArgs e)
        {
            if (_canvas == null) return;
            _canvas.Undo();
            button_undo.Enabled = _canvas.CanUndo;
        }

        private void button_redo_Click(object sender, EventArgs e)
        {
            if (_canvas == null) return;
            _canvas.Redo();
            button_redo.Enabled = _canvas.CanRedo;
        }

        private void colorPicker_ChangedColor(object sender, EventArgs e)
        {
            if (_canvas == null) return;
            _canvas.Color = colorPicker.SelectedColor;
            ChangeCanvasCursor();
        }

        private void numericUpDown_size_ValueChanged(object sender, EventArgs e)
        {
            if (_canvas == null) return;
            _canvas.LineSize = (int) numericUpDown_size.Value;
            ChangeCanvasCursor();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_canvas == null) return;
            _canvas.Mode = GetCurrentDrawMode();
            ChangeCanvasCursor();
        }

        private void canvas_Painted(object sender, EventArgs e)
        {
            menuItem_save.Enabled = !_canvas.IsSaved;
            button_undo.Enabled = _canvas.CanUndo;
            button_redo.Enabled = _canvas.CanRedo;
        }
        #endregion

        #region Private Method
        private void CreateCanvas()
        {
            if (_canvas != null)
            {
                _canvas.Painted -= canvas_Painted;
                panel_canvas.Controls.Remove(_canvas);
                _canvas.Dispose();
                _canvas = null;
            }

            _savePath = null;
            _saveFormat = null;
            using (var dialog = new CanvasMakeForm())
            {
                if (dialog.ShowDialog() != DialogResult.OK) return;

                if (dialog.CanvasImage != null)
                {
                    _canvas = new Canvas(dialog.CanvasImage);
                }
                else
                {
                    _canvas = new Canvas(dialog.CanvasWidth, dialog.CanvasHeight);
                }
                _canvas.Color = colorPicker.SelectedColor;
                _canvas.LineSize = (int) numericUpDown_size.Value;
                _canvas.Mode = GetCurrentDrawMode();
                _canvas.Painted += canvas_Painted;

                menuItem_save.Enabled = true;
                menuItem_saveAs.Enabled = true;
                panel_canvas.Controls.Add(_canvas);
                ChangeCanvasCursor();
            }
        }

        private void Save()
        {
            if (_canvas == null || _canvas.Image == null) return;

            if (string.IsNullOrWhiteSpace(_savePath))
            {
                SaveAs();
                return;
            }

            _canvas.Save(_savePath, _saveFormat);
            menuItem_save.Enabled = false;
        }

        private void SaveAs()
        {
            if (_canvas == null || _canvas.Image == null) return;

            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "png 파일|*.png|jpeg 파일|*.jpeg|bmp 파일|*.bmp;";
            if (sf.ShowDialog() != DialogResult.OK) return;

            _savePath = sf.FileName;
            string extension = Path.GetExtension(_savePath);
            switch(extension)
            {
                case ".png":
                    _saveFormat = ImageFormat.Png;
                    break;
                case ".jpeg":
                    _saveFormat = ImageFormat.Jpeg;
                    break;
                case ".bmp":
                    _saveFormat = ImageFormat.Bmp;
                    break;
            }

            Save();
        }

        private DrawMode GetCurrentDrawMode()
        {
            if (radioButton_pen.Checked)
            {
                return DrawMode.Pen;
            }
            else if (radioButton_higlighter.Checked)
            {
                return DrawMode.Highlighter;
            }
            else if (radioButton_square.Checked)
            {
                return DrawMode.Square;
            }
            else if (radioButton_circle.Checked)
            {
                return DrawMode.Circle;
            }
            else
            {
                return DrawMode.Pen;
            }
        }

        private void ChangeCanvasCursor()
        {
            switch (_canvas.Mode)
            {
                case DrawMode.Pen:
                    {
                        var bitmap = new Bitmap(_canvas.LineSize, _canvas.LineSize);
                        using (var g = Graphics.FromImage(bitmap))
                        using (var brush = new SolidBrush(_canvas.Color))
                        {
                            g.FillEllipse(brush, 0, 0, _canvas.LineSize, _canvas.LineSize);
                        }
                        _canvas.Cursor = new Cursor(bitmap.GetHicon());
                    }
                    break;
                case DrawMode.Highlighter:
                    {
                        var bitmap = new Bitmap(_canvas.LineSize, _canvas.LineSize);
                        using (var g = Graphics.FromImage(bitmap))
                        using (var brush = new SolidBrush(_canvas.HighlightColor))
                        {
                            g.FillEllipse(brush, 0, 0, _canvas.LineSize, _canvas.LineSize);
                        }
                        _canvas.Cursor = new Cursor(bitmap.GetHicon());
                    }
                    break;
                default:
                    _canvas.Cursor = Cursors.Default;
                    break;
            }
        }
        #endregion
    }
}