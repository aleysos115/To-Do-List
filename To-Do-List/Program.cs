using System;
using System.Collections.Generic;
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
			header = header.PadLeft(Console.WindowWidth, '~');
			List<Item> itemList = new List<Item>();
			String input = " ";
			while(input != "quit")
			{
				PrintMenu(itemList);
				input = Console.ReadLine();
				switch (input)
				{
					case "quit":
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
				item.printItem(itemList.IndexOf(item));
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
			itemList.ElementAt(index).printItem(index);
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
