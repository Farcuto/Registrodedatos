using System;
using System.IO;
using System.Text;

namespace Registro_V1
{
	class Program
	{
		static void Main(string[] args)
		{	
			bool add = true;
			char conditional;
			long id;
			int edad;
			byte select = 0;
			string name, last_name, record, input;

			Console.Write("1- Agregar \n2- Listar\n3- Buscar\nElija la opcion deseada: ");
			select = Byte.Parse(Console.ReadLine());

			switch(select)
			{
				case 1:
					while(add)
					{
						Console.Write("Inserte su Numero de Cedula: ");
						id = (Int64.Parse(Console.ReadLine()));

						Console.Write("Inserte su Nombre: ");
						name = Console.ReadLine();

						Console.Write("Inserte su Apellido: ");
						last_name = Console.ReadLine();

						Console.Write("Inserte su edad: ");
						edad = (Int32.Parse(Console.ReadLine()));

						Console.WriteLine("La Informacion registrada es: " + id + "," + name + "," + last_name + "," + edad + "\n \n");

						Console.Write("Desea Seguir Agregando?(Y/N):  ");
						conditional = Char.Parse(Console.ReadLine());

						using (Stream file_write = new FileStream("/Users/fernandor/Desktop/C/Registro.csv",FileMode.Append, FileAccess.Write))
						{
							using (StreamWriter Data = new StreamWriter(file_write))
							{
								Data.WriteLine(id + "," + name + "," + last_name + "," + edad);
							}
						}

						if(conditional == 'Y' || conditional == 'y')
						{
							add = true;
						}
						if(conditional == 'N' || conditional == 'n')
						{
							add = false;
						}

					}

				break;

				case 2:
					Console.WriteLine("\nLISTAR	\n \n");
					Stream file_read = new FileStream("/Users/fernandor/Desktop/C/Registro.csv",FileMode.Open, FileAccess.Read);
					StreamReader read = new StreamReader(file_read);

					while(!read.EndOfStream)
					{
						Console.WriteLine(read.ReadLine());
					}
					Console.WriteLine("__________________________________________________________________");
					Console.WriteLine("Fin...");
					Console.ReadKey();

				break;

				case 3:
					Console.WriteLine("\nBUSCAR	\n \n");
					Stream file_find = new FileStream("/Users/fernandor/Desktop/C/Registro.csv",FileMode.Open, FileAccess.Read);
					StreamReader find = new StreamReader(file_find);

					Console.Write("Inserte la Cedula o Id que desea Buscar: ");
					input = Console.ReadLine();

					record = find.ReadLine();

					while(record != null)
					{
						if(record.Contains(input))
						{
							Console.WriteLine(record);
						}
						record = find.ReadLine();
					}
					Console.ReadKey();

				break;


			}

		}
	}
}
