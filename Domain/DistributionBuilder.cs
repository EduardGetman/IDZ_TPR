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
            if (positions.Length < employees.Length)
            {
                throw new ArgumentException();
            }
            _positions = positions;
            _employees = employees;
        }

        public Position[] Positions => _positions;
        public ModelCompetence[] Employees => _employees;
        public Distribution BuildOptimalDistribution()
        {
            int[] numbers = GenerateNumbers();
            Distribution bestDistribution = BuildDistribution(numbers);
            while (NextSet(numbers))
            {
                Distribution nextDistribution = BuildDistribution(numbers);
                if (bestDistribution.Effectiveness < nextDistribution.Effectiveness)
                {
                    bestDistribution = nextDistribution;
                }
            }
            return bestDistribution;
        }

        private Distribution BuildDistribution(int[] numbers)
        {
            List<Appointment> appointments = new List<Appointment>();
            for (int i = 0; i < _positions.Length; i++)
            {
                appointments.Add(new Appointment(_employees[numbers[i]], _positions[i]));
            }
            return new Distribution(appointments.ToArray());
        }

        private int[] GenerateNumbers()
        {
            int[] result = new int[_employees.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = i;
            }
            return result;
        }
        #region Код с форума. Необходим для поиска всех возможных вариантов назначения
        // НЕТРОГАТЬ БЛЯ!
        // ОНО РАБОТАЕТ!
        // А КАК, НЕ ЗНАЮ(
        // НО И ХУЙ С НИМ!
        // ИСТОЧНИК: https://prog-cpp.ru/permutation/ - СПАСИБО ИМ!
        private static bool NextSet(int[] arrayNumbers)
        {
            int j = arrayNumbers.Length - 2;
            while (j != -1 && arrayNumbers[j] >= arrayNumbers[j + 1]) j--;
            if (j == -1)
                return false; // больше перестановок нет
            int k = arrayNumbers.Length - 1;
            while (arrayNumbers[j] >= arrayNumbers[k]) k--;
            swap(arrayNumbers, j, k);
            int l = j + 1, r = arrayNumbers.Length - 1; // сортируем оставшуюся часть последовательности
            while (l < r)
                swap(arrayNumbers, l++, r--);
            return true;

        }
        private static void swap(int[] array, int i, int j)
        {
            int s = array[i];
            array[i] = array[j];
            array[j] = s;
        }
        #endregion
    }
}
