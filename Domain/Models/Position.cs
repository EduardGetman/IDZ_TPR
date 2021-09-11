using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdzTpr.Domain
{
    class Position : IEnumerable
    {
        ModelCompetence _modelCompetence;
        private double _importance;

        public Requirement this[int index]
        {
            get
            {
                Requirement requirement = _modelCompetence[index] as Requirement;
                if (requirement is null)
                {
                    throw new ArgumentException();
                }
                return requirement;
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentException();
                }
                _modelCompetence[index] = value;
            }
        }
        public double Importance
        {
            get => _importance; set
            {
                if (value <= 0 || value > 1)
                {
                    throw new ArgumentException();
                }
                _importance = value;
            }
        }
        public void Add(Requirement requirement) => _modelCompetence.Add(requirement);
        public void Remove(int index) => _modelCompetence.Remove(index);

        public IEnumerator GetEnumerator()
        {
            List<Requirement> requirements = new List<Requirement>(_modelCompetence.Assessments.Length);
            foreach (AssessmentСompetence assessment in _modelCompetence.Assessments)
            {
                requirements.Add(assessment as Requirement);

            }
            return requirements.GetEnumerator();
        }
        public bool ModelEquals(ModelCompetence modelCompetence) => _modelCompetence.ModelEquals(modelCompetence);
    }
}
