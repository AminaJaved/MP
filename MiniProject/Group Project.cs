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

namespace MiniProject
{
    public partial class Group_Project : Form
    {
        private static Group_Project l = null;
        public Group_Project()
        {
            InitializeComponent();
            DbConnect.getInstance().ConnectionString = "Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;User ID=sa;Password=java";
        }
        public static Group_Project getInstance()
        {
            if (l == null)
            {
                l = new Group_Project();
                l.Show();
                return l;
            }
            else
            {
                return l;
            }
        }

        private void Group_Project_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;Persist Security Info=True;User ID=sa;Password=java");
            connect.Open();
            string s = "Select Id from Project";
            SqlCommand sc = new SqlCommand(s, connect);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                string id = sdr[0].ToString();
                comboBox1.Items.Add(id);
            }
            sdr.Close();

            string s1 = "Select Id from [Group]";
            SqlCommand sc1 = new SqlCommand(s1, connect);
            SqlDataReader sdr1 = sc1.ExecuteReader();
            while (sdr1.Read())
            {
                string id = sdr1[0].ToString();
                comboBox2.Items.Add(id);
            }
            sdr1.Close();

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
            string s = "Insert into GroupProject(ProjectId,GroupId,AssignmentDate) values ('" + comboBox1.Text + "', '" + comboBox2.Text + "','" + dateTimePicker1.Value + "')";
            SqlCommand sc = new SqlCommand(s, connect);
            sc.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Hurray its Added sucessfully");
        }
    }
}
