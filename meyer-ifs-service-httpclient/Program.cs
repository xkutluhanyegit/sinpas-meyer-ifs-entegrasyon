// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");


var username = "meyer";
var password = "Kth26*98.";
var baseUrl = "https://localhost:7244/api/Person/getall_person";

using (var client = new HttpClient())
{
    var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");

    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

    var response = await client.GetAsync(baseUrl);
    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Response:");
        Console.WriteLine(content);
    }
    else
    {
        Console.WriteLine($"Hata: {(int)response.StatusCode} - {response.ReasonPhrase}");
    }
}