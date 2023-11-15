using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConAppAssignment13_15th_nov_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 3: Prompt user to enter text
            Console.WriteLine("Enter a piece of text:");
            string userInput = Console.ReadLine();

            // Step 4: Call implemented methods and display results
            int wordCount = CountWords(userInput);
            List<string> emailAddresses = ValidateEmailAddresses(userInput);
            List<string> mobileNumbers = ExtractMobileNumbers(userInput);

            Console.WriteLine($"Word Count: {wordCount}");
            Console.WriteLine("Email Addresses:");
            foreach (var email in emailAddresses)
            {
                Console.WriteLine(email);
            }

            Console.WriteLine("Mobile Numbers:");
            foreach (var number in mobileNumbers)
            {
                Console.WriteLine(number);
            }

            // Step 5: Custom Regex search
            Console.WriteLine("Enter a custom regular expression:");
            string customRegex = Console.ReadLine();
            List<string> customMatches = PerformCustomRegexSearch(userInput, customRegex);

            Console.WriteLine("Custom Regex Matches:");
            foreach (var match in customMatches)
            {
                Console.WriteLine(match);
            }
        }

        // Step 2: Count Words
        static int CountWords(string text)
        {
            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        // Step 3: Validate Email Addresses
        static List<string> ValidateEmailAddresses(string text)
        {
            var emailRegex = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b");
            var matches = emailRegex.Matches(text);

            var emailList = new List<string>();
            foreach (Match match in matches)
            {
                emailList.Add(match.Value);
            }

            return emailList;
        }

        // Step 4: Extract Mobile Numbers
        static List<string> ExtractMobileNumbers(string text)
        {
            var mobileRegex = new Regex(@"\b\d{10}\b");
            var matches = mobileRegex.Matches(text);

            var mobileList = new List<string>();
            foreach (Match match in matches)
            {
                mobileList.Add(match.Value);
            }

            return mobileList;
        }

        // Step 5: Perform Custom Regex Search
        static List<string> PerformCustomRegexSearch(string text, string customRegex)
        {
            var customRegexObj = new Regex(customRegex);
            var matches = customRegexObj.Matches(text);

            var resultList = new List<string>();
            foreach (Match match in matches)
            {
                resultList.Add(match.Value);
            }

            return resultList;
        }
    }
}
