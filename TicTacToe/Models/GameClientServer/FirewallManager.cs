using System.Diagnostics;

namespace TicTacToe.Models.GameClientServer
{
	internal class FirewallManager
	{
		private readonly string _ruleName;

		internal FirewallManager(string ruleName)
			=> _ruleName = ruleName;

		internal void AddFirewallRule(int port)
		{
			if (!IsRuleExists())
			{
				string command = $"netsh advfirewall firewall add rule name=\"{_ruleName}\" dir=in action=allow protocol=TCP localport={port} profile=private";
				ExecuteCommand(command);
			}
		}
		internal void RemoveFirewallRule()
		{
			if (IsRuleExists())
			{
				string command = $"netsh advfirewall firewall delete rule name=\"{_ruleName}\"";
				ExecuteCommand(command);
			}
		}

		private bool IsRuleExists()
		{
			string command = $"netsh advfirewall firewall show rule name=\"{_ruleName}\"";
			var output = ExecuteCommand(command);
			return output.Contains(_ruleName);
		}
		private string ExecuteCommand(string command)
		{
			using (var process = new Process())
			{
				process.StartInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = $"/C {command}",
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};

				process.Start();
				process.WaitForExit();
				return process.StandardOutput.ReadToEnd();
			}
		}
	}
}