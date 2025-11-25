using System;
using System.Data.SqlClient;

namespace _7_Retrieve_Auto_Number_after_Inserting__Adding_Data_
{
    internal class Program
    {

        static string ConnectionString = "Server=DESKTOP-T9IS20A\\SQLEXPRESS;Database=ContactsDB;User Id=sa;Password=123456;";

       
        static void AddNewContactAndGetID(stContact NewContact)
        {

            string query = @"INSERT INTO Contacts (FirstName, LastName ,Email, Phone, Address, CountryID)
                        VALUES (@FirstName, @LastName ,@Email, @Phone, @Address, @CountryID);
                        SELECT SCOPE_IDENTITY()";

            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand commad = new SqlCommand(query, sqlConnection);


            commad.Parameters.AddWithValue("@FirstName", NewContact.FirstName);
            commad.Parameters.AddWithValue("@LastName", NewContact.LastName);
            commad.Parameters.AddWithValue("@Email", NewContact.Email);
            commad.Parameters.AddWithValue("@Phone", NewContact.Phone);
            commad.Parameters.AddWithValue("@Address", NewContact.Address);
            commad.Parameters.AddWithValue("@CountryID", NewContact.CountryID);

            

            try
            {
                sqlConnection.Open();

                object result = commad.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(), out int insertedid))
                {
               
                    Console.WriteLine($"New Inserted ID: {insertedid}");
                }
                else
                {
                    Console.WriteLine("Failed to retrieve the new contact ID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
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


            stContact stContact = new stContact()
            {
                FirstName = "Ahmed",
                LastName = "Samman",
                Email = "AS@.com",
                Phone = "0123456789",
                Address = "Cairo",
                CountryID = 1
            };


            AddNewContactAndGetID(stContact);

            Console.ReadKey();

        }
    }
}
