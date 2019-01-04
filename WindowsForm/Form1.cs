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

namespace WindowsForm
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=192.168.1.44\MSSQLSERVER_2017;Initial Catalog=CDAC;Persist Security Info=True;User ID=cdacdev;Password=cdacdev123#");

        SqlDataAdapter adpt;

        SqlCommand cmd;

        Employee emp = new Employee();

        int ID = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            con.Open();            DataTable dt = new DataTable();            adpt = new SqlDataAdapter("select * from Emp", con);            adpt.Fill(dt);            dataGridView1.DataSource = dt;            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
                            //cmd = new SqlCommand("insert into Emp (EmpName,EmpDesignation) values(@ename,@edesignation)", con);                //con.Open();                               //cmd.Parameters.AddWithValue("@ename", txtempname.Text);                //cmd.Parameters.AddWithValue("@edesignation",txtempde.Text);
                
                //cmd.ExecuteNonQuery();                //con.Close();                //MessageBox.Show("Record Inserted Successfully");



            if (txtempname.Text != "" && txtempde.Text != "")            {                cmd = new SqlCommand("insert into Emp(EmpName,EmpDesignation) values(@ename,@edesign)", con);                con.Open();                cmd.Parameters.AddWithValue("@ename", emp.EmpName);                cmd.Parameters.AddWithValue("@edesign", emp.EmpDesign);                               cmd.ExecuteNonQuery();                con.Close();                MessageBox.Show("Record Inserted Successfully");            }




        }



        //Display Data in DataGridView
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter("select * from Emp", con);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //Clear Data
        private void ClearData()
        {
            txtempname.Text = "";
            txtempde.Text = "";
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cDACDataSet1.Emp' table. You can move, or remove it, as needed.
            this.empTableAdapter.Fill(this.cDACDataSet1.Emp);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            //{
            //    dataGridView1.Rows.RemoveAt(item.Index);
            //}


            
                
           


        }

        private void button2_Click(object sender, EventArgs e)

        {
            if (txtempname.Text != "" && txtempde.Text != "")
            {
                cmd = new SqlCommand("update Emp set EmpName=@ename,EmpDesignation=@edesign where EmpID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@ename", txtempname.Text);
                cmd.Parameters.AddWithValue("@edesign", txtempde.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }






        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtempname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtempname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

        }
    }
    }
 }

