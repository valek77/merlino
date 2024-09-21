using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Merlino
{


    public class OllamaClient
    {
        public string ServerUrl { get; set; }
        public string Model { get; set; }

        private static readonly HttpClient client = new HttpClient();

        public OllamaClient(string serverUrl, string model)
        {
            ServerUrl = serverUrl;
            Model = model;
        }

        public async Task<ApiResponse> SendMessages(List<Message> messages)
        {
            var requestBody = new
            {
                model = Model,
                stream = false,
                messages = messages
            };

            // Serializza il corpo della richiesta in formato JSON
            string json = System.Text.Json.JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Esegui la chiamata POST
            var response = await client.PostAsync(ServerUrl, content);

            // Leggi la risposta
            string result = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };


            // Deserializza la risposta in un oggetto ApiResponse
            ApiResponse apiResponse = JsonSerializer.Deserialize<ApiResponse>(result,options);

      

            return apiResponse;
        }



        public async Task<ApiResponse> SendMessages(string message)
        {

            var messages = new List<Message>
                {
                new Message("user", message)
                };


            var requestBody = new
            {
                model = Model,
                stream = false,
                messages = messages
            };

            // Serializza il corpo della richiesta in formato JSON
            string json = System.Text.Json.JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Esegui la chiamata POST
            var response = await client.PostAsync(ServerUrl, content);

            // Leggi la risposta
            string result = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };


            // Deserializza la risposta in un oggetto ApiResponse
            ApiResponse apiResponse = JsonSerializer.Deserialize<ApiResponse>(result, options);



            return apiResponse;
        }
    }

    public class ApiResponse
    {
        public string Model { get; set; }
        public string CreatedAt { get; set; } // Usa string per i timestamp, così come appaiono nel JSON
        public Message message { get; set; }  // L'oggetto message
        public string DoneReason { get; set; }
        public bool Done { get; set; }
        public long TotalDuration { get; set; }
        public long LoadDuration { get; set; }
        public int PromptEvalCount { get; set; }
        public long PromptEvalDuration { get; set; }
        public int EvalCount { get; set; }
        public long EvalDuration { get; set; }
    }

        public class Message
    {
        public string Role { get; set; }
        public string Content { get; set; }

        public Message() { }

        public Message(string role, string content)
        {
            Role = role;
            Content = content;
        }
    }



}
