
using DocuSign.eSign.Model;
using System;

namespace AddressBook_Service
{
    public class Program
    {
       

        static void Main(string[] args)
        {
            AddressBookService addressBook = new AddressBookService();
            bool flag = true;
            while(flag)
            {
                Console.WriteLine("Enter The Option= 1.AddAddressBook \n 2.RetrieveEntriesFromAddressBookDB \n 3.Update Data \n 4.Delete Data");
                int option=Convert.ToInt32(Console.ReadLine());
                switch(option)
                {
                    case 1:

                        AddressBook address=new AddressBook()
                        {
                            FirstName = "Akash",
                            LastName = "Mane",
                            Address = "Bhigwan",
                            City = "Pune",
                            State = "Maha",
                            Zip = 7865,
                            MobNo = 724962454,
                            Email = "maneakash3938@gmail.com",
                            Type = "Novel",
                            AddressBookName = "ABC",
                        };
                        addressBook.AddAddressBookInDB(address);
                        break;

                       
                    case 4:
                        addressBook.DeleteDataFromDatabase("Akash");
                        break;
                }
            }
        }
    }
}
