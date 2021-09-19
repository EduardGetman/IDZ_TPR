using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Competences;
using Domain.Models;
using Domain.Models.Builders;
using Domain;
namespace TestDomain
{
    class Program
    {
        static CompetenceLevelScale scale = new CompetenceLevelScale(0, 5);
        static ModelParametrs[] modelParametrs = new ModelParametrs[]
        {
            new ModelParametrs(scale,"Model1",0, new AssesmentParametrs[]{
                new AssesmentParametrs("c1",3),
                new AssesmentParametrs("c2",4),
                new AssesmentParametrs("c3",3),
            }),
            new ModelParametrs(scale,"Model2",0, new AssesmentParametrs[]{
                new AssesmentParametrs("c1",4),
                new AssesmentParametrs("c2",4),
                new AssesmentParametrs("c3",3),
            }),
            new ModelParametrs(scale,"Model3",0, new AssesmentParametrs[]{
                new AssesmentParametrs("c1",3),
                new AssesmentParametrs("c2",4),
                new AssesmentParametrs("c3",4),
            }),
            new ModelParametrs(scale,"Model4",0, new AssesmentParametrs[]{
                new AssesmentParametrs("c1",4),
                new AssesmentParametrs("c2",4),
                new AssesmentParametrs("c3",4),
            })

        };
        static ModelParametrs[] positionParametrs = new ModelParametrs[]
        {
            new ModelParametrs(scale,"Position1",0.25, new AssesmentParametrs[]{
                new AssesmentParametrs("c1",2),
                new AssesmentParametrs("c2",3),
                new AssesmentParametrs("c3",2),
            }),
            new ModelParametrs(scale,"Position2",0.25, new AssesmentParametrs[]{
                new AssesmentParametrs("c1",3),
                new AssesmentParametrs("c2",3),
                new AssesmentParametrs("c3",2),
            }),
            new ModelParametrs(scale,"Position3",0.25, new AssesmentParametrs[]{
                new AssesmentParametrs("c1",2),
                new AssesmentParametrs("c2",3),
                new AssesmentParametrs("c3",3),
            }),
            new ModelParametrs(scale,"Position4",0.25, new AssesmentParametrs[]{
                new AssesmentParametrs("c1",3),
                new AssesmentParametrs("c2",3),
                new AssesmentParametrs("c3",3),
            })

        };
        static void Main(string[] args)
        {
            ModelCompetence[] models = ConstructModels();
            Position[] positions = ConstructPosition();
            DistributionBuilder distributionBuilder = new DistributionBuilder(positions, models);
            Distribution distribution = distributionBuilder.BuildOptimalDistribution();
            Console.WriteLine(DistributionToString(distribution));
        }
        static ModelCompetence[] ConstructModels()
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
        static Position[] ConstructPosition()
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
}
