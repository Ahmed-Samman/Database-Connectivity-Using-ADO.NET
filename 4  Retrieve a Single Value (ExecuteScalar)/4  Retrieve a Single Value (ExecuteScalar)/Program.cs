using System;
using System.Data.SqlClient;

namespace _4__Retrieve_a_Single_Value__ExecuteScalar_
{
    internal class Program
    {
        
        static string ConnectionString = "Server=DESKTOP-T9IS20A\\SQLEXPRESS;Database=ContactsDB;User Id=sa;Password=123456;";
        
        static string GetFirstName(int ContactID)
        {

            string FirstName = string.Empty;

            string QueryString = "SELECT Contacts.FirstName FROM Contacts WHERE Contacts.ContactID = @ContactID";
            
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("@ContactID", ContactID);
            
            try
            {
               Connection.Open();
               
                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    FirstName = Result.ToString();
                }
                else
                {
                    FirstName = "No contact found with the provided ContactID.";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
         
            Connection.Close();
            return FirstName;
        }


        static void Main(string[] args)
        {
            
            Console.WriteLine(GetFirstName(1));
            Console.ReadKey();
        }
    }
}
