using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDZ_TPR.Model
{
    class Competence
    {
        public static int maxLevel;
        string name;
        int level;

        public string Name { get => name; set => name = value; }
        public int Level
        {
            get => level; set
            {
                if (value < 0 || value >maxLevel)
                {
                    throw new Exception("Уровень компетенции меньше нуля или больше максимального значения: " + value);
                }
                level = value;
            }
        }
    }
}
