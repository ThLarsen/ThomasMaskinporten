using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThomasMaskinporten.Core;

public static class MaskinportenWebClient
{
    public static async Task<MaskinportenResponse> ExchangeTokenAsync(string outgoingtoken)
    {
        using (var client = new HttpClient())
        {   
            //Headers
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            
            //Body
            var Body = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "urn:ietf:params:oauth:grant-type:jwt-bearer"),
                new KeyValuePair<string, string>("assertion", outgoingtoken)
            };

            //Request
            var Request = new HttpRequestMessage(HttpMethod.Post, "https://ver2.maskinporten.no/token")
            {
                Content = new FormUrlEncodedContent(Body)
            };

            //Response
            string Result = await client.SendAsync(Request).Result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<MaskinportenResponse>(Result);
        }        
    }
}