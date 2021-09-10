using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDZ_TPR.Model;

namespace IDZ_TPR
{
    public partial class Form1 : Form
    {
        bool SelectedEmployees;
        List<Employee> employees;
        List<Position> positions;
        public Form1()
        {
            InitializeComponent();
        }

        private void GridModelList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectedEmployees)
            {

            }
        }

        private void BtnShowWorker_Click(object sender, EventArgs e)
        {
            SelectedEmployees = true;
            GridModelListSet(employees.ToArray());
        }

        private void BtnPositionShow_Click(object sender, EventArgs e)
        {
            SelectedEmployees = false;
            GridModelListSet(positions.ToArray());
        }
        private void GridModelListSet(ModelCompetences[] models)
        {
            if (models.Length == 0)
            {
                return;
            }
            GridModelList.Rows.Clear();
            foreach (var item in models)
            {
                GridModelList.Rows.Add(item.Name);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void BtnMatixConstruct_Click(object sender, EventArgs e)
        {

        }
    }
}
