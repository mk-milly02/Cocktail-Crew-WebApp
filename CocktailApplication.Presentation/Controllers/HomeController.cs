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

    [Route("{controller}/categories")]
    public async Task<IActionResult> Categories()
    {
        CatergoryViewModel model = new() 
        { 
            CategoryName = "Cocktail",
            Drinks = await _cocktail.Filter("cocktail")
        };
        return View(model);
    }

    [Route("{controller}/categories")]
    [HttpPost]
    public async Task<IActionResult> Categories(string category)
    {
        CatergoryViewModel model = new() 
        { 
            CategoryName = category,
            Drinks = await _cocktail.Filter(category)
        };
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
