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

            // Execution

            askForEmail();

            Console.WriteLine($"{usersEmail}");
        }
    }
}
