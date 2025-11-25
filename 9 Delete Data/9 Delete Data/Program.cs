using System;
using System.Data.SqlClient;

namespace _9_Delete_Data
{
    internal class Program
    {
        static string connectionString = "Server=DESKTOP-T9IS20A\\SQLEXPRESS;Database=ContactsDB;User Id=sa;Password=123456;";


        static void DeleteContact(int ContactID)
        {
            string query = @"DELETE FROM Contacts WHERE ContactID = @ContactID";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();
            
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Contact deleted successfully Rows affected: {rowsAffected}");
                }
                else
                {
                    Console.WriteLine("No contact found with the specified ContactID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            connection.Close();
        } 


        static void Main(string[] args)
        {


            DeleteContact(7);
            Console.ReadKey();
        }
    }
}
