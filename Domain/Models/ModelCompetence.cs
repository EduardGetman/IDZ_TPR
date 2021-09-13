using System;
using System.Collections.Generic;
using Domain.Competences;

namespace Domain.Models
{
    class ModelCompetence
    {
        private AssessmentСompetence[] _assessments;

        public ModelCompetence(AssessmentСompetence[] assessments, CompetenceLevelScale levelScale)
        {
            _assessments = assessments;
            LevelScale = levelScale;
        }

        public CompetenceLevelScale LevelScale { get; private set; }
        internal AssessmentСompetence[] Assessments => _assessments;

        public AssessmentСompetence this[int index]
        {
            get => _assessments[index];
            set
            {
                if (CompetenceValidtion(value, out Exception exception))
                {
                    throw exception;
                }
                _assessments[index] = value;
            }
        }
        virtual protected ArgumentException ConstructDifferentScaleExcepsion(CompetenceLevelScale AssignedScale)
        {
            return new ArgumentException($"Попытка установить компетенцию с другой шкалой. "
                                                + $"Текущая шкала:{LevelScale}. "
                                                + $"Шкала присваиваеммой компетенции: {AssignedScale}");
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

