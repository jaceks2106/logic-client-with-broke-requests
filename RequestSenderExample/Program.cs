﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RequestSenderExample
{
    class Program
    {
        static async Task Main()
        {
            const string url = "http://localhost:5000/testapi/file";
            var client = new HttpClient();

            while (true)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Please click [T] to send wrong content-type");
                Console.WriteLine("Please click [D] to send wrong content-disposition");
                Console.WriteLine("Please click [Esc] key to end...");

                var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new MultipartFormDataContent()
                };

                var key = GetProperKey();
                switch (key)
                {
                    case ConsoleKey.T:
                        // API throws InvalidDataException
                        request.BreakHeaderContentType();
                        break;
                    case ConsoleKey.D:
                        // API throws ArgumentNullException
                        request.BreakHeaderContentDisposition();
                        break;
                    default:
                        return;
                }

                Console.Clear();
                Console.WriteLine("Sending request...");

                try
                {
                    var response = await client.SendAsync(request).ConfigureAwait(false);
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"{response.StatusCode}: {content}");
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static ConsoleKey GetProperKey()
        {
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.T:
                    case ConsoleKey.D:
                    case ConsoleKey.Escape:
                        return key.Key;
                    default:
                        break;
                }
            }
        }
    }
}
