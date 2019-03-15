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
            SqlConnection connect = new SqlConnection(ConnectionString);
            connect.Open();
            if (connect.State == ConnectionState.Open)
            {
                string s = "INSERT INTO ProjectAdvisor(AdvisorId,ProjectId, AdvisorRole,AssignmentDate)VALUES('" + comboBox1.Text + "','" + comboBox2.Text + "', (SELECT Id FROM Lookup WHERE Lookup.Value = '" + (comboBox3.Text) + "') ,'" + Convert.ToDateTime(dateTimePicker1.Value) + "');";
                SqlCommand cmd = new SqlCommand(s, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Successfully");

            }
        }
    }
}
