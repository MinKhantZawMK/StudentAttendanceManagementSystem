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
    public partial class AddStudent : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString);
        SqlCommand cmd;
        String str;
        
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btn_addstu_Click(object sender, EventArgs e)
        {
            conn.Open();
            string str = "Insert into Student (RNO, Name, ClassRoom, Phone, Email, StuYear)" + "Values (@rno, @name, @classroom, @phone, @email, @StuYear)";
            cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@rno", txt_stuRno.Text);
            cmd.Parameters.AddWithValue("@name", txt_stuname.Text);
            cmd.Parameters.AddWithValue("@classroom", txt_stuCR.Text);
            cmd.Parameters.AddWithValue("@phone", txt_phone.Text);
            cmd.Parameters.AddWithValue("@email", txt_email.Text);
            cmd.Parameters.AddWithValue("@StuYear", cmb_Year.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Successful");
            clear();
            cmd.Dispose();
            conn.Close();
        }
        public void clear()
        {
            txt_email.Text = "";
            txt_phone.Text = "";
            txt_stuCR.Text = "";
            txt_stuname.Text = "";
            txt_stuRno.Text = "";
            cmb_Year.Text = "Choose Year";
        }

    }
}
