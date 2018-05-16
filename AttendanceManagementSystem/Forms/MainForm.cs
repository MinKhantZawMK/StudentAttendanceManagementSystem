using AttendanceManagementSystem.Forms;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString);
        SqlCommand cmd;
        String str;
        private BindingSource bindingSource1 = new BindingSource();
        SqlDataReader dr;
        SqlCommand cmdmajor;
        SqlDataReader sqldr;
        private void btn_addnewstu_Click(object sender, EventArgs e)
        {

            //AddStudent astu = new AddStudent();
            //astu.Show();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //List<string> iList = new List<string>();
            //iList.Add("1BE");
            //iList.Add("2BE");
            //iList.Add("3BE");
            //iList.Add("4BE");
            //iList.Add("5BE");
            //iList.Add("6BE");
            cmb_stulist.DataSource = LoginForm.ylist;
            // TODO: This line of code loads data into the 'studentAttendanceSystemDBDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.studentAttendanceSystemDBDataSet.Student);

            dataGridView1.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;
            //GetData("select RNO, Name,  ClassRoom, StuYear from Student");

            //add column in dataGridView
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            //DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            //   button.Text = "View Details";
            cmb.HeaderText = "Attendance";
            cmb.Name = "attendance";
            cmb.MaxDropDownItems = 4;
            cmb.Items.Add("Present");
            cmb.Items.Add("Absent");
            dataGridView1.Columns.Add(cmb);

        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                str = "select * from Student where StuYear = @comvalue";
                cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@comvalue", cmb_stulist.Text);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dataGridView1.Visible = true;
                    panel2.Visible = true;
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;                 
                    // dataGridView1.Columns.Add(button);
                    dataGridView1.Columns[3].HeaderCell.Style.BackColor = Color.LimeGreen;
                    dataGridView1.EnableHeadersVisualStyles = false;
                    this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvUserDetails_RowPostPaint);

                }
                else
                {
                    MessageBox.Show("No student List...");
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
                dr.Close();
            }

        }
        private void dgvUserDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        private void cmb_stulist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string str1 = "select distinct s.Subjects from Student stu, Subjects s where stu.StuYear = s.SubMajor and s.SubMajor =@major ";
                cmdmajor = new SqlCommand(str1, conn);
                cmdmajor.Parameters.AddWithValue("@major", cmb_stulist.Text);
                sqldr = cmdmajor.ExecuteReader();

                List<string> list = new List<string>();

                while (sqldr.Read())
                {
                    list.Add((string)sqldr.GetValue(0));
                }
                cmb_sub.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqldr.Close();
                cmdmajor.Dispose();
                conn.Close();
            }
        }
        private void btn_attsave_Click(object sender, EventArgs e)
        {
            List<string> attendancelist = new List<string>();
            int present = 0;
            int absent = 0;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string strdgv = "Insert into Attendance (RollNo, StudentName, Year, Datetime, Attendance, Course, ClassRoom)" + "Values (@rno, @stname, @year, @date, @attendance, @course, @class)";
                    SqlCommand cmdmajor = new SqlCommand(strdgv, conn);
                    cmdmajor.Parameters.AddWithValue("@rno", dataGridView1.Rows[i].Cells[0].Value);
                    cmdmajor.Parameters.AddWithValue("@stname", dataGridView1.Rows[i].Cells[1].Value);
                    cmdmajor.Parameters.AddWithValue("@year", cmb_stulist.Text);
                    cmdmajor.Parameters.AddWithValue("@date", DateTime.Parse(dateTimePicker1.Value.ToString("d")));
                    cmdmajor.Parameters.AddWithValue("@attendance", dataGridView1.Rows[i].Cells[3].Value);
                    cmdmajor.Parameters.AddWithValue("@course", cmb_sub.Text);
                    cmdmajor.Parameters.AddWithValue("@class", dataGridView1.Rows[i].Cells[2].Value);
                    conn.Open();
                    cmdmajor.ExecuteNonQuery();
                    conn.Close();
                    attendancelist.Add(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                MessageBox.Show("Added successfully!");
                for (int i = 0; i < attendancelist.Count; i++)
                {
                    if (attendancelist[i] == "Present")
                    {
                        present += 1;
                    }
                    else
                    {
                        absent += 1;
                    }

                }

                lbl_present.Text = present.ToString();
                lbl_absent.Text = absent.ToString();
                lbl_total.Text = attendancelist.Count().ToString();
                panel3.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void radio_present_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[3].Value = "Present";

            }
        }
        private void radio_absent_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[3].Value = "Absent";

            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm lfm = new LoginForm();
            lfm.Show();
            this.Close();
        }
    }

}
