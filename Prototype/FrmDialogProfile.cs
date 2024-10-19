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
    public partial class FrmDialogProfile : Form
    {
        GlobalProcedures gproc;
        string imageLoc;
        int userID;
        public FrmDialogProfile(int userID)
        {
            InitializeComponent();
            gproc = new GlobalProcedures();
            this.userID = userID;
        }

        private void FrmDialogProfile_Load(object sender, EventArgs e)
        {
            gproc.fncDatabaseConnection();
            fillTextBox();
            btnUpload.Visible = false;
            btnSave.Visible = false;
        }

        public void fillTextBox()
        {
            try
            {
                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procGetAccount";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_id", userID);

                gproc.sqlHotelAdapter = new MySqlDataAdapter(gproc.sqlCommand);
                gproc.datHotel = new DataTable();

                gproc.sqlHotelAdapter.Fill(gproc.datHotel);

                    txtUsername.Text = gproc.datHotel.Rows[0]["username"].ToString();
                    txtPassword.Text = gproc.datHotel.Rows[0]["password"].ToString();
                    txtEmail.Text = gproc.datHotel.Rows[0]["email"].ToString();
                    txtAddress.Text = gproc.datHotel.Rows[0]["address"].ToString();
                    txtContactNo.Text = gproc.datHotel.Rows[0]["contactNo"].ToString();
                    txtFirstname.Text = gproc.datHotel.Rows[0]["firstName"].ToString();
                    txtLastname.Text = gproc.datHotel.Rows[0]["lastName"].ToString();
                    dtmBirthdate.Value = Convert.ToDateTime(gproc.datHotel.Rows[0]["birthdate"]);
                    cmbGender.SelectedItem = gproc.datHotel.Rows[0]["gender"].ToString();
                    picProfile.Image = Image.FromFile(gproc.datHotel.Rows[0]["image"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gproc.sqlHotelAdapter?.Dispose();
                gproc.datHotel?.Dispose();
            }
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            fillTextBox();
            btnUpload.Visible = true;
            btnSave.Visible = true;
            btnEdit.Visible = false;

            txtUsername.ReadOnly = false;
            txtPassword.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtFirstname.ReadOnly = false;
            txtLastname.ReadOnly = false;
            txtContactNo.ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procUpdateAccount";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_id", userID);
                gproc.sqlCommand.Parameters.AddWithValue("@p_username", txtUsername.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_password", txtPassword.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_firstName", txtFirstname.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_lastName", txtLastname.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_email", txtEmail.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_contactNo", txtContactNo.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_address", txtAddress.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_birthdate", dtmBirthdate.Value.ToString("yyyy-MM-dd"));
                gproc.sqlCommand.Parameters.AddWithValue("@p_gender", cmbGender.Text);
                gproc.sqlCommand.Parameters.AddWithValue("@p_image", imageLoc);
                gproc.sqlCommand.ExecuteNonQuery();

                fillTextBox();
                txtUsername.ReadOnly = true;
                txtPassword.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtAddress.ReadOnly = true;
                txtFirstname.ReadOnly = true;
                txtLastname.ReadOnly = true;
                txtContactNo.ReadOnly = true;

                btnEdit.Visible = true;
                btnUpload.Visible = false;
                btnSave.Visible = false;
            }
            catch (Exception ex)
            {
            }
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

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
