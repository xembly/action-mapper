
namespace KeyMapper
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.textBoxProcessId = new System.Windows.Forms.TextBox();
			this.labelProcessId = new System.Windows.Forms.Label();
			this.textBoxProcessName = new System.Windows.Forms.TextBox();
			this.labelProcessName = new System.Windows.Forms.Label();
			this.textBoxWindowName = new System.Windows.Forms.TextBox();
			this.labelAltAPressed = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.labelWindowName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBoxProcessId
			// 
			this.textBoxProcessId.BackColor = System.Drawing.Color.White;
			this.textBoxProcessId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxProcessId.Location = new System.Drawing.Point(13, 34);
			this.textBoxProcessId.Name = "textBoxProcessId";
			this.textBoxProcessId.ReadOnly = true;
			this.textBoxProcessId.Size = new System.Drawing.Size(395, 23);
			this.textBoxProcessId.TabIndex = 0;
			// 
			// labelProcessId
			// 
			this.labelProcessId.AutoSize = true;
			this.labelProcessId.BackColor = System.Drawing.Color.Transparent;
			this.labelProcessId.Location = new System.Drawing.Point(13, 13);
			this.labelProcessId.Name = "labelProcessId";
			this.labelProcessId.Size = new System.Drawing.Size(61, 15);
			this.labelProcessId.TabIndex = 1;
			this.labelProcessId.Text = "Process ID";
			// 
			// textBoxProcessName
			// 
			this.textBoxProcessName.BackColor = System.Drawing.Color.White;
			this.textBoxProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxProcessName.Location = new System.Drawing.Point(12, 81);
			this.textBoxProcessName.Name = "textBoxProcessName";
			this.textBoxProcessName.ReadOnly = true;
			this.textBoxProcessName.Size = new System.Drawing.Size(395, 23);
			this.textBoxProcessName.TabIndex = 0;
			// 
			// labelProcessName
			// 
			this.labelProcessName.AutoSize = true;
			this.labelProcessName.BackColor = System.Drawing.Color.Transparent;
			this.labelProcessName.Location = new System.Drawing.Point(13, 60);
			this.labelProcessName.Name = "labelProcessName";
			this.labelProcessName.Size = new System.Drawing.Size(82, 15);
			this.labelProcessName.TabIndex = 1;
			this.labelProcessName.Text = "Process Name";
			// 
			// textBoxWindowName
			// 
			this.textBoxWindowName.BackColor = System.Drawing.Color.White;
			this.textBoxWindowName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxWindowName.Location = new System.Drawing.Point(12, 131);
			this.textBoxWindowName.Name = "textBoxWindowName";
			this.textBoxWindowName.ReadOnly = true;
			this.textBoxWindowName.Size = new System.Drawing.Size(395, 23);
			this.textBoxWindowName.TabIndex = 0;
			// 
			// labelAltAPressed
			// 
			this.labelAltAPressed.AutoSize = true;
			this.labelAltAPressed.BackColor = System.Drawing.Color.Transparent;
			this.labelAltAPressed.Location = new System.Drawing.Point(13, 160);
			this.labelAltAPressed.Name = "labelAltAPressed";
			this.labelAltAPressed.Size = new System.Drawing.Size(87, 15);
			this.labelAltAPressed.TabIndex = 1;
			this.labelAltAPressed.Text = "Alt + A Pressed";
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 180);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(395, 23);
			this.progressBar.TabIndex = 2;
			// 
			// timer
			// 
			this.timer.Interval = 50;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// labelWindowName
			// 
			this.labelWindowName.AutoSize = true;
			this.labelWindowName.BackColor = System.Drawing.Color.Transparent;
			this.labelWindowName.Location = new System.Drawing.Point(12, 110);
			this.labelWindowName.Name = "labelWindowName";
			this.labelWindowName.Size = new System.Drawing.Size(86, 15);
			this.labelWindowName.TabIndex = 1;
			this.labelWindowName.Text = "Window Name";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(420, 218);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.labelAltAPressed);
			this.Controls.Add(this.labelWindowName);
			this.Controls.Add(this.labelProcessName);
			this.Controls.Add(this.labelProcessId);
			this.Controls.Add(this.textBoxWindowName);
			this.Controls.Add(this.textBoxProcessName);
			this.Controls.Add(this.textBoxProcessId);
			this.Name = "Main";
			this.Text = "Key Mapper Example";
			this.Shown += new System.EventHandler(this.Main_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxProcessId;
		private System.Windows.Forms.Label labelProcessId;
		private System.Windows.Forms.TextBox textBoxProcessName;
		private System.Windows.Forms.Label labelProcessName;
		private System.Windows.Forms.TextBox textBoxWindowName;
		private System.Windows.Forms.Label labelAltAPressed;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Label labelWindowName;
	}
}
