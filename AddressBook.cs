using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace AddressBook_System
{
    public class AddressBook
    {
        public List<Contact> contacts;
        public string AddressBook_Name;
        public AddressBook(string addressbookName)
        {
            contacts = new List<Contact>();
            AddressBook_Name = addressbookName;
        }
        public Contact AddToContact()
        {
            Contact contact = new Contact();
            Console.WriteLine("Enter FirstName:");
            var name= Console.ReadLine();
            contact.FirstName = name;
            Console.WriteLine("Enter LastName:");
            contact.LastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            contact.Address = Console.ReadLine();
            Console.WriteLine("Enter City");
            contact.City = Console.ReadLine();
            Console.WriteLine("Enter State");
            contact.State = Console.ReadLine();
            Console.WriteLine("Enter Email Id");
            contact.Email = Console.ReadLine();
            Console.WriteLine("Enter Zipcode");
            contact.ZipCode = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Phone Number");
            contact.PhoneNumber = int.Parse(Console.ReadLine());
            contacts.Add(contact);
            return contact;
        }
        public void Display()
        {
            if (contacts.Count <= 0)
            {
                Console.WriteLine("No contacts available");
            }
            else
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine("AddressBook Name: " + AddressBook_Name + "\n FirstName: " + contact.FirstName + "\n LastName:" + contact.LastName + "\n Address: " + contact.Address + "\n City: " + contact.City + "\n State: " + contact.State + "\n Email Id" + contact.Email + "\n ZipCode: " + contact.ZipCode + "\n Phone number: " + contact.PhoneNumber);
                }
            }

        }
        public void EditContact()
        {
            Console.WriteLine("Enter FirstName of conatc to edit that contact");
            string name = Console.ReadLine();
            Contact contact = null;
            foreach (var res in contacts)
            {
                if (res.FirstName == name)
                {
                    contact = res;
                }
            }
            if (contact == null)
            {
                Console.WriteLine("No contact present with given name");
            }
            contact = AddToContact();
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].FirstName == name)
                {
                    contacts[i] = contact; break;
                }
            }

            Console.WriteLine("Contact Edited successfully");

        }
        public void search()
        {
            Console.WriteLine("Enter 1 to search by city \nEnter 2 to search by state");
            int input = int.Parse(Console.ReadLine());
            string res="";
            switch(input)
            {
                case 1:
                    Console.WriteLine("Enter city name");
                    var city = Console.ReadLine();
                    res = city;
                    break;
                case 2:
                    Console.WriteLine("Enter state name");
                    var state = Console.ReadLine();
                    res= state;
                    break;
            }
            foreach (var contact in contacts)
            {
                if (contact.City.Equals(res) || contact.State.Equals(res))
                    Console.WriteLine("AddressBook Name: " + AddressBook_Name + "\n FirstName: " + contact.FirstName + "\n LastName:" + contact.LastName + "\n Address: " + contact.Address + "\n City: " + contact.City + "\n State: " + contact.State + "\n Email Id" + contact.Email + "\n ZipCode: " + contact.ZipCode + "\n Phone number: " + contact.PhoneNumber);
                else Console.WriteLine("person search by city or state is not present in contact");
            }

        }
        public void DeleteContact()
        {
            Console.WriteLine("Enter the FirstName of the contact to Delete");
            string dname = Console.ReadLine();
            bool flag = true;

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].FirstName==dname)
                {
                    contacts.RemoveAt(i);
                    Console.WriteLine("Contact deleted Successfully");
                    flag = false;

                }   
            }
            if (flag)
            {
                 Console.WriteLine($"No contact present of {dname} name");
            }

        }
    }
}
