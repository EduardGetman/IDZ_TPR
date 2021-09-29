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
		List<List<String>> matrixOne;
		List<List<String>> matrixTwo;
		int minSkillLevel;
		int maxSkillLevel;
		int employeeCount;
		int employeeCompetenceCount;
		int functionCount;
		int competenceCount;

		public ViewData() { }

		public ViewData(List<List<String>> matrixOne,
		List<List<String>> matrixTwo,
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
