using System;
using System.Data.SqlClient;

namespace _8_Update_Data
{
    internal class Program
    {
        static string connection = @"Server=DESKTOP-T9IS20A\SQLEXPRESS;Database=ContactsDB;User Id=sa;Password=123456;";

        struct stContact
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }
        }


        static void UpdateContact(int ContactID, stContact NewUpdateContact)
        {
            string query = @"UPDATE Contacts SET 
                           FirstName = @FirstName,
                           LastName = @LastName,
                           Email = @Email,
                           Phone = @Phone,
                           Address = @Address,
                           CountryID = @CountryID
                           WHERE ContactID = @ContactID";

            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand command = new SqlCommand(query, sqlConnection);


            command.Parameters.AddWithValue("@ContactID", ContactID);
            command.Parameters.AddWithValue("@FirstName", NewUpdateContact.FirstName);
            command.Parameters.AddWithValue("@LastName", NewUpdateContact.LastName);
            command.Parameters.AddWithValue("@Email", NewUpdateContact.Email);
            command.Parameters.AddWithValue("@Phone", NewUpdateContact.Phone);
            command.Parameters.AddWithValue("@Address", NewUpdateContact.Address);
            command.Parameters.AddWithValue("@CountryID", NewUpdateContact.CountryID);


            try
            {
                sqlConnection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Contact updated successfully.");
                }
                else
                {
                    Console.WriteLine("No contact found with the provided ContactID.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            
            sqlConnection.Close();
            
        }


        static void Main(string[] args)
        {

            stContact stContact = new stContact()
            {
                FirstName = "Mohamed",
                LastName = "Abo-Hadhoud",
                Email = "Moh@.com",
                Phone = "01111111111",
                Address = "2333 Street",
                CountryID = 2
            };
            

            UpdateContact(1, stContact);
            Console.ReadKey();
        }
    }
}
