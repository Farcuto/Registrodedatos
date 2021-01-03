using System;

using System.IO;

namespace RegistroV5
{
    class Program
    {
        
        static int Bits(int edad, char gender, char state, char grade)
        {
            int date;

                date = edad << 4;

            if (gender == 'F')
            {
                date |= 8;
            }

            if (state == 'C')
            {
                date |= 4;
            }

            if (grade == 'M')
            {
                date |= 1;
            }
            else if (grade == 'G')
            {
                date |= 2;
            }
            else if (grade == 'P')
            {
                date |= 3;
            }

            return date;
        }

        static void ReadBits(int date, out int edad, out char gender, out char state, out char grade)
        {
            edad = date >> 4;

            date &= 15;
            if ((date >> 3) == 1)
            {
                gender = 'F';
            }

            else
            {
                gender = 'M';
            }

            date &= 7;

            if ((date >> 2) == 1)
            {
                state = 'C';
            }
            else
            {
                state = 'S';
            }

            date &= 3;

            if (date == 0)
            {
                grade = 'I';
            }
            else if (date == 1)
            {
                grade = 'M';
            }
            else if (date == 2)
            {
                grade = 'G';
            }
            else
            {
                grade = 'P';
            }



        }

		static void Main(string[] args)//
		{

			char conditional, split = ',', gender = 'n', state = 'n', grade = 'n';
			string[] camp = new string[4];
			string id = "", name, last_name, record, input, line, pass1, pass2;
			bool add = true, found = true;
			byte select = 0;
			int edad = 0, date;
			decimal money = 0;


			StreamReader reader;
			StreamWriter write;

			Console.Write("1- Agregar \n2- Listar\n3- Buscar\n4- Editar\n5- Eliminar\nElija la opcion deseada: ");
			select = Byte.Parse(Console.ReadLine());

			switch (select)
			{
				case 1:
					while (add)
					{
						Console.Write("Inserte su Numero de Cedula: ");
						id = Readid();
						Console.WriteLine();

						Console.Write("Inserte su Nombre: ");
						name = Console.ReadLine();
						Console.WriteLine();

						Console.Write("Inserte su Apellido: ");
						last_name = Console.ReadLine();
						Console.WriteLine();


						/*Console.Write("Inserte su edad: ");
						edad = ReadAge();
						Console.WriteLine();*/

						Console.Write("Edad: ");
						edad = Convert.ToInt32(Console.ReadLine().ToUpper());
						Console.WriteLine();

						Console.Write("Genero(F/M): ");
						gender = Convert.ToChar(Console.ReadLine().ToUpper());
						Console.WriteLine();

						Console.Write("Estado(S/C): ");
						state = Convert.ToChar(Console.ReadLine().ToUpper());
						Console.WriteLine();

						Console.Write("Grado(I/M/G/P): ");
						grade = Convert.ToChar(Console.ReadLine().ToUpper());
						Console.WriteLine();

						Console.WriteLine(Bits(edad, gender, state, grade));
						Console.WriteLine();


						date = Bits(edad, gender, state, grade);

						ReadBits(date, out edad, out gender, out state, out grade);

						Console.WriteLine("Edad: {0}", edad);
						Console.WriteLine("Genero: {0}", gender);
						Console.WriteLine("Estado: {0}", state);
						Console.WriteLine("Grado: {0}", grade);

						Console.Write("Ahorros: ");
						money = ReadMoney();
						Console.WriteLine();

						password:
						Console.Write("Contraseña: ");
						pass1 = ReadPassword();
						Console.WriteLine();

						Console.Write("confirmar Contraseña: ");
						pass2 = ReadPassword();
						Console.WriteLine();

						if (pass1 == pass2)
						{
							Console.WriteLine("La Informacion registrada es: " + id + "," + name + "," + last_name + "," + edad + "," + gender + "," + state + "," + grade + "," + money + "," + pass1 + "\n \n");
						}
						else
						{
							goto password;
						}

						Console.Write("Desea Seguir Agregando?(Y/N):  ");
						conditional = Char.Parse(Console.ReadLine());

						using (Stream file_write = new FileStream("/Users/fernandor/Desktop/C/Registro.csv", FileMode.Append, FileAccess.Write))
						{
							using (StreamWriter Data = new StreamWriter(file_write))
							{
								Data.WriteLine(id + "," + name + "," + last_name + "," + edad + "," + gender + "," + state + "," + grade + "," + money + "," + pass1);
							}
						}

						if (conditional == 'Y' || conditional == 'y')
						{
							add = true;
						}
						if (conditional == 'N' || conditional == 'n')
						{
							add = false;
						}

					}

					break;

				case 2:
					Console.WriteLine("\nLISTAR	\n \n");
					Stream file_read = new FileStream("/Users/fernandor/Desktop/C/Registro.csv", FileMode.Open, FileAccess.Read);
					StreamReader read = new StreamReader(file_read);

					while (!read.EndOfStream)
					{
						Console.WriteLine(read.ReadLine());

					}
					Console.WriteLine("__________________________________________________________________");
					Console.WriteLine("Fin...");
					Console.ReadKey();

					break;

				case 3:
					Console.WriteLine("\nBUSCAR	\n \n");
					Stream file_find = new FileStream("/Users/fernandor/Desktop/C/Registro.csv", FileMode.Open, FileAccess.Read);
					StreamReader find = new StreamReader(file_find);

					Console.Write("Inserte la Cedula o Id que desea Buscar: ");
					input = Console.ReadLine();

					record = find.ReadLine();

					while (record != null)
					{
						if (record.Contains(input))
						{
							Console.WriteLine(record);
						}
						record = find.ReadLine();
					}
					Console.ReadKey();

					break;

				case 4:
					try
					{
						reader = File.OpenText("/Users/fernandor/Desktop/C/Registro.csv");
						write = File.CreateText("/Users/fernandor/Desktop/C/tmp_Registro.csv");
						id = Readid();
						line = reader.ReadLine();

						while (line != null)
						{
							camp = line.Split(split);
							if (camp[0].Trim().Equals(id))
							{
								found = true;
								Console.WriteLine("La Informacion registrada es: " + id);
								Console.WriteLine("Es correcto el valor encontrado?(Y/N): ");
								conditional = Convert.ToChar(Console.ReadLine());

								if (conditional == 'Y' || conditional == 'y')
								{
									Console.Write("Inserte su Numero de Cedula: ");
									id = Readid();

									Console.Write("Inserte su Nombre: ");
									name = Console.ReadLine();

									Console.Write("Inserte su Apellido: ");
									last_name = Console.ReadLine();

									/*Console.Write("Inserte su edad: ");
									edad = ReadAge();*/

									Console.Write("Edad: ");
									edad = Convert.ToInt32(Console.ReadLine().ToUpper());
									Console.WriteLine();

									Console.Write("Genero(F/M): ");
									gender = Convert.ToChar(Console.ReadLine().ToUpper());
									Console.WriteLine();

									Console.Write("Estado(S/C): ");
									state = Convert.ToChar(Console.ReadLine().ToUpper());
									Console.WriteLine();

									Console.Write("Grado(I/M/G/P): ");
									grade = Convert.ToChar(Console.ReadLine().ToUpper());
									Console.WriteLine();

									Console.WriteLine(Bits(edad, gender, state, grade));
									Console.WriteLine();


									date = Bits(edad, gender, state, grade);

									ReadBits(date, out edad, out gender, out state, out grade);

									Console.WriteLine("Edad: {0}", edad);
									Console.WriteLine("Genero: {0}", gender);
									Console.WriteLine("Estado: {0}", state);
									Console.WriteLine("Grado: {0}", grade);

									Console.WriteLine("La Informacion registrada es: " + id + "," + name + "," + last_name + "," + edad + "," + gender + "," + state + "," + grade + "," + money + "," + "\n \n");

									Console.Write("Desea guardar?(Y/N): ");
									conditional = Convert.ToChar(Console.ReadLine());

									if (conditional == 'Y' || conditional == 'y')
									{
										write.WriteLine(id + "," + name + "," + last_name + "," + date + "," + money);
									}

								}


							}

							else
							{
								write.WriteLine(line);
							}
							line = reader.ReadLine();
						}

						if (found == false)
						{
							Console.WriteLine("Esta cedula no exite");

						}
						else
						{
							reader.Close();
							write.Close();
							File.Delete("/Users/fernandor/Desktop/C/Registro.csv");
							File.Move("/Users/fernandor/Desktop/C/tmp_Registro.csv", "/Users/fernandor/Desktop/C/Registro.csv");
						}
					}
					catch (FileNotFoundException ex)
					{
						Console.WriteLine("Error: {0}", ex.Message);
					}

					break;

				case 5:
					try
					{
						reader = File.OpenText("/Users/fernandor/Desktop/C/Registro.csv");
						write = File.CreateText("/Users/fernandor/Desktop/C/tmp_Registro.csv");

						Console.Write("Introduzca la cedula que desea eliminar: ");
						id = Readid();
						line = reader.ReadLine();

						while (line != null)
						{
							camp = line.Split(',');
							if (camp[0].Trim().Equals(id))
							{
								found = true;



							}

							else
							{
								write.WriteLine(line);
							}
							line = reader.ReadLine();
						}

						if (found == false)
						{
							Console.WriteLine("Esta cedula no exite");

						}
						else
						{
							reader.Close();
							write.Close();
							File.Delete("/Users/fernandor/Desktop/C/Registro.csv");
							File.Move("/Users/fernandor/Desktop/C/tmp_Registro.csv", "/Users/fernandor/Desktop/C/Registro.csv");
						}
					}
					catch (FileNotFoundException ex)
					{
						Console.WriteLine("Error: {0}", ex.Message);
					}

					break;


			}

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


	}//


}