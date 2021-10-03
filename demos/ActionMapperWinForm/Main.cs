using System;
using System.Diagnostics;
using System.Windows.Forms;
using Xembly.ActionMapper;

namespace KeyMapper
{
	public partial class Main : Form
	{
		private delegate void MainFormEvent<T>(T args);

		public Main(IKeyActionMapper keyActionMapper)
		{
			InitializeComponent();

			keyActionMapper.Add(ActionRegister.Self(KeyModifiers.Alt, (int) Keys.A, e =>
			{
				// Invoke is required as the thread ID of this async call is
				// different than the creating thread for the form.
				//Invoke(new MainFormEvent<ActionEventArgs>(e => textBoxKeyActionValue.Text = e.ToString()), e);
				Invoke(new MainFormEvent<ActionEventArgs>(e => {
					timer.Stop();
					progressBar.Value = 100;
					timer.Start();
				}), e);
			}));
		}

		private void Main_Shown(object sender, EventArgs e)
		{
			var process = Process.GetCurrentProcess();
			textBoxProcessId.Text = process.Id.ToString();
			textBoxProcessName.Text = process.ProcessName;
			textBoxWindowName.Text = process.MainWindowTitle;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if (progressBar.Value == 0) return;
			progressBar.Value -= 5;
		}
	}
}
