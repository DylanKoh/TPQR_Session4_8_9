﻿namespace TPQR_Session4_8_9
{
    partial class UpdateCompetitor
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
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSkill = new System.Windows.Forms.ComboBox();
            this.cbCompetitors = new System.Windows.Forms.ComboBox();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.rbEndDate = new System.Windows.Forms.RadioButton();
            this.txtModuleName = new System.Windows.Forms.TextBox();
            this.cbProgress = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 14F);
            this.label6.Location = new System.Drawing.Point(271, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(445, 29);
            this.label6.TabIndex = 15;
            this.label6.Text = "Update Competitor Training Records";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 679);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1013, 64);
            this.panel2.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 93);
            this.panel1.TabIndex = 13;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 17);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 58);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(733, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASEAN Skills 2020";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Skill: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Competitor’s Name: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Sort By: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(275, 25);
            this.label5.TabIndex = 19;
            this.label5.Text = "Search By Module Name: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Search By Progress: ";
            // 
            // cbSkill
            // 
            this.cbSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkill.FormattingEnabled = true;
            this.cbSkill.Location = new System.Drawing.Point(314, 155);
            this.cbSkill.Name = "cbSkill";
            this.cbSkill.Size = new System.Drawing.Size(328, 33);
            this.cbSkill.TabIndex = 21;
            this.cbSkill.SelectedIndexChanged += new System.EventHandler(this.cbSkill_SelectedIndexChanged);
            // 
            // cbCompetitors
            // 
            this.cbCompetitors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompetitors.FormattingEnabled = true;
            this.cbCompetitors.Location = new System.Drawing.Point(314, 193);
            this.cbCompetitors.Name = "cbCompetitors";
            this.cbCompetitors.Size = new System.Drawing.Size(362, 33);
            this.cbCompetitors.TabIndex = 22;
            this.cbCompetitors.SelectedIndexChanged += new System.EventHandler(this.cbCompetitors_SelectedIndexChanged);
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Checked = true;
            this.rbName.Location = new System.Drawing.Point(314, 235);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(91, 29);
            this.rbName.TabIndex = 23;
            this.rbName.TabStop = true;
            this.rbName.Text = "Name";
            this.rbName.UseVisualStyleBackColor = true;
            this.rbName.CheckedChanged += new System.EventHandler(this.rbName_CheckedChanged);
            // 
            // rbEndDate
            // 
            this.rbEndDate.AutoSize = true;
            this.rbEndDate.Location = new System.Drawing.Point(411, 235);
            this.rbEndDate.Name = "rbEndDate";
            this.rbEndDate.Size = new System.Drawing.Size(125, 29);
            this.rbEndDate.TabIndex = 24;
            this.rbEndDate.TabStop = true;
            this.rbEndDate.Text = "End Date";
            this.rbEndDate.UseVisualStyleBackColor = true;
            this.rbEndDate.CheckedChanged += new System.EventHandler(this.rbEndDate_CheckedChanged);
            // 
            // txtModuleName
            // 
            this.txtModuleName.Location = new System.Drawing.Point(314, 275);
            this.txtModuleName.Name = "txtModuleName";
            this.txtModuleName.Size = new System.Drawing.Size(362, 32);
            this.txtModuleName.TabIndex = 25;
            this.txtModuleName.TextChanged += new System.EventHandler(this.txtModuleName_TextChanged);
            // 
            // cbProgress
            // 
            this.cbProgress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProgress.FormattingEnabled = true;
            this.cbProgress.Items.AddRange(new object[] {
            "No Filter",
            "Completed",
            "In Progress",
            "Not Started"});
            this.cbProgress.Location = new System.Drawing.Point(314, 322);
            this.cbProgress.Name = "cbProgress";
            this.cbProgress.Size = new System.Drawing.Size(328, 33);
            this.cbProgress.TabIndex = 26;
            this.cbProgress.SelectedIndexChanged += new System.EventHandler(this.cbProgress_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(12, 377);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(989, 223);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(866, 630);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(135, 43);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "TrainingID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 145;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Training Module";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 183;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Duration (Days)";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 185;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Start Date";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 134;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Estimated End Date";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 176;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Progress (%)";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 159;
            // 
            // UpdateCompetitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 743);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbProgress);
            this.Controls.Add(this.txtModuleName);
            this.Controls.Add(this.rbEndDate);
            this.Controls.Add(this.rbName);
            this.Controls.Add(this.cbCompetitors);
            this.Controls.Add(this.cbSkill);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "UpdateCompetitor";
            this.Text = "Update Competitor Progress";
            this.Load += new System.EventHandler(this.UpdateCompetitor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSkill;
        private System.Windows.Forms.ComboBox cbCompetitors;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.RadioButton rbEndDate;
        private System.Windows.Forms.TextBox txtModuleName;
        private System.Windows.Forms.ComboBox cbProgress;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}