using Domain.Competences;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
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
