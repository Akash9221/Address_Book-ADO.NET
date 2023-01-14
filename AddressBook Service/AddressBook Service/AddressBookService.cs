using DocuSign.eSign.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook_Service
{
    public class AddressBookService
    {
        public static string connectionString= @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Address_Book_SystemService_Database;";

        public void AddAddressBookInDB(AddressBook address)
        {
            SqlConnection sQLConnection = new SqlConnection(connectionString);
            try
            {
                using (sQLConnection)
                {
                    sQLConnection.Open();
                    SqlCommand command = new SqlCommand("SPAddAddressBook", sQLConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName",address.FirstName);
                    command.Parameters.AddWithValue("@LastName", address.LastName);
                    command.Parameters.AddWithValue("@Address", address.Address);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@State", address.State);
                    command.Parameters.AddWithValue("@Zip", address.Zip);
                    command.Parameters.AddWithValue("@MobNo", address.MobNo);
                    command.Parameters.AddWithValue("@Email", address.Email);
                    command.Parameters.AddWithValue("@Type", address.Type);
                    command.Parameters.AddWithValue("@AddressBookName", address.AddressBookName);
                    int result = command.ExecuteNonQuery(); 
                    sQLConnection.Close();  
                    if(result>=1)
                    {
                      Console.WriteLine("Address Book Added Succesfully");
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                }
            }
            catch (Exception ex)
            {
                //Handle Exception Here
                System.Console.WriteLine(ex.Message);
            }
        }
        

    }
    }
