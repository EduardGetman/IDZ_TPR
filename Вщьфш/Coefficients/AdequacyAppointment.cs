using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdzTpr.Domain
{
    class AdequacyAppointment
    {
        Requirement _requirement;
        AssessmentСompetence _qualification;

        public AdequacyAppointment(Requirement requirement, AssessmentСompetence qualification)
        {
            Validation(requirement, qualification);
            _requirement = requirement;
            _qualification = qualification;
            CalculationAdequacy();
        }

        public string CompetenceName => _requirement.Name;
        public CompetenceLevelScale CompetenceLevelScale => _requirement.Scale;
        public int RequirementLevel => _requirement.Level;
        public int QualificationLevel => _qualification.Level;
        public double Adequacy { get; private set; }
        private void Validation(Requirement requirement, AssessmentСompetence qualification)
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
            Adequacy = Math.Min(QualificationLevel, RequirementLevel) / (double)RequirementLevel;
        }

    }
}
