using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;

namespace MagicWrighterHomework
{
    class DogsApp

    {
        static void Main(string[] args)
        {

            bool repeat = false;
            do
            {
                Console.WriteLine("Press 1 to view all dog Breeds:");
                Console.WriteLine("Press 2 to save a random image of a dog:");
                string response = Console.ReadLine();
                if (response == "1")
                {
                    GetBreeds();
                }
                if (response == "2")
                {
                    DownloadImage();
                }
                if (response != "1" || response != "2")
                {
                    Console.WriteLine("Please enter 1 or 2");
                    repeat = true;
                }
                Console.WriteLine("Continue? (y/n)");
                string answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    repeat = true;
                }
                if (answer == "n")
                {
                    repeat = false;
                }
            } while (repeat == true);
        }


        public static void GetBreeds()
        {
            string breedUrl = "https://dog.ceo/api/breeds/list/all";
            string breeds = CallRestMethod(breedUrl);
            Console.WriteLine(breeds);
        }

        private static string CallRestMethod(string breedUrl)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(breedUrl);
            webRequest.Method = "GET";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Encoding enc = Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webResponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webResponse.Close();
            return result;
        }

        public static void DownloadImage()
        {

            using (WebClient webClient = new WebClient())
            {
                string url = "https://dog.ceo/api/breeds/image/random";
                string fileName = "C:\\Windows\\Temp\\dog.jpg";
                webClient.DownloadFile(url, fileName);
                Console.WriteLine($"Image successfully downloaded to {fileName}");
            }
        }
    }
}
