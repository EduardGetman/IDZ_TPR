using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Competences;
using Domain.Models.Builders;
using Domain;

namespace View
{
    struct ModelParametrs
    {
        public CompetenceLevelScale Scale;
        public string Name;
        public double Importance;
        public AssesmentParametrs[] Assesments;
        public ModelParametrs(CompetenceLevelScale scale, string name, double importance, AssesmentParametrs[] assesments)
        {
            Scale = scale;
            Name = name;
            Importance = importance;
            Assesments = assesments;
        }
    }

    struct AssesmentParametrs
    {
        public string Name;
        public int Level;

        public AssesmentParametrs(string name, int level)
        {
            Name = name;
            Level = level;
        }
    }
}
