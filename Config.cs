using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogViewer
{
    public class Config
    {
        public string fileName { get; set; }
        public string fontName { get; set; }
        public float fontSize { get; set; }
        public int maxLines { get; set; }

        public int left { get; set; } = int.MaxValue;
        public int top { get; set; } = int.MaxValue;
        public int width { get; set; } = int.MaxValue;
        public int height { get; set; } = int.MaxValue;

        public void UpdateDefauls(Form form)
        {
            if (string.IsNullOrEmpty(fontName))
            {
                fontName = "Courier New";
            }
            if (fontSize == 0)
            {
                fontSize = 9;
            }
            if (maxLines == 0)
            {
                maxLines = 100;
            }

            if (left == int.MaxValue)
            {
                left = form.Left;
            }
            if (top == int.MaxValue)
            {
                top = form.Top;
            }
            if (width == int.MaxValue)
            {
                width = form.Width;
            }
            if (height == int.MaxValue)
            {
                height = form.Height;
            }
        }
    }
}
