namespace View
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.employeeSkillsDGV = new System.Windows.Forms.DataGridView();
			this.necessarySkillsDGV = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.calculateEmployeeAssignmentButton = new System.Windows.Forms.Button();
			this.employeeCompetenceNUD = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.employeeCountNUD = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.applyForEmployeeBTN = new System.Windows.Forms.Button();
			this.functionCountNUD = new System.Windows.Forms.NumericUpDown();
			this.competenceCountNUD = new System.Windows.Forms.NumericUpDown();
			this.applySkillsNUD = new System.Windows.Forms.Button();
			this.minSkillLevelNUD = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.maxSkillLevelNUD = new System.Windows.Forms.NumericUpDown();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.employeeSkillsDGV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.necessarySkillsDGV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.employeeCompetenceNUD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.employeeCountNUD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.functionCountNUD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.competenceCountNUD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.minSkillLevelNUD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maxSkillLevelNUD)).BeginInit();
			this.SuspendLayout();
			// 
			// employeeSkillsDGV
			// 
			this.employeeSkillsDGV.AllowUserToAddRows = false;
			this.employeeSkillsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.employeeSkillsDGV.Location = new System.Drawing.Point(12, 30);
			this.employeeSkillsDGV.Name = "employeeSkillsDGV";
			this.employeeSkillsDGV.Size = new System.Drawing.Size(698, 522);
			this.employeeSkillsDGV.TabIndex = 0;
			// 
			// necessarySkillsDGV
			// 
			this.necessarySkillsDGV.AllowUserToAddRows = false;
			this.necessarySkillsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.necessarySkillsDGV.Location = new System.Drawing.Point(716, 30);
			this.necessarySkillsDGV.Name = "necessarySkillsDGV";
			this.necessarySkillsDGV.Size = new System.Drawing.Size(718, 522);
			this.necessarySkillsDGV.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(225, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "Навыки сотрудников";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(713, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(230, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Необходнимые навки";
			// 
			// calculateEmployeeAssignmentButton
			// 
			this.calculateEmployeeAssignmentButton.Location = new System.Drawing.Point(595, 659);
			this.calculateEmployeeAssignmentButton.Name = "calculateEmployeeAssignmentButton";
			this.calculateEmployeeAssignmentButton.Size = new System.Drawing.Size(229, 23);
			this.calculateEmployeeAssignmentButton.TabIndex = 4;
			this.calculateEmployeeAssignmentButton.Text = "Расчитать распределение сотрудников";
			this.calculateEmployeeAssignmentButton.UseVisualStyleBackColor = true;
			this.calculateEmployeeAssignmentButton.Click += new System.EventHandler(this.calculateEmployeeAssignmentButton_Click);
			// 
			// employeeCompetenceNUD
			// 
			this.employeeCompetenceNUD.Location = new System.Drawing.Point(510, 584);
			this.employeeCompetenceNUD.Name = "employeeCompetenceNUD";
			this.employeeCompetenceNUD.Size = new System.Drawing.Size(120, 20);
			this.employeeCompetenceNUD.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(353, 560);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(140, 15);
			this.label3.TabIndex = 6;
			this.label3.Text = "Колличество сотрудников";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(353, 587);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(151, 15);
			this.label4.TabIndex = 7;
			this.label4.Text = "Колличество компетенций";
			// 
			// employeeCountNUD
			// 
			this.employeeCountNUD.Location = new System.Drawing.Point(510, 558);
			this.employeeCountNUD.Name = "employeeCountNUD";
			this.employeeCountNUD.Size = new System.Drawing.Size(120, 20);
			this.employeeCountNUD.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(781, 560);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(124, 15);
			this.label5.TabIndex = 9;
			this.label5.Text = "Количество функций";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(781, 587);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(138, 15);
			this.label6.TabIndex = 11;
			this.label6.Text = "Количество компетенций";
			// 
			// applyForEmployeeBTN
			// 
			this.applyForEmployeeBTN.Location = new System.Drawing.Point(483, 610);
			this.applyForEmployeeBTN.Name = "applyForEmployeeBTN";
			this.applyForEmployeeBTN.Size = new System.Drawing.Size(75, 23);
			this.applyForEmployeeBTN.TabIndex = 13;
			this.applyForEmployeeBTN.Text = "Применить";
			this.applyForEmployeeBTN.UseVisualStyleBackColor = true;
			this.applyForEmployeeBTN.Click += new System.EventHandler(this.applyForEmployeeBTN_Click);
			// 
			// functionCountNUD
			// 
			this.functionCountNUD.Location = new System.Drawing.Point(926, 558);
			this.functionCountNUD.Name = "functionCountNUD";
			this.functionCountNUD.Size = new System.Drawing.Size(120, 20);
			this.functionCountNUD.TabIndex = 14;
			// 
			// competenceCountNUD
			// 
			this.competenceCountNUD.Location = new System.Drawing.Point(926, 585);
			this.competenceCountNUD.Name = "competenceCountNUD";
			this.competenceCountNUD.Size = new System.Drawing.Size(120, 20);
			this.competenceCountNUD.TabIndex = 15;
			// 
			// applySkillsNUD
			// 
			this.applySkillsNUD.Location = new System.Drawing.Point(876, 610);
			this.applySkillsNUD.Name = "applySkillsNUD";
			this.applySkillsNUD.Size = new System.Drawing.Size(75, 23);
			this.applySkillsNUD.TabIndex = 16;
			this.applySkillsNUD.Text = "Применить";
			this.applySkillsNUD.UseVisualStyleBackColor = true;
			this.applySkillsNUD.Click += new System.EventHandler(this.applySkillsNUD_Click);
			// 
			// minSkillLevelNUD
			// 
			this.minSkillLevelNUD.Location = new System.Drawing.Point(227, 560);
			this.minSkillLevelNUD.Name = "minSkillLevelNUD";
			this.minSkillLevelNUD.Size = new System.Drawing.Size(120, 20);
			this.minSkillLevelNUD.TabIndex = 20;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(11, 587);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(151, 15);
			this.label7.TabIndex = 19;
			this.label7.Text = "Максимальный уровень компетенции";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(11, 560);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(169, 15);
			this.label8.TabIndex = 18;
			this.label8.Text = "Минимальный уровень навыка";
			// 
			// maxSkillLevelNUD
			// 
			this.maxSkillLevelNUD.Location = new System.Drawing.Point(227, 586);
			this.maxSkillLevelNUD.Name = "maxSkillLevelNUD";
			this.maxSkillLevelNUD.Size = new System.Drawing.Size(120, 20);
			this.maxSkillLevelNUD.TabIndex = 17;
			this.maxSkillLevelNUD.ValueChanged += new System.EventHandler(this.maxSkillLevelNUD_ValueChanged);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(1242, 611);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 22;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1446, 690);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.minSkillLevelNUD);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.maxSkillLevelNUD);
			this.Controls.Add(this.applySkillsNUD);
			this.Controls.Add(this.competenceCountNUD);
			this.Controls.Add(this.functionCountNUD);
			this.Controls.Add(this.applyForEmployeeBTN);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.employeeCountNUD);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.employeeCompetenceNUD);
			this.Controls.Add(this.calculateEmployeeAssignmentButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.necessarySkillsDGV);
			this.Controls.Add(this.employeeSkillsDGV);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.employeeSkillsDGV)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.necessarySkillsDGV)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.employeeCompetenceNUD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.employeeCountNUD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.functionCountNUD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.competenceCountNUD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.minSkillLevelNUD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.maxSkillLevelNUD)).EndInit();
			this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView employeeSkillsDGV;

        private System.Windows.Forms.NumericUpDown employeeCompetenceNUD;

        private System.Windows.Forms.NumericUpDown employeeCountNUD;

        private System.Windows.Forms.Button applyForEmployeeBTN;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown4;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown2;

        private System.Windows.Forms.Button calculateEmployeeAssignmentButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.DataGridView employeeSkillsdataGridView;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.DataGridView necessarySkillsDGV;

        private System.Windows.Forms.DataGridView dataGridView1;

		#endregion

		private System.Windows.Forms.NumericUpDown functionCountNUD;
		private System.Windows.Forms.NumericUpDown competenceCountNUD;
		private System.Windows.Forms.Button applySkillsNUD;
		private System.Windows.Forms.NumericUpDown minSkillLevelNUD;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown maxSkillLevelNUD;
		private System.Windows.Forms.Button button3;
	}
}