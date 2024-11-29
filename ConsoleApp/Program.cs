// See https://aka.ms/new-console-template for more information
using System.Configuration;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

var Api = ConfigurationManager.AppSettings["AppAPI"];
Console.WriteLine("Hello, welcome to elevator application");
Console.WriteLine("Enter 1 to to view list of buildings");
Console.WriteLine("Enter 2 to view list of elevators");
int choice = Convert.ToInt32(Console.ReadLine());

switch (choice)
{
    case 1:
        await ListBuildings(Api);
        break;
    case 2:
       await ListElevators(Api);
        break;
    default:
        Console.WriteLine("Invalid Choice");
        break;
}


    static async Task ListBuildings(string Api)
    {
        var client = new HttpClient();
        var response = await client.GetAsync(Api + "/buildings");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);
        Console.ReadLine();
    }

static async Task ListElevators(string Api)
{
    var client = new HttpClient();
    var response = await client.GetAsync(Api + "/elevators");
    response.EnsureSuccessStatusCode();
    var result = await response.Content.ReadAsStringAsync();
    Console.WriteLine(result);
}




