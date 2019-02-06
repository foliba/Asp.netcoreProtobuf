using System;
using System.Net.Http;
using System.Net.Http.Headers;
using ProtobufPOC.DTOs;
using Newtonsoft.Json;
using ProtobufPOC.Helpers;

namespace WebClientProtobuf
{
    class Program
    {
        static readonly string baseAddress = "https://localhost:5001/";

        static void Main(string[] args)
        {
            // HTTP GET with Protobuf Response Body
            var client = new HttpClient { BaseAddress = new Uri(baseAddress) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ConfigHelper.GetContentType(ContentType.Protobuf)));

            HttpResponseMessage response = client.GetAsync("api/Values").Result;

            if (response.IsSuccessStatusCode)
            {
                var message = response.Content.ReadAsStreamAsync().Result;
                var dto = ProtoBuf.Serializer.Deserialize<ResponseDTO>(message);


                Console.WriteLine(JsonConvert.SerializeObject(dto));
                var proto = ProtoBuf.Serializer.GetProto<ResponseDTO>();
                Console.WriteLine("Proto:");
                Console.WriteLine(proto);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}