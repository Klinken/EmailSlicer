using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmailSlicer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables

            string usersEmail;

            // Methods

                // Ask for users email and store it

            string getEmail()
            {
                // Make sure its an email
                Regex regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");

                string email = Console.ReadLine();



                if (!regex.IsMatch(email))
                {
                    Console.WriteLine("There seems to be a problem with your email, please try again.");

                    return getEmail();

                }

                return usersEmail = email;

            }

            // Check users email for custom or popular domain


            string getDomain(string email)
            {
                //Split the mail into an array of char
                char[] emailToArray = email.ToCharArray();

                List<char> domain = new List<char>();

                //Find and return position of @

                int index = Array.FindIndex(emailToArray, x => x == '@');

                //Return all the char between the @ and a . to a new array

                for (int i = index + 1; i < emailToArray.Length; i++)
                {
                  
                    if (emailToArray[i] == '.')
                    {
                        break;
                    }

                    domain.Add(emailToArray[i]);

                }

                string domainName = String.Join("", domain.ToArray());

                //Create a string from the array

                return domainName;

            }
                
            string checkDomain(string domain)
            {
                switch (domain)
                {
                    case "gmail":
                    case "hotmail":
                    case "yahoo":
                    case "aol":
                    case "msn":
                    case "wanadoo":
                    case "orange":
                        return $"{domain} is a popular domain";
                    default:
                        return $"{domain} is a custom domain";
                }
            }

            // Execution

            getEmail();

            Console.WriteLine(getDomain(usersEmail));

        }
    }
}
