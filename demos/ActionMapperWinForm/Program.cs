using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xembly.ActionMapper;

namespace KeyMapper
{
	class Program
	{
		static void Main(string[] args)
		{
			//var (provider, keyActionMapper) = ByDirect();
			var (provider, keyActionMapper) = ByDependencyInjection();


			keyActionMapper.Start();
			Debug.WriteLine("Mapper Started!");

			keyActionMapper.Add(ActionRegister.All(KeyModifiers.None, (int) Keys.A, APressed));

			//_ = Task.Factory.StartNew(async () =>
			//{
			//	await Task.Delay(5000);
			//	keyActionMapper.Stop();
			//	Debug.WriteLine("Mapper Stopped!");

			//	keyActionMapper.Remove(DPressed);

			//	await Task.Delay(5000);
			//	keyActionMapper.Start();
			//	Debug.WriteLine("Mapper Restarted");
			//});

			if (provider == null) Application.Run();
			else
			{
				Application.Run(provider.GetRequiredService<Main>());
				provider.Dispose();
			}
		}

		static void ShiftControlFPressedKeyDown(ActionEventArgs p) => Debug.WriteLine($"Ctrl + Shift + F --- pressed from {p}!!!!");
		static void ShiftControlFPressed(ActionEventArgs p) => Debug.WriteLine($"Ctrl + Shift + F --- pressed from {p}!");
		static void DPressed(ActionEventArgs p) => Debug.WriteLine($"D --- pressed from {p}!");
		static void SPressed(ActionEventArgs p) => Debug.WriteLine($"S --- pressed from {p}!");
		static void WPressed(ActionEventArgs p) => Debug.WriteLine($"W --- pressed from {p}!");
		static void APressed(ActionEventArgs p) => Debug.WriteLine($"A --- pressed from {p}!");

		public static (ServiceProvider, IKeyActionMapper) ByDirect()
		{
			var keyActionMapper = ActionRegister.KeyActionMapper();
			keyActionMapper.Add(
				ActionRegister.All(KeyModifiers.Shift | KeyModifiers.Control, (int) Keys.F, ShiftControlFPressedKeyDown, true),
				ActionRegister.All(KeyModifiers.Shift | KeyModifiers.Control, (int) Keys.F, ShiftControlFPressed),
				ActionRegister.ByWindowName("notepad", KeyModifiers.None, (int) Keys.D, DPressed),
				ActionRegister.ByName("Notepad", KeyModifiers.None, (int) Keys.S, SPressed),
				ActionRegister.ById(58612, KeyModifiers.None, (int) Keys.W, WPressed));
			return (null, keyActionMapper);
		}

		public static (ServiceProvider, IKeyActionMapper) ByDependencyInjection()
		{
			var services = new ServiceCollection()
				.AddKeyActions(
					ActionRegister.All(KeyModifiers.Shift | KeyModifiers.Control, (int) Keys.F, ShiftControlFPressedKeyDown, true),
					ActionRegister.All(KeyModifiers.Shift | KeyModifiers.Control, (int) Keys.F, ShiftControlFPressed),
					ActionRegister.ByWindowName("notepad", KeyModifiers.None, (int) Keys.D, DPressed),
					ActionRegister.ByName("Notepad", KeyModifiers.None, (int) Keys.S, SPressed),
					ActionRegister.ById(58612, KeyModifiers.None, (int) Keys.W, WPressed)
				)
				.AddScoped<Main>();

			var provider = services.BuildServiceProvider();
			return (provider, provider.GetService<IKeyActionMapper>());
		}
	}
}
