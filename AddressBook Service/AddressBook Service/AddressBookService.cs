﻿using DocuSign.eSign.Model;
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
        public void RetrieveEntriesFromAddressBookDB()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                List<AddressBook> addressBooks = new List<AddressBook>();
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("SPRetrieveAllDetails", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AddressBook addressBook = new AddressBook();
                            addressBook.FirstName = dr.GetString(0);
                            addressBook.LastName = dr.GetString(1);
                            addressBook.Address = dr.GetString(2);
                            addressBook.City = dr.GetString(3);
                            addressBook.State = dr.GetString(4);
                            addressBook.Zip = dr.GetInt32(5);
                            addressBook.MobNo = dr.GetInt32(6);
                            addressBook.Email = dr.GetString(7);
                            addressBook.Type = dr.GetString(8);
                            addressBook.AddressBookName = dr.GetString(9);
                            Console.WriteLine("FirstName" + addressBook.FirstName);
                            Console.WriteLine("LastName" + addressBook.LastName);
                            Console.WriteLine("Address" + addressBook.Address);
                            Console.WriteLine("City" + addressBook.City);
                            Console.WriteLine("State" + addressBook.State);
                            Console.WriteLine("Zip" + addressBook.Zip);
                            Console.WriteLine("MobNo" + addressBook.MobNo);
                            Console.WriteLine("Email" + addressBook.Email);
                            Console.WriteLine("Type" + addressBook.Type);
                            Console.WriteLine("AddressBookName" + addressBook.AddressBookName);
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No Database Found");
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }

    }
    }
