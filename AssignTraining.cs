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
    public partial class AssignTraining : Form
    {
        DateTime compDate = new DateTime(2020, 10, 1, 09, 00, 00);
        public AssignTraining()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new AdminMainMenu()).ShowDialog();
            Close();
        }

        private void AssignTraining_Load(object sender, EventArgs e)
        {
            LoadSkills();
        }

        private void LoadSkills()
        {
            cbSkill.Items.Clear();
            cbCat.Items.Clear();
            cbTrainingModule.Items.Clear();
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
            using (var context = new Session4Entities())
            {
                var getCat = (from x in context.User_Type
                              where x.userTypeName != "Admin"
                              select x.userTypeName).ToArray();
                cbCat.Items.AddRange(getCat);
            }
        }

        private void cbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                var getSkillID = (from x in context.Skills
                                  where x.skillName == cbSkill.SelectedItem.ToString()
                                  select x.skillId).FirstOrDefault();
                var getCatID = (from x in context.User_Type
                                where x.userTypeName == cbCat.SelectedItem.ToString()
                                select x.userTypeId).FirstOrDefault();
                var getTrainings = (from x in context.Training_Module
                                    where x.skillIdFK == getSkillID && x.userTypeIdFK == getCatID && x.Assign_Training.Count() == 0
                                    select x.moduleName).ToArray();
                cbTrainingModule.Items.AddRange(getTrainings);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                var getSkillID = (from x in context.Skills
                                  where x.skillName == cbSkill.SelectedItem.ToString()
                                  select x.skillId).FirstOrDefault();
                var getCatID = (from x in context.User_Type
                                where x.userTypeName == cbCat.SelectedItem.ToString()
                                select x.userTypeId).FirstOrDefault();
                var getTrainings = (from x in context.Training_Module
                                    where x.skillIdFK == getSkillID && x.userTypeIdFK == getCatID && x.moduleName == cbTrainingModule.SelectedItem.ToString()
                                    select x).FirstOrDefault();
                if (dtpStart.Value.AddDays(getTrainings.durationDays) > compDate)
                {
                    MessageBox.Show("Unable to add training! It will end after competition date!");
                }
                else
                {
                    var boolCheck = true;
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        if (Convert.ToInt32(dataGridView1[0, item.Index].Value) == getTrainings.moduleId)
                        {
                            boolCheck = false;
                            break;
                        }
                    }
                    if (boolCheck == false)
                    {
                        MessageBox.Show("Unable to add duplicates!");
                    }
                    else
                    {
                        var newRow = new List<string>()
                        {
                            getTrainings.moduleId.ToString(), cbSkill.SelectedItem.ToString(),
                            cbCat.SelectedItem.ToString(), getTrainings.moduleName, dtpStart.Value.ToShortDateString()
                        };
                        dataGridView1.Rows.Add(newRow.ToArray());
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a training to remove!");
            }
            else
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                MessageBox.Show("Removed!");
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            using (var context =new Session4Entities())
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var skill = dataGridView1[1, row.Index].Value.ToString();
                    var cat = dataGridView1[2, row.Index].Value.ToString();
                    var getSkillID = (from x in context.Skills
                                      where x.skillName == skill
                                      select x.skillId).FirstOrDefault();
                    var getCatID = (from x in context.User_Type
                                    where x.userTypeName == cat
                                    select x.userTypeId).FirstOrDefault();
                    var getPeople = (from x in context.Users
                                     where x.skillIdFK == getSkillID && x.userTypeIdFK == getCatID
                                     select x);
                    foreach (var item in getPeople)
                    {
                        var newTraining = new Assign_Training()
                        {
                            moduleIdFK = Convert.ToInt32(dataGridView1[0, row.Index].Value),
                            progress = 0,
                            startDate = DateTime.Parse(dataGridView1[4, row.Index].Value.ToString()),
                            userIdFK = item.userId
                        };
                        context.Assign_Training.Add(newTraining);

                    }
                }
                context.SaveChanges();
            }
            MessageBox.Show("Training assigned completed!");
            Hide();
            (new AdminMainMenu()).ShowDialog();
            Close();
        }
    }
}
