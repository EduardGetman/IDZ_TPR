using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDZ_TPR.Model
{
    class Position: ModelCompetences
    {
        // Значимость выполняемой функции (w)
        int significance;

        public int Significance
        {
            get => significance; set
            {
                if (value < 0)
                {
                    throw new Exception("Значимость это положительное число");
                }
                significance = value;
            }
        }
    }
}
