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
    public partial class FrmStaffDashboard : Form
    {
        GlobalProcedures gproc;
        int userID;
        public FrmStaffDashboard(int userID)
        {
            InitializeComponent();
            gproc = new GlobalProcedures();
            this.userID = userID;
        }

        private void FrmStaffDashboard_Load(object sender, EventArgs e)
        {
            gproc.fncDatabaseConnection();
        }

        public void displayRooms()
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
        private void btnAddRoom_Click(object sender, EventArgs e)
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

    }
}
