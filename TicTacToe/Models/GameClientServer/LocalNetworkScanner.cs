using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

using TicTacToe.Models.GameInfo.Settings;

namespace TicTacToe.Models.GameClientServer
{
	internal class LocalNetworkScanner
	{
		private const char SUBNET_SEPARATOR = '/';

		private readonly GameClient _gameClient;
		private readonly int _port;
		private EventHandler<LobbyPreviewEventArgs> CreateLobbyPreview;
		public LocalNetworkScanner(GameClient gameClient, int port,
			EventHandler<LobbyPreviewEventArgs> createLobbyPreview)
		{
			_port = port;
			_gameClient = gameClient;
			CreateLobbyPreview = createLobbyPreview;
		}

		internal async Task<List<IPAddress>> ScanLocalNetworkAsync()
		{
			string subnet = GetLocalSubnet() ?? throw new InvalidOperationException("Failed to determine subnet.");
			List<IPAddress> allIPs = GetAllIPInSubnet(subnet);
			return await ScanNetworkForPortAsync(allIPs);
		}

		private string GetLocalSubnet()
		{
			foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
				if (ni.OperationalStatus == OperationalStatus.Up)
					foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
						if (ip.Address.AddressFamily == AddressFamily.InterNetwork) // IPv4
						{
							string localIP = ip.Address.ToString();
							string subnetMask = ip.IPv4Mask.ToString();
							return localIP + SUBNET_SEPARATOR + subnetMask;
						}

			return null;
		}

		private List<IPAddress> GetAllIPInSubnet(string subnet)
		{
			List<IPAddress> ipAddresses = new List<IPAddress>();

			string[] parts = subnet.Split(SUBNET_SEPARATOR);
			IPAddress ip = IPAddress.Parse(parts[0]);
			IPAddress mask = IPAddress.Parse(parts[1]);

			byte[] ipBytes = ip.GetAddressBytes();
			byte[] maskBytes = mask.GetAddressBytes();

			for (int i = 1; i < 255; i++)
			{
				byte[] newIpBytes = (byte[])ipBytes.Clone();
				newIpBytes[3] = (byte)i; // Changing the last byte

				if (IsValidIpInSubnet(newIpBytes, ipBytes, maskBytes))
					ipAddresses.Add(new IPAddress(newIpBytes));
			}

			return ipAddresses;
		}
		private bool IsValidIpInSubnet(byte[] newIpBytes, byte[] baseIpBytes, byte[] maskBytes)
		{
			for (int j = 0; j < maskBytes.Length; j++)
				if ((newIpBytes[j] & maskBytes[j]) != (baseIpBytes[j] & maskBytes[j]))
					return false;

			return true; // If all bytes match, return true
		}

		private async Task<List<IPAddress>> ScanNetworkForPortAsync(List<IPAddress> ipAddresses)
		{
			List<IPAddress> devicesWithOpenPort = new List<IPAddress>();

			var tasks = new List<Task<bool>>();

			foreach (var ip in ipAddresses)
				tasks.Add(IsPortOpenAsync(ip));
			bool[] results = await Task.WhenAll(tasks);

			for (int i = 0; i < results.Length; i++)
				if (results[i])
					devicesWithOpenPort.Add(ipAddresses[i]);

			return devicesWithOpenPort;
		}
		private async Task<bool> IsPortOpenAsync(IPAddress ip, int timeout = 300)
		{
			try
			{
				using (TcpClient tcpClient = new TcpClient())
				{
					var connectionTask = tcpClient.ConnectAsync(ip, _port);
					var success = await Task.WhenAny(connectionTask,
						Task.Delay(TimeSpan.FromMilliseconds(timeout))) == connectionTask;

					if (!success)
						return false;

					await connectionTask;

					NetworkGameSettings networkGameSettings = await _gameClient.GetGameSettings(ip, _port);
					OnCreateLobbyPreview(new LobbyPreviewEventArgs(ip, _port, networkGameSettings));
					return true;
				}
			}
			catch
			{ return false; }
		}
		private void OnCreateLobbyPreview(LobbyPreviewEventArgs e)
		{
			var temp = System.Threading.Volatile.Read(ref CreateLobbyPreview);
			temp?.Invoke(this, e);
		}
	}
}