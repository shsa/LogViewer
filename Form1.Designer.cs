
namespace LogViewer
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
            this.components = new System.ComponentModel.Container();
            this.tbLogFileName = new System.Windows.Forms.TextBox();
            this.btnSelectFileName = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbLogText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbLogFileName
            // 
            this.tbLogFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLogFileName.Location = new System.Drawing.Point(12, 12);
            this.tbLogFileName.Name = "tbLogFileName";
            this.tbLogFileName.Size = new System.Drawing.Size(592, 23);
            this.tbLogFileName.TabIndex = 0;
            this.tbLogFileName.TextChanged += new System.EventHandler(this.tbLogFileName_TextChanged);
            // 
            // btnSelectFileName
            // 
            this.btnSelectFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFileName.Location = new System.Drawing.Point(610, 12);
            this.btnSelectFileName.Name = "btnSelectFileName";
            this.btnSelectFileName.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFileName.TabIndex = 1;
            this.btnSelectFileName.Text = "Select";
            this.btnSelectFileName.UseVisualStyleBackColor = true;
            this.btnSelectFileName.Click += new System.EventHandler(this.btnSelectFileName_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbLogText
            // 
            this.tbLogText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLogText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbLogText.Location = new System.Drawing.Point(12, 41);
            this.tbLogText.Multiline = true;
            this.tbLogText.Name = "tbLogText";
            this.tbLogText.ReadOnly = true;
            this.tbLogText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLogText.Size = new System.Drawing.Size(673, 309);
            this.tbLogText.TabIndex = 2;
            this.tbLogText.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 362);
            this.Controls.Add(this.tbLogText);
            this.Controls.Add(this.btnSelectFileName);
            this.Controls.Add(this.tbLogFileName);
            this.Name = "Form1";
            this.Text = "Log viewer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogFileName;
        private System.Windows.Forms.Button btnSelectFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbLogText;
    }
}

