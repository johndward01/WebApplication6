using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApplication6.Models;

namespace WebApplication6.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var client = new HttpClient();
        var root = new Root();
        var url = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita";
        var response = client.GetStringAsync(url).Result;
        root = JsonConvert.DeserializeObject<Root>(response);
        return View(root);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
