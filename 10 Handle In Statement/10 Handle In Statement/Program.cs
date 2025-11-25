using System;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;

namespace _10_Handle_In_Statement
{
    internal class Program
    {
        static string connectionString = "Server=DESKTOP-T9IS20A\\SQLEXPRESS;Database=ContactsDB;User Id=sa;Password=123456;";
        static void DeleteContact(string Contacts)
        {

            string query = @"DELETE FROM Contacts
                            WHERE Contacts.ContactID in (" + Contacts + ")";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);


            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Contacts deleted successfully.");
                }
                else
                {
                    Console.WriteLine("No contacts found with the specified IDs.");
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

            DeleteContact("4, 6, 10");

            Console.ReadKey();
        }
    }
}
