using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
	static class Helper
	{
		public static String SubStringtoChar(ref String input, char stopper)
		{
			String result;
			int index = input.IndexOf(stopper);
			if(index != -1)
			{
				result = input.Substring(0, index);
				input = input.Remove(0, index + 1);
				return result;
			}
			else
			{
				return input;
			}
		}

		public static DateTime StringToDate(string input)
		{
			int DD, MM, YYYY;
			DD = Int32.Parse(input.Substring(0, input.IndexOf('/')));
			input = input.Remove(0, input.IndexOf('/') + 1);
			MM = Int32.Parse(input.Substring(0, input.IndexOf('/')));
			input = input.Remove(0, input.IndexOf('/') + 1);
			YYYY = Int32.Parse(input);
			return new DateTime(YYYY, MM, DD);
		}
	}
}
