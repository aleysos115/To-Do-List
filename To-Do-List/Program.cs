using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
	class Program
	{
		public static String header = "";
		public static String Welcome = "Welcome to the Planner";
		static void Main(string[] args)
		{
			FileStream file = new FileStream("tasks.json", FileMode.OpenOrCreate, FileAccess.ReadWrite);
			header = header.PadLeft(Console.WindowWidth, '~');
			List<Item> itemList = new List<Item>();
			ReadFile(itemList, file);
			String input = " ";
			while(input != "quit")
			{
				PrintMenu(itemList);
				input = Console.ReadLine();
				switch (input)
				{
					case "quit":
						WriteFile(itemList, file);
						break;
					case "add":
						itemList.Add(AddItem(input));
						break;
					case "delete":
						DeleteItem(itemList);
						break;
					case "complete":
						SetComplete(itemList);
						break;
				}
					
			}
			file.Close();
		}

		public static void ReadFile(List<Item> itemList, FileStream file)
		{
			try
			{
				using (StreamReader reader = new StreamReader(file))
				{
					List<Item> fromFile = Helper.ReadJsonFromFile<Item>(reader);
					if (fromFile != null)
					{
						foreach (Item item in fromFile)
						{
							itemList.Add(item);
						}
					}
				}
			}
			catch (Exception e)
			{
				throw new Exception(String.Format("An error ocurred while executing the data import: {0}", e.Message), e);
			}
			finally
			{
				File.Delete("tasks.json");
			}
		}

		public static void WriteFile(List<Item> itemList, FileStream file)
		{
			try
			{
				using (StreamWriter writer = File.AppendText("tasks.json"))
				{
					Helper.WriteJsonToFile<Item>(writer, itemList);
				}
			}
			catch (Exception e)
			{
				throw new Exception(String.Format("An error ocurred while executing the data import: {0}", e.Message), e);
			}
		}

		static void PrintMenu(List<Item> itemList)
		{
			Console.Clear();
			Console.WriteLine(header);
			Console.SetCursorPosition((Console.WindowWidth - Welcome.Length) / 2, Console.CursorTop);
			Console.WriteLine(Welcome);
			Console.WriteLine();
			Console.WriteLine(new String('_', Console.WindowWidth));
			foreach (Item item in itemList)
			{
				item.PrintItem(itemList.IndexOf(item));
			}
			Console.WriteLine(new String('_', Console.WindowWidth));
			Console.WriteLine(" add - add task\n delete - delete task\n complete - mark completed\n quit - close\n");
			Console.SetCursorPosition(1, Console.CursorTop);
		}
		
		static Item AddItem(String input)
		{
			Console.SetCursorPosition(1, Console.CursorTop);
			Console.WriteLine("Please state the name of the Task");
			Console.SetCursorPosition(1, System.Console.CursorTop);
			String name = Console.ReadLine();

			Console.SetCursorPosition(1, Console.CursorTop);
			Console.WriteLine("Please write the due date in DD/MM/YYYY formate");
			Console.SetCursorPosition(1, Console.CursorTop);
			DateTime date = Helper.StringToDate(Console.ReadLine());

			Console.SetCursorPosition(1, Console.CursorTop);
			Console.WriteLine("Please state the description of the task");
			Console.SetCursorPosition(1, Console.CursorTop);
			String description = Console.ReadLine();

			return new Item(name, date, description);
		}

		static void DeleteItem(List<Item> itemList)
		{
			Console.SetCursorPosition(1, Console.CursorTop);
			Console.WriteLine("Please enter index of item you wish to delete");

			Console.SetCursorPosition(1, Console.CursorTop);
			int index = Int32.Parse(System.Console.ReadLine());

			Console.SetCursorPosition(1, Console.CursorTop);
			Console.WriteLine("Are you sure you want to Delete:");
			Console.SetCursorPosition(1, Console.CursorTop);
			itemList.ElementAt(index).PrintItem(index);
			Console.SetCursorPosition(1, Console.CursorTop);
			Console.WriteLine("	y/n");
			Console.SetCursorPosition(1, Console.CursorTop);
			String input = Console.ReadLine();
			if(input == "y")
			{
				itemList.RemoveAt(index);
			}
			else
			{
				return;
			}
		}
		static void SetComplete(List<Item> itemList)
		{
			Console.SetCursorPosition(1, Console.CursorTop);
			Console.WriteLine("Please enter index of item you wish to set complete");
			Console.SetCursorPosition(1, Console.CursorTop);
			int index = Int32.Parse(Console.ReadLine());
			itemList.ElementAt(index).SetComplete(true);
		}
	}
}
