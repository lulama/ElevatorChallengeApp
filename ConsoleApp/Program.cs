// See https://aka.ms/new-console-template for more information
using System.Configuration;

var Api = ConfigurationManager.AppSettings["AppAPI"];
Console.WriteLine("Hello, welcome to elevator application, Enter 1 to to view list of buildings");
int choice = Convert.ToInt32(Console.ReadLine());

if (choice == 1)
{
    var client = new HttpClient();
    var response = await client.GetAsync(Api + "/buildings");
    response.EnsureSuccessStatusCode();
    var result = await response.Content.ReadAsStringAsync();
    Console.WriteLine(result);
}

