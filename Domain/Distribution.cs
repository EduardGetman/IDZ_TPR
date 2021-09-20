using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Distribution : IEnumerable<Appointment>
    {
        Appointment[] _appointments;

        public Distribution(Appointment[] appointment)
        {
            _appointments = appointment;
        }

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
        public int Length => _appointments.Length;
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
        public override string ToString()
        {
            string result = string.Empty;
            foreach (Appointment appointment in  _appointments)
            {
                result += $"Производственная функция: {appointment.PositionName} - Сотрудник:{appointment.EmployeeName}, Эффективность назначения = {appointment.Effectiveness}";
                result += Environment.NewLine;
            }
            result += $"Общая эффективность назначения ={Effectiveness}";
            return result;
        }
    }
}
