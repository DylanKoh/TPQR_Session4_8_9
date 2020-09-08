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
    public partial class TrackOverall : Form
    {
        public TrackOverall()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new AdminMainMenu()).ShowDialog();
            Close();
        }

        private void TrackOverall_Load(object sender, EventArgs e)
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
            chart1.Series.Clear();
            dgvCompetitor.Rows.Clear();
            dgvExpert.Rows.Clear();
            dgvTrainingModules.Rows.Clear();
            dgvTrainingModules.Columns.Clear();
            dgvExpert.Columns.Clear();
            dgvCompetitor.Columns.Clear();
            dgvTrainingModules.Columns.Add("Trainee Category", "Trainee Category");
            dgvExpert.Columns.Add("Status (Experts)", "Status (Experts)");
            dgvCompetitor.Columns.Add("Status (Competitors)", "Status (Competitors)");
            chart1.Series.Add("Completed");
            chart1.Series.Add("In Progress");
            chart1.Series.Add("Not Started");
            using (var context = new Session4Entities())
            {
                var getSkillID = (from x in context.Skills
                                  where x.skillName == cbSkill.SelectedItem.ToString()
                                  select x.skillId).FirstOrDefault();
                var getOverallModules = (from x in context.Assign_Training
                                         where x.User.skillIdFK == getSkillID
                                         select x).ToList();
                var getDistinctDatesFilter = (from x in getOverallModules
                                              group x by x.startDate.ToString("MM/yyyy") into y
                                              select y);
                var getDistinctExpertTraining = (from x in getOverallModules
                                                 where x.User.userTypeIdFK == 2
                                                 group x by x.Training_Module.moduleName into y
                                                 select y);
                var getDistinctCompetitorTraining = (from x in getOverallModules
                                                     where x.User.userTypeIdFK == 3
                                                     group x by x.Training_Module.moduleName into y
                                                     select y);
                var expertRow = new List<string>() { "Expert" };
                var competitorRow = new List<string>() { "Competitor" };
                var expertCompleted = new List<string>() { "Completed" };
                var expertInProgress = new List<string>() { "In Progress" };
                var expertNotStarted = new List<string>() { "Not Started" };
                var competitorCompleted = new List<string>() { "Completed" };
                var competitorInProgress = new List<string>() { "In Progress" };
                var competitorNotStarted = new List<string>() { "Not Started" };
                foreach (var item in getDistinctDatesFilter)
                {
                    dgvTrainingModules.Columns.Add($"No. of Training Modules Start in {item.Key}", $"No. of Training Modules Start in {item.Key}");
                    expertRow.Add(item.Where(x => x.User.userTypeIdFK == 2).Select(x => x.moduleIdFK).Distinct().Count().ToString());
                    competitorRow.Add(item.Where(x => x.User.userTypeIdFK == 3).Select(x => x.moduleIdFK).Distinct().Count().ToString());
                }
                dgvTrainingModules.Rows.Add(competitorRow.ToArray());
                dgvTrainingModules.Rows.Add(expertRow.ToArray());
                foreach (var item in getDistinctExpertTraining)
                {
                    dgvExpert.Columns.Add($"{item.Key}", $"{item.Key}");
                    expertCompleted.Add(item.Where(x => x.progress == 100).Count().ToString());
                    expertInProgress.Add(item.Where(x => x.progress > 0 && x.progress < 100).Count().ToString());
                    expertNotStarted.Add(item.Where(x => x.progress == 0).Count().ToString());
                }
                dgvExpert.Rows.Add(expertCompleted.ToArray());
                dgvExpert.Rows.Add(expertInProgress.ToArray());
                dgvExpert.Rows.Add(expertNotStarted.ToArray());

                foreach (var item in getDistinctCompetitorTraining)
                {
                    dgvCompetitor.Columns.Add($"{item.Key}", $"{item.Key}");
                    competitorCompleted.Add(item.Where(x => x.progress == 100).Count().ToString());
                    competitorInProgress.Add(item.Where(x => x.progress > 0 && x.progress < 100).Count().ToString());
                    competitorNotStarted.Add(item.Where(x => x.progress == 0).Count().ToString());
                }
                dgvCompetitor.Rows.Add(competitorCompleted.ToArray());
                dgvCompetitor.Rows.Add(competitorInProgress.ToArray());
                dgvCompetitor.Rows.Add(competitorNotStarted.ToArray());

                foreach (var item in getDistinctCompetitorTraining)
                {
                    chart1.Series[0].Points.AddXY(item.Key, item.Where(x => x.progress == 100).Count());
                    chart1.Series[1].Points.AddXY(item.Key, item.Where(x => x.progress > 0 && x.progress < 100).Count());
                    chart1.Series[2].Points.AddXY(item.Key, item.Where(x => x.progress == 0).Count());

                }
            }
        }
    }
}
