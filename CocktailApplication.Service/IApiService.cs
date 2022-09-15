using CocktailApplication.Domain;

namespace CocktailApplication.Service;

public interface IApiService
{
    //Search cocktail by name
    Task<IEnumerable<Drink>?> Search(string name);

    //Lookup a random cocktail
    Task<Drink?> Lookup();

    //Filter by category
    Task<IEnumerable<Drink>?> Filter(string category);
    
    //List by ingredients
    Task<IEnumerable<Drink>?> GetAllIngredients();
}
