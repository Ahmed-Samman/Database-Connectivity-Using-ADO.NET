using System;
using System.Data.SqlClient;


namespace _6_Insert_Add_Data
{
    internal class Program
    {  

        static string connectionString = "Server=DESKTOP-T9IS20A\\SQLEXPRESS;Database=ContactsDB;User Id=sa;Password=123456;";

        static void AddNewContact(stContact NewContact)
        {

            string Query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
                VALUES (@FirstName,@LastName, @Email, @Phone, @Address, @CountryID)";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

            // Add parameters to prevent SQL injection
            sqlCommand.Parameters.AddWithValue("@FirstName", NewContact.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", NewContact.LastName);
            sqlCommand.Parameters.AddWithValue("@Email", NewContact.Email);
            sqlCommand.Parameters.AddWithValue("@Phone", NewContact.Phone);
            sqlCommand.Parameters.AddWithValue("@Address", NewContact.Address);
            sqlCommand.Parameters.AddWithValue("@CountryID", NewContact.CountryID);


            try
            {
                sqlConnection.Open();

                int rowsAffected = sqlCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("New contact added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add new contact.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            
             sqlConnection.Close();


        }


        struct stContact
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }
        }


        static void Main(string[] args)
        {
            stContact newContact = new stContact
            {

                FirstName = "Mohammed",
                LastName = "Abu-Hadhude",
                Email = "Moh@.com",
                Phone = "123-456-7890",
                Address = "1234 Main street",
                CountryID = 1
            };
            AddNewContact(newContact);


            Console.ReadKey();
        }
    }
}
