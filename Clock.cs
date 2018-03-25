namespace Clock
{
	using System;
	using System.Drawing;
	using System.Collections;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Data;
    using System.Resources;

	/// <summary>
	/// Clock
	/// </summary>
	public class Clock : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label DateLabel;
		private System.Windows.Forms.Label TimeLabel;
		private System.ComponentModel.IContainer components;
        private static System.Drawing.Size initialSize = new System.Drawing.Size(200, 100);

		public Clock()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

            StartPosition = FormStartPosition.WindowsDefaultLocation;
            Properties.Settings.Default.Upgrade();
            int left, top;
            if(Properties.Settings.Default.Left != ""
                && int.TryParse(Properties.Settings.Default.Left, out left))
            {
                Left = left;
                StartPosition = FormStartPosition.Manual;
            }
            if(Properties.Settings.Default.Top != ""
                && int.TryParse(Properties.Settings.Default.Top, out top))
            {
                Top = top;
                StartPosition = FormStartPosition.Manual;
            }

            this.Move += (sender, e) =>
            {
                Properties.Settings.Default.Left = Left.ToString();
                Properties.Settings.Default.Top = Top.ToString();
            };
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.DateLabel = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.TimeLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();

			this.Controls.Add(this.TimeLabel);
			this.Controls.Add(this.DateLabel);
			// 
			// DateLabel
			// 
			this.DateLabel.BackColor = System.Drawing.Color.Transparent;
			this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 96F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DateLabel.ForeColor = System.Drawing.Color.Red;
			this.DateLabel.Location = new System.Drawing.Point(0, 8);
			this.DateLabel.Name = "DateLabel";
			this.DateLabel.Size = new System.Drawing.Size(800, 144);
			this.DateLabel.TabIndex = 0;
			this.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// TimeLabel
			// 
			this.TimeLabel.BackColor = System.Drawing.Color.Transparent;
			this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 96F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TimeLabel.ForeColor = System.Drawing.Color.Red;
			this.TimeLabel.Location = new System.Drawing.Point(0, 152);
			this.TimeLabel.Name = "TimeLabel";
			this.TimeLabel.Size = new System.Drawing.Size(800, 144);
			this.TimeLabel.TabIndex = 1;
			this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Clock
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = initialSize;
			this.ControlBox = true;
			this.ForeColor = System.Drawing.Color.Red;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Name = "Clock";
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Clock";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.Resize += Form1_Resize;
            this.Shown += Form1_Resize;
			this.ResumeLayout(true);

            this.FormClosing += (sender, e) =>
            {
                Properties.Settings.Default.Save();
            };

            System.EventHandler maxMin = (sender, e) =>
                    this.WindowState = 
                        (this.WindowState == FormWindowState.Maximized)
                        ? FormWindowState.Normal
                        : FormWindowState.Maximized;

            this.DoubleClick += maxMin;
            foreach(Control ctrl in this.Controls)
            {
                ctrl.DoubleClick += maxMin;
            }
		}

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            var me = (Form)sender;
            double r1 = (double)me.ClientSize.Height / initialSize.Height;
            double r2 = (double)me.ClientSize.Width / initialSize.Width;

            double r = Math.Min(r1, r2);
            if(r < 1.0e-7) return;

            var f = new System.Drawing.Font("Microsoft Sans Serif", (float)r * initialSize.Height / 2.3f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            DateLabel.Font = f;
            TimeLabel.Font = f;
            DateLabel.Height = f.Height;
            TimeLabel.Height = f.Height;
            DateLabel.Width = me.Width;
            TimeLabel.Width = me.Width;
            var qq = me.ClientSize.Height;
            qq -= DateLabel.Height + TimeLabel.Height;
            qq /= 2;
            DateLabel.Top = qq;
            TimeLabel.Top = qq + DateLabel.Height;
        }

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			DateLabel.Text = DateTime.Now.ToString("dd-MM-yy");
			TimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
		}

		private void Form1_KeyPress(object sender, KeyPressEventArgs e)
		{
            if(e.KeyChar == (char)13)
            {
                this.WindowState =
                    (this.WindowState == FormWindowState.Maximized)
                    ? FormWindowState.Normal
                    : FormWindowState.Maximized;
            }
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main() 
		{
			Application.Run(new Clock());
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
	}
}
