using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceManagementSystem.Forms
{
    public partial class StudentRegistration : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString);
        SqlCommand cmd;
        String str;
        SqlDataReader dr;
        
        public StudentRegistration()
        {
            InitializeComponent();
        }

        private void StudentRegistration_Load(object sender, EventArgs e)
        {
            List<string> yearlist = new List<string>();
            List<string> classlist = new List<string>();

            try
            {
                conn.Open();
                str = "select Years from Year";
                cmd = new SqlCommand(str, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    yearlist.Add(dr["Years"].ToString());
                }
                dr.Close();

                string s = "select RoomNo from Room";
                SqlCommand cm = new SqlCommand(s, conn);
                SqlDataReader d = cm.ExecuteReader();
                while (d.Read())
                {
                    classlist.Add(d["RoomNO"].ToString());
                }
                d.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                cmd.Dispose();
                conn.Close();
            }

            cmb_year.DataSource = yearlist;
            cmb_class.DataSource = classlist;
           
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm mf = new MainForm();
            mf.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btn_addstu_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                str = "Insert into Student (RNO,Name,ClassRoom,Phone,Email,StuYear) values (@rno, @name, @class, @phone, @email, @stuyear)";
                cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@rno", txt_rollno.Text);
                cmd.Parameters.AddWithValue("@name", txt_name.Text);
                cmd.Parameters.AddWithValue("@class", cmb_class.Text);
                cmd.Parameters.AddWithValue("@phone", txt_ph.Text);
                cmd.Parameters.AddWithValue("@email", txt_email.Text);
                cmd.Parameters.AddWithValue("@stuyear", cmb_year.Text);
                cmd.ExecuteNonQuery();
                clear();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        private void clear()
        {
            txt_email.Clear();
            txt_name.Clear();
            txt_ph.Clear();
            txt_rollno.Clear();
        }
    }
}
