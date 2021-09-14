using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Distribution:IEnumerable<Appointment>
    {
        Appointment[] _appointments;
        public double Effectiveness
        {
            get
            {
                double result = 0;
                foreach (var item in _appointments)
                {
                    result += item.Effectiveness;
                }
                return result;
            }
        }
        public Appointment this[int index]
        {
            get => _appointments[index];
        }
        public IEnumerator<Appointment> GetEnumerator()
        {
            return ((IEnumerable<Appointment>)_appointments).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _appointments.GetEnumerator();
        }
    }
}
