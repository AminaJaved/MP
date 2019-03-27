using System;
//using System.Collections.Generic;D:\VS2015\Projects\MiniProject\MiniProject\App.config
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
    public partial class GroupEvaluation : Form
    {
        private static GroupEvaluation l = null;
        public GroupEvaluation()
        {
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;User ID=sa;Password=java";
        public static GroupEvaluation getInstance()
        {
            if (l == null)
            {
                l = new GroupEvaluation();
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
            try

            {

                String s = "Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;User ID=sa;Password=java";
                String q = "INSERT INTO GroupEvaluation(GroupId,EvaluationId,ObtainedMarks,EvaluationDate)VALUES((select Id from [Group] where [Group].Id = '" + comboBox1.Text + "'),(select MAX(Id) from Evaluation),('" + Convert.ToInt32(textBox1.Text) + "'),('" + Convert.ToDateTime(dateTimePicker1.Text) + "'));";
                SqlConnection connection = new SqlConnection(s);
                SqlCommand cmd = new SqlCommand(q, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted successfully");

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupEvaluation_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;Persist Security Info=True;User ID=sa;Password=java");
            connect.Open();
            string s = "Select Id from [Group]";
            SqlCommand sc = new SqlCommand(s, connect);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                string id = sdr[0].ToString();
                comboBox1.Items.Add(id);
            }
            sdr.Close();

            string s1 = "Select Id from Evaluation";
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
