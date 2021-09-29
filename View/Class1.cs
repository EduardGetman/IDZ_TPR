using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
	[Serializable]
	public class Class1
	{
		public String data{get;set;}

		public Class1() { }
		public Class1(String data) { this.data = data; }
	}
}
