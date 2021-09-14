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
                // При расчёте адекватности назначения если требование равно нулю расчёт сведётся к 0/0.
                // С точки зрения бизнес-логики если требование равно 0, то адекватность назначения в любом случае равна 1
                // Спорный момент, но если принять 0/0 = 1, то я нагородил лишнюю иерархию.
                //if (value == 0)
                //{
                //    throw ConstructRequirementLevelZeroException();
                //}
                base.Level = value;
            }
        }
        private ArgumentException ConstructRequirementLevelZeroException()
        {
            return new ArgumentException("Уровень требования не может быть равен 0");
        }
    }
}
