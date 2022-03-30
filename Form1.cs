using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogViewer
{
    public partial class Form1 : Form
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        Config config = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("config.json"))
            {
                try
                {
                    config = System.Text.Json.JsonSerializer.Deserialize<Config>(File.ReadAllText("config.json", Encoding.UTF8));
                }
                catch
                {
                    config = new Config();
                }
            }
            else
            {
                config = new Config();
            }
            config.UpdateDefauls(this);
            tbLogFileName.Text = config.fileName;

            SetWindowPos(Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            Location = new Point(config.left, config.top);
            Size = new Size(config.width, config.height);

            tbLogText.Font = new Font(config.fontName, config.fontSize);
        }

        private void btnSelectFileName_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbLogFileName.Text = openFileDialog1.FileName;
            }
        }

        long lastReadLength = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var fileName = tbLogFileName.Text;
                if (!File.Exists(fileName))
                {
                    return;
                }
                var fileSize = new FileInfo(fileName).Length;
                if (fileSize > lastReadLength)
                {
                    var text = "";
                    using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        if (lastReadLength == 0)
                        {
                            lastReadLength = Math.Max(0, fileSize - 1024);
                        }
                        fs.Seek(lastReadLength, SeekOrigin.Begin);
                        var buffer = new byte[1024];

                        while (true)
                        {
                            var bytesRead = fs.Read(buffer, 0, buffer.Length);
                            lastReadLength += bytesRead;

                            if (bytesRead == 0)
                                break;

                            text += ASCIIEncoding.ASCII.GetString(buffer, 0, bytesRead);
                        }
                    }
                    tbLogText.AppendText(text);
                    if (tbLogText.Lines.Length > config.maxLines)
                    {
                        text = string.Join("\r\n", tbLogText.Lines.TakeLast(config.maxLines));
                        tbLogText.Clear();
                        tbLogText.AppendText(text);
                    }
                }
            }
            catch { }
        }

        void SaveConfig()
        {
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var json = System.Text.Json.JsonSerializer.Serialize(config, options);
            File.WriteAllText("config.json", json);
        }

        private void tbLogFileName_TextChanged(object sender, EventArgs e)
        {
            if (config.fileName != tbLogFileName.Text)
            {
                config.fileName = tbLogFileName.Text;
                SaveConfig();
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (config != null && (config.left != Left || config.top != Top))
            {
                config.left = Left;
                config.top = Top;
                SaveConfig();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (config != null && (config.width != Width || config.height != Height))
            {
                config.width = Width;
                config.height = Height;
                SaveConfig();
            }
        }
    }
}
