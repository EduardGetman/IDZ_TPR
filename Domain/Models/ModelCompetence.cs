using Domain.Competences;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    class ModelCompetence : IEnumerable<AssessmentСompetence>
    {
        protected AssessmentСompetence[] _assessments;

        public ModelCompetence(AssessmentСompetence[] assessments, CompetenceLevelScale levelScale, string name)
        {
            _assessments = assessments;
            LevelScale = levelScale;
            Name = name;
        }
        public string Name { get; set; }
        public CompetenceLevelScale LevelScale { get; private set; }
        public AssessmentСompetence[] Assessments => _assessments;

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
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Assessments.GetEnumerator();
        }

        public IEnumerator<AssessmentСompetence> GetEnumerator()
        {
            return ((IEnumerable<AssessmentСompetence>)Assessments).GetEnumerator();
        }
        public override string ToString()
        {
            return Name; 
        }
    }
}

