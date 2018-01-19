using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
	class Item
	{
		private String taskName;
		private DateTime date;
		private String description;
		private bool isComplete = false;
		public Item(String _taskName, DateTime _date, String _description)
		{
			taskName = _taskName;
			date = _date;
			description = _description;
			isComplete = false;
		}

		public void printItem(int index)
		{
			System.Console.WriteLine("|\t" + index.ToString().PadRight(5) + "|" + taskName.PadRight(5) + "|" + date.ToString().PadRight(5) + "|\t" + isComplete.ToString());
		}

		public void setComplete(bool complete)
		{
			isComplete = complete;
		}
	}
}
