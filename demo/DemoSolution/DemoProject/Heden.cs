using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject
{
	public class Heden
	{
		public string GeefHeden()
		{
			return DateTime.Now.ToShortTimeString();
		}

		public string WriteFile()
		{
			if (Directory.Exists("E:\\what\\huh.txt"))
			{
				return "yay bestaat";
			}
			return "nope bestaat niet";
		}
	}
}
