﻿
namespace IDZ_TPR
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GridMatrixView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.GridModelList = new System.Windows.Forms.DataGridView();
            this.ModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnPositionShow = new System.Windows.Forms.Button();
            this.BtnShowWorker = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnMatixConstruct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridMatrixView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridModelList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridMatrixView
            // 
            this.GridMatrixView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridMatrixView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridMatrixView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GridMatrixView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridMatrixView.Location = new System.Drawing.Point(593, 35);
            this.GridMatrixView.Name = "GridMatrixView";
            this.GridMatrixView.ReadOnly = true;
            this.GridMatrixView.RowHeadersWidth = 51;
            this.GridMatrixView.RowTemplate.Height = 24;
            this.GridMatrixView.Size = new System.Drawing.Size(882, 598);
            this.GridMatrixView.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(65, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Просмотр списка";
            // 
            // GridModelList
            // 
            this.GridModelList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GridModelList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridModelList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GridModelList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridModelList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModelName});
            this.GridModelList.Location = new System.Drawing.Point(276, 35);
            this.GridModelList.Name = "GridModelList";
            this.GridModelList.RowHeadersWidth = 51;
            this.GridModelList.RowTemplate.Height = 24;
            this.GridModelList.Size = new System.Drawing.Size(311, 598);
            this.GridModelList.TabIndex = 13;
            this.GridModelList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridModelList_CellContentClick);
            // 
            // ModelName
            // 
            this.ModelName.HeaderText = "Модели компетнций";
            this.ModelName.MinimumWidth = 6;
            this.ModelName.Name = "ModelName";
            this.ModelName.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnPositionShow);
            this.panel1.Controls.Add(this.BtnShowWorker);
            this.panel1.Location = new System.Drawing.Point(11, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 118);
            this.panel1.TabIndex = 14;
            // 
            // BtnPositionShow
            // 
            this.BtnPositionShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnPositionShow.Location = new System.Drawing.Point(18, 67);
            this.BtnPositionShow.Name = "BtnPositionShow";
            this.BtnPositionShow.Size = new System.Drawing.Size(226, 34);
            this.BtnPositionShow.TabIndex = 6;
            this.BtnPositionShow.Text = "Должности";
            this.BtnPositionShow.UseVisualStyleBackColor = true;
            this.BtnPositionShow.Click += new System.EventHandler(this.BtnPositionShow_Click);
            // 
            // BtnShowWorker
            // 
            this.BtnShowWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnShowWorker.Location = new System.Drawing.Point(18, 15);
            this.BtnShowWorker.Name = "BtnShowWorker";
            this.BtnShowWorker.Size = new System.Drawing.Size(226, 34);
            this.BtnShowWorker.TabIndex = 3;
            this.BtnShowWorker.Text = "Сотрудники";
            this.BtnShowWorker.UseVisualStyleBackColor = true;
            this.BtnShowWorker.Click += new System.EventHandler(this.BtnShowWorker_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(42, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Действие для модели";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BtnUpdate);
            this.panel2.Controls.Add(this.BtnDelete);
            this.panel2.Controls.Add(this.BtnAdd);
            this.panel2.Location = new System.Drawing.Point(11, 191);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 144);
            this.panel2.TabIndex = 17;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnUpdate.Location = new System.Drawing.Point(18, 94);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(226, 34);
            this.BtnUpdate.TabIndex = 7;
            this.BtnUpdate.Text = "Изменить";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnDelete.Location = new System.Drawing.Point(18, 54);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(226, 34);
            this.BtnDelete.TabIndex = 6;
            this.BtnDelete.Text = "Удалить";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnAdd.Location = new System.Drawing.Point(18, 14);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(226, 34);
            this.BtnAdd.TabIndex = 3;
            this.BtnAdd.Text = "Добавить";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(87, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Построить";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.BtnMatixConstruct);
            this.panel3.Location = new System.Drawing.Point(11, 364);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(259, 62);
            this.panel3.TabIndex = 12;
            // 
            // BtnMatixConstruct
            // 
            this.BtnMatixConstruct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnMatixConstruct.Location = new System.Drawing.Point(18, 13);
            this.BtnMatixConstruct.Name = "BtnMatixConstruct";
            this.BtnMatixConstruct.Size = new System.Drawing.Size(226, 34);
            this.BtnMatixConstruct.TabIndex = 3;
            this.BtnMatixConstruct.Text = "Матрицу для должности";
            this.BtnMatixConstruct.UseVisualStyleBackColor = true;
            this.BtnMatixConstruct.Click += new System.EventHandler(this.BtnMatixConstruct_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 645);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.GridMatrixView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GridModelList);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GridMatrixView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridModelList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridMatrixView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GridModelList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnPositionShow;
        private System.Windows.Forms.Button BtnShowWorker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnMatixConstruct;
    }
}

