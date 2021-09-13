using Domain.Competences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    abstract class AbstractBuilder
    {
        protected CompetenceLevelScale _scale;
        protected Dictionary<Competence, int> _assesmentParametrs;
        public AbstractBuilder(CompetenceLevelScale scale)
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
    }
}
