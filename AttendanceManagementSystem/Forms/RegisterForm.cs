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

namespace AttendanceManagementSystem
{
    public partial class RegisterForm : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString);
        SqlCommand cmd1;
    
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            txt_regpassword.UseSystemPasswordChar = true;
            txt_conpass.UseSystemPasswordChar = true;
        }

        private void btn_register(object sender, EventArgs e)
        {
            #region checkbox value
            string y1 = "not assign";
            string y2 = "not assign";
            string y3 = "not assign";
            string y4 = "not assign";
            string y5 = "not assign";
            string y6 = "not assign";

            if (chb_1be.Checked == true)
            {
                y1 = chb_1be.Text;
            }
            if (chb_2be.Checked == true)
            {
                y2 = chb_2be.Text;
            }
            if (chb_3be.Checked == true)
            {
                y3 = chb_3be.Text;
            }
            if (chb_4be.Checked == true)
            {
                y4 = chb_4be.Text;
            }
            if (chb_5be.Checked == true)
            {
                y5 = chb_5be.Text;
            }
            if (chb_6be.Checked == true)
            {
                y6 = chb_6be.Text;
            }

            #endregion
            try
            {
                conn.Open();
                string str = "Insert into Users ( UserName, Password, Phone, YearOne, YearTwo, YearThree, YearFour, YearFive, YearSix)" + "Values (@username, @password, @phone, @y1, @y2, @y3, @y4, @y5, @y6)";
                cmd1 = new SqlCommand(str, conn);
                cmd1.Parameters.AddWithValue("@username", txt_reguser.Text);
                cmd1.Parameters.AddWithValue("@password", txt_regpassword.Text);
                cmd1.Parameters.AddWithValue("@phone", txt_phone.Text);
                cmd1.Parameters.AddWithValue("@y1", y1);
                cmd1.Parameters.AddWithValue("@y2", y2);
                cmd1.Parameters.AddWithValue("@y3", y3);
                cmd1.Parameters.AddWithValue("@y4", y4);
                cmd1.Parameters.AddWithValue("@y5", y5);
                cmd1.Parameters.AddWithValue("@y6", y6);
                cmd1.ExecuteNonQuery();

                //string str2 = "Insert into Year  (UName, Year1, Year2, Year3, Year4, Year5, Year6)" + "Values (@user, @y1, @y2, @y3, @y4, @y5, @y6)";
                //cmd2 = new SqlCommand(str2, conn);
                //cmd2.Parameters.AddWithValue("@user", txt_reguser.Text);
                //cmd2.Parameters.AddWithValue("@y1", y1);
                //cmd2.Parameters.AddWithValue("@y2", y2);
                //cmd2.Parameters.AddWithValue("@y3", y3);
                //cmd2.Parameters.AddWithValue("@y4", y4);
                //cmd2.Parameters.AddWithValue("@y5", y5);
                //cmd2.Parameters.AddWithValue("@y6", y6);
                //cmd2.ExecuteNonQuery();

                MessageBox.Show("Successfully");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd1.Dispose();             
                conn.Close();
            }

        }

        public void Clear()
        {
            txt_reguser.Text = "";
            txt_conpass.Text = "";
            txt_phone.Text = "";
            txt_regpassword.Text = "";
            chb_1be.Checked = false;
            chb_2be.Checked = false;
            chb_3be.Checked = false;
            chb_4be.Checked = false;
            chb_5be.Checked = false;
            chb_6be.Checked = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm logf = new LoginForm();
            logf.Show();
            this.Hide();
        }

      
        private void chk_password_Click(object sender, EventArgs e)
        {
            if (chk_password.Checked)
            {
                txt_regpassword.UseSystemPasswordChar = false;
            }
            else if (!chk_password.Checked)
            {
                txt_regpassword.UseSystemPasswordChar = true;
            }
        }

        private void chk_compassword_Click(object sender, EventArgs e)
        {
            if (chk_comfirmpassword.Checked)
            {
                txt_conpass.UseSystemPasswordChar = false;
            }
            else
            {
                txt_conpass.UseSystemPasswordChar = true;
            }
        }
    }
}
