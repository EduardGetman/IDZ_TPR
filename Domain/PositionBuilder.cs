using Domain.Competences;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class PositionBuilder : AbstractBuilder
    {
        public PositionBuilder(CompetenceLevelScale scale) : base(scale)
        {
        }
        public ModelCompetence Build()
        {
            return new Position(BuildAssesments(), _scale);
        }
        private Requirement[] BuildAssesments()
        {
            List<AssessmentСompetence> assessments = new List<AssessmentСompetence>();
            foreach (var item in _assesmentParametrs)
            {
                assessments.Add(new AssessmentСompetence(item.Key, item.Value);
            }
            return assessments.ToArray();
        }
    }
}
