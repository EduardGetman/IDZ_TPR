using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdzTpr.Domain
{
    class Competence
    {
        public Competence(CompetenceLevelScale levelScale, string name)
        {
            Scale = levelScale;
            Name = name;
        }

        public CompetenceLevelScale Scale { get;private set; }
        public string Name { get; set; }

        public AssessmentСompetence AssessmentСompetenceFactory(int level)
        {
            if (!Scale.LevelIncludedInRange(level))
            {
                throw ConstructLevelOutOfRangeExcepsion(Name, level);
            }
            return new AssessmentСompetence(this, level);
        }
        Exception ConstructLevelOutOfRangeExcepsion(string name, int level)
        {
            string message = $"Уровень вышел за диапозон: {this.ToString()}."
                             + $" Уровень компетенции {name} равен {level}";
            return new ArgumentException(message);
        }
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            Competence competence = obj as Competence;
            if (competence is null)
            {
                return false;
            }
            return Scale.Equals(competence) && Name ==competence.Name;
        }
        public override int GetHashCode() => base.GetHashCode();
    }
}
