using System;

namespace Domain.Competences
{
    public class CompetenceLevelScale
    {        
        Exception ConstructNameIsEmptyExcepsion()
        {
            string message = $"Название компетенции не может быть пустым";
            return new ArgumentException(message);
        }

        public CompetenceLevelScale(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public bool LevelIncludedInRange(AssessmentСompetence competence) => LevelIncludedInRange(competence.Level);
        public bool LevelIncludedInRange(int level) => level >= MinValue && level <= MaxValue;
        public Competence CompetenceFactory(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw ConstructNameIsEmptyExcepsion();
            }
            return new Competence(this, name);
        }
        public override string ToString()
        {
            return $"({MinValue} ;{MaxValue})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            CompetenceLevelScale scale = obj as CompetenceLevelScale;
            if (scale is null)
            {
                return false;
            }
            return scale.MinValue == MinValue && scale.MaxValue == MaxValue;    
        }
        public override int GetHashCode() => base.GetHashCode();
    }
}
