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
    public partial class Report1 : Form
    {
        private static Report1 l = null;
        public Report1()
        {
            InitializeComponent();
            DbConnect.getInstance().ConnectionString = "Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;Persist Security Info=True;User ID=sa;Password=java";
        }
        public static Report1 getInstance()
        {
            if (l == null)
            {
                l = new Report1();
                l.Show();
                return l;
            }
            else
            {
                return l;
            }
        }

        private void Report1_Load(object sender, EventArgs e)
        {
            String cmd = "SELECT GroupStudent.GroupId,Student.RegistrationNo,GroupProject.ProjectId,Project.Title,Project.Description,ProjectAdvisor.AdvisorId,ProjectAdvisor.AdvisorRole from GroupStudent INNER JOIN Student on GroupStudent.StudentId = Student.Id inner join GroupProject on GroupStudent.GroupId=GroupProject.GroupId inner join Project on GroupProject.ProjectId=Project.Id inner join ProjectAdvisor on GroupProject.ProjectId=ProjectAdvisor.ProjectId";
            var reader = DbConnect.getInstance().getData(cmd);

            List<Report> project = new List<Report>();
            while (reader.Read())
            {
                Report pro = new Report();
                pro.GroupID = (int)reader.GetValue(0);
                pro.RegistrationNo = reader.GetString(1);
                pro.ProjectID = (int)reader.GetValue(2);
                pro.title = reader.GetString(3);
                pro.description = reader.GetString(4);
                pro.AdvisorId = (int)reader.GetValue(5);
                pro.AdvisorRole = (int)reader.GetValue(6);
                project.Add(pro);
            }
            dataGridView1.DataSource = project;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyHome l = MyHome.getInstance();
            l.Show();
            this.Hide();
        }
    }
}
