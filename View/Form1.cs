using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

            necessarySkillsDGV.Columns.Add("Функция", "Функция");
            for (int i = 0; i < functionCountNUD.Value; ++i)
            {
                necessarySkillsDGV.Columns.Add(i.ToString(), "");
            }

            for (var i = 0; i <= competenceCountNUD.Value; ++i)
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
            for (int i = 1; i < necessarySkillsDGV.Columns.Count; ++i)
            {
                skillNamesList.Add(Convert.ToString(necessarySkillsDGV.Rows[0].Cells[i].Value));
                //skillNamesList.Add(necessarySkillsDGV.Rows[0].Cells[i].Value.ToString());
            }
            string[] skillNames = skillNamesList.ToArray();

            int[][] positionsLevels = new int[necessarySkillsDGV.Rows.Count - 1][];
            for (int i = 0; i < necessarySkillsDGV.Rows.Count - 1; ++i)
            {
                positionsLevels[i] = new int[necessarySkillsDGV.Columns.Count - 1];
            }

            List<List<int>> positionsLevelss = new List<List<int>>();
            for (int i = 1; i <= necessarySkillsDGV.Rows.Count; ++i)
            {
                for (int j = 1; j <= necessarySkillsDGV.Columns.Count - 1; ++j)
                {
                    positionsLevels[i - 1][j - 1] = Convert.ToInt32(necessarySkillsDGV.Rows[i].Cells[j].Value);
                }
            }

            int[] importanceCoefficient = new int[necessarySkillsDGV.Columns.Count - 1];
            for (int i = 1; i < necessarySkillsDGV.Rows.Count; ++i)
            {
                importanceCoefficient[i - 1] = Convert.ToInt32(necessarySkillsDGV.Rows[i].Cells[necessarySkillsDGV.Columns.Count - 1].Value);
            }


            int[][] employsLevels = new int[employeeSkillsDGV.Rows.Count][];
            for (int i = 0; i < employeeSkillsDGV.Rows.Count; ++i)
            {
                employsLevels[i] = new int[employeeSkillsDGV.Columns.Count];
            }

            for (int i = 1; i <= employeeSkillsDGV.Rows.Count; ++i)
            {
                for (int j = 1; j <= employeeSkillsDGV.Columns.Count; ++j)
                {
                    employsLevels[i - 1][j - 1] = Convert.ToInt32(employeeSkillsDGV.Rows[i].Cells[j].Value);

                }
            }

            int scaleMin = Convert.ToInt32(minSkillLevelNUD.Value);
            int scaleMax = Convert.ToInt32(maxSkillLevelNUD.Value);

            Analysis.main(skillNames, positionsLevels, importanceCoefficient, employsLevels, new KeyValuePair<int, int>(scaleMin, scaleMax));
        }

        private void maxSkillLevelNUD_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}