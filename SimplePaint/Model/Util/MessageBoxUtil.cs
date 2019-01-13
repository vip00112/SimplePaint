using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimplePaint
{
    public class MessageBoxUtil
    {
        private const string Title = "Simple Paint";

        public static void Info(string msg)
        {
            MessageBox.Show(msg, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(string msg)
        {
            MessageBox.Show(msg, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirm(string msg)
        {
            var result = MessageBox.Show(msg, Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
            return result;
        }

        public static DialogResult YesNoCancel(string msg)
        {
            return MessageBox.Show(msg, Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
    }
}
