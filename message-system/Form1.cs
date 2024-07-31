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

namespace message_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LRMEISB\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from TBLPEOPLE where NUMBER=@P1 AND PASSWORD=@P2", con);
            cmd.Parameters.AddWithValue("@P1", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@P2", textBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form2 frm = new Form2();
                frm.number = maskedTextBox1.Text;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Informatin!");
            }
        }
    }
}
