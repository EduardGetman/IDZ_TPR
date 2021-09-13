using System;
using System.Collections.Generic;
using Domain.Competences;
using Domain.Models;

namespace Domain
{
    class ModelBuilder:AbstractBuilder    {
        public ModelBuilder(CompetenceLevelScale scale) : base(scale)
        {
        }

        public ModelCompetence Build()
        {
            return new ModelCompetence(BuildAssesments(), _scale);
        }
        private AssessmentСompetence[] BuildAssesments()
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
