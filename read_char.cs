using System;

namespace read_char_by_me
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Leer char por char");

			string password = "",id = "", age = "", money = "";

			Console.Write("Contraseña: ");
			ReadPassword(password);
			Console.WriteLine();

			bool success = password == ReadPassword("\nConfirme la Contraseña: ");

			if (success == false)
			{
				Console.WriteLine("\nLa Contraseña son identicas");
			}

			Console.Write("Cedula: ");
			id = ReadCedula();
			Console.WriteLine();

			Console.Write("Edad: ");
			age = ReadAge();
			Console.WriteLine();

			Console.Write("Ahorros: ");
			money = ReadMoney();
			Console.WriteLine();

		}

		static string ReadPassword()
		{
			Console.Write("");

			while (true)
			{
				string password = "";
				ConsoleKey key;

				do
				{
					var keyInfo = Console.ReadKey(intercept: true);
					key = keyInfo.Key;

					if (key == ConsoleKey.Backspace && password.Length > 0)
					{
						Console.Write("\b \b");
						password = password.Remove(password.Length - 1);
					}
					else if (!char.IsControl(keyInfo.KeyChar))
					{
						Console.Write("*");
						password += keyInfo.KeyChar;
					}


				} while (key != ConsoleKey.Enter);

				if (password == "")
				{
					continue;
				}

				return password;
			}

		}

		static string Readid()
		{
			Console.Write("");
			while (true)
			{
				string data = "";
				ConsoleKey key;

				do
				{
					var keyInfo = Console.ReadKey(intercept: true);
					key = keyInfo.Key;

					int value;
					bool success = int.TryParse(keyInfo.KeyChar.ToString(), out value);

					if (key == ConsoleKey.Backspace && data.Length > 0)
					{
						Console.Write("\b \b");
						data = data.Remove(data.Length - 1);
					}
					else if (!char.IsControl(keyInfo.KeyChar) && success)
					{
						Console.Write(keyInfo.KeyChar);
						data += keyInfo.KeyChar;
					}

				} while (key != ConsoleKey.Enter);

				if (data == "")
					continue;

				return data;
			}
		}

		static int ReadAge()
		{
			
				Console.Write("");
				while (true)
				{
					string data = "";
					ConsoleKey key;

					do
					{
						var keyInfo = Console.ReadKey(intercept: true);
						key = keyInfo.Key;

						int value;
						bool success = int.TryParse(keyInfo.KeyChar.ToString(), out value);

						if (key == ConsoleKey.Backspace && data.Length > 0)
						{
							Console.Write("\b \b");
							data = data.Remove(data.Length - 1);
						}
						else if (!char.IsControl(keyInfo.KeyChar) && success)
						{
							Console.Write(keyInfo.KeyChar);
							data += keyInfo.KeyChar;
						}
					} while (key != ConsoleKey.Enter);

					if (data == "")
						continue;

					return int.Parse(data);

				}

		}

		static decimal ReadMoney()
		{
			Console.Write("");
			while (true)
			{
				string data = "";
				ConsoleKey key;
				int c = 0;

				do
				{
					var keyInfo = Console.ReadKey(intercept: true);
					key = keyInfo.Key;

					int value;
					bool success = int.TryParse(keyInfo.KeyChar.ToString(), out value) || (keyInfo.KeyChar == '.' && c == 0);

					if (keyInfo.KeyChar == '.')
					{
						c = 1;
					}
					else
					{
						c = 0;
					}

					if (key == ConsoleKey.Backspace && data.Length > 0)
					{
						Console.Write("\b \b");
						data = data.Remove(data.Length - 1);
					}
					else if (!char.IsControl(keyInfo.KeyChar) && success)
					{
						Console.Write(keyInfo.KeyChar);
						data += keyInfo.KeyChar;
					}

				} while (key != ConsoleKey.Enter);

				if (data == "")
				{
					continue;
				}

				return decimal.Parse(data);

			}

		}




	
	}

}
