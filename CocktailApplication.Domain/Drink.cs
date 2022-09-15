using Newtonsoft.Json;

namespace CocktailApplication.Domain;
public class Drink
    {
        [JsonProperty("idDrink")]
        public string? Id { get; set; }

        [JsonProperty("strDrink")]
        public string? Name { get; set; }

        [JsonProperty("strTags")]
        public string? Tags { get; set; }

        [JsonProperty("strCategory")]
        public string? Category { get; set; }

        [JsonProperty("strAlcoholic")]
        public string? Alcoholic { get; set; }

        [JsonProperty("strGlass")]
        public string? Glass { get; set; }

        [JsonProperty("strInstructions")]
        public string? Instructions { get; set; }

        [JsonProperty("strDrinkThumb")]
        public string? DrinkThumb { get; set; }

        [JsonProperty("strIngredient1")]
        public string? Ingredient1 { get; set; }

        [JsonProperty("strIngredient2")]
        public string? Ingredient2 { get; set; }

        [JsonProperty("strIngredient3")]
        public string? Ingredient3 { get; set; }

        [JsonProperty("strIngredient4")]
        public string? Ingredient4 { get; set; }

        [JsonProperty("strIngredient5")]
        public string? Ingredient5 { get; set; }

        [JsonProperty("strMeasure1")]
        public string? Measure1 { get; set; }

        [JsonProperty("strMeasure2")]
        public string? Measure2 { get; set; }

        [JsonProperty("strMeasure3")]
        public string? Measure3 { get; set; }

        [JsonProperty("strMeasure4")]
        public string? Measure4 { get; set; }

        [JsonProperty("strMeasure5")]
        public string? Measure5 { get; set; }

        [JsonProperty("strImageSource")]
        public string? ImageSource { get; set; }
    }
