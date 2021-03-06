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
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button3.Visible = true;
            button2.Visible = true;

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            employeeCountNUD.Visible = false;
            employeeCompetenceNUD.Visible = false;
            functionCountNUD.Visible = false;
            competenceCountNUD.Visible = false;
            applyForEmployeeBTN.Visible = false;
            applySkillsNUD.Visible = false;

            openFileDialog1.Filter = "Text files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog1.Filter = "Text files (*.json)|*.json|All files (*.*)|*.*";
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
            for (int i = 0; i < competenceCountNUD.Value; ++i)
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
            Distribution appointments;
            try
            {
                appointments = Analysis.main(
                    skillNames,
                    positionsLevels,
                    normalizeImportance(importanceCoefficient.ToList()).ToArray(),
                    employsLevels,
                    new KeyValuePair<int, int>(scaleMin, scaleMax),
                    employeeNames.ToArray(),
                    positionNames.ToArray(),
                    requiredCompetenceName.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при вычислениях!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            Form form = new Form2(appointments);
            form.Show();

            resultRTP.Text = appointments.ToString();
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
                new string[] { "Сотрудник1", "3", "4","4"},
                new string[] { "Сотрудник2", "4","4","3"},
                new string[] { "Сотрудник3", "3", "4","4"},
                new string[] { "Сотрудник4", "4","4","4" }
            };

            string[][] two = new string[][]
            {
                new string[] { "", "c1", "c2","c3", ""},
                new string[] { "Функция1", "2", "3","2", "1"},
                new string[] { "Функция2", "3", "3","2", "1"},
                new string[] { "Функция3", "2", "3","3", "1"},
                new string[] { "Функция4", "3", "3","3", "1"}
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog1.FileName;

            String[][] matrixOne = new String[employeeSkillsDGV.Rows.Count][];

            for (int i = 0; i < employeeSkillsDGV.Rows.Count; ++i)
            {
                String[] matrRow = new String[employeeSkillsDGV.ColumnCount];
                for (int j = 0; j < employeeSkillsDGV.Rows[i].Cells.Count; ++j)
                {
                    matrRow[j] = Convert.ToString(employeeSkillsDGV.Rows[i].Cells[j].Value);
                }
                matrixOne[i] = matrRow;
            }

            String[][] matrixTwo = new String[necessarySkillsDGV.Rows.Count][];

            for (int i = 0; i < necessarySkillsDGV.Rows.Count; ++i)
            {
                String[] matrRow = new String[necessarySkillsDGV.ColumnCount];
                for (int j = 0; j < necessarySkillsDGV.ColumnCount; ++j)
                {
                    matrRow[j] = Convert.ToString(necessarySkillsDGV.Rows[i].Cells[j].Value);
                }
                matrixTwo[i] = matrRow;
            }

            ViewData viewData = new ViewData(matrixOne, matrixTwo,
                Convert.ToInt32(minSkillLevelNUD.Value), Convert.ToInt32(maxSkillLevelNUD.Value),
                Convert.ToInt32(employeeCountNUD.Value), Convert.ToInt32(employeeCompetenceNUD.Value),
             Convert.ToInt32(functionCountNUD.Value), Convert.ToInt32(competenceCountNUD.Value));


            File.WriteAllText(filename, JsonSerializer.Serialize(viewData));

            //BinaryFormatter formatter = new BinaryFormatter();

            //using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            //{
            //	formatter.Serialize(fs, viewData);
            //}
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            String jsonString = File.ReadAllText(openFileDialog1.FileName);
            ViewData deserilize = JsonSerializer.Deserialize<ViewData>(jsonString);


            //using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate))
            //{
            //    deserilize = (ViewData)formatter.Deserialize(fs);
            //}

            minSkillLevelNUD.Value = deserilize.minSkillLevel;
            maxSkillLevelNUD.Value = deserilize.maxSkillLevel;

            employeeCountNUD.Value = deserilize.employeeCount;
            employeeCompetenceNUD.Value = deserilize.employeeCompetenceCount;

            functionCountNUD.Value = deserilize.functionCount;
            competenceCountNUD.Value = deserilize.competenceCount;

            employeeSkillsDGV.Rows.Clear();
            employeeSkillsDGV.Columns.Clear();

            employeeSkillsDGV.Columns.Add("ФИО сотрудников", "ФИО сотрудников");
            for (int i = 0; i < employeeCompetenceNUD.Value; ++i)
            {
                employeeSkillsDGV.Columns.Add(i.ToString(), "");
            }

            foreach (var row in deserilize.matrixOne)
            {
                employeeSkillsDGV.Rows.Add(row);
            }

            necessarySkillsDGV.Rows.Clear();
            necessarySkillsDGV.Columns.Clear();

            necessarySkillsDGV.Columns.Add("Должность", "Должность");
            for (int i = 0; i < competenceCountNUD.Value; ++i)
            {
                necessarySkillsDGV.Columns.Add(i.ToString(), "");
            }
            necessarySkillsDGV.Columns.Add("Коэффициент важности производственной функции", "Коэффициент важности производственной функции");

            foreach (var row in deserilize.matrixTwo)
            {
                necessarySkillsDGV.Rows.Add(row);
            }

            necessarySkillsDGV.Rows[0].HeaderCell.Value = "Названия компетенций";
            employeeSkillsDGV.Rows[0].HeaderCell.Value = "Названия компетенций";

        }

        private void InpuNamesButton_Click(object sender, EventArgs e)
        {
            InputNames names;
            FormInputNames formInputNames;
            if (TryGetNames(out names))
            {
                formInputNames = new FormInputNames(names);
            }
            else
            {
                formInputNames = new FormInputNames();
            }
            formInputNames.ShowDialog();
            names = formInputNames.Names;
            if (names is null)
            {
                return;
            }
            SetNames(names);
        }

        // Если на форме уже есть имена компетенций, сотрудников и должностей,
        // то помещаешь их в names и возвращаешь true иначе names = null, return false
        private bool TryGetNames(out InputNames names)
        {
            names = new InputNames(new List<string>(), new List<string>(), new List<string>());
            if (employeeSkillsDGV.Rows.Count == 0)
            {
                names = null;
                return false;
            }

            if (necessarySkillsDGV.Rows.Count == 0)
            {
                names = null;
                return false;
            }

            for (int i = 1; i < employeeSkillsDGV.Rows.Count; ++i)
                names.EmployeeNames.Add(Convert.ToString(employeeSkillsDGV.Rows[i].Cells[0].Value));

            for (int i = 1; i < employeeSkillsDGV.Columns.Count; ++i)
                names.CompetenceNames.Add(Convert.ToString(employeeSkillsDGV.Rows[0].Cells[i].Value));

            for (int i = 1; i < necessarySkillsDGV.Rows.Count; ++i)
                names.PositionNames.Add(Convert.ToString(necessarySkillsDGV.Rows[i].Cells[0].Value));

            return true;
        }
        // Заполняешь имена столбцов и колонок из names
        private void SetNames(InputNames names)
        {
            employeeCountNUD.Value = names.EmployeeNames.Count;
            employeeCompetenceNUD.Value = names.CompetenceNames.Count;
            competenceCountNUD.Value = names.CompetenceNames.Count;
            functionCountNUD.Value = names.PositionNames.Count;


            employeeSkillsDGV.Rows.Clear();
            employeeSkillsDGV.Columns.Clear();

            employeeSkillsDGV.Columns.Add("ФИО сотрудников", "ФИО сотрудников");
            for (int i = 0; i < employeeCompetenceNUD.Value; ++i)
            {
                employeeSkillsDGV.Columns.Add(i.ToString(), "");
            }

            employeeSkillsDGV.Rows.Add();
            foreach (var row in names.EmployeeNames)
            {
                employeeSkillsDGV.Rows.Add(row);
            }

            necessarySkillsDGV.Rows.Clear();
            necessarySkillsDGV.Columns.Clear();

            necessarySkillsDGV.Columns.Add("Должность", "Должность");
            for (int i = 0; i < competenceCountNUD.Value; ++i)
            {
                necessarySkillsDGV.Columns.Add(i.ToString(), "");
            }
            necessarySkillsDGV.Columns.Add("Коэффициент важности производственной функции", "Коэффициент важности производственной функции");

            necessarySkillsDGV.Rows.Add();
            foreach (var row in names.PositionNames)
            {
                necessarySkillsDGV.Rows.Add(row);
            }

            necessarySkillsDGV.Rows[0].HeaderCell.Value = "Названия компетенций";
            employeeSkillsDGV.Rows[0].HeaderCell.Value = "Названия компетенций";


            //for (int i = 1; i < employeeSkillsDGV.Rows.Count; ++i)
            //    employeeSkillsDGV.Rows[i].Cells[0].Value = names.EmployeeNames.ElementAt(i - 1);

            for (int i = 1; i < employeeSkillsDGV.Columns.Count; ++i)
                employeeSkillsDGV.Rows[0].Cells[i].Value = names.CompetenceNames.ElementAt(i - 1);

            for (int i = 1; i < names.PositionNames.Count + 1; ++i)
                necessarySkillsDGV.Rows[0].Cells[i].Value = names.PositionNames.ElementAt(i - 1);

            //for (int i = 0; i < necessarySkillsDGV.Rows.Count; ++i)
            //    necessarySkillsDGV.Rows[i].Cells[0].Value = names.PositionNames.ElementAt(i - 1);
        }
    }
}