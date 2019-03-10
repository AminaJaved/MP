﻿using System;
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
    public partial class Form1 : Form
    {
        private static Form1 l = null;
        public Form1()
        {
            InitializeComponent();
            DbConnect.getInstance().ConnectionString = "Data Source=DESKTOP-TOIHAAB;Initial Catalog=ProjectA;User ID=sa;Password=java";
        }
        public static Form1 getInstance()
        {
            if (l == null)
            {
                l = new Form1();
                l.Show();
                return l;
            }
            else
            {
                return l;
            }
        }
        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MyHome l = MyHome.getInstance();
            l.Show();
            this.Hide();
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
                String firstname = textBox1.Text;
                String lastname = textBox2.Text;
                String contact = textBox3.Text;
                String email = textBox4.Text;
                DateTime db = dateTimePicker1.Value;
                int x = 0;
                int gender;
                if (radioButton1.Checked == true)
                {
                    gender = 1;
                }
                else
                {
                    gender = x;
                }


                String cmd = String.Format("INSERT INTO Person(FirstName,LastName,Contact,Email,DateOfBirth,Gender) values('{0}','{1}','{2}','{3}','{4}','{5}' )", firstname, lastname, contact, email, db, gender);
                int rows = DbConnect.getInstance().exectuteQuery(cmd);
                MessageBox.Show(String.Format("{0} rows affected", rows));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DbConnect.getInstance().closeConnection();
        }
    }
}
