using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyUrlApp
{
    public class TinyUrlService
    {
        private Dictionary<string, string> shortToLongUrlMap; // Map to store short URL to long URL mapping
        private Dictionary<string, int> urlClickCountMap; // Map to store short URL click count

        //Constructor
        public TinyUrlService()
        {
            shortToLongUrlMap = new Dictionary<string, string>();
            urlClickCountMap = new Dictionary<string, int>();
        }

        // Method to create a short URL with associated long URL
        public string CreateShortUrl(string longUrl = "www.adroit-tt.com", string customShortUrl = null)
        {
            string shortUrl = customShortUrl ?? GenerateShortUrl();

            if (shortToLongUrlMap.ContainsKey(shortUrl))
            {
                throw new ArgumentException("Short URL already exists.");
            }

            shortToLongUrlMap.Add(shortUrl, longUrl);
            urlClickCountMap.Add(shortUrl, 0); // Initialize click count to 0

            return shortUrl;
        }

        // Method to delete a short URL
        public void DeleteShortUrl(string shortUrl)
        {
            if (shortToLongUrlMap.ContainsKey(shortUrl))
            {
                shortToLongUrlMap.Remove(shortUrl);
                urlClickCountMap.Remove(shortUrl);
            }
            else
            {
                throw new ArgumentException("Short URL does not exist.");
            }
        }

        // Method to get the long URL from a short URL
        public string GetLongUrl(string shortUrl)
        {
            if (shortToLongUrlMap.ContainsKey(shortUrl))
            {
                urlClickCountMap[shortUrl]++; // Increment click count
                return shortToLongUrlMap[shortUrl];
            }
            else
            {
                throw new ArgumentException("Short URL does not exist.");
            }
        }

        // Method to get the number of times a short URL has been clicked
        public int GetClickCount(string shortUrl)
        {
            if (urlClickCountMap.ContainsKey(shortUrl))
            {
                return urlClickCountMap[shortUrl];
            }
            else
            {
                throw new ArgumentException("Short URL does not exist.");
            }
        }


        // Helper method to generate a random short URL
        private string GenerateShortUrl()
        {
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const int shortUrlLength = 8; // We can adjust the length of the short URL as needed

            Random random = new Random();
            char[] chars = new char[shortUrlLength];

            for (int i = 0; i < shortUrlLength; i++)
            {
                chars[i] = allowedChars[random.Next(allowedChars.Length)];
            }

            return new string(chars);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string? inLongUrl = null;
            string? inShortUrl = null;
            if (!args?.Any() ?? true)
            {
                Console.WriteLine("Enter a Long URL:");
                inLongUrl = Console.ReadLine();

                Console.WriteLine("Do you want to enter a short URL(Optional): y/n");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    Console.WriteLine("Enter a short URL:");
                    inShortUrl = Console.ReadLine();
                }


            }
            else
            {

                if (args.Length == 1)
                {
                    inLongUrl = args[0];
                }
                else if (args.Length == 2)
                {
                    inLongUrl = args[0];
                    inShortUrl = args[1];
                }
            }



            TinyUrlService tinyUrlService = new TinyUrlService();

            string shortUrl = tinyUrlService.CreateShortUrl(inLongUrl, inShortUrl);
            Console.WriteLine($"Short URL: {shortUrl}");

            string longUrl = tinyUrlService.GetLongUrl(shortUrl);
            Console.WriteLine($"Long URL: {longUrl}");

            int clickCount = tinyUrlService.GetClickCount(shortUrl);
            Console.WriteLine($"Click Count: {clickCount}");

            tinyUrlService.GetLongUrl(shortUrl); //Click again 

            clickCount = tinyUrlService.GetClickCount(shortUrl);
            Console.WriteLine($"Click Count: {clickCount}");

            tinyUrlService.DeleteShortUrl(shortUrl);
            Console.WriteLine($"Short URL deleted.");
        }
    }
}