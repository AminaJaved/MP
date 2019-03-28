using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class ProjectAdvisor : Form
    {
        private static ProjectAdvisor l = null;
        public ProjectAdvisor()
        {
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;User ID=sa;Password=java";
        public static ProjectAdvisor getInstance()
        {
            if (l == null)
            {
                l = new ProjectAdvisor();
                l.Show();
                return l;
            }
            else
            {
                return l;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyHome h = MyHome.getInstance();
            h.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;Persist Security Info=True;User ID=sa;Password=java");
            connect.Open();
            string sl = "Select Id from Lookup where Value = '" + comboBox3.Text + "'";
            SqlCommand scd = new SqlCommand(sl, connect);
            int i = (int)scd.ExecuteScalar();
            string s = "Insert into ProjectAdvisor(AdvisorId,ProjectId, AdvisorRole,AssignmentDate) values ('" + comboBox1.Text + "', '" + comboBox2.Text + "','" + i + "','" + dateTimePicker1.Value + "')";
            SqlCommand sc = new SqlCommand(s, connect);
            sc.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Hurray its Added sucessfully");
        }

        private void ProjectAdvisor_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;Persist Security Info=True;User ID=sa;Password=java");
            connect.Open();
            string s = "Select Id from Advisor";
            SqlCommand sc = new SqlCommand(s, connect);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                string id = sdr[0].ToString();
                comboBox1.Items.Add(id);
            }
            sdr.Close();

            string s1 = "Select Id from Project";
            SqlCommand sc1 = new SqlCommand(s1, connect);
            SqlDataReader sdr1 = sc1.ExecuteReader();
            while (sdr1.Read())
            {
                string id = sdr1[0].ToString();
                comboBox2.Items.Add(id);
            }
            sdr1.Close();
        }
    }
}
