using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class DistributionBuilder
    {
        Position[] _positions;
        ModelCompetence[] _employees;

        public DistributionBuilder(Position[] positions, ModelCompetence[] employees)
        {
            _positions = positions;
            _employees = employees;
        }

        public Position[] Positions => _positions;
        public ModelCompetence[] Employees => _employees;
        public Distribution BuildOptimalDistribution()
        {
            throw new NotImplementedException();
        }
    }
}
