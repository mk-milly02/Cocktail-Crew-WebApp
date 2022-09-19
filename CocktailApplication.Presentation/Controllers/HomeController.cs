using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CocktailApplication.Presentation.Models;
using CocktailApplication.Service;
using CocktailApplication.Domain;

namespace CocktailApplication.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IApiService _cocktail;

    public HomeController(IApiService cocktail)
    {
        _cocktail = cocktail;
    }

    public async Task<IActionResult> Index()
    {
        Drink? model = await _cocktail.Lookup();
        return View(model);
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

    [Route("{controller}/results")]
    public async Task<IActionResult> Search(string name)
    {
        var model = await _cocktail.Search(name);
        return model != null ? View(model) : View("NoResultsFound");
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
