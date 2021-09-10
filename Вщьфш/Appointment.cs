﻿using System;
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
        private double _adequacy;

        public Appointment(ModelCompetence employee, Position position)
        {
            Validation(employee, position);
            Employee = employee;
            Position = position;
            DetermineAdequacyAppointment();
        }

        public double Adequacy
        {
            get => _adequacy; 
            private set
            {
                if (value <= 0 || value > 1)
                {
                    throw new ArgumentException();
                }
                _adequacy = value;
            }
        }
        public ModelCompetence Employee { get => _employee; set => _employee = value; }
        public Position Position { get => _position; set => _position = value; }
        public double Effectiveness => Adequacy * Position.Importance;
        private void Validation(ModelCompetence employee, Position position)
        {
            if (position.ModelEquals(employee))
            {
                throw new ArgumentException();
            }
        }
        public ImportanceRequirement[] CalculateImportanceRequirement()
        {
            List<ImportanceRequirement> importances = new List<ImportanceRequirement>();
            foreach (var item in Position)
            {
                importances.Add(new ImportanceRequirement(item, Position));
            }
            return importances.ToArray();
        }
        public RelativeAdequacy[] CalculateRelativeAdequceArray()
        {
            ImportanceRequirement[] importances = CalculateImportanceRequirement();
            List<RelativeAdequacy> adequacies = new List<RelativeAdequacy>();
            foreach (var item in importances)
            {
                AssessmentСompetence skill;
                if (_employee.TryGetByAssesmentCompetence(item.Requirement, out skill))
                {
                    throw new InvalidOperationException();
                }
                adequacies.Add(new RelativeAdequacy(item, skill));
            }
            return adequacies.ToArray();
        }
        public void DetermineAdequacyAppointment()
        {
            double adequacy = 0;
            RelativeAdequacy[] adequacies = CalculateRelativeAdequceArray();
            foreach (var item in adequacies)
            {
                adequacy += item.Adequacy;
            }
            Adequacy = adequacy;
        }

    }
}
