using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.Competences;

namespace Domain
{
    class ModelBuilder
    {
        private List<AssessmentСompetence> _assessments;
        public AssessmentСompetence[] Assessments => _assessments.ToArray();
        public CompetenceLevelScale Scale { get; private set; }
        private bool Validation(AssessmentСompetence assessment)
        {
            if (!ModelCompetence.CompetenceValidtion(assessment, Scale, out Exception exception))
            {
                throw exception; 
            }
            
        }
        private bool Validation(AssessmentСompetence[] assessments)
        {
            foreach (var item in assessments)
            {
                if (!Validation(item))
                {
                    return false;
                }
            }
            return true;
        }
        public void Add(AssessmentСompetence competence)
        {
            if (ModelCompetence.CompetenceValidtion(competence, Scale, out Exception exception))
            {
                throw exception;
            }
            _assessments.Add(competence);
        }
        public void Remove(int index)
        {
            _assessments.Remove(Assessments[index]);
        }
    }
}
