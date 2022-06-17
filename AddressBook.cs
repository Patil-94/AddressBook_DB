using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_27_AddressBook_Using_FIleIO
{
    public class AddressBook
    {
        //creating Generic Dictionary object
        Dictionary<string, List<Contact>> Book = new Dictionary<string, List<Contact>>();
        // method to take contact info
        public Object AddContact()
        {
            List<Contact> addContact = new List<Contact>(); //creating generic List for storing contacts info
            Console.Write("\n How many contacts do you want to add : ");
            int num = Convert.ToInt32(Console.ReadLine());
            int count = 1;
            while (num > 0)
            {
                Console.Write("\n Enter the contact Details For Contact {0} \n", count);
                Contact obj = new Contact();     //creating obj of Contact class to pass info taken from user 
                Console.Write("Enter Firstname :- ");
                obj.FirstName = Console.ReadLine();
                Console.Write("Enter Lastname :- ");
                obj.LastName = Console.ReadLine();

                Console.Write("Enter Address :- ");
                obj.Address = Console.ReadLine();

                Console.Write(" Enter City :- ");
                obj.City = Console.ReadLine();

                Console.Write(" Enter State :- ");
                obj.State = Console.ReadLine();

                Console.Write(" Enter pincode :- ");
                obj.Zip = Convert.ToInt32(Console.ReadLine());

                Console.Write(" Enter PhoneNumber :- ");
                obj.PhoneNumber = Convert.ToInt64(Console.ReadLine());

                Console.Write("Enter Email :- ");
                obj.Email = Console.ReadLine();

                // >> UC7 : To avoid duplicate contact entry in AddressBook //
                //------------------------------------------------------------//
                if (addContact.Count > 0)
                {
                    foreach (var element in addContact)
                    {
                        if (element.FirstName.ToLower() != obj.FirstName.ToLower() || element.LastName.ToLower() != obj.LastName.ToLower())
                        {   
                            addContact.Add(obj); //Adding objeect holding all info of current user we are adding to List
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n This contact is already in Address Book....");
                            Console.WriteLine("Enter the details again...");
                            num++;
                            count--;
                        }
                    }
                }
                else
                {
                    addContact.Add(obj); //Adding obj holding all info of current user we are adding it to List
                }
                num--;
                count++;
            }

            // >> UC 11 & 12 :sorting contact in addressBook based on name,address,city,state,Pincode etc //
            //--------------------------------------------------------------------------------------------//
            addContact.Sort((x, y) => x.FirstName.CompareTo(y.FirstName) 
                                    + x.LastName.CompareTo(y.LastName)
                                    + x.Address.CompareTo(y.Address)
                                    + x.City.CompareTo(y.City)
                                    + x.State.CompareTo(y.State)
                                    + x.Zip.CompareTo(y.Zip));
            return addContact;//Returning the whole sorted List
        }
        //Method to Add AddressBook 
        public void AddBook(string Bookname)
        {
            List<Contact> addcontact = (List<Contact>)AddContact(); //  addcontact method which is returning List object

            if (addcontact != null)//checking  null or not Null
            {
                Book.Add(Bookname, addcontact); // Adding Book to Dictionary with Key and Value as BookName and Obj return by add contact method 
                Console.WriteLine("\nBook Added Successfully...");
            }
            else
            {
                Console.WriteLine("\nAddressBook Creation Failed!!");
            }

        }
        //Method to display Contacts in BOOk 
        public void DisplayBookData()
        {
            if (Book.Count > 0)
            {
                GetBookNames();
                Console.Write("\nEnter the Name of AddressBook of which you want to See the Details :- ");
                string Bookname = Console.ReadLine();
                foreach (var element in Book) //Iterating elements in Book
                {
                    if (element.Key.Contains(Bookname)) // selecting only that elemet which contain BookName 
                    {
                        Console.WriteLine("\nRecords in AddressBook " + Bookname);
                        foreach (var data in element.Value)
                        {
                            Console.WriteLine("\nFirstName :- " + data.FirstName + "\n" + "LastName :- " + data.LastName + "\n" + "Address :- " + data.Address + "\n" + "City :- " + data.City + "\n " + "State :- " + data.State + "\n" + "Zip :- " + data.Zip + " \n" + "PhoneNumber :- " + data.PhoneNumber + "\n" + "Email :- " + data.Email + "\n");
                        }
                        break;
                    }

                }
            }
            else
            {
                Console.WriteLine("\nSorry!! You don't have Any Book Yet...");
            }

        }

        //To get the names of All AddressBooks in Dictionary
        public void GetBookNames()
        {
            int numOfBooks = 0;
            Console.WriteLine("Books Present in Record :");
            foreach (var Books in Book)
            {
                numOfBooks++;
                Console.WriteLine(numOfBooks + ". " + Books.Key);
            }
        }

        //To AddNew Contact in Existing dictionary
        public void AddNewContact()
        {
            Console.WriteLine("\nChoose the Book in which You want to ADD New Contact :");
            GetBookNames();
            Console.Write("\nEnter Your choice :- ");
            string BookName_ToAddContact = Console.ReadLine();
            if (Book.ContainsKey(BookName_ToAddContact))
            {
                Console.Write("\nHow many contacts do you want to add :- ");
                int num = Convert.ToInt32(Console.ReadLine());
                int count = 1;
                while (num > 0)
                {
                    List<Contact> addNew_Contact = new List<Contact>(); //creating generic List for storing contact
                    Console.Write("\nEnter the contact Details For Contact {0} \n", count);
                    Contact obj = new Contact();     //creating obj of Contact 
                    Console.Write("> Firstname :- ");
                    obj.FirstName = Console.ReadLine();
                    Console.Write("> Enter Lastname :- ");
                    obj.LastName = Console.ReadLine();

                    Console.Write("> Enter Address :- ");
                    obj.Address = Console.ReadLine();

                    Console.Write("> Enter City :- ");
                    obj.City = Console.ReadLine();

                    Console.Write("> Enter State :- ");
                    obj.State = Console.ReadLine();

                    Console.Write("> Enter pincode :- ");
                    obj.Zip = Convert.ToInt32(Console.ReadLine());

                    Console.Write("> Enter PhoneNumber :- ");
                    obj.PhoneNumber = Convert.ToInt64(Console.ReadLine());

                    Console.Write("> Enter Email :- ");
                    obj.Email = Console.ReadLine();

                    if (addNew_Contact.Count > 0)
                    {
                        foreach (var element in addNew_Contact)
                        {
                            if (element.FirstName.ToLower() != obj.FirstName.ToLower() || element.LastName.ToLower() != obj.LastName.ToLower())
                            {
                                addNew_Contact.Add(obj); //Adding obj holding all info of current user we are adding it to List
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nThis contact is already in Address Book....");
                                Console.WriteLine("Enter the details again...");
                                num++;
                                count--;
                            }
                        }
                    }
                    else
                    {
                        addNew_Contact.Add(obj); //Adding obj holding all info of current user we are adding it to List
                    }
                    num--;
                    count++;
                   
                    foreach (var element in Book)
                    {
                        if (element.Key.Equals(BookName_ToAddContact))
                        {   
                            element.Value.AddRange(addNew_Contact);
                            element.Value.Sort((x, y) => x.FirstName.CompareTo(y.FirstName)
                                    + x.LastName.CompareTo(y.LastName)
                                    + x.Address.CompareTo(y.Address)
                                    + x.City.CompareTo(y.City)
                                    + x.State.CompareTo(y.State)
                                    + x.Zip.CompareTo(y.Zip));
                            Console.WriteLine("\nNew Contacts are added to AddressBook " + BookName_ToAddContact);
                            break;
                        }
                    }
                }
            }
        }

        //To Delete The address Book from dictionary
        public void DeleteAddressBook()
        {
            Console.WriteLine("\nChoose the Book which You want to Delete :");
            GetBookNames();
            Console.Write("\nEnter Your choice :- ");
            string BookName_ToAddContact = Console.ReadLine();
            foreach (var element in Book)
            {
                if (element.Key.Equals(BookName_ToAddContact))
                {
                    Book.Remove(BookName_ToAddContact);
                    Console.WriteLine("Book Deleted Successfully...");
                    break;
                }
            }
        }

        //>>  UC 8 : Search Conatact by CityName And State Name
        public void SearchContact_By_CityName_StateName()
        {
            Console.Write("\nEnter the city Name of contact :- ");
            string CityName_TO_Search = Console.ReadLine();
            Console.Write("\nEnter the State Name of contact :- ");
            string StateName_TO_Search = Console.ReadLine();
            Console.WriteLine("\nSearched Result :-");
            int count = 0;
            if (Book.Count > 0)
            {
                foreach (var element in Book)
                {
                    foreach (var data in element.Value)
                    {
                        if (data.City.ToLower() == CityName_TO_Search.ToLower() && data.State.ToLower() == StateName_TO_Search.ToLower())
                        {
                            count++;
                            Console.Write("\nRecord {0} : ", count);
                            Console.WriteLine("\nFirstName :- " + data.FirstName + "\n" + "LastName :- " + data.LastName + "\n" + "Address :- " + data.Address + "\n" + "City :- " + data.City + "\n " + "State :- " + data.State + "\n" + "Zip :- " + data.Zip + " \n" + "PhoneNumber :- " + data.PhoneNumber + "\n" + "Email :- " + data.Email + "\n");
                        }
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("\nNo Records Found with City Name :- {0} | State Name :- {1}", CityName_TO_Search, StateName_TO_Search);
                }
            }
            else
                Console.WriteLine("\nYou Don't have any AddressBook To search!!");
        }

        // >> UC13 : Read Write Data of AddressBooks TO Text file
        public void WriteAddressBooksData_To_TextFile_UsingFileIO()
        {
            string PathofFile_StoringAddressBooksData = @"D:\Day-27-AddressBook-Using_FileIO\Day-27-AddressBook_Using_FIleIO\AddressBookData.txt";
            int count = 0;
            using(StreamWriter sr=File.AppendText(PathofFile_StoringAddressBooksData))
            {
                sr.WriteLine("-------------- Records Of AddressBook System -------------\n");
                foreach (var element in Book)
                {
                    foreach(var data in element.Value)
                    {   count++;
                        sr.WriteLine("\nRecord No :- "+count+"\n\nFirstName :- " + data.FirstName + "\n" + "LastName :- " + data.LastName + "\n" + "Address :- " + data.Address + "\n" + "City :- " + data.City + "\n " + "State :- " + data.State + "\n" + "Zip :- " + data.Zip + " \n" + "PhoneNumber :- " + data.PhoneNumber + "\n" + "Email :- " + data.Email + "\n");
                    }

                }
                sr.Close();
            }
            Console.WriteLine("\n>> Data of AddressBooks successfully stored in File...");
        }
    }
}
