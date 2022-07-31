using Microsoft.Data.SqlClient;
using Shop.Models;

namespace Shop.Databases
{
    public class CustomerDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopItems;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Insert(CustomerModel customer)
        {

            int newIdNumber = -1;
            string sqlStatement = "INSERT INTO dbo.Customers VALUES (@Name,@Password)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@Password", customer.Surname);
                command.Parameters.AddWithValue("@Id", customer.Id);
                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                return newIdNumber;
            }
        }

        public bool CheckIfLogged(CustomerModel customer)
        {
            bool success = false;
            string sqlStatement = "SELECT * FROM dbo.Customers WHERE EmailAdress = @EmailAdress AND Password = @Password";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
                sqlCommand.Parameters.Add("@EmailAdress", System.Data.SqlDbType.NVarChar, 50).Value = customer.EmailAdress;
                sqlCommand.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = customer.Password;

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            return success;


        }
    }
}
