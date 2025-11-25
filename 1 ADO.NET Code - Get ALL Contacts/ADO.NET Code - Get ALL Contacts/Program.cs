using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.Remoting.Messaging;

namespace ADO.NET_Code___Get_ALL_Contacts
{
    public class Program
    {
        static string connectionString = "Server = DESKTOP-T9IS20A\\SQLEXPRESS; Database = ContactsDB; User Id = sa; Password = 123456;";
        
        public static void PrintAllContacts()
        {
            string query = "SELECT * FROM Contacts";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand Commandquery = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = Commandquery.ExecuteReader();
                
                while(reader.Read())
                {
                    int ContactID = (int)reader["ContactID"];
                    string FirstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    string Email = (string)reader["Email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Address"];
                    int CountryID = (int)reader["CountryID"];
                    

                    Console.WriteLine($"ContactID : {ContactID}");
                    Console.WriteLine($"FirstName : {FirstName}");
                    Console.WriteLine($"LastName  : {LastName}");
                    Console.WriteLine($"Email     : {Email}");
                    Console.WriteLine($"PhoneNumbe: {Phone}");
                    Console.WriteLine($"Address   : {Address}");
                    Console.WriteLine($"CountryID : {CountryID}");
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

            PrintAllContacts();
            Console.ReadKey();
        }
    }
}
