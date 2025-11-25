using System;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
namespace _5_Find_Single_Contact
{
    internal class Program
    {
        static string ConnectionString = "Server=DESKTOP-T9IS20A\\SQLEXPRESS;Database=ContactsDB; User Id= sa; Password=123456;";
      
     
        static bool FindContactByID(int ID, ref stContact ContactInfo)
        {

            bool found = false;

            string query = "SELECT * FROM Contacts WHERE Contacts.ContactID = @ContactID";
            SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    ContactInfo.ContactID = (int)reader["ContactID"];
                    ContactInfo.FirstName = (string)reader["FirstName"];
                    ContactInfo.LastName = (string)reader["LastName"];
                    ContactInfo.Email = (string)reader["Email"];
                    ContactInfo.Phone = (string)reader["Phone"];
                    ContactInfo.Address = (string)reader["Address"];
                    ContactInfo.CountryID = (int)reader["CountryID"];
                    found = true; // Contact found
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);              
            }
           
            connection.Close();   
            return found;
        }


        struct stContact
        {
            public int ContactID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }
        }

      

        static void Main(string[] args)
        {

            stContact Contact = new stContact();

            if (FindContactByID(1, ref Contact))
            {

                Console.WriteLine($"ContactID : {Contact.ContactID}");
                Console.WriteLine($"FirstName : {Contact.FirstName}");
                Console.WriteLine($"LastName  : {Contact.LastName}");
                Console.WriteLine($"Email     : {Contact.Email}");
                Console.WriteLine($"Phone     : {Contact.Phone}");
                Console.WriteLine($"Address   : {Contact.Address}");
                Console.WriteLine($"CountryID : {Contact.CountryID}");

            }
            else
            {
                Console.WriteLine("Contact not found!");
            }

            Console.ReadKey();
        }
    }
}
