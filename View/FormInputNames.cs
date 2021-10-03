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
    public partial class FormInputNames : Form
    {
        private const int _competenceColumn = 0;
        private const int _employeeColumn = 1;
        private const int _positionColumn = 2;
        private const int _columnCount = 3;

        public InputNames Names { get; private set; }
        public FormInputNames()
        {
            InitializeComponent();
        }

        public FormInputNames(InputNames names)
        {
            InitializeComponent();
            SetInputNameToDGV(names);
            //SetCompetencesName(names.CompetenceNames.ToArray());
            //SetEmployeesName(names.EmployeeNames.ToArray());
            //SetPositionsName(names.PositionNames.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Names = new InputNames(GetCompetencesName(), GetEmployeesName(), GetPositionsName());
            Close();
        }

        private List<string> GetCompetencesName() => GetColumnValue(_competenceColumn);
        private List<string> GetEmployeesName() => GetColumnValue(_employeeColumn);
        private List<string> GetPositionsName() => GetColumnValue(_positionColumn);
        private void SetCompetencesName(string[] names) => SetColumnValue(_competenceColumn, names);
        private void SetEmployeesName(string[] names) => SetColumnValue(_employeeColumn, names);
        private void SetPositionsName(string[] names) => SetColumnValue(_positionColumn, names);
        private List<string> GetColumnValue(int columnNumber)
        {
            List<string> names = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string name = dataGridView1[columnNumber, i].Value?.ToString();
                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }
                names.Add(name);
            }
            return names;
        }
        private void SetColumnValue(int columnNumber, string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (dataGridView1.RowCount <= i)
                {
                    dataGridView1.Rows.Add();
                }
                dataGridView1[columnNumber, i].Value = names[i];
            }
        }
        private void SetInputNameToDGV(InputNames names)
        {
            int rowCount = GetMaxNumber(names.CompetenceNames.Count,
                                        names.EmployeeNames.Count,
                                        names.PositionNames.Count);
            for (int i = 0; i < rowCount; i++)
            {
                string[] rowValues = new string[]
                {
                    names.CompetenceNames.Count > i ? names.CompetenceNames[i] : string.Empty,
                    names.EmployeeNames.Count > i ? names.EmployeeNames[i] : string.Empty,
                    names.PositionNames.Count > i ? names.PositionNames[i] : string.Empty
                };
                dataGridView1.Rows.Add(rowValues);
            }
        }
        private int GetMaxNumber(params int[] numbers)
        {
            int result = 0;
            foreach (var item in numbers)
            {
                result = item > result ? item : result;
            }
            return result;
        }
    }
    public class InputNames
    {
        public InputNames(List<string> competenceNames, List<string> employeeNames, List<string> positionNames)
        {
            CompetenceNames = competenceNames;
            EmployeeNames = employeeNames;
            PositionNames = positionNames;
        }

        public List<string> CompetenceNames { get; set; }
        public List<string> EmployeeNames { get; set; }
        public List<string> PositionNames { get; set; }
    }
}
