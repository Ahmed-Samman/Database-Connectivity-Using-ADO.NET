using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Parameterized_Query_With_Like
{
    internal class Program
    {

        static string connectionString = "Server=DESKTOP-T9IS20A\\SQLEXPRESS; Database=ContactsDB; User Id=sa; Password=123456";

        static void SearchContactsStartsWith(string StartsWidth)
        {
            string Query = "SELECT * FROM Contacts WHERE Contacts.FirstName LIKE '' + @StartsWidth + '%'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@StartsWidth", StartsWidth);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                             
                while (reader.Read())
                {
                    int ContactID = (int)reader["ContactID"];
                    string FirstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    string Email = (string)reader["Email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Address"];
                    int CountryId = (int)reader["CountryID"];

                    Console.WriteLine($"ContactID: {ContactID}");
                    Console.WriteLine($"FirstName: {FirstName}");
                    Console.WriteLine($"LastName: {LastName}");
                    Console.WriteLine($"Email: {Email}");
                    Console.WriteLine($"Phone: {Phone}");
                    Console.WriteLine($"Address: {Address}");
                    Console.WriteLine($"CountryId: {CountryId}");
                    Console.WriteLine("-------------------------------\n");
                }
                    reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            connection.Close();            
        }

        static void SearchContactsEndsWith(string EndsWidth)
        {
            string Query = "SELECT * FROM Contacts WHERE Contacts.FirstName LIKE '%' + @EndsWidth + ''";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@EndsWidth", EndsWidth);

            try 
            { 
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int ContactID = (int)reader["ContactID"];
                    string FirstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    string Email = (string)reader["Email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Address"];
                    int CountryId = (int)reader["CountryID"];


                    Console.WriteLine($"ContactID: {ContactID}");
                    Console.WriteLine($"FirstName: {FirstName}");
                    Console.WriteLine($"LastName: {LastName}");
                    Console.WriteLine($"Email: {Email}");
                    Console.WriteLine($"Phone: {Phone}");
                    Console.WriteLine($"Address: {Address}");
                    Console.WriteLine($"CountryId: {CountryId}");
                    Console.WriteLine("-------------------------------\n");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();      
        }

        static void SearchContactsContains(string Contains)
        {

            string Query = "SELECT * FROM Contacts WHERE Contacts.FirstName LIKE '%' + @Contains + '%'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
             
                while (reader.Read())
                {
                    int ContactID = (int)reader["ContactID"];
                    string FirstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    string Email = (string)reader["Email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Address"];
                    int CountryId = (int)reader["CountryID"];
                
                    Console.WriteLine($"ContactID: {ContactID}");
                    Console.WriteLine($"FirstName: {FirstName}");
                    Console.WriteLine($"LastName: {LastName}");
                    Console.WriteLine($"Email: {Email}");
                    Console.WriteLine($"Phone: {Phone}");
                    Console.WriteLine($"Address: {Address}");
                    Console.WriteLine($"CountryId: {CountryId}");
                    Console.WriteLine("-------------------------------\n");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }



        static void Main(string[] args)
        {
            // Search for contacts whose first name starts with 'j'
            SearchContactsStartsWith("j");

            // Search for contacts whose first name ends with 'ne'
            SearchContactsEndsWith("ne");

            // Search for contacts whose first name contains 'ae'
            SearchContactsContains("ae");

            Console.ReadKey();
        }
    }
}
