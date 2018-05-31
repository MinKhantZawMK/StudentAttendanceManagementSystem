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

            cmb_stulist.DataSource = LoginForm.ylist;
            cmb_Room.DataSource = GetRoom();
           // this.studentTableAdapter.Fill(this.studentAttendanceSystemDBDataSet.Student);

            dataGridView1.Visible = true;
            panel3.Visible = false;
            panel2.Visible = true;           
            radio_absent.Enabled = false;
            radio_present.Enabled = false;
            btn_attsave.Enabled = false;


            //add column in dataGridView
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();

            cmb.HeaderText = "Attendance";
            cmb.Name = "attendance";
            cmb.MaxDropDownItems = 4;
            cmb.Items.Add("Present");
            cmb.Items.Add("Absent");
            dataGridView1.Columns.Add(cmb);

        }
        private void btn_search_Click(object sender, EventArgs e)
        {
          
            radio_absent.Enabled = true;
            radio_present.Enabled = true;
            btn_attsave.Enabled = true;

            try
            {
                conn.Open();
                str = "select * from Student where StuYear = @comvalue and ClassRoom = @room";
                cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@comvalue", cmb_stulist.Text);
                cmd.Parameters.AddWithValue("@room", cmb_Room.Text);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dataGridView1.Visible = true;
                    panel2.Visible = true;
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
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

            CustomDialogBox.CustomDialogBox cusdialogbox = new CustomDialogBox.CustomDialogBox();
            cusdialogbox.ShowDialog();
            if(cusdialogbox.DialogResult == DialogResult.Yes)
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
                        cmdmajor.Parameters.AddWithValue("@rno", dataGridView1.Rows[i].Cells[1].Value);
                        cmdmajor.Parameters.AddWithValue("@stname", dataGridView1.Rows[i].Cells[2].Value);
                        cmdmajor.Parameters.AddWithValue("@year", cmb_stulist.Text);
                        cmdmajor.Parameters.AddWithValue("@date", DateTime.Parse(dateTimePicker1.Value.ToString("d")));
                        cmdmajor.Parameters.AddWithValue("@attendance", dataGridView1.Rows[i].Cells[4].Value);
                        cmdmajor.Parameters.AddWithValue("@course", cmb_sub.Text);
                        cmdmajor.Parameters.AddWithValue("@class", dataGridView1.Rows[i].Cells[3].Value);
                        conn.Open();
                        cmdmajor.ExecuteNonQuery();
                        conn.Close();
                        attendancelist.Add(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    }
                  
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


            //DialogResult dialogResult = MessageBox.Show("Are you sure to save", "Save To Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question, ColorDial);
            //if (dialogResult == DialogResult.Yes)
            //{
               
            //}
            //else if (dialogResult == DialogResult.No)
            //{
                
            //}
           

        }
        private void radio_present_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[4].Value = "Present";

            }
        }
        private void radio_absent_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[4].Value = "Absent";

            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm lfm = new LoginForm();
            lfm.Show();
            this.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Visible = false;
          
        }
        private void btn_edit_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //StuReg_panel.Visible = true;
            //panel3.Visible = false;
            //string stuid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString();
            //string rno = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Roll No."].Value.ToString();
            //string name = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Name"].Value.ToString();
            //string classroom = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ClassRoom"].Value.ToString();
            //string year = cmb_stulist.Text;
            //string attendance =
            //string course = cmb_sub.Text;           

        }
        private List<string> GetRoom()
        {
            List<string> room = new List<string>();
            try
            {
                conn.Open();               
                str = "select distinct ClassRoom from Student";
                cmd = new SqlCommand(str, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    room.Add(dr["ClassRoom"].ToString());
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return room;
        }

        private void link_StuReg_Click(object sender, EventArgs e)
        {
            StudentRegistration stdreg = new StudentRegistration();
            stdreg.ShowDialog();
           
        }
    }
}
