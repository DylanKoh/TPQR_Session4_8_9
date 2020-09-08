﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session4_8_9
{
    public partial class UpdateCompetitor : Form
    {
        public UpdateCompetitor()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new LoginForm()).ShowDialog();
            Close();
        }

        private void UpdateCompetitor_Load(object sender, EventArgs e)
        {
            LoadSkills();

        }

        private void LoadSkills()
        {
            cbSkill.Items.Clear();
            using (var context = new Session4Entities())
            {
                var getSkills = (from x in context.Skills
                                 where x.skillName != "Admin"
                                 select x.skillName).ToArray();
                cbSkill.Items.AddRange(getSkills);
            }
        }

        private void cbSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCompetitors.Items.Clear();
            using (var context = new Session4Entities())
            {
                var getSkillID = (from x in context.Skills
                                  where x.skillName == cbSkill.SelectedItem.ToString()
                                  select x.skillId).FirstOrDefault();
                var getCompetitors = (from x in context.Users
                                      where x.userTypeIdFK == 3 && x.skillIdFK == getSkillID
                                      select x.name).ToArray();
                cbCompetitors.Items.AddRange(getCompetitors);
            }
        }

        private void cbCompetitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbProgress.SelectedIndex = 0;
        }

        private void rbEndDate_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            using (var context = new Session4Entities())
            {
                var getSkillID = (from x in context.Skills
                                  where x.skillName == cbSkill.SelectedItem.ToString()
                                  select x.skillId).FirstOrDefault();
                var training = (from x in context.Assign_Training
                                where x.User.name == cbCompetitors.SelectedItem.ToString() && x.User.skillIdFK == getSkillID && x.User.userTypeIdFK == 3
                                select x).ToList();
                if (cbProgress.SelectedItem.ToString() == "No Filter")
                {
                    if (rbEndDate.Checked)
                    {
                        if (string.IsNullOrWhiteSpace(txtModuleName.Text))
                        {
                            var ordered = training.OrderByDescending(x => x.startDate.AddDays(x.Training_Module.durationDays));
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                        else
                        {
                            var ordered = training.OrderByDescending(x => x.startDate.AddDays(x.Training_Module.durationDays)).Where(x => x.Training_Module.moduleName.ToLower().Contains(txtModuleName.Text.ToLower())); ;
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(txtModuleName.Text))
                        {
                            var ordered = training.OrderBy(x => x.Training_Module.moduleName);
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                        else
                        {
                            var ordered = training.OrderBy(x => x.Training_Module.moduleName).Where(x => x.Training_Module.moduleName.ToLower().Contains(txtModuleName.Text.ToLower()));
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                    }
                }
                else if (cbProgress.SelectedItem.ToString() == "Completed")
                {
                    var orderedProgress = training.Where(x => x.progress == 100);
                    if (rbEndDate.Checked)
                    {
                        if (string.IsNullOrWhiteSpace(txtModuleName.Text))
                        {
                            var ordered = orderedProgress.OrderByDescending(x => x.startDate.AddDays(x.Training_Module.durationDays));
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                        else
                        {
                            var ordered = orderedProgress.OrderByDescending(x => x.startDate.AddDays(x.Training_Module.durationDays)).Where(x => x.Training_Module.moduleName.ToLower().Contains(txtModuleName.Text.ToLower())); ;
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(txtModuleName.Text))
                        {
                            var ordered = orderedProgress.OrderBy(x => x.Training_Module.moduleName);
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                        else
                        {
                            var ordered = orderedProgress.OrderBy(x => x.Training_Module.moduleName).Where(x => x.Training_Module.moduleName.ToLower().Contains(txtModuleName.Text.ToLower()));
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                    }
                }
                else if (cbProgress.SelectedItem.ToString() == "In Progress")
                {
                    var orderedProgress = training.Where(x => x.progress < 100 && x.progress > 0);
                    if (rbEndDate.Checked)
                    {
                        if (string.IsNullOrWhiteSpace(txtModuleName.Text))
                        {
                            var ordered = orderedProgress.OrderByDescending(x => x.startDate.AddDays(x.Training_Module.durationDays));
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                        else
                        {
                            var ordered = orderedProgress.OrderByDescending(x => x.startDate.AddDays(x.Training_Module.durationDays)).Where(x => x.Training_Module.moduleName.ToLower().Contains(txtModuleName.Text.ToLower())); ;
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(txtModuleName.Text))
                        {
                            var ordered = orderedProgress.OrderBy(x => x.Training_Module.moduleName);
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                        else
                        {
                            var ordered = orderedProgress.OrderBy(x => x.Training_Module.moduleName).Where(x => x.Training_Module.moduleName.ToLower().Contains(txtModuleName.Text.ToLower()));
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                    }
                }
                else
                {
                    var orderedProgress = training.Where(x => x.progress == 0);
                    if (rbEndDate.Checked)
                    {
                        if (string.IsNullOrWhiteSpace(txtModuleName.Text))
                        {
                            var ordered = orderedProgress.OrderByDescending(x => x.startDate.AddDays(x.Training_Module.durationDays));
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                        else
                        {
                            var ordered = orderedProgress.OrderByDescending(x => x.startDate.AddDays(x.Training_Module.durationDays)).Where(x => x.Training_Module.moduleName.ToLower().Contains(txtModuleName.Text.ToLower())); ;
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(txtModuleName.Text))
                        {
                            var ordered = orderedProgress.OrderBy(x => x.Training_Module.moduleName);
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                        else
                        {
                            var ordered = orderedProgress.OrderBy(x => x.Training_Module.moduleName).Where(x => x.Training_Module.moduleName.ToLower().Contains(txtModuleName.Text.ToLower()));
                            foreach (var item in ordered)
                            {
                                var newRow = new List<string>()
                            {
                                item.trainingId.ToString(), item.Training_Module.moduleName,
                                item.Training_Module.durationDays.ToString(),
                                item.startDate.ToShortDateString(),
                                item.startDate.AddDays(item.Training_Module.durationDays).ToShortDateString(),
                                item.progress.ToString()
                            };
                                dataGridView1.Rows.Add(newRow.ToArray());
                            }
                        }
                    }
                }

            }

        }

        private void rbName_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtModuleName_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbProgress_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                var trainingID = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                using (var context = new Session4Entities())
                {
                    var getOldProgress = (from x in context.Assign_Training
                                          where x.trainingId == trainingID
                                          select x.progress).FirstOrDefault();
                    if (!int.TryParse(dataGridView1[5, e.RowIndex].Value.ToString(), out _) || getOldProgress > Convert.ToInt32(dataGridView1[e.ColumnIndex, e.RowIndex].Value))
                    {
                        MessageBox.Show("Please make sure new progress is more than or equal to the current progress with a valid integer!");
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = getOldProgress;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                using (var context = new Session4Entities())
                {
                    var trainingID = Convert.ToInt32(dataGridView1[0, item.Index].Value);
                    var getTraining = (from x in context.Assign_Training
                                       where x.trainingId == trainingID
                                       select x).FirstOrDefault();
                    getTraining.progress = Convert.ToInt32(dataGridView1[5, item.Index].Value);
                    context.SaveChanges();
                    
                }
            }
            MessageBox.Show("Updated progress successful!");
            LoadData();
        }
    }
}
