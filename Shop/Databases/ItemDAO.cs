using Microsoft.Data.SqlClient;
using Shop.Models;
using Shop.Controllers;
using System.Drawing;
using System.Data;

namespace Shop.Databases
{
    public class ItemDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopItems;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void PopulateList(List<ItemModel> items)
        {





            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlStatement = "SELECT * FROM dbo.Items4";

                SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);



                //sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                //sqlCommand.Parameters.Add("@Image", System.Data.SqlDbType.NVarChar);
                //sqlCommand.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar);
                //sqlCommand.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar);
                //sqlCommand.Parameters.Add("@Price", System.Data.SqlDbType.Decimal);
                //sqlCommand.Parameters.Add("@ItemsOnStock", System.Data.SqlDbType.Int);


                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            items.Add(new ItemModel
                            {
                                Id = reader.GetInt32(0),
                                Image = reader.GetString(1),
                                Name = reader.GetString(2),
                                Description = reader.GetString(3),
                                Price = (decimal)reader.GetValue(4),
                                ItemsOnStock = (int)reader.GetValue(5),
                                Category = reader.GetString(6),


                            });
                        }
                    }
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].ItemsOnStock > 0)
                        {
                            items[i].Available = true;

                        }

                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }



        }
        public List<ItemModel> Search(string searchTerm)
        {
            List<ItemModel> items = new List<ItemModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlStatement = "SELECT * FROM dbo.Items4 WHERE Name LIKE @Name";

                SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);



                sqlCommand.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');
                //sqlCommand.Parameters.Add("@Image", System.Data.SqlDbType.NVarChar);
                //sqlCommand.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar);
                //sqlCommand.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar);
                //sqlCommand.Parameters.Add("@Price", System.Data.SqlDbType.Decimal);
                //sqlCommand.Parameters.Add("@ItemsOnStock", System.Data.SqlDbType.Int);


                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            items.Add(new ItemModel
                            {
                                Id = reader.GetInt32(0),
                                Image = reader.GetString(1),
                                Name = reader.GetString(2),
                                Description = reader.GetString(3),
                                Price = (decimal)reader.GetValue(4),
                                ItemsOnStock = (int)reader.GetValue(5),
                                Category = reader.GetString(6),
                            });







                        }
                    }
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].ItemsOnStock > 0)
                        {
                            items[i].Available = true;

                        }

                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }
            return items;



        }
        public List<ItemModel> SearchByCategory(string searchTerm)
        {
            List<ItemModel> items = new List<ItemModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlStatement = "SELECT * FROM dbo.Items4 WHERE Category LIKE @Category";

                SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);



                sqlCommand.Parameters.AddWithValue("@Category", '%' + searchTerm + '%');
                //sqlCommand.Parameters.Add("@Image", System.Data.SqlDbType.NVarChar);
                //sqlCommand.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar);
                //sqlCommand.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar);
                //sqlCommand.Parameters.Add("@Price", System.Data.SqlDbType.Decimal);
                //sqlCommand.Parameters.Add("@ItemsOnStock", System.Data.SqlDbType.Int);


                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            items.Add(new ItemModel
                            {
                                Id = reader.GetInt32(0),
                                Image = reader.GetString(1),
                                Name = reader.GetString(2),
                                Description = reader.GetString(3),
                                Price = (decimal)reader.GetValue(4),
                                ItemsOnStock = (int)reader.GetValue(5),
                                Category = reader.GetString(6),
                            });







                        }
                    }
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].ItemsOnStock > 0)
                        {
                            items[i].Available = true;

                        }

                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }
            return items;
        }
    }
}
