using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Coefficients;

namespace Domain
{
    public class CalculationLog
    {
        private readonly string newLine = Environment.NewLine;
        public string TextLog { get; private set; }

        public CalculationLog(Distribution distribution)
        {
            TextLog = ConvertDistributionToLog(distribution);
        }
        private string ConvertDistributionToLog(Distribution distribution)
        {
            string log = SetEmployeesToLog(distribution.Select(x => x.Employee)) + newLine;
            log += SetPositionToLog(distribution.Select(x => x.Position)) + newLine;
            log += "Расчёт коэфицентов важности требований для каждой функции:" + newLine;
            foreach (Appointment appointment in distribution)
            {
                log += ImportanceRequirementToLog(appointment.CalculateImportanceRequirement(),
                                                  appointment.PositionName) + newLine;
            }
            log += "Расчёт коэфициентов адекватности назначения сотрудника на функцию" + newLine + newLine;
            foreach (Appointment appointment in distribution)
            {
                log += $"Назначение {appointment.EmployeeName} на {appointment.PositionName}: " + newLine;
                log += AdequacyToLog(appointment.CalculateRelativeAdequceArray()) + newLine + newLine;
            }
            log += "Итог распределения:" + newLine;
            log += distribution.ToString();
            return log;

        }
        private string SetEmployeesToLog(IEnumerable<ModelCompetence> employees)
        {
            string employeesLog = "Список сотрудников и их компетенции:" + newLine;
            foreach (ModelCompetence employee in employees)
            {
                employeesLog += $"Сотрудник: {employee.Name}{newLine}Компетенции:";
                string competencesString = string.Empty;
                employee.ToList().ForEach(x => competencesString += $" {x.Name} = {x.Level};");
                employeesLog +=  competencesString + newLine;
            }
            return employeesLog;
        }
        private string SetPositionToLog(IEnumerable<Position> positions)
        {
            string positionsLog = "Список функций и их требования:" + newLine;
            foreach (Position position in positions)
            {
                positionsLog += $"Функция {position.Name}; Нормализованная важность функции = {position.Importance:0.00};" +
               
                    $"{newLine}Требования:";
                string competencesString = string.Empty;
                position.ToList().ForEach(x => competencesString += $" {x.Name} = {x.Level};");
                positionsLog += competencesString + newLine;
            }
            return positionsLog;
        }
        private string ImportanceRequirementToLog(IEnumerable<ImportanceRequirement> importances, string positionName)
        {
            string importancesCalc = $"Функция: {positionName}{newLine}";
            foreach (ImportanceRequirement importance in importances)
            {
                importancesCalc += $"Требование:{importance.Requirement.Name}; Важность: {importance.ImportanceAssessment:0.00}; ";
            }
            return importancesCalc;
        }
        private string AdequacyToLog(IEnumerable<AbsoluteAdequacy> adequacies)
        {
            string log = "Оценки адекватности: " + newLine;
            foreach (AbsoluteAdequacy adequacy in adequacies)
            {
                log += $"Кометенция: {adequacy.CompetenceName}; " +
                       $"Относительная адекватность: {adequacy.CalcRelativeAdequacy():0.00}; " +
                       $"Адекватность: {adequacy.Adequacy:0.00}{newLine}";
            }
            return log;
        }
    }
}
