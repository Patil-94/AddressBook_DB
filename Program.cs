// See https://aka.ms/new-console-template for more information
using Day_27_AddressBook_Using_FIleIO;

Console.WriteLine("-- Welcome To AddressBook Application --");

AddressBook contact = new AddressBook();  //creating obj of AddressBook class to access it methods
bool check = true;
while (check)
{
    Console.Write("\nChooce Operation : \n1.Create AddressBooks\n2.Display AddressBook Contact\n3.Add New Contact to AddressBook\n4.Search Contact By CityName and StateName\n5.Delete Contact\n6.Exit\n>> Enter your Choice :- ");
    int option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 1:
            Console.WriteLine("\n>> Create AddressBook Operation :");
            Console.Write("\nHow many AddressBooks You want to create ");
            int countofBook = Convert.ToInt32(Console.ReadLine());
            int num = 0;
            while (countofBook > 0)
            {
                num++;
                Console.Write("\nEnter the {0} AddressBook Name to create ", num);
                string name = Console.ReadLine();
                contact.AddBook(name);
                countofBook--;
            }
            break;
        case 2:
            Console.WriteLine("\n AddressBooks Details :");
            contact.DisplayBookData();
            break;

        case 3:
            Console.WriteLine("\n Add New Contact");
            contact.AddNewContact();
            break;

        case 4:
            Console.WriteLine("\n Search contact by CityName and State Name:");
            contact.SearchContact_By_CityName_StateName();
            break;
        case 5:
            Console.WriteLine("\n Delete AddressBook");
            contact.DeleteAddressBook();
            break;

        case 6:
            Console.WriteLine("\n Writing Data OF AddressBook TO File...");
            contact.WriteAddressBooksData_To_TextFile_UsingFileIO();
            break;

        case 7:
            check = false;
            break;

        default: Console.WriteLine("\n Please Enter correct choice!!"); break;
    }
}