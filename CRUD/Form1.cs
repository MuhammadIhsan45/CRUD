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


namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            GetEmpList();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=IHSAN\\MUHAMMADIHSAN;Initial Catalog=TestSP_DB;Persist Security Info=True;User ID=sa;Password=123");
        private void button1_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(textBox1.Text);
            string empname = textBox2.Text, city = comboBox1.Text, contact = textBox4.Text,sex = " ";
            double age = double.Parse(textBox3.Text);
            DateTime joindate = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true) { sex = "Male"; } else { sex = "Female"; }
            con.Open();
            SqlCommand c = new SqlCommand("exec IsertEmp_SP '" + empid + "','" + empname + "','" + city + "','" + age + "','" + sex + "','" + joindate + "','" + contact+ "'");
            c.Connection = con;
            c.ExecuteNonQuery();
            MessageBox.Show("NICE berhasil");
            GetEmpList();

        }
        void GetEmpList()
        {
            SqlCommand c = new SqlCommand("exec ListEmp_SP", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update
            int empid = int.Parse(textBox1.Text);
            string empname = textBox2.Text, city = comboBox1.Text, contact = textBox4.Text, sex = " ";
            double age = double.Parse(textBox3.Text);
            DateTime joindate = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true) { sex = "Male"; } else { sex = "Female"; }
            con.Open();
            SqlCommand c = new SqlCommand("exec UpdateEmp_SP '" + empid + "','" + empname + "','" + city + "','" + age + "','" + sex + "','" + joindate + "','" + contact + "'");
            c.Connection = con;
            c.ExecuteNonQuery();
            MessageBox.Show("updted berhasil");
            GetEmpList();
        }
    }
}
