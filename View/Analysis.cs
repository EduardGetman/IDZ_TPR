using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Competences;
using Domain.Models.Builders;
using Domain;

namespace View
{
	class Analysis
	{
		//string[] name { get; set; } // Названия компетенций
		//int[][] positionsLevels { get; set; }// Внутр чатьс табл 2
		//int[] importanceCoefficient { get; set; }// Коэф важности производственной функции
		//int[][] employsLevels { get; set; }// Внутр чатьс табл 1

		public static Dictionary<string, string> main(string[] name, int[][] positionsLevels, int[] importanceCoefficient, int[][] employsLevels, KeyValuePair<int,int> minAndMaxSkillLevel)
		{
			CompetenceLevelScale scale = new CompetenceLevelScale(0, 5);
			List<ModelCompetence> models = new List<ModelCompetence>();
			List<Position> positions = new List<Position>();
			foreach (int[] employee in employsLevels)
			{
				ModelBuilder modelBuilder = new ModelBuilder(scale, "Имя сторудника");
				for (int i = 0; i < employee.Length; i++)
				{
					modelBuilder.Add(name[i], employee[i]);
				}
				models.Add(modelBuilder.Build());
			}
			foreach (int[] positionLevels in positionsLevels)
			{
				ModelBuilder positonBuilder = new PositionBuilder(scale, "Название компетенции");
				for (int i = 0; i < positionLevels.Length; i++)
				{
					positonBuilder.Add(name[i], positionLevels[i]);
				}
				positions.Add(positonBuilder.Build() as Position);
			}
			DistributionBuilder distributionBuilder = new DistributionBuilder(positions.ToArray(), models.ToArray());
			Distribution distibution = distributionBuilder.BuildOptimalDistribution();
			double effectiveness = distibution.Effectiveness;

			Dictionary<string, string> EmployeePositionsDisribution = new Dictionary<string, string>();
			foreach (Appointment item in distibution)
			{
				EmployeePositionsDisribution.Add(item.Employee.Name, item.Position.Name);
			}

			return EmployeePositionsDisribution;
		}
	}
}
