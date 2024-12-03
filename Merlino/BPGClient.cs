using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Merlino
{
    public class BPGClient
    {
        private readonly HttpClient client;
        private Preferences prefs;
        private string authToken;



        public BPGClient()
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls;

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };

            client = new HttpClient(handler);
            prefs = Preferences.LoadPreferences();
            //   Login(prefs.BpgUsername, prefs.BpgPassword);
        }

        public async Task<string> Login()
        {

            var request = new HttpRequestMessage(HttpMethod.Post, prefs.BpgUrl);

          


            var requestBody = new
            {
                email = prefs.BpgUsername,
                password = prefs.BpgPassword
            };

            string json = System.Text.Json.JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            request.Content = content;
            var response = await client.PostAsync(prefs.BpgUrl + "/api/login", content);
            response.EnsureSuccessStatusCode();
            string responseStr = await response.Content.ReadAsStringAsync();


            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            AuthResponse authResp = JsonSerializer.Deserialize<AuthResponse>(responseStr, options);

            authToken = authResp.Token;

            return authToken;

        }

        public async void Logout()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, prefs.BpgUrl);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
            var response = await client.PostAsync(prefs.BpgUrl + "/api/logout", null);
            response.EnsureSuccessStatusCode();
        }


        public async Task<List<string>> FilterNumbers(FilterInput input)
        {
            

            // Serializza il corpo della richiesta in formato JSON
            string json = System.Text.Json.JsonSerializer.Serialize(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Aggiungi il token di autenticazione all'header della richiesta
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);


            // Esegui la chiamata POST
            var response = await client.PostAsync(prefs.BpgUrl + "/api/filter-numbers", content);

            // Leggi la risposta
            string result = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };



            List<string> res = JsonSerializer.Deserialize<List<string>>(result, options);



            return res;
        }




    }



    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CompanyId { get; set; }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
        public User User { get; set; }
    }



    public class NumberRow
    {
        public string row { get; set; }
        public string number { get; set; }
    }

    public class FilterInput
    {
        public List<NumberRow> number_list { get; set; }

        public FilterInput() {
            number_list = new List<NumberRow>();
        }
        
    }


}
