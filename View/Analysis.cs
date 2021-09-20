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

		public static Distribution main(string[] skillName, int[][] positionsLevels,
			Double[] importanceCoefficient, int[][] employsLevels,
			KeyValuePair<int, int> minAndMaxSkillLevel, String[] employeeNames, String[] positionNames,
			String[] requiredCompetenceName)
		{
			CompetenceLevelScale scale = new CompetenceLevelScale(minAndMaxSkillLevel.Key, minAndMaxSkillLevel.Value);

			List<ModelParametrs> modelParametrs = new List<ModelParametrs>();

			for (int i = 0; i < importanceCoefficient.Length; ++i)
			{
				List<AssesmentParametrs> assesmentParametrs = new List<AssesmentParametrs>();
				for (int j = 0; j < skillName.Length; ++j)
				{
					assesmentParametrs.Add(new AssesmentParametrs(skillName[j], employsLevels[i][j]));
				}
				modelParametrs.Add(new ModelParametrs(scale, employeeNames[i], importanceCoefficient[i],
	assesmentParametrs.ToArray()));
			}


			List<ModelParametrs> positionParametrs = new List<ModelParametrs>();

			for (int i = 0; i < positionNames.Length; ++i)
			{
				List<AssesmentParametrs> assesmentParametrs = new List<AssesmentParametrs>();
				for (int j = 0; j < requiredCompetenceName.Length; ++j)
				{
					assesmentParametrs.Add(new AssesmentParametrs(requiredCompetenceName[j], positionsLevels[i][j]));
				}
				positionParametrs.Add(new ModelParametrs(scale, positionNames[i], importanceCoefficient[i],
					assesmentParametrs.ToArray()));
			}

			ModelCompetence[] models = ConstructModels(modelParametrs.ToArray());
			Position[] positions = ConstructPosition(positionParametrs.ToArray());
			DistributionBuilder distributionBuilder = new DistributionBuilder(positions, models);
			return distributionBuilder.BuildOptimalDistribution();
		}
		static ModelCompetence[] ConstructModels(ModelParametrs[] modelParametrs)
		{
			List<ModelCompetence> models = new List<ModelCompetence>();
			foreach (ModelParametrs model in modelParametrs)
			{
				ModelBuilder builder = new ModelBuilder(model.Scale, model.Name);
				foreach (AssesmentParametrs assesment in model.Assesments)
				{
					builder.Add(assesment.Name, assesment.Level);
				}
				models.Add(builder.Build());
			}
			return models.ToArray();
		}
		static Position[] ConstructPosition(ModelParametrs[] positionParametrs)
		{
			List<Position> positions = new List<Position>();
			foreach (ModelParametrs model in positionParametrs)
			{
				PositionBuilder builder = new PositionBuilder(model.Scale, model.Name, model.Importance);
				foreach (AssesmentParametrs assesment in model.Assesments)
				{
					builder.Add(assesment.Name, assesment.Level);
				}
				positions.Add(builder.Build() as Position);
			}
			return positions.ToArray();
		}
		static string DistributionToString(Distribution distribution)
		{
			string result = string.Empty;
			foreach (Appointment appointment in distribution)
			{
				result += $"Position: {appointment.PositionName} - Employee:{appointment.EmployeeName}, Effectiveness = {appointment.Effectiveness}";
				result += Environment.NewLine;
			}
			result += $"Total effectiveness ={distribution.Effectiveness}";
			return result;
		}
	}

	//public static Dictionary<string, string> main(string[] competenceName, int[][] positionsLevels, Double[] importanceCoefficient, int[][] employsLevels,
	//	KeyValuePair<int, int> minAndMaxSkillLevel, String[] employeeNames, String[] positionNames)
	//{
	//	CompetenceLevelScale scale = new CompetenceLevelScale(0, 5);
	//	List<ModelCompetence> models = new List<ModelCompetence>();
	//	List<Position> positions = new List<Position>();



	//	//foreach (int[] employee in employsLevels)
	//	//{
	//	//	ModelBuilder modelBuilder = new ModelBuilder(scale, "Имя сторудника");
	//	//	for (int i = 0; i < employee.Length; i++)
	//	//	{
	//	//		modelBuilder.Add(competenceName[i], employee[i]);
	//	//	}
	//	//	models.Add(modelBuilder.Build());
	//	//}
	//	for (int i = 0; i < employsLevels.Length; ++i)
	//	{//Имя сотрудника+
	//		ModelBuilder modelBuilder = new ModelBuilder(scale, employeeNames[i]);
	//		for (int j = 0; j < employsLevels[i].Length; j++)
	//		{//название компетенций+
	//			modelBuilder.Add(competenceName[j], employsLevels[i][j]);
	//		}
	//		models.Add(modelBuilder.Build());
	//	}


	//	//foreach (int[] positionLevels in positionsLevels)
	//	//{
	//	//	ModelBuilder positonBuilder = new PositionBuilder(scale, "Название компетенции",);
	//	//	for (int i = 0; i < positionLevels.Length; i++)
	//	//	{
	//	//		positonBuilder.Add(competenceName[i], positionLevels[i]);
	//	//	}
	//	//	positions.Add(positonBuilder.Build() as Position);
	//	//}
	//	for (int i = 0; i < positionsLevels.Length; ++i)
	//	{//Названия должностей
	//		ModelBuilder positonBuilder = new PositionBuilder(scale, positionNames[i], importanceCoefficient[i]);
	//		for (int j = 0; j < positionsLevels[i].Length; ++j)
	//		{
	//			positonBuilder.Add(competenceName[i], positionsLevels[i][j]);
	//		}
	//		positions.Add(positonBuilder.Build() as Position);
	//	}

	//	DistributionBuilder distributionBuilder = new DistributionBuilder(positions.ToArray(), models.ToArray());
	//	Distribution distibution = distributionBuilder.BuildOptimalDistribution();
	//	double effectiveness = distibution.Effectiveness;

	//	Dictionary<string, string> EmployeePositionsDisribution = new Dictionary<string, string>();
	//	foreach (Appointment item in distibution)
	//	{
	//		EmployeePositionsDisribution.Add(item.Employee.Name, item.Position.Name);
	//	}

	//	return EmployeePositionsDisribution;
	//}
}