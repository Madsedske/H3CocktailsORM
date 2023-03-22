using H3CocktailsORM;

var databaseManager = new DatabaseManager();
DrinkManager drinkManager = new DrinkManager(databaseManager);

var context = databaseManager.CreateContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();
context.SaveChanges();
context = databaseManager.CreateContext();


Console.WriteLine("Hvilken drink vil du lave?");
string name = Console.ReadLine();
Console.WriteLine($"Du valgte {name}..!");
Console.WriteLine("Hvad skal der i?");
var ingridents1 = Console.ReadLine();
Console.WriteLine("Skriv i ml hvor meget der skal i.");
var ingridents1ML = Console.ReadLine();


var ingredient = new Ingredient()
{
    Name = ingridents1
};

context.Ingredients.Add(ingredient);
context.SaveChanges();

context = databaseManager.CreateContext();

var recipe = new Recipe
{
    Ingredients = new Dictionary<Ingredient, double>
    {
        { ingredient, double.Parse(ingridents1ML!) },
    }
};

context = databaseManager.CreateContext();

var drink = new Drink
{
    Name = name!,
    Recipe = recipe,
};

context.Drinks.Add(drink);
context.SaveChanges();


Console.WriteLine("Din drink er hentet fra databasen.");
var hentetDrink = drinkManager.GetDrink(name);
Console.WriteLine(hentetDrink.Name +" " + hentetDrink.Recipe);


Console.ReadKey();