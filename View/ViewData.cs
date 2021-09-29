using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
	[Serializable]
	public class ViewData
	{
		//List<List<String>> matrixOne { get; set; }
		//List<List<String>> matrixTwo { get; set; }
		public String[][] matrixOne { get; set; }
		public String[][] matrixTwo { get; set; }
		public int minSkillLevel { get; set; }
		public int maxSkillLevel { get; set; }
		public int employeeCount { get; set; }
		public int employeeCompetenceCount { get; set; }
		public int functionCount { get; set; }
		public int competenceCount { get; set; }

		public ViewData() { }

		public ViewData(String[][] matrixOne,
		String[][] matrixTwo,
		int minSkillLevel,
		int maxSkillLevel,
		int employeeCount,
		int employeeCompetenceCount,
		int functionCount,
		int competenceCount)
		{
			this.matrixOne = matrixOne;
			this.matrixTwo = matrixTwo;
			this.minSkillLevel = minSkillLevel;
			this.maxSkillLevel = maxSkillLevel;
			this.employeeCount = employeeCount;
			this.employeeCompetenceCount = employeeCompetenceCount;
			this.functionCount = functionCount;
			this.competenceCount = competenceCount;
		}
	}
}