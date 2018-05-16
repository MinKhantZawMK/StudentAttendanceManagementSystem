using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using AttendanceManagementSystem.Model;

namespace AttendanceManagementSystem
{
    public partial class LoginForm : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString);
        SqlCommand cmd;
        String str;
        SqlDataReader dr;
        SqlCommand cm;
        string s;

        public static List<string> ylist = new List<string>();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(btn_login.Text == "Login")
            {
                List<string> year = new List<string>();

                string one = "";
                string two = "";
                string three = "";
                string four = "";
                string five = "";
                string six = "";
                try
                {
                    conn.Open();
                    str = "Select * from Users where UserName = @name and Password = @password";
                    cmd = new SqlCommand(str, conn);
                    cmd.Parameters.AddWithValue("@name", txt_username.Text);
                    cmd.Parameters.AddWithValue("@password", txt_password.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            one = dr["YearOne"].ToString();
                            two = dr["YearTwo"].ToString();
                            three = dr["YearThree"].ToString();
                            four = dr["YearFour"].ToString();
                            five = dr["YearFive"].ToString();
                            six = dr["YearSix"].ToString();
                        }
                        //MessageBox.Show("Login Successful!");                  
                        year.Add(one);
                        year.Add(two);
                        year.Add(three);
                        year.Add(four);
                        year.Add(five);
                        year.Add(six);

                        for (int i = 0; i < year.Count; i++)
                        {
                            if (year[i] != "not assign")
                            {
                                ylist.Add(year[i]);
                            }
                        }

                        this.Hide();
                        MainForm fm = new MainForm();
                        fm.Show();
                    }
                    else
                    {
                        lbl_confirmpassword.Visible = true;
                        lbl_confirmpassword.Text = "Username and Password are not correct";
                        lbl_confirmpassword.ForeColor = Color.Red;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
            else
            {
               
                try
                {
                    conn.Open();
                    s = "select * from Users where UserName = @uname";
                    cm = new SqlCommand(s, conn);
                    cm.Parameters.AddWithValue("@uname", txt_username.Text);
                    dr = cm.ExecuteReader();

                    if(dr.HasRows)
                    {
                        dr.Close();
                        str = "update Users set Password = @pass where UserName = @name";
                        cmd = new SqlCommand(str, conn);
                        cmd.Parameters.AddWithValue("@pass", txt_password.Text);
                        cmd.Parameters.AddWithValue("@name", txt_username.Text);
                        cmd.ExecuteNonQuery();

                        cmd.Dispose();
                        LoginView();
                    }
                    else
                    {
                        lbl_login.Text = "UserName does not exit";
                        
                    }
                   
                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cm.Dispose();                                      
                    dr.Close();
                    conn.Close();

                }              

            }
          
        }
        private void link_reg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassView();
            clear();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

            LoginView();
        }

        private void clear()
        {
            txt_newpassword.Text = "";
            txt_password.Text = "";
            txt_username.Text = "";
        }

        public void LoginView()
        {
            lbl_login.Text = "LOGIN";
            lbl_password.Text = "Password";
            btn_login.Text = "Login";
            txt_newpassword.Visible = false;
            lbl_confirmpassword.Visible = false;
            link_forgetpassword.Visible = true;
        }

        public void ForgotPassView()
        {
            lbl_login.Text = "Change your Password";
            lbl_password.Text = "NewPassword";
            btn_login.Text = "Change";
            lbl_confirmpassword.Text = "ComfirmPassword";
            lbl_confirmpassword.ForeColor = Color.DarkSlateGray;
            txt_newpassword.Visible = true;
            lbl_confirmpassword.Visible = true;
            link_forgetpassword.Visible = false;
        }

        private void link_login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginView();
        }

        private void chk_show_Click(object sender, EventArgs e)
        {
            if (chk_show.Checked)
            {
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
            }
        }
    }
}
