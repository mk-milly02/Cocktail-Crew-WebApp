using CocktailApplication.Domain;

namespace CocktailApplication.Presentation.Models;

public class CatergoryViewModel
{
    public string? CategoryName { get; set; }

    public IEnumerable<Drink>? Drinks { get; set; }
}
