using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Form2 : Form
    {
        public Form2(Distribution distribution)
        {
            InitializeComponent();
            CalculationLog log = new CalculationLog(distribution);
            textBox1.Text = log.TextLog;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            File.WriteAllText(saveFileDialog.FileName, textBox1.Text);
        }
    }
}
