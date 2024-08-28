using System;
using System.Globalization;
using System.Windows.Forms;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities;

namespace TicTacToe
{
	internal static class Program
	{
		internal static string SerializePath = $"{Environment.CurrentDirectory}\\playerInfo.txt";
		internal static readonly string EncryptKey = "pR7sF2xK6lO4mN7y";

		/// <summary>
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			CultureInfo.CurrentUICulture = new CultureInfo("en");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Player player = Serializator.Deserialize<Player>(SerializePath, EncryptKey);
			if (player != null)
				Application.Run(new Forms.MainForm(player));
			else
				Application.Run(new Forms.StartForm());
		}
	}
}