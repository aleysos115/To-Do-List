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
		bool isComplete;
		public Item(String _taskName, DateTime _date, String _description)
		{
			taskName = _taskName;
			date = _date;
			description = _description;
			isComplete = false;
		}

		public void printItem()
		{
			System.Console.WriteLine(taskName.PadLeft(5, ' ') + description.PadLeft(5, ' ') + date.ToLongDateString().PadLeft(5, ' '));
		}
	}
}
