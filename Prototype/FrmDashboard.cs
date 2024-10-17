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
        private int userID;
        public FrmDashboard(int userID)
        {
            InitializeComponent();
            gproc = new GlobalProcedures();
            this.userID = userID;
        }
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            gproc.fncDatabaseConnection();
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

        private void btnRooms_Click(object sender, EventArgs e)
        {
            pnlDashboard.Visible = false;
            pnlRooms.Visible = true;

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

            pnlDashboard.Visible = false;
            pnlRooms.Visible = false;
            pnlReservations.Visible = true;

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
    }
}
