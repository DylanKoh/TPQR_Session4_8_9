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
    public partial class TrackCompetitors : Form
    {
        int _skillID = 0;
        public TrackCompetitors(int skillID)
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

        private void TrackCompetitors_Load(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                var getSkill = (from x in context.Skills
                                where x.skillId == _skillID
                                select x).FirstOrDefault();
                lblSkill.Text = getSkill.skillName;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                var getCompetitors = (from x in context.Assign_Training
                                      where x.User.skillIdFK == getSkill.skillId && x.User.userTypeIdFK == 3
                                      group x by x.User.name into y
                                      select y);
                var getTraining = (from x in context.Assign_Training
                                   where x.User.skillIdFK == getSkill.skillId && x.User.userTypeIdFK == 3
                                   group x by x.Training_Module.moduleName into y
                                   select y);
                dataGridView1.Columns.Add("Name of Competitor", "Name of Competitor");
                foreach (var item in getTraining)
                {
                    dataGridView1.Columns.Add(item.Key, item.Key);
                }
                foreach (var item in getCompetitors)
                {
                    var newRow = new List<string>() { item.Key };
                    foreach (var module in getTraining)
                    {
                        newRow.Add(item.Where(x => x.Training_Module.moduleName == module.Key).Select(x => x.progress).FirstOrDefault().ToString());
                    }
                    dataGridView1.Rows.Add(newRow.ToArray());
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewColumn cell in dataGridView1.Columns)
                    {
                        if (dataGridView1[cell.Index, row.Index].Value.ToString() == "0")
                        {
                            dataGridView1[cell.Index, row.Index].Style.BackColor = Color.Red;
                        }
                    }
                }
            }
        }
    }
}
