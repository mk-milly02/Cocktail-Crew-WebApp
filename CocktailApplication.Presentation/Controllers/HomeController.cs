using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CocktailApplication.Presentation.Models;
using CocktailApplication.Service;

namespace CocktailApplication.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IApiService _cocktail;

    public HomeController(IApiService cocktail)
    {
        _cocktail = cocktail;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("{controller}/list-ingredients")]
    public async Task<IActionResult> Ingredients()
    {
        List<string> model = new();
        var results = await _cocktail.GetAllIngredients();

        foreach (var drink in results!)
        {
            model.Add(drink.Ingredient1!);
        }

        return View(model);
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
