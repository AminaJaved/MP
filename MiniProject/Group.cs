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
    public partial class Group : Form
    {
        private static Group l = null;
        public Group()
        {
            InitializeComponent();
            DbConnect.getInstance().ConnectionString = "Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;User ID=sa;Password=java";
        }
        public string ConnectionString = "Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;User ID=sa;Password=java";
        public static Group getInstance()
        {
            if (l == null)
            {
                l = new Group();
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
            try

            {

                String s = "Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;User ID=sa;Password=java";
                String q = "INSERT INTO [Group](Created_On)VALUES(('" + Convert.ToDateTime(dateTimePicker1.Text) + "'));";
                SqlConnection connect = new SqlConnection(s);
                SqlCommand command = new SqlCommand(q, connect);
                connect.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Data is inserted successfully");


                connect.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyHome h = MyHome.getInstance();
            h.Show();
            this.Hide();
        }

        private void Group_Load(object sender, EventArgs e)
        {

        }
    }
}
