using Domain.Competences;
using System.Collections.Generic;

namespace Domain.Models.Builders
{
    class PositionBuilder : ModelBuilder
    {
        public PositionBuilder(CompetenceLevelScale scale) : base(scale)
        {
        }
        public override ModelCompetence Build()
        {
            return new Position(BuildRequirements(), _scale);
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
