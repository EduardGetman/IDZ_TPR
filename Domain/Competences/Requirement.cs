using System;

namespace Domain.Competences
{
    class Requirement : AssessmentСompetence
    {
        public Requirement(Competence competence, int level) : base(competence, level)
        {
            Level = level;
        }

        public override int Level
        {
            get => base.Level;
            protected set
            {
                if (value == 0)
                {
                    throw ConstructRequirementLevelZeroException();
                }
                base.Level = value;
            }
        }
        private ArgumentException ConstructRequirementLevelZeroException()
        {
            return new ArgumentException("Уровень требования не может быть равен 0");
        }
    }
}
