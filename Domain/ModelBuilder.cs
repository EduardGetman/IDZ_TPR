using System;
using System.Collections.Generic;
using Domain.Competences;
using Domain.Models;

namespace Domain
{
    class ModelBuilder:AbstractBuilder    {
        protected CompetenceLevelScale _scale;
        protected Dictionary<Competence, int> _assesmentParametrs;
        public ModelBuilder(CompetenceLevelScale scale)
        {
            _scale = scale;
        }
        public CompetenceLevelScale Scale => _scale;
        public int this[string name]
        {
            get => _assesmentParametrs[_scale.CompetenceFactory(name)];
        }
        public void Add(string name, int level)
        {
            if (!Scale.LevelIncludedInRange(level) || string.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }
            Competence competence = Scale.CompetenceFactory(name);
            if (_assesmentParametrs.ContainsKey(competence))
            {
                throw new ArgumentException();
            }
            _assesmentParametrs.Add(competence, level);
        }
        public void Remove(string name) => _assesmentParametrs.Remove(_scale.CompetenceFactory(name));
        public bool Contains(string name) => _assesmentParametrs.ContainsKey(_scale.CompetenceFactory(name));
        virtual public ModelCompetence Build()
        {
            return new ModelCompetence(BuildAssesments(), _scale);
        }
        private AssessmentСompetence[] BuildAssesments()
        {
            List<AssessmentСompetence> assessments = new List<AssessmentСompetence>();
            foreach (var item in _assesmentParametrs)
            {
                assessments.Add(new AssessmentСompetence(item.Key, item.Value));
            }
            return assessments.ToArray();
        }
    }
}
