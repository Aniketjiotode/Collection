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
        Dictionary<string, string> citys;
        Dictionary<string, string> states;
        public AddressBook(string addressbookName)
        {
            contacts = new List<Contact>();
            citys = new Dictionary<string, string>();
            states = new Dictionary<string, string>();
            AddressBook_Name = addressbookName;
        }
        public Contact AddToContact()
        {
            Contact contact = new Contact();
            Console.WriteLine("Enter FirstName:");
            var name = Console.ReadLine();
            contact.FirstName = name;
            Console.WriteLine("Enter LastName:");
            var lastname = Console.ReadLine();
            contact.LastName = lastname;
            Console.WriteLine("Enter Address");
            var address = Console.ReadLine();
            contact.Address = address;
            Console.WriteLine("Enter City");
            var city = Console.ReadLine();
            contact.City = city;
            Console.WriteLine("Enter State");
            var state = Console.ReadLine();
            contact.State = state;
            Console.WriteLine("Enter Email Id");
            var email = Console.ReadLine();
            contact.Email = email;
            Console.WriteLine("Enter Zipcode");
            contact.ZipCode = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Phone Number");
            contact.PhoneNumber = int.Parse(Console.ReadLine());
            contacts.Add(contact);
            citys.Add(city, name);
            states.Add(state, name);
            return contact;
        }
        public void Display()
        {
            Console.WriteLine("Enter 1 to print all data  \nEnter 2 to view persons by state or city");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
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
                    break;
                case 2:
                    Console.WriteLine("Enter 1 to view person by city\nEnter 2 to view persons by state");
                    int input2 = int.Parse(Console.ReadLine());
                    switch (input2)
                    {
                        case 1:
                            if (citys.Count <= 0)
                            {
                                Console.WriteLine("No contacts available");
                            }
                            else
                            {
                                foreach (var c in citys)
                                {
                                    Console.WriteLine(c);
                                }
                            }
                            break;
                        case 2:
                            if (states.Count <= 0)
                            {
                                Console.WriteLine("No contacts available");
                            }
                            else
                            {
                                foreach (var s in states)
                                {
                                    Console.WriteLine(s);
                                }
                            }
                            break;
                    }
                    break;
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
            string res = "";
            switch (input)
            {
                case 1:
                    Console.WriteLine("Enter city name");
                    var city = Console.ReadLine();
                    res = city;
                    break;
                case 2:
                    Console.WriteLine("Enter state name");
                    var state = Console.ReadLine();
                    res = state;
                    break;
            }
            foreach (var contact in contacts)
            {
                if (contact.City.Equals(res) || contact.State.Equals(res))
                    Console.WriteLine("AddressBook Name: " + AddressBook_Name + "\n FirstName: " + contact.FirstName + "\n LastName:" + contact.LastName + "\n Address: " + contact.Address + "\n City: " + contact.City + "\n State: " + contact.State + "\n Email Id" + contact.Email + "\n ZipCode: " + contact.ZipCode + "\n Phone number: " + contact.PhoneNumber);
                else Console.WriteLine("person search by city or state is not present in contact");
            }
            Console.ReadLine();
        }

        public void DeleteContact()
        {
            Console.WriteLine("Enter the FirstName of the contact to Delete");
            string dname = Console.ReadLine();
            bool flag = true;

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].FirstName == dname)
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
