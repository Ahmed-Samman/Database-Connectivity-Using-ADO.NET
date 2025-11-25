using System;

using System.Data.SqlClient;

namespace _2_Parameterized_Query
{
    public class Program
    {
        static string connectionString = "Server=DESKTOP-T9IS20A\\SQLEXPRESS;Database=ContactsDB;User Id=sa;Password=123456";

        // This method is intended to demonstrate the use of a single parameter in a SQL query.
        static void PrintAllContactsWithFirstName(string FirstName)
        {
            string query = "SELECT * FROM Contacts WHERE Contacts.FirstName = @FirstName";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            // Use parameters to prevent SQL Injection attacks
            command.Parameters.AddWithValue("@FirstName", FirstName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    int ContactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    string Email = (string)reader["Email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Address"];
                    int CountryID = (int)reader["CountryID"];

                    Console.WriteLine($"ContactID: {ContactID}");
                    Console.WriteLine($"FirstName: {firstName}");
                    Console.WriteLine($"LastName : {LastName}");
                    Console.WriteLine($"Email    : {Email}");
                    Console.WriteLine($"Phone    : {Phone}");
                    Console.WriteLine($"Address  : {Address}");
                    Console.WriteLine($"CountryID: {CountryID}");
                    Console.WriteLine("------------------------------");
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();


        }

        // This method is intended to demonstrate the use of multiple parameters in a SQL query.
        static void PrintAllContactsWithFirstNameAndCountryID(string FirstName, int CountryID)
        {
            string query = "SELECT * FROM Contacts WHERE Contacts.FirstName = @FirstName AND Contacts.CountryID = @CountryID";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            // Use parameters to prevent SQL Injection attacks
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    int ContactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    string Email = (string)reader["Email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"ContactID: {ContactID}");
                    Console.WriteLine($"FirstName: {firstName}");
                    Console.WriteLine($"LastName : {LastName}");
                    Console.WriteLine($"Email    : {Email}");
                    Console.WriteLine($"Phone    : {Phone}");
                    Console.WriteLine($"Address  : {Address}");
                    Console.WriteLine($"CountryID: {countryID}");
                    Console.WriteLine("------------------------------");
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
            PrintAllContactsWithFirstName("Jane");
            //PrintAllContactsWithFirstNameAndCountryID("Jane", 1);
            Console.ReadKey();

        }
    }
}
