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
    public partial class ExpertMainMenu : Form
    {
        int _skillID = 0;
        public ExpertMainMenu(int skillID)
        {
            InitializeComponent();
            _skillID = skillID;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new LoginForm()).ShowDialog();
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Hide();
            (new UpdateExpert(_skillID)).ShowDialog();
            Close();
        }

        private void btnTrackCompetitors_Click(object sender, EventArgs e)
        {
            Hide();
            (new TrackCompetitors(_skillID)).ShowDialog();
            Close();
        }
    }
}
