using System;
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
    public partial class UpdateExpert : Form
    {
        int _skillID;
        public UpdateExpert(int skillID)
        {
            InitializeComponent();
            _skillID = skillID;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new ExpertMainMenu(_skillID)).ShowDialog();
            Close();
        }

        private void rbProgress_CheckedChanged(object sender, EventArgs e)
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
                var getTraining = (from x in context.Assign_Training
                                   where x.User.name == cbExperts.SelectedItem.ToString() && x.User.skillIdFK == getSkillID && x.User.userTypeIdFK == 2
                                   select x);
                if (rbName.Checked)
                {
                    var ordered = getTraining.OrderBy(x => x.Training_Module.moduleName);
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
                    var ordered = getTraining.OrderByDescending(x => x.progress);
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
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if ((DateTime.Today - DateTime.Parse(dataGridView1[4, item.Index].Value.ToString())).TotalDays <= 5 || DateTime.Today > DateTime.Parse(dataGridView1[4, item.Index].Value.ToString()))
                {
                    dataGridView1.Rows[item.Index].DefaultCellStyle.BackColor = Color.Red;
                }
                else if ((DateTime.Today - DateTime.Parse(dataGridView1[4, item.Index].Value.ToString())).TotalDays <= 14)
                {
                    dataGridView1.Rows[item.Index].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }


        }

        private void rbName_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void UpdateExpert_Load(object sender, EventArgs e)
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
            cbExperts.Items.Clear();
            using (var context = new Session4Entities())
            {
                var getSkillID = (from x in context.Skills
                                  where x.skillName == cbSkill.SelectedItem.ToString()
                                  select x.skillId).FirstOrDefault();
                var getExperts = (from x in context.Users
                                  where x.userTypeIdFK == 2 && x.skillIdFK == getSkillID
                                  select x.name).ToArray();
                cbExperts.Items.AddRange(getExperts);
            }
        }

        private void cbExperts_SelectedIndexChanged(object sender, EventArgs e)
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
