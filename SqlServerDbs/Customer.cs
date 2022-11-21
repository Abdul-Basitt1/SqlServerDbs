using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SqlServerDbs
{
    public class Customer
    {

        private static string mycon = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        
        private const string InsertQuery = "Insert Into customer(CompanyName,ContactName,Phone) Values(@CompanyName, @ContactName, @Phone)";
        public bool InsertCustomer(Customer customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(mycon))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    com.Parameters.AddWithValue("@ContactName", customer.ContactName);
                    com.Parameters.AddWithValue("@Phone", customer.Phone);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        private const string UpdateQuery = "Update customer set CompanyName=@CompanyName,ContactName=@ContactName,Phone=@Phone where CustomerID=@CustomerID";
        public bool UpdateCustomer(Customer customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(mycon))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                {
                    com.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    com.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    com.Parameters.AddWithValue("@ContactName", customer.ContactName);
                    com.Parameters.AddWithValue("@Phone", customer.Phone);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        private const string DeleteQuery = "Delete from customer where CustomerID=@CustomerID";
        public bool DeleteCustomer(Customer customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(mycon))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                {
                    com.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    com.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    com.Parameters.AddWithValue("@ContactName", customer.ContactName);
                    com.Parameters.AddWithValue("@Phone", customer.Phone);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        private const string SelectQuery = "Select * from customer";
        public DataTable GetEmployees()
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(mycon))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SelectQuery, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;

        }
    }
}
