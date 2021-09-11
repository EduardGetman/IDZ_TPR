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
        }
	}
}