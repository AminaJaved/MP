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

    public partial class AddGroup : Form
    {
        private static AddGroup l = null;
        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;Persist Security Info=True;User ID=sa;Password=java");
        public AddGroup()
        {
            InitializeComponent();
            DbConnect.getInstance().ConnectionString = "Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;User ID=sa;Password=java";
        }
        public static AddGroup getInstance()
        {
            if (l == null)
            {
                l = new AddGroup();
                l.Show();
                return l;
            }
            else
            {
                return l;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;Persist Security Info=True;User ID=sa;Password=java");
            connect.Open();
            string sl = "Select Id from Lookup where Value = '" + comboBox1.Text + "'";
            SqlCommand scd = new SqlCommand(sl, connect);
            int i = (int)scd.ExecuteScalar();
            string s = "Insert into GroupStudent(GroupId,StudentId,Status,AssignmentDate) values ('" + comboBox3.Text + "', '" + comboBox2.Text + "','" + i + "','" + dateTimePicker1.Value+ "')";
            SqlCommand sc = new SqlCommand(s, connect);
            sc.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Hurray its Added sucessfully");
        }

        private void AddGroup_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;Persist Security Info=True;User ID=sa;Password=java");
            connect.Open();
            string s = "Select Id from Student";
            SqlCommand sc = new SqlCommand(s, connect);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                string id = sdr[0].ToString();
                comboBox2.Items.Add(id);
            }
            sdr.Close();

            string s1 = "Select Id from [Group]";
            SqlCommand sc1 = new SqlCommand(s1, connect);
            SqlDataReader sdr1 = sc1.ExecuteReader();
            while (sdr1.Read())
            {
                string id = sdr1[0].ToString();
                comboBox3.Items.Add(id);
            }
            sdr1.Close();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyHome h = MyHome.getInstance();
            h.Show();
            this.Hide();
        }
    }
    
}
