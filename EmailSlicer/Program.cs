using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmailSlicer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Ask for users email and store it

            string getEmail()
            {
                // Make sure its an email
                Regex regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");

                Console.Write("Please enter your email: ");
                string email = Console.ReadLine();



                if (!regex.IsMatch(email))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("There seems to be a problem with the format of your email, please try again.\n");

                    Console.ResetColor();

                    return getEmail();

                }

                return email;

            }

            string getDomain(string email)
            {
                //Split the mail into an array of char
                char[] emailToArray = email.ToCharArray();

                List<char> domain = new List<char>();

                //Find and return position of @

                int index = Array.FindIndex(emailToArray, x => x == '@') + 1;

                //Return all the char between the @ and a . to a new array

                for (int i = index; i < emailToArray.Length; i++)
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

            // Check users email for custom or popular domain

            string checkDomain(string domain)
            {
                bool isPopularDomain;

                switch (domain)
                {
                    case "gmail":
                    case "hotmail":
                    case "yahoo":
                    case "aol":
                    case "msn":
                    case "wanadoo":
                    case "orange":
                        isPopularDomain = true;
                        break;
                    default:
                        isPopularDomain = false;
                        break;
                }

                return $"\n{domain.ToUpper()} is a {(isPopularDomain == true ? "popular" : "custom")} domain!";

            }

            // Execution

            Console.WriteLine(
                checkDomain(
                    getDomain(
                        getEmail()
                         )));


        }
    }
}
