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
    
    public partial class MyHome : Form
    {
        private static MyHome h = null;
        public MyHome()
        {
            InitializeComponent();
        }
        public static MyHome getInstance()
        {
            if (h == null)
            {
                h = new MyHome();
                h.Show();
                return h;
            }
            else
            {
                return h;
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void addStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 l = Form1.getInstance();
            l.Show();
            this.Hide();
        }

        private void studentRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StdRecords l = StdRecords.getInstance();
            l.Show();
            this.Hide();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void instructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Advisor l = Advisor.getInstance();
            l.Show();
            this.Hide();
        }

        private void evaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MyHome_Load(object sender, EventArgs e)
        {

        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void addProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project l = Project.getInstance();
            l.Show();
            this.Hide();

        }

        private void projectRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProRecords l = ProRecords.getInstance();
            l.Show();
            this.Hide();

        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void evaluationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Evaluation l = Evaluation.getInstance();
            l.Show();
            this.Hide();
        }

        private void groupEvaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupEvaluation l = GroupEvaluation.getInstance();
            l.Show();
            this.Hide();
        }

        private void evaluateIndividualsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void projectAdvisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectAdvisor l = ProjectAdvisor.getInstance();
            l.Show();
            this.Hide();

        }

        private void createGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddGroup l = AddGroup.getInstance();
            l.Show();
            this.Hide();

        }

        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group l = Group.getInstance();
            l.Show();
            this.Hide();

        }

        private void groupProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group_Project l = Group_Project.getInstance();
            l.Show();
            this.Hide();

        }
    }
}
