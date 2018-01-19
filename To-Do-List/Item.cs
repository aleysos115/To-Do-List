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
			Console.WriteLine("|" + Helper.PadBoth(index.ToString(), 10) + "|" + Helper.PadBoth(taskName, 20) + "|" + Helper.PadBoth(date.ToShortDateString(), 20) + "|" + Helper.PadBoth(isComplete.ToString(), 10) + "|");
		}

		public void SetComplete(bool complete)
		{
			isComplete = complete;
		}
	}
}
