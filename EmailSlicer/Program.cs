using System;
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

            string askForEmail()
            {
                // Make sure its an email
                Regex regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");

                string email = Console.ReadLine();



                if (!regex.IsMatch(email))
                {
                    Console.WriteLine("There seems to be a problem with your email, please try again.");

                    return askForEmail();

                }

                return usersEmail = email;

            }

            // Check users email for custom or popular domain


            string checkEmailDomain(string email)
            {
                //Split the mail into an array of char
                char[] emailToArray = email.ToCharArray();

                char[] domain = new char[10];

                int start = 0;

                //Find and return position of @

                var index = Array.FindIndex(emailToArray, x => x == '@');

                //Return all the char between the @ and a . to a new array

                for (int i = index + 1; i < emailToArray.Length; i++)
                {
                  
                    if (emailToArray[i] == '.')
                    {
                        break;
                    }

                    domain[start] = emailToArray[i];

                    start++;

                }

                string domainName = String.Join("", domain);

                //Create a string from the array

                return domainName;

            }
                
            string checkForKnownDomains(string domain)
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
                        return $"{ domain} is a popular domain";
                    default:
                        return $"{domain} is a custom domain";
                }
            }

            // Execution

            askForEmail();

            Console.WriteLine(checkForKnownDomains(checkEmailDomain(usersEmail)));
        }
    }
}
