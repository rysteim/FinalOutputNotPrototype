using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    public partial class FrmStartUp : Form
    {
        GlobalProcedures gproc;
        string imageLoc;
        int userID;
        public FrmStartUp()
        {
            InitializeComponent();
            gproc = new GlobalProcedures();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = true;
            pnlSignup.Visible = false;
            btnLogin.BackColor = Color.FromArgb(64, 64, 64);
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btnLogin.ForeColor = Color.White;
            btnSignup.BackColor = Color.White;
            btnSignup.FlatAppearance.BorderColor = Color.White;
            btnSignup.ForeColor = Color.Black;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;
            pnlSignup.Visible = true;
            btnLogin.BackColor = Color.White;
            btnLogin.FlatAppearance.BorderColor = Color.White;
            btnLogin.ForeColor = Color.Black;
            btnSignup.BackColor = Color.FromArgb(64, 64, 64);
            btnSignup.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btnSignup.ForeColor = Color.White;
        }

        private void FrmStartUp_Load(object sender, EventArgs e)
        {
            gproc.fncDatabaseConnection();
            pnlSignup.Visible = false;
            dialogUpload.Visible = false;
        }

        private void btnLogin1_Click(object sender, EventArgs e)
        {
            logIn();
        }

        private void btnSignup1_Click(object sender, EventArgs e)
        {
            dialogUpload.Visible = true;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog profilePic = new OpenFileDialog();
            profilePic.Filter = "Images Files (*.jpg;*.gif;*.bmp)|*.jpg;*.gif;*.bmp";
            if (profilePic.ShowDialog() == DialogResult.OK)
            {
                picProfile.Image = new Bitmap(profilePic.FileName);
                imageLoc = profilePic.FileName;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            dialogUpload.Visible = false;
            signUp();
        }

        public void signUp()
        {
            try
            {
                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procAddAccount";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_username", txtUsername1.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_password", txtPassword1.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_email", txtEmail.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_address", txtAddress.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_contactNo", txtContactNo.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_firstName", txtFirstname.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_lastName", txtLastname.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_birthdate", dtmBirthdate.Value.ToString("yyyy-MM-dd"));
                gproc.sqlCommand.Parameters.AddWithValue("@p_gender", txtPassword.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_image", imageLoc);
                gproc.sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Record Successfully Registered.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnlLogin.Visible = true;
                pnlSignup.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sign up failed. \n Error: " + ex.Message);
                clearInputs();
            }
        }

        public void logIn()
        {
            userID = -1;
            try
            {
                gproc.sqlHotelAdapter = new MySqlDataAdapter();
                gproc.datHotel = new DataTable();

                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procAccountLogIn";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_username", txtUsername.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_password", txtPassword.Text);
                MessageBox.Show("Log in successful.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                gproc.sqlHotelAdapter.SelectCommand = gproc.sqlCommand;
                gproc.sqlHotelAdapter.Fill(gproc.datHotel);

                if (gproc.datHotel.Rows.Count > 0)
                {
                    string result = gproc.datHotel.Rows[0]["id"].ToString();
                    if (!string.IsNullOrEmpty(result))
                    {
                        userID = Convert.ToInt32(result); // Save the user ID
                        MessageBox.Show($"Log in successful. User ID: {userID}", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Open the dashboard and hide the login form
                        new FrmDashboard(userID).Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                gproc.sqlHotelAdapter.Dispose();
                gproc.datHotel.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Log in failed. \n Error: " + ex.Message);
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        public void clearInputs()
        {
            txtUsername1.Clear();
            txtPassword1.Clear();
            txtFirstname.Clear();
            txtLastname.Clear();
            txtEmail.Clear();
            txtContactNo.Clear();
            txtAddress.Clear();
            dtmBirthdate.Value = DateTime.Now;
            cmbGender.SelectedIndex = -1;
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Enter your username...")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Enter your username...";
                txtUsername.ForeColor = Color.Silver;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter your password...")
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = "Enter your password...";
                txtPassword.ForeColor = Color.Silver;
            }
        }

        private void txtUsername1_Enter(object sender, EventArgs e)
        {
            if (txtUsername1.Text == "Enter your username...")
            {
                txtUsername1.Text = "";
                txtUsername1.ForeColor = Color.Black;
            }
        }

        private void txtUsername1_Leave(object sender, EventArgs e)
        {

            if (txtUsername1.Text == "")
            {
                txtUsername1.Text = "Enter your username...";
                txtUsername1.ForeColor = Color.Silver;
            }
        }

        private void txtPassword1_Enter(object sender, EventArgs e)
        {
            if (txtPassword1.Text == "Enter your password...")
            {
                txtPassword1.UseSystemPasswordChar = true;
                txtPassword1.Text = "";
                txtPassword1.ForeColor = Color.Black;
            }
        }

        private void txtPassword1_Leave(object sender, EventArgs e)
        {
            if (txtPassword1.Text == "")
            {
                txtPassword1.UseSystemPasswordChar = false;
                txtPassword1.Text = "Enter your password...";
                txtPassword1.ForeColor = Color.Silver;
            }
        }

        private void txtFirstname_Enter(object sender, EventArgs e)
        {
            if (txtFirstname.Text == "Enter your first name...")
            {
                txtFirstname.Text = "";
                txtFirstname.ForeColor = Color.Black;
            }
        }

        private void txtFirstname_Leave(object sender, EventArgs e)
        {
            if (txtFirstname.Text == "")
            {
                txtFirstname.Text = "Enter your first name...";
                txtFirstname.ForeColor = Color.Silver;
            }
        }

        private void txtLastname_Enter(object sender, EventArgs e)
        {
            if (txtLastname.Text == "Enter your last name...")
            {
                txtLastname.Text = "";
                txtLastname.ForeColor = Color.Black;
            }
        }

        private void txtLastname_Leave(object sender, EventArgs e)
        {
            if (txtLastname.Text == "")
            {
                txtLastname.Text = "Enter your last name...";
                txtLastname.ForeColor = Color.Silver;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Enter your email...")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Enter your email...";
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void txtContactNo_Enter(object sender, EventArgs e)
        {
            if (txtContactNo.Text == "Enter your contact no...")
            {
                txtContactNo.Text = "";
                txtContactNo.ForeColor = Color.Black;
            }
        }
        private void txtContactNo_Leave(object sender, EventArgs e)
        {
            if (txtContactNo.Text == "")
            {
                txtContactNo.Text = "Enter your contact no...";
                txtContactNo.ForeColor = Color.Silver;
            }
        }
        private void txtAddress_Enter(object sender, EventArgs e)
        {
            if (txtAddress.Text == "Enter your address...")
            {
                txtAddress.Text = "";
                txtAddress.ForeColor = Color.Black;
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (txtAddress.Text == "")
            {
                txtAddress.Text = "Enter your address...";
                txtAddress.ForeColor = Color.Silver;
            }
        }

    }
}
