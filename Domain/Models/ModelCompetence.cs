using System;
using System.Collections.Generic;
using Domain.Competences;

namespace Domain
{
    class ModelCompetence
    {
        private List<AssessmentСompetence> _assessments;
        public CompetenceLevelScale LevelScale { get; private set; }
        public AssessmentСompetence[] Assessments => _assessments.ToArray();
        public AssessmentСompetence this[int index]
        {
            get => Assessments[index];
            set
            {
                if (CompetenceValidtion(value, out Exception exception))
                {
                    throw exception;
                }
                Assessments[index] = value;
            }
        }
        virtual protected ArgumentException ConstructDifferentScaleExcepsion(CompetenceLevelScale AssignedScale)
        {
            return new ArgumentException($"Попытка установить компетенцию с другой шкалой. "
                                                + $"Текущая шкала:{LevelScale}. "
                                                + $"Шкала присваиваеммой компетенции: {AssignedScale}");
        }
        public void Add(AssessmentСompetence competence)
        {
            if (CompetenceValidtion(competence, out Exception exception))
            {
                throw exception;
            }
            _assessments.Add(competence);
        }
        public void Remove(int index)
        {
            _assessments.Remove(Assessments[index]);
        }
        private bool CompetenceValidtion(AssessmentСompetence competence, out Exception exception)
        {
            exception = null;
            if (!competence.Scale.Equals(LevelScale))
            {
                exception = ConstructDifferentScaleExcepsion(competence.Scale);
                return false;
            }
            return true;
        }
        public bool TryGetByAssesmentCompetence(AssessmentСompetence assessment, out AssessmentСompetence outAssessment)
        {
            outAssessment = null;
            foreach (AssessmentСompetence item in Assessments)
            {
                if (item.CompetenciesCoincide(assessment))
                {
                    outAssessment = item;
                    return true;
                }
            }
            return false;
        }
        public bool ModelEquals(ModelCompetence modelCompetence)
        {
            foreach (AssessmentСompetence assessment in modelCompetence.Assessments)
            {
                if (!TryGetByAssesmentCompetence(assessment,out _))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

