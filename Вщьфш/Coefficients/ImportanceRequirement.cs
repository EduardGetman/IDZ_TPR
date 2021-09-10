using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdzTpr.Domain
{
    class ImportanceRequirement
    {
        public Requirement Requirement { get;private set; }
        public Position Postion { get;private set; }
        public double ImportanceAssessment { get; private set; }

        public ImportanceRequirement(Requirement requirement, Position postion)
        {
            Requirement = requirement;
            Postion = postion;
            EvaluateImportance();
        }

        public void EvaluateImportance()
        {
            int levelSumm = 0;
            foreach (Requirement requirement in Postion)
            {
                levelSumm += requirement.Level;
            }            
            ImportanceAssessment = Requirement.Level / (double)levelSumm;
        }
    }
}
