using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDZ_TPR.Model
{
    class Employee: ModelCompetences
    {
        double psichophysicalState;

        public double PichophysicalState1
        {
            get => psichophysicalState;
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new Exception("Псхофизическое состояние работника определяется числом от 0 до 1");
                }
                psichophysicalState = value;
            }
        }
    }
}
