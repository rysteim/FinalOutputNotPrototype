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
        private double total, reduction;
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
            pnlReservations.Visible = false;
            //pnlTenants.Visible = false;
            //pnlPersonnel.Visible = false;
            displayAddons();
            displayOnDataGridAddons();
            totalPrice();
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
            dtgAddon.Visible = true;
            lblTotalPrice.Visible = true;
            pnlPromos.Visible = false;
            dtgPromo.Visible = false;
            lblTotalDiscount.Visible = false;
            showAddons();
            hidePromos();
            totalPrice();
            displayAddons();
            displayOnDataGridAddons();

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
            dtgPromo.Visible = true;
            lblTotalDiscount.Visible = true;
            pnlAddons.Visible = false;
            dtgAddon.Visible = false;
            lblTotalPrice.Visible = false;
            showPromos();
            hideAddons();
            getDiscount();
            displayPromos();
            displayOnDataGridPromos();

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
        }

        public void showAddons()
        {
            btnAddAddons.Visible = true;
            btnEditAddons.Visible = true;
            btnDeleteAddons.Visible = true;
        }

        public void hidePromos()
        {
            btnAddPromos.Visible = false;
            btnEditPromos.Visible = false;
            btnDeletePromos.Visible = false;
        }

        public void showPromos()
        {
            btnAddPromos.Visible = true;
            btnEditPromos.Visible = true;
            btnDeletePromos.Visible = true;
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

                cmbPromo.Items.Clear();
                if (gproc.datHotel.Rows.Count > 0)
                {
                    foreach (DataRow row in gproc.datHotel.Rows)
                    {
                        cmbPromo.Items.Add(row["promoName"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Record not Found!", "Records", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

        

        private void btnSubmitAddons_Click(object sender, EventArgs e)
        {

        }

        private void btnAddAddons_Click(object sender, EventArgs e)
        {
            try
            {
                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procAddAccountAddons";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_accountid", userID);
                gproc.sqlCommand.Parameters.AddWithValue("@p_addonsid", cmbAddons.SelectedIndex + 1);
                gproc.sqlCommand.Parameters.AddWithValue("@p_addons_description", lblAddons.Text);
                gproc.sqlCommand.ExecuteNonQuery();

                totalPrice();
                displayOnDataGridAddons();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnDeleteAddons_Click(object sender, EventArgs e)
        {
            try
            {
                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procDeleteAccountAddons";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_id", Convert.ToInt32(dtgAddon.CurrentRow.Cells[0].Value));
                gproc.sqlCommand.ExecuteNonQuery();

                totalPrice();
                displayOnDataGridAddons();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnAddPromos_Click(object sender, EventArgs e)
        {
            try
            {
                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procAddAccountPromo";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_accountid", userID);
                gproc.sqlCommand.Parameters.AddWithValue("@p_promoid", cmbPromo.SelectedIndex + 1);
                gproc.sqlCommand.Parameters.AddWithValue("@p_promo_description", lblPromo.Text);
                gproc.sqlCommand.ExecuteNonQuery();

                getDiscount();
                displayOnDataGridPromos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDeletePromos_Click(object sender, EventArgs e)
        {
            try
            {
                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procDeleteAccountPromo";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_id", Convert.ToInt32(dtgPromo.CurrentRow.Cells[0].Value));
                gproc.sqlCommand.ExecuteNonQuery();

                getDiscount();
                displayOnDataGridPromos();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSubmitAP_Click(object sender, EventArgs e)
        {
            try
            {
                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procAddAddons_Promo";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_accountid", userID);
                gproc.sqlCommand.Parameters.AddWithValue("@p_addonPrice", total);
                gproc.sqlCommand.Parameters.AddWithValue("@p_promoDiscount", reduction);
                gproc.sqlCommand.ExecuteNonQuery();

                MessageBox.Show($"Submitted!", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void displayOnDataGridAddons()
        {
            try
            {
                gproc.sqlHotelAdapter = new MySqlDataAdapter();
                gproc.datHotel = new DataTable();

                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procGetAccountAddons";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_id", userID);

                gproc.sqlHotelAdapter.SelectCommand = gproc.sqlCommand;
                gproc.sqlHotelAdapter.Fill(gproc.datHotel);

                if (gproc.datHotel.Rows.Count > 0)
                {
                    dtgAddon.Rows.Clear();

                    foreach (DataRow row in gproc.datHotel.Rows)
                    {
                        dtgAddon.Rows.Add(
                            row["ID"].ToString(),
                            row["ADDON NAME"].ToString(),
                            row["ADDON PRICE"].ToString(),
                            row["DESCRIPTION"].ToString()
                        );
                    }
                }
                else
                {
                    totalPrice();
                    dtgAddon.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                gproc.sqlHotelAdapter?.Dispose();
                gproc.datHotel?.Dispose();
            }
        }

        public void displayOnDataGridPromos()
        {
            try
            {
                gproc.sqlHotelAdapter = new MySqlDataAdapter();
                gproc.datHotel = new DataTable();

                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procGetAccountPromo";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_id", userID);

                gproc.sqlHotelAdapter.SelectCommand = gproc.sqlCommand;
                gproc.sqlHotelAdapter.Fill(gproc.datHotel);

                if (gproc.datHotel.Rows.Count > 0)
                {
                    dtgPromo.Rows.Clear();

                    foreach (DataRow row in gproc.datHotel.Rows)
                    {
                        dtgPromo.Rows.Add(
                            row["ID"].ToString(),
                            row["PROMO NAME"].ToString(),
                            row["PROMO DISCOUNT"].ToString(),
                            row["DESCRIPTION"].ToString()
                        );
                    }
                }
                else
                {
                    dtgPromo.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                gproc.sqlHotelAdapter?.Dispose();
                gproc.datHotel?.Dispose();
            }
        }

        private void totalPrice()
        {
            try
            {
                gproc.sqlHotelAdapter = new MySqlDataAdapter();
                gproc.datHotel = new DataTable();

                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procTotalAddons";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_id", userID);

                gproc.sqlHotelAdapter.SelectCommand = gproc.sqlCommand;
                gproc.sqlHotelAdapter.Fill(gproc.datHotel);

                if (gproc.datHotel.Rows.Count > 0)
                {
                    total = Convert.ToDouble(gproc.datHotel.Rows[0]["TOTAL PRICE"].ToString());
                    lblTotalPrice.Text = $"Total Price: ₱{total:F2}";
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                gproc.sqlHotelAdapter?.Dispose();
                gproc.datHotel?.Dispose();
            }
        }

        private void lblFirstname_Click(object sender, EventArgs e)
        {
            new FrmDialogProfile(userID).ShowDialog();
            getAccount();
        }

        private void getDiscount()
        {
            try
            {
                gproc.sqlHotelAdapter = new MySqlDataAdapter();
                gproc.datHotel = new DataTable();

                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procTotalDiscount";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_id", userID);

                gproc.sqlHotelAdapter.SelectCommand = gproc.sqlCommand;
                gproc.sqlHotelAdapter.Fill(gproc.datHotel);

                if (gproc.datHotel.Rows.Count > 0)
                {
                    reduction = Convert.ToDouble(gproc.datHotel.Rows[0]["TOTAL DISCOUNT"].ToString());
                    lblTotalDiscount.Text = $"Total Discount: {reduction}%";
                }
                else
                {
                    MessageBox.Show("Record not Found!", "Records", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                gproc.sqlHotelAdapter?.Dispose();
                gproc.datHotel?.Dispose();
            }
        }

        private void btnMakeReservation_Click(object sender, EventArgs e)
        {
            try
            {
                gproc.sqlHotelAdapter = new MySqlDataAdapter();
                gproc.datHotel = new DataTable();

                gproc.sqlCommand.Parameters.Clear();
                gproc.sqlCommand.CommandText = "procTotalDiscount";
                gproc.sqlCommand.CommandType = CommandType.StoredProcedure;
                gproc.sqlCommand.Parameters.AddWithValue("@p_id", userID);

                gproc.sqlHotelAdapter.SelectCommand = gproc.sqlCommand;
                gproc.sqlHotelAdapter.Fill(gproc.datHotel);

                if (gproc.datHotel.Rows.Count > 0)
                {
                }
                else
                {
                    MessageBox.Show("Record not Found!", "Records", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                gproc.sqlHotelAdapter?.Dispose();
                gproc.datHotel?.Dispose();
            }
        }

    }
}
