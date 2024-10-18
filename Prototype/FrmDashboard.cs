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
    public partial class FrmDashboard : Form
    {
        GlobalProcedures gproc;
        private int userID, row;
        public FrmDashboard(int userID)
        {
            InitializeComponent();
            gproc = new GlobalProcedures();
            this.userID = userID;
        }
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            gproc.fncDatabaseConnection();
            pnlReservations.Visible = false;
            pnlAddonsPromo.Visible = false;
            pnlRooms.Visible = false;
            //pnlTenants.Visible = false;
            //pnlPersonnel.Visible = false;
            getAccount();
        }

        public void getAccount()
        {
            try
            {
                gproc.sqlHotelAdapter = new MySqlDataAdapter();
                gproc.datHotel = new DataTable();

                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procGetAccount";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_id", userID);
                gproc.sqlCommand.ExecuteNonQuery();

                gproc.sqlHotelAdapter.SelectCommand = gproc.sqlCommand;
                gproc.sqlHotelAdapter.Fill(gproc.datHotel);

                if (gproc.datHotel.Rows.Count > 0)
                {
                    lblFirstname.Text = gproc.datHotel.Rows[0]["firstName"].ToString();
                    picProfile.Image = Image.FromFile(gproc.datHotel.Rows[0]["image"].ToString());
                    
                    if (IsTenant(userID))
                    {
                        lblPosition.Text = "Tenant";
                        ifTenant();
                    }
                }
                else
                {
                    MessageBox.Show("No account found with the given ID.");
                }

                gproc.sqlHotelAdapter.Dispose();
                gproc.datHotel.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Log in failed. \n Error: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new FrmStartUp().Show();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {

        }

        private bool IsTenant(int userID)
        {
            gproc.sqlCommand.Parameters.Clear();
            gproc.sqlCommand.CommandText = "procCheckTenant";
            gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
            gproc.sqlCommand.Parameters.AddWithValue("@p_id", userID);

            gproc.datHotel = new DataTable(); // Reset DataTable
            gproc.sqlHotelAdapter.SelectCommand = gproc.sqlCommand;
            gproc.sqlHotelAdapter.Fill(gproc.datHotel);

            return gproc.datHotel.Rows.Count > 0;
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            pnlRooms.Visible = true;
            pnlDashboard.Visible = false;
            pnlReservations.Visible = false;
            pnlAddonsPromo.Visible = false;
            //pnlTenants.Visible = false;
            //pnlPersonnel.Visible = false;

            btnRooms.BackColor = Color.FromArgb(64, 64, 64);
            btnRooms.FlatAppearance.BorderColor = Color.Black;
            btnRooms.ForeColor = Color.White;

            btnDashboard.BackColor = Color.White;
            btnDashboard.FlatAppearance.BorderColor = Color.Gray;
            btnDashboard.ForeColor = Color.Black;

            btnTenants.BackColor = Color.White;
            btnTenants.FlatAppearance.BorderColor = Color.Gray;
            btnTenants.ForeColor = Color.Black;

            btnPersonnel.BackColor = Color.White;
            btnPersonnel.FlatAppearance.BorderColor = Color.Gray;
            btnPersonnel.ForeColor = Color.Black;

            btnReservations.BackColor = Color.White;
            btnReservations.FlatAppearance.BorderColor = Color.Gray;
            btnReservations.ForeColor = Color.Black;

            btnAddonsPromo.BackColor = Color.White;
            btnAddonsPromo.FlatAppearance.BorderColor = Color.Gray;
            btnAddonsPromo.ForeColor = Color.Black;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

            pnlDashboard.Visible = true;
            pnlRooms.Visible = false;
            pnlReservations.Visible = false;
            pnlAddonsPromo.Visible = false;
            //pnlTenants.Visible = false;
            //pnlPersonnel.Visible = false;

            btnDashboard.BackColor = Color.FromArgb(64, 64, 64);
            btnDashboard.FlatAppearance.BorderColor = Color.Black;
            btnDashboard.ForeColor = Color.White;

            btnRooms.BackColor = Color.White;
            btnRooms.FlatAppearance.BorderColor = Color.Gray;
            btnRooms.ForeColor = Color.Black;

            btnTenants.BackColor = Color.White;
            btnTenants.FlatAppearance.BorderColor = Color.Gray;
            btnTenants.ForeColor = Color.Black;

            btnPersonnel.BackColor = Color.White;
            btnPersonnel.FlatAppearance.BorderColor = Color.Gray;
            btnPersonnel.ForeColor = Color.Black;

            btnReservations.BackColor = Color.White;
            btnReservations.FlatAppearance.BorderColor = Color.Gray;
            btnReservations.ForeColor = Color.Black;

            btnAddonsPromo.BackColor = Color.White;
            btnAddonsPromo.FlatAppearance.BorderColor = Color.Gray;
            btnAddonsPromo.ForeColor = Color.Black;
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            pnlReservations.Visible = true;
            pnlDashboard.Visible = false;
            pnlRooms.Visible = false;
            pnlAddonsPromo.Visible = false;
            //pnlTenants.Visible = false;
            //pnlPersonnel.Visible = false;

            btnReservations.BackColor = Color.FromArgb(64, 64, 64);
            btnReservations.FlatAppearance.BorderColor = Color.Black;
            btnReservations.ForeColor = Color.White;

            btnRooms.BackColor = Color.White;
            btnRooms.FlatAppearance.BorderColor = Color.Gray;
            btnRooms.ForeColor = Color.Black;

            btnTenants.BackColor = Color.White;
            btnTenants.FlatAppearance.BorderColor = Color.Gray;
            btnTenants.ForeColor = Color.Black;

            btnPersonnel.BackColor = Color.White;
            btnPersonnel.FlatAppearance.BorderColor = Color.Gray;
            btnPersonnel.ForeColor = Color.Black;

            btnDashboard.BackColor = Color.White;
            btnDashboard.FlatAppearance.BorderColor = Color.Gray;
            btnDashboard.ForeColor = Color.Black;

            btnAddonsPromo.BackColor = Color.White;
            btnAddonsPromo.FlatAppearance.BorderColor = Color.Gray;
            btnAddonsPromo.ForeColor = Color.Black;
        }

        private void btnAddonsPromo_Click(object sender, EventArgs e)
        {
            pnlAddonsPromo.Visible = true;
            pnlDashboard.Visible = false;
            pnlRooms.Visible = false;
            pnlReservations.Visible = false;
            //pnlTenants.Visible = false;
            //pnlPersonnel.Visible = false;
            displayAddons();
            resetAP();

            btnAddonsPromo.BackColor = Color.FromArgb(64, 64, 64);
            btnAddonsPromo.FlatAppearance.BorderColor = Color.Black;
            btnAddonsPromo.ForeColor = Color.White;

            btnRooms.BackColor = Color.White;
            btnRooms.FlatAppearance.BorderColor = Color.Gray;
            btnRooms.ForeColor = Color.Black;

            btnTenants.BackColor = Color.White;
            btnTenants.FlatAppearance.BorderColor = Color.Gray;
            btnTenants.ForeColor = Color.Black;

            btnPersonnel.BackColor = Color.White;
            btnPersonnel.FlatAppearance.BorderColor = Color.Gray;
            btnPersonnel.ForeColor = Color.Black;

            btnDashboard.BackColor = Color.White;
            btnDashboard.FlatAppearance.BorderColor = Color.Gray;
            btnDashboard.ForeColor = Color.Black;

            btnReservations.BackColor = Color.White;
            btnReservations.FlatAppearance.BorderColor = Color.Gray;
            btnReservations.ForeColor = Color.Black;
        }

        private void btnAddons_Click(object sender, EventArgs e)
        {
            pnlAddons.Visible = true;
            pnlPromos.Visible = false;
            showAddons();
            hidePromos();
            displayAddons();

            btnAddons.BackColor = Color.FromArgb(64, 64, 64);
            btnAddons.FlatAppearance.BorderColor = Color.Black;
            btnAddons.ForeColor = Color.White;

            btnPromos.BackColor = Color.White;
            btnPromos.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnPromos.ForeColor = Color.Black;
        }

        private void btnPromos_Click(object sender, EventArgs e)
        {
            pnlPromos.Visible = true;
            pnlAddons.Visible = false;
            showPromos();
            hideAddons();
            displayPromos();

            btnPromos.BackColor = Color.FromArgb(64, 64, 64);
            btnPromos.FlatAppearance.BorderColor = Color.Black;
            btnPromos.ForeColor = Color.White;

            btnAddons.BackColor = Color.White;
            btnAddons.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnAddons.ForeColor = Color.Black;
        }

        public void ifTenant()
        {
            btnRooms.Visible = false;
            btnTenants.Visible = false;
            btnPersonnel.Visible = false;
        }

        public void hideAddons()
        {
            btnAddAddons.Visible = false;
            btnEditAddons.Visible = false;
            btnDeleteAddons.Visible = false;
            btnSubmitAddons.Visible = false;
        }

        public void showAddons()
        {
            btnAddAddons.Visible = true;
            btnEditAddons.Visible = true;
            btnDeleteAddons.Visible = true;
            btnSubmitAddons.Visible = true;
        }

        public void hidePromos()
        {
            btnAddPromos.Visible = false;
            btnEditPromos.Visible = false;
            btnDeletePromos.Visible = false;
            btnSubmitPromos.Visible = false;
        }

        public void showPromos()
        {
            btnAddPromos.Visible = true;
            btnEditPromos.Visible = true;
            btnDeletePromos.Visible = true;
            btnSubmitPromos.Visible = true;
        }

        public void resetAP()
        {
            pnlAddons.Visible = true;
            pnlPromos.Visible = false;
            showAddons();
            hidePromos();

            btnAddons.BackColor = Color.FromArgb(64, 64, 64);
            btnAddons.FlatAppearance.BorderColor = Color.Black;
            btnAddons.ForeColor = Color.White;

            btnPromos.BackColor = Color.White;
            btnPromos.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnPromos.ForeColor = Color.Black;
        }

        public void displayAddons()
        {
            try
            {
                gproc.sqlHotelAdapter = new MySqlDataAdapter();
                gproc.datHotel = new DataTable();

                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procGetAddons";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;

                gproc.sqlHotelAdapter.SelectCommand = gproc.sqlCommand;
                gproc.datHotel.Clear();
                gproc.sqlHotelAdapter.Fill(gproc.datHotel);

                cmbAddons.Items.Clear();

                if (gproc.datHotel.Rows.Count > 0)
                {
                    foreach (DataRow row in gproc.datHotel.Rows)
                    {
                        cmbAddons.Items.Add(row["name"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Record not Found!", "Records", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gproc.sqlHotelAdapter?.Dispose();
                gproc.datHotel?.Dispose();
            }
        }

        private void cmbAddons_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gproc.sqlHotelAdapter = new MySqlDataAdapter();
                gproc.datHotel = new DataTable();

                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procSearchAddons";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_id", cmbAddons.SelectedIndex + 1);
                gproc.sqlHotelAdapter.SelectCommand = gproc.sqlCommand;
                gproc.sqlCommand.ExecuteNonQuery();
                gproc.datHotel.Clear();
                gproc.sqlHotelAdapter.Fill(gproc.datHotel);
                if (gproc.datHotel.Rows.Count > 0)
                {
                    txtAddons.Text = "₱" + gproc.datHotel.Rows[0]["price"].ToString() + ".00";
                    lblAddons.Text = gproc.datHotel.Rows[0]["description"].ToString();
                }
                else
                {
                    MessageBox.Show("Record not Found!", "Records", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                gproc.sqlHotelAdapter.Dispose();
                gproc.datHotel.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cmbPromo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gproc.sqlHotelAdapter = new MySqlDataAdapter();
                gproc.datHotel = new DataTable();

                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procSearchPromo";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_id", cmbPromo.SelectedIndex + 1);
                gproc.sqlHotelAdapter.SelectCommand = gproc.sqlCommand;
                gproc.sqlCommand.ExecuteNonQuery();
                gproc.datHotel.Clear();
                gproc.sqlHotelAdapter.Fill(gproc.datHotel);
                if (gproc.datHotel.Rows.Count > 0)
                {
                    txtPromo.Text = gproc.datHotel.Rows[0]["percentageDiscount"].ToString() + "%";
                    lblPromo.Text = gproc.datHotel.Rows[0]["description"].ToString();
                }
                else
                {
                    MessageBox.Show("Record not Found!", "Records", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                gproc.sqlHotelAdapter.Dispose();
                gproc.datHotel.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void displayPromos()
        {
            try
            {
                gproc.sqlHotelAdapter = new MySqlDataAdapter();
                gproc.datHotel = new DataTable();

                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procGetPromos";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlHotelAdapter.SelectCommand = gproc.sqlCommand;
                gproc.sqlCommand.ExecuteNonQuery();
                gproc.datHotel.Clear();
                gproc.sqlHotelAdapter.Fill(gproc.datHotel);
                if (gproc.datHotel.Rows.Count > 0)
                {
                    row = 0;
                    while (!(gproc.datHotel.Rows.Count - 1 < row))
                    {
                        cmbPromo.Items.Add(gproc.datHotel.Rows[row]["promoName"].ToString());
                        row++;
                    }
                }
                else
                {
                    MessageBox.Show("Record not Found!", "Records", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                gproc.sqlHotelAdapter.Dispose();
                gproc.datHotel.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
