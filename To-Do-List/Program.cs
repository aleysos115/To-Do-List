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
			header = header.PadLeft(System.Console.WindowWidth, '~');
			List<Item> itemList = new List<Item>();
			String input = " ";
			while(input != "quit")
			{
				PrintMenu(itemList);
				input = System.Console.ReadLine();
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
			System.Console.Clear();
			System.Console.WriteLine(header);
			System.Console.SetCursorPosition((System.Console.WindowWidth - Welcome.Length) / 2, System.Console.CursorTop);
			System.Console.WriteLine(Welcome);
			System.Console.WriteLine();
			System.Console.WriteLine(new String('_', System.Console.WindowWidth));
			foreach (Item item in itemList)
			{
				System.Console.Write(itemList.IndexOf(item) + "		");
				item.printItem(itemList.IndexOf(item));
			}
			System.Console.WriteLine(new String('_', System.Console.WindowWidth));
			System.Console.WriteLine(" add - add task\n delete - delete task\n complete - mark completed\n quit - close\n");
			System.Console.SetCursorPosition(1, System.Console.CursorTop);
		}
		
		static Item AddItem(String input)
		{
			System.Console.WriteLine("Please state the name of the Task");
			String name = System.Console.ReadLine();

			System.Console.WriteLine("Please write the due date in DD/MM/YYYY formate");
			DateTime date = Helper.StringToDate(System.Console.ReadLine());

			System.Console.WriteLine("Please state the description of the task");
			String description = System.Console.ReadLine();

			return new Item(name, date, description);
		}

		static void DeleteItem(List<Item> itemList)
		{
			System.Console.WriteLine("Please enter index of item you wish to delete");
			int index = Int32.Parse(System.Console.ReadLine());
			System.Console.WriteLine("Are you sure you want to Delete:");
			System.Console.Write(index + "		");
			itemList.ElementAt(index).printItem(index);
			System.Console.WriteLine("	y/n");
			String input = System.Console.ReadLine();
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
			System.Console.WriteLine("Please enter index of item you wish to set complete");
			int index = Int32.Parse(System.Console.ReadLine());
			itemList.ElementAt(index).setComplete(true);
		}
	}
}
