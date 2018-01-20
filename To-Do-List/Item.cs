using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
	class Item
	{
		public String taskName;
		public DateTime date;
		public String description;
		public bool isComplete = false;
		public Item(String _taskName, DateTime _date, String _description)
		{
			taskName = _taskName;
			date = _date;
			description = _description;
			isComplete = false;
		}

		public void PrintItem(int index)
		{
			Console.WriteLine("|" + Helper.PadBoth(index.ToString(), 10) + "|" + Helper.PadBoth(taskName, 20) + "|" + Helper.PadBoth(date.ToShortDateString(), 20) + "|" + Helper.PadBoth(isComplete.ToString(), 10) + "|");
		}

		public void SetComplete(bool complete)
		{
			isComplete = complete;
		}
	}
}
