using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdzTpr.Domain
{
    class Appointment
    {
        ModelCompetence _employee;
        Position _position;

        public Appointment(ModelCompetence employee, Position position)
        {
            Validation(employee, position);
            Employee = employee;
            Position = position;
        }
        
        public ModelCompetence Employee { get => _employee; set => _employee = value; }
        public Position Position { get => _position; set => _position = value; }
        private void Validation(ModelCompetence employee, Position position)
        {
            if (position.ModelEquals(employee))
            {
                throw new ArgumentException();
            }
        }

    }
}
