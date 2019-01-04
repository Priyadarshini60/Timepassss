using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=192.168.1.44\MSSQLSERVER_2017;Initial Catalog=CDAC;Persist Security Info=True;User ID=cdacdev;Password=cdacdev123#");
        SqlDataAdapter adapt;
        SqlCommand cmd;
        Employee employee ;
        int ID = 0;
      
        public Form1()
        {
            InitializeComponent();
            Display();
           
        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textDesig.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
          
        }
        public void Display()
        {
             //con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Emp", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
     

    
        private void ClearData()
        {
            textName.Text = "";
            textDesig.Text = "";
            ID = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            SqlCommand command;
            employee = new Employee(textName.Text.ToString(), textDesig.Text.ToString());
            string update = "update Emp set EmpName=@ename,EmpDesignation=@edesign where EmpID=@empId";
            con.Open();    //open connection with database
            command = new SqlCommand(update, con);
            command.Parameters.AddWithValue("@empId", ID);
            command.Parameters.AddWithValue("@ename", employee.Name);
            command.Parameters.AddWithValue("@edesign", employee.designation);

            command.CommandType = CommandType.Text;
            int i = command.ExecuteNonQuery();
            Display();
            ClearData();
            MessageBox.Show(i + " Row(s) updated ");
            con.Close();
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (ID != 0)
            {
                cmd = new SqlCommand("delete Emp where EmpId=@id", con);   //delete query
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                Display();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            employee = new Employee(textName.Text.ToString(), textDesig.Text.ToString());
            if (textName.Text != "" && textDesig.Text != "")
            {
               
                cmd = new SqlCommand("insert into Emp(EmpName,EmpDesignation) values(@ename,@edesign)", con);
             
                cmd.Parameters.AddWithValue("@ename", employee.Name);
                cmd.Parameters.AddWithValue("@edesign", employee.designation);
               
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
                Display();
            }
            else
            {
                MessageBox.Show("Please insert");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cDACDataSet.Emp' table. You can move, or remove it, as needed.
            this.empTableAdapter.Fill(this.cDACDataSet.Emp);

        }
      
    }
   
}
