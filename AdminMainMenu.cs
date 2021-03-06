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
    public partial class AdminMainMenu : Form
    {
        public AdminMainMenu()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new LoginForm()).ShowDialog();
            Close();
        }

        private void btnTrackOverall_Click(object sender, EventArgs e)
        {
            Hide();
            (new TrackOverall()).ShowDialog();
            Close();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            Hide();
            (new AssignTraining()).ShowDialog();
            Close();
        }
    }
}
