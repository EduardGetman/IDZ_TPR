using System;
using System.Collections.Generic;
using Domain.Competences;

namespace Domain.Models.Builders
{
    public class ModelBuilder
    {
        protected CompetenceLevelScale _scale;
        protected Dictionary<Competence, int> _assesmentParametrs;
        public ModelBuilder(CompetenceLevelScale scale, string name)
        {
            _scale = scale;
            Name = name;
            _assesmentParametrs = new Dictionary<Competence, int>();
        }
        public CompetenceLevelScale Scale => _scale;

        public string Name { get; set; }

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
            return new ModelCompetence(BuildAssesments(), _scale, Name);
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