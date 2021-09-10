using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdzTpr.Domain
{
    class ImportanceRequirement
    {
        public Requirement Requirement { get; set; }
        public double ImportanceAssessment { get; private set; }

        public ImportanceRequirement(Requirement requirement)
        {
            Requirement = requirement;
        }

        public void EvaluateImportance(Position position)
        {
            int levelSumm = 0;
            foreach (Requirement requirement in position)
            {
                levelSumm += requirement.Level;
            }            
            ImportanceAssessment = Requirement.Level / (double)levelSumm;
        }
    }
}
