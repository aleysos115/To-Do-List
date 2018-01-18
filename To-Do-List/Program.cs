using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
	class Program
	{
		public static String header = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
		public static String Welcome = "Welcome to the Planner";
		static void Main(string[] args)
		{
			List<Item> itemList = new List<Item>();
			System.Console.WriteLine(header);
			System.Console.WriteLine(Welcome.PadLeft(System.Console.WindowWidth / 3, ' '));
			//itemList.Add(new Item("Go to Work", new DateTime(2018, 1, 18, 12, 00, 00), "Seven hour shift at Jack London"));
			String input = " ";
			while(input != "quit")
			{
				foreach (Item item in itemList)
				{
					item.printItem();
				}
				System.Console.WriteLine("add - add task, delete - delete task, complete - mark completed, quit - close");
				input = System.Console.ReadLine();
				switch (input)
				{
					case "quit":
						break;
					case "add":
						System.Console.WriteLine("Please enter a new task formate(Name, Date(dd/mm/yyyy), Description)");
						input = System.Console.ReadLine();
						itemList.Add(new Item(Helper.SubStringtoChar(ref input, ','), Helper.StringToDate(Helper.SubStringtoChar(ref input, ',')), Helper.SubStringtoChar(ref input, ',')));
						break;
					case "delete":
						break;
					case "complete":
						break;
				}
					
			}
		}
	}
}
