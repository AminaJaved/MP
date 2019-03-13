using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class Advisor : Form
    {
        private static Advisor l = null;
        public Advisor()
        {
            InitializeComponent();
            DbConnect.getInstance().ConnectionString = "Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;User ID=sa;Password=java";
        }
        public static Advisor getInstance()
        {
            if (l == null)
            {
                l = new Advisor();
                l.Show();
                return l;
            }
            else
            {
                return l;
            }
        }

        private void Advisor_Load(object sender, EventArgs e)
        {
            /*String cmd = "Select * from Advisor";
            var reader = DbConnect.getInstance().getData(cmd);

            List<Advisors> students = new List<Advisors>();
            while (reader.Read())
            {
                Advisor std = new Advisor();
                std.ID = (int)reader.GetValue(0);
                std.designation = reader.GetString(1);
                std.salary = reader.GetString(2);

            }*/
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                String designation = comboBox1.Text;
                String salary = textBox2.Text;
                String cmd = String.Format("INSERT INTO Advisor(Designation,Salary) values('{0}','{1} )", designation, salary);
                int rows = DbConnect.getInstance().exectuteQuery(cmd);
                MessageBox.Show(String.Format("{0} rows affected", rows));
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
    }
}
