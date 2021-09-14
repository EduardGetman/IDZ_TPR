using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Competences;

namespace Domain.Models
{
    class Position : ModelCompetence
    {
        private double _importance;

        public Position(AssessmentСompetence[] assessments, CompetenceLevelScale levelScale, string name) : base(assessments, levelScale, name)
        {
        }

        public Position(AssessmentСompetence[] assessments, CompetenceLevelScale levelScale, string name, double importance) : base(assessments, levelScale, name)
        {
            Importance = importance;
        }

        public double Importance
        {
            get => _importance; set
            {
                if (value <= 0 || value > 1)
                {
                    throw new ArgumentException();
                }
                _importance = value;
            }
        }
    }
}
