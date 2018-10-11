using System;
using System.Net.Http;
using System.Net.Http.Headers;
using ProtobufPOC.DTOs;
using Newtonsoft.Json;

namespace WebClientProtobuf
{
    class Program
    {
        static void Main(string[] args)
        {
            // HTTP GET with Protobuf Response Body
            var client = new HttpClient { BaseAddress = new Uri("https://localhost:5001/") };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));

            HttpResponseMessage response = client.GetAsync("api/Values").Result;

            if (response.IsSuccessStatusCode)
            {
                var message = response.Content.ReadAsStreamAsync().Result;
                var dto = ProtoBuf.Serializer.Deserialize<ResponseDTO>(message);

                Console.WriteLine(JsonConvert.SerializeObject(dto));

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            Console.ReadLine();
        }
    }
}