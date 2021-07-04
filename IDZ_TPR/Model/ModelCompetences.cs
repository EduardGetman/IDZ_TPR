using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDZ_TPR.Model
{
    class ModelCompetences
    {
        string name;
        private List<Competence> competences;

        public string Name { get => name; set => name = value; }
        internal List<Competence> Competences { get => competences; set => competences = value; }
    }
}
