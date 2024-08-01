using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace message_system
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string number;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LRMEISB\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");

        void inbox()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tblmessages WHERE RECEIVER=" + number, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
        void sent()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Tblmessages WHERE SENDER=" + number, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView3.DataSource = dt2;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            lblNumber.Text = number;
            inbox();
            sent();

            con.Open();
            SqlCommand cmd = new SqlCommand("Select Name,Surname from TBLPEOPLE where number=" + number, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblNameSurname.Text = dr[0] + " " + dr[1];
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into TBLMESSAGES(SENDER, RECEIVER, TITLE,CONTENTT) values(@p1,@p2,@p3,@p4)", con);
            cmd.Parameters.AddWithValue("@p1", number);
            cmd.Parameters.AddWithValue("@p2", mskdReceiver.Text);
            cmd.Parameters.AddWithValue("@p3", txtTitle.Text);
            cmd.Parameters.AddWithValue("@p4", rchTxtCntnt.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sent");
            inbox();
        }
    }
}
