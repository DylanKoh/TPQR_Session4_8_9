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
        string _userID;
        public ExpertMainMenu(string userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new LoginForm()).ShowDialog();
            Close();
        }
    }
}
