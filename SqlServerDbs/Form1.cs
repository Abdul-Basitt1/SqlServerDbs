using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlServerDbs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Customer customer = new Customer();

        private void addrecord(object sender, EventArgs e)
        {
            customer.CompanyName = textBox1.Text;
            customer.ContactName = textBox2.Text;
            customer.Phone = textBox3.Text;
            var success = customer.InsertCustomer(customer);
            dataGridView1.Visible = true;
            dataGridView1.DataSource = customer.GetEmployees();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Customer Added Succesfully");
            }
            else
            {
                MessageBox.Show("Customer Addtion Failed");
            }
        }

        private void clearfields(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }

        private void delete_cust(object sender, EventArgs e)
        {
            customer.CustomerID = textBox4.Text;
            var success = customer.DeleteCustomer(customer);
            dataGridView1.Visible = true;
            dataGridView1.DataSource = customer.GetEmployees();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Customer Deleted Succesfully");
            }
            else
            {
                MessageBox.Show("Customer Deletion Failed");
            }
        }

        private void update_cust(object sender, EventArgs e)
        {
            customer.CompanyName = textBox1.Text;
            customer.ContactName = textBox2.Text;
            customer.Phone = textBox3.Text;
            customer.CustomerID = textBox5.Text;
            dataGridView1.Visible = true;
            var success = customer.UpdateCustomer(customer);
            dataGridView1.DataSource = customer.GetEmployees();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Customer Updated Succesfully");
            }
            else
            {
                MessageBox.Show("Customer Updation Failed");
            }

        }

        private void fillselect_items_tofields(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.Visible = true;
            var index = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
        }
    }
}
