namespace Junkosoft
{
	#region Namespaces
	using System;
	using System.Drawing;
	using System.Collections;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Data;
	#endregion

	/// <summary>
	/// Clock
	/// </summary>
	public class Clock : System.Windows.Forms.Form
	{
		#region Controls
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label DateLabel;
		private System.Windows.Forms.Label TimeLabel;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Constructors
		public Clock()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		#endregion

		#region Windows Form Designer generated code
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
			this.ClientSize = new System.Drawing.Size(800, 296);
			this.ControlBox = false;
			this.Controls.Add(this.TimeLabel);
			this.Controls.Add(this.DateLabel);
			this.ForeColor = System.Drawing.Color.Red;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Clock";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Clock";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
			this.ResumeLayout(false);

		}
		#endregion

		#region Control Events
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			DateLabel.Text = DateTime.Now.ToString("MM-dd-yyyy");
			TimeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");

		}

		private void Form1_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main() 
		{
			Application.Run(new Clock());
		}
		#endregion

		#region Protected Methods
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
		#endregion
	}
}
