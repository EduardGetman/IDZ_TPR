using System;
using Domain.Competences;

namespace Domain.Coefficients
{
    class RelativeAdequacy
    {
        private AssessmentСompetence _requirement;
        private AssessmentСompetence _qualification;
        private double _importance;

        public double Adequacy { get; private set; }
        public string CompetenceName => _requirement.Name;
        public CompetenceLevelScale CompetenceLevelScale => _requirement.Scale;
        public int RequirementLevel => _requirement.Level;
        public int QualificationLevel => _qualification.Level;

        public RelativeAdequacy(ImportanceRequirement importance, AssessmentСompetence qualification)
        {
            Validation(importance.Requirement, qualification);
            _requirement = importance.Requirement;
            _qualification = qualification;
            _importance = importance.ImportanceAssessment;
            CalculationAdequacy();
        }
        public RelativeAdequacy(AssessmentСompetence requirement, AssessmentСompetence qualification)
        {
            Validation(requirement, qualification);
            _requirement = requirement;
            _qualification = qualification;
            _importance = 1;
            CalculationAdequacy();
        }
        private void Validation(AssessmentСompetence requirement, AssessmentСompetence qualification)
        {
            if (requirement.CompetenciesCoincide(qualification))
            {
                throw ConstructMismatchCompetenciesException(requirement, qualification);
            }
        }
        private ArgumentException ConstructMismatchCompetenciesException(
            AssessmentСompetence requirement,
            AssessmentСompetence qualification)
        {
            return new ArgumentException($"Невозможно сравнить оценки разных компетенций." +
                $"{Environment.NewLine} Требование:" +
                $"{Environment.NewLine} Наименование: {requirement.Name}" +
                $"{Environment.NewLine} Шкала: {requirement.Scale}" +
                $"{Environment.NewLine} Квалификация:" +
                $"{Environment.NewLine} Наименование: {qualification.Name}" +
                $"{Environment.NewLine} Шкала: {qualification.Scale}");
        }
        private void CalculationAdequacy()
        {
            if (RequirementLevel == 0)
            {
                Adequacy = 1;
            }
            Adequacy = (Math.Min(QualificationLevel, RequirementLevel) / (double)RequirementLevel) * _importance;
        }

    }
}
