using Domain.Competences;
using System.Collections.Generic;

namespace Domain.Models.Builders
{
    public class PositionBuilder : ModelBuilder
    {
        public PositionBuilder(CompetenceLevelScale scale, string name) : base(scale, name)
        {
        }
        public override ModelCompetence Build()
        {
            return new Position(BuildRequirements(), _scale, Name);
        }
        private Requirement[] BuildRequirements()
        {
            List<Requirement> requirements = new List<Requirement>();
            foreach (var item in _assesmentParametrs)
            {
                requirements.Add(new Requirement(item.Key, item.Value));
            }
            return requirements.ToArray();
        }
    }
}
