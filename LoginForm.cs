using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session4_8_9
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void txtFilePath_DoubleClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var data = File.ReadAllLines(txtFilePath.Text);
            var duplicate = 0;
            foreach (var item in data)
            {
                var values = item.Split(',');
                var userID = values[0];
                using (var context = new Session4Entities())
                {
                    var findUser = (from x in context.Users
                                    where x.userId == userID
                                    select x).FirstOrDefault(); 
                    if (findUser != null)
                    {
                        duplicate += 1;
                        continue;
                    }
                    else
                    {
                        var newUser = new User()
                        {
                            userId = userID,
                            skillIdFK = Int32.Parse(values[1]),
                            passwd = values[2],
                            name = values[3],
                            userTypeIdFK = int.Parse(values[4])
                        };
                        context.Users.Add(newUser);
                        context.SaveChanges();
                    }
                }

            }
            MessageBox.Show($"Succussfully added all user! Duplicates: {duplicate}");
            txtFilePath.Text = string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please ensure fields are filled!");
            }
            else
            {
                using (var context = new Session4Entities())
                {
                    var findUser = (from x in context.Users
                                    where x.userId == txtUserID.Text
                                    select x).FirstOrDefault();
                    if (findUser == null)
                    {
                        MessageBox.Show("User not found!");
                    }
                    else if (findUser.passwd != txtPassword.Text)
                    {
                        MessageBox.Show("Password incorrect!");
                    }
                    else
                    {
                        MessageBox.Show($"Welcome {findUser.name}!");
                        if (findUser.userTypeIdFK == 1)
                        {
                            Hide();
                            (new AdminMainMenu()).ShowDialog();
                            Close();
                        }
                        else if (findUser.userTypeIdFK == 2)
                        {

                        }
                        else
                        {
                            Hide();
                            (new UpdateCompetitor()).ShowDialog();
                            Close();
                        }
                    }
                }
            }
        }
    }
}
