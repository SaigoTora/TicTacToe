using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TicTacToe.Models.Utilities
{
	internal static class Serializator
	{
		internal static void Serialize<T>(T entity, string path, string key) where T : class
		{
			using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
			{
				// Hide the file
				File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);

				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, entity);

				stream.Close();
				Encrypt(key, path);
			}
		}
		internal static T Deserialize<T>(string path, string key) where T : class
		{
			try
			{
				Encrypt(key, path);// Deciphering the data
				using (FileStream stream = new FileStream(path, FileMode.Open))
				{
					BinaryFormatter formatter = new BinaryFormatter();
					T entity = (T)formatter.Deserialize(stream);

					stream.Close();
					Encrypt(key, path);// Encrypt the data back

					return entity;
				}
			}
			catch
			{
				DeleteSerializationFile(path);
				return null;
			}
		}
		internal static void DeleteSerializationFile(string path)
		{
			if (File.Exists(path))
				File.Delete(path);
		}

		private static void Encrypt(string key, string path)
		{// XOR encryption method
			byte[] keyBytes = Convert.FromBase64String(key);

			using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
			{
				// Buffer of read data
				byte[] buffer = new byte[4096];
				int bytesRead;

				while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
				{// Read data in blocks
					for (int i = 0; i < bytesRead; i++)
						buffer[i] = (byte)(buffer[i] ^ keyBytes[i % keyBytes.Length]);

					// Move the file position to the beginning of the block to write the encrypted data
					fileStream.Seek(-bytesRead, SeekOrigin.Current);
					fileStream.Write(buffer, 0, bytesRead);
				}
			}
		}
	}
}