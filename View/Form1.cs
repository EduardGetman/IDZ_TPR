using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Models;
using Domain.Competences;
using Domain.Models.Builders;
using Domain;

namespace View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button3.Visible = true;
            button2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void applyForEmployeeBTN_Click(object sender, EventArgs e)
        {
            employeeSkillsDGV.Rows.Clear();
            employeeSkillsDGV.Columns.Clear();

            employeeSkillsDGV.Columns.Add("ФИО сотрудников", "ФИО сотрудников");
            for (int i = 0; i < employeeCompetenceNUD.Value; ++i)
            {
                employeeSkillsDGV.Columns.Add(i.ToString(), "");
            }

            for (var i = 0; i <= employeeCountNUD.Value; ++i)
            {
                employeeSkillsDGV.Rows.Add();
            }

            employeeSkillsDGV.Rows[0].HeaderCell.Value = "Названия компетенций";
        }

        private void applySkillsNUD_Click(object sender, EventArgs e)
        {
            necessarySkillsDGV.Rows.Clear();
            necessarySkillsDGV.Columns.Clear();

            necessarySkillsDGV.Columns.Add("Должность", "Должность");
            for (int i = 0; i < competenceCountNUD.Value; ++i)//TODO баги отображения
            {
                necessarySkillsDGV.Columns.Add(i.ToString(), "");
            }

            necessarySkillsDGV.Rows.Add();
            for (var i = 0; i < functionCountNUD.Value; ++i)
            {
                necessarySkillsDGV.Rows.Add();
            }

            necessarySkillsDGV.Rows[0].HeaderCell.Value = "Названия компетенций";

            necessarySkillsDGV.Columns.Add("Коэффициент важности производственной функции", "Коэффициент важности производственной функции");

            //employeeSkillsDGV.Rows.Add();
            //employeeSkillsDGV.Rows.Add();

            //employeeSkillsDGV.Rows[Convert.ToInt32(competenceCountNUD.Value) + 1].HeaderCell.Value = "Минимальный навык";
            //employeeSkillsDGV.Rows[Convert.ToInt32(competenceCountNUD.Value) + 2].HeaderCell.Value = "Максимальный навык";
        }

        private void calculateEmployeeAssignmentButton_Click(object sender, EventArgs e)
        {
            List<String> skillNamesList = new List<string>();
            for (int i = 1; i < necessarySkillsDGV.Columns.Count - 1; ++i)
            {
                skillNamesList.Add(Convert.ToString(necessarySkillsDGV.Rows[0].Cells[i].Value));
                //skillNamesList.Add(necessarySkillsDGV.Rows[0].Cells[i].Value.ToString());
            }
            string[] skillNames = skillNamesList.ToArray();

            int[][] positionsLevels = new int[necessarySkillsDGV.Rows.Count - 1][];
            for (int i = 0; i < necessarySkillsDGV.Rows.Count - 1; ++i)
            {
                positionsLevels[i] = new int[necessarySkillsDGV.Columns.Count - 2];
            }

            List<List<int>> positionsLevelss = new List<List<int>>();
            for (int i = 1; i < necessarySkillsDGV.Rows.Count; ++i)
            {
                for (int j = 1; j < necessarySkillsDGV.Columns.Count - 1; ++j)
                {
                    positionsLevels[i - 1][j - 1] = Convert.ToInt32(necessarySkillsDGV.Rows[i].Cells[j].Value);
                }
            }

            int[] importanceCoefficient = new int[Convert.ToInt32(functionCountNUD.Value)];
            for (int i = 1; i < necessarySkillsDGV.Rows.Count; ++i)
            {
                importanceCoefficient[i - 1] = Convert.ToInt32(necessarySkillsDGV.Rows[i].Cells[necessarySkillsDGV.Columns.Count - 1].Value);
            }


            int[][] employsLevels = new int[employeeSkillsDGV.Rows.Count - 1][];
            for (int i = 0; i < employeeSkillsDGV.Rows.Count - 1; ++i)
            {
                employsLevels[i] = new int[employeeSkillsDGV.Columns.Count - 1];
            }

            for (int i = 1; i < employeeSkillsDGV.Rows.Count; ++i)
            {
                for (int j = 1; j < employeeSkillsDGV.Columns.Count; ++j)
                {
                    employsLevels[i - 1][j - 1] = Convert.ToInt32(employeeSkillsDGV.Rows[i].Cells[j].Value);

                }
            }

            int scaleMin = Convert.ToInt32(minSkillLevelNUD.Value);
            int scaleMax = Convert.ToInt32(maxSkillLevelNUD.Value);

            List<String> employeeNames = new List<string>();
            for (int i = 1; i < employeeSkillsDGV.Rows.Count; ++i)
            {
                employeeNames.Add(Convert.ToString(employeeSkillsDGV.Rows[i].Cells[0].Value));
            }

            List<String> positionNames = new List<String>();
            for (int i = 1; i < necessarySkillsDGV.Rows.Count; ++i)
            {
                positionNames.Add(Convert.ToString(necessarySkillsDGV.Rows[i].Cells[0].Value));
            }

            List<String> requiredCompetenceName = new List<string>();

            for (int i = 1; i < necessarySkillsDGV.Columns.Count - 1; ++i)
            {
                requiredCompetenceName.Add(Convert.ToString(necessarySkillsDGV.Rows[0].Cells[i].Value));
            }

            Distribution appointments = Analysis.main(skillNames, positionsLevels, normalizeImportance(importanceCoefficient.ToList()).ToArray(), employsLevels,
                new KeyValuePair<int, int>(scaleMin, scaleMax), employeeNames.ToArray(), positionNames.ToArray(), requiredCompetenceName.ToArray());

            resultRTP.Text = appointments.ToString();
        }

        static string DistributionToString(Distribution distribution)
        {
            string result = string.Empty;
            foreach (Appointment appointment in distribution)
            {
                result += $"Position: {appointment.PositionName} - Employee:{appointment.EmployeeName}, Effectiveness = {appointment.Effectiveness}";
                result += Environment.NewLine;
            }
            result += $"Total effectiveness ={distribution.Effectiveness}";
            return result;
        }

        public List<Double> normalizeImportance(List<int> source)
        {
            List<Double> result = new List<Double>();

            int summ = source.Sum();

            foreach (int elem in source)
            {
                result.Add(Convert.ToDouble(elem) / Convert.ToDouble(summ));
            }

            return result;
        }

        private void maxSkillLevelNUD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            minSkillLevelNUD.Value = 0;
            maxSkillLevelNUD.Value = 5;
            employeeCountNUD.Value = 2;
            employeeCompetenceNUD.Value = 2;
            functionCountNUD.Value = 2;
            competenceCountNUD.Value = 2;
            applyForEmployeeBTN_Click(this, new EventArgs());
            applySkillsNUD_Click(this, new EventArgs());

            //employeeSkillsDGV
            //necessarySkillsDGV
            string[][] one = new string[][]
            {
                new string[] { "", "Комп1", "Комп2"},
                new string[] {"Сот1", "1", "2"},
                new string[] { "Сот2", "3", "4"},
            };

            string[][] two = new string[][]
            {
                new string[] { "", "Комп1", "Комп2",""},
                new string[] {"Дол1", "1", "2","4"},
                new string[] { "Дол2", "3", "4", "6"},
            };

            employeeSkillsDGV.RowCount = one.Length;

            for (int i = 0; i < one.Length; ++i)
            {
                for (int j = 0; j < one[i].Length; ++j)
                {
                    employeeSkillsDGV.Rows[i].Cells[j].Value = one[i][j];
                }
            }

            necessarySkillsDGV.RowCount = two.Length;

            for (int i = 0; i < two.Length; ++i)
            {
                for (int j = 0; j < two[i].Length; ++j)
                {
                    necessarySkillsDGV.Rows[i].Cells[j].Value = two[i][j];
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            minSkillLevelNUD.Value = 0;
            maxSkillLevelNUD.Value = 4;
            employeeCountNUD.Value = 4;
            employeeCompetenceNUD.Value = 3;
            functionCountNUD.Value = 4;
            competenceCountNUD.Value = 3;
            applyForEmployeeBTN_Click(this, new EventArgs());
            applySkillsNUD_Click(this, new EventArgs());

            //employeeSkillsDGV
            //necessarySkillsDGV
            string[][] one = new string[][]
            {
                new string[] { "", "c1", "c2","c3"},
                new string[] { "Model1", "3", "4","4"},
                new string[] { "Model2", "4","4","3"},
                new string[] { "Model3", "3", "4","4"},
                new string[] { "Model4", "4","4","4" }
            };

            string[][] two = new string[][]
            {
                new string[] { "", "c1", "c2","c3", ""},
                new string[] { "Position1", "2", "3","2", "1"},
                new string[] { "Position2", "3", "3","2", "1"},
                new string[] { "Position3", "2", "3","3", "1"},
                new string[] { "Position4", "3", "3","3", "1"}
            };

            employeeSkillsDGV.RowCount = one.Length;

            for (int i = 0; i < one.Length; ++i)
            {
                for (int j = 0; j < one[i].Length; ++j)
                {
                    employeeSkillsDGV.Rows[i].Cells[j].Value = one[i][j];
                }
            }

            necessarySkillsDGV.RowCount = two.Length;

            for (int i = 0; i < two.Length; ++i)
            {
                for (int j = 0; j < two[i].Length; ++j)
                {
                    necessarySkillsDGV.Rows[i].Cells[j].Value = two[i][j];
                }
            }
        }
    }
}