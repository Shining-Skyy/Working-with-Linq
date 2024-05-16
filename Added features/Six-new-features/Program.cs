using Six_new_features;

List<ProductEntity> Product = new List<ProductEntity>()
{
    new ProductEntity(1, "Ali", 15),
    new ProductEntity(2, "Amir", 26),
    new ProductEntity(3, "Majid", 30),
    new ProductEntity(3, "Javad", 18),
};

//Chunk method test
int number = 1;
foreach (var category in Product.Chunk(2))
{
    Console.WriteLine("category = " + number);

    foreach (var item in category)
    {
        Console.WriteLine($"...>>> {item.Id} + {item.Name} + {item.Age}");
    }
    Console.WriteLine(new String('-', 20));
    number++;
}

//***********************

//Max and Min Method
var Max = Product.MaxBy(p => p.Age);
Console.WriteLine("oldest age: " + Max.Age);

Console.WriteLine(new String('-', 20));

var Min = Product.MinBy(p => p.Age);
Console.WriteLine("youngest age: " + Min.Age);

//***********************

//Default value if null is returned/ Methods:(first, last, single)...OrDefault
//The condition we set is not equal, so null is returned, we put the default value instead of null
var first = Product.FirstOrDefault(p => p.Id == 8, new ProductEntity(id: 5, name: "Test", age: 5));
Console.WriteLine($"Default Value: Id= {first.Id} Name= {first.Name} Age= {first.Age}");

//***********************

//Take Method
var Take1 = Product.Take(2..);//Display after the first 2 numbers
var Take2 = Product.Take(..3);//Display the first 3 numbers
var Take3 = Product.Take(^2..);//Show the last 2 numbers
foreach (var item in Take3)
{
    Console.WriteLine(item.Age);
}

//***********************

//Zip Method
//Combines 3 arrays together
int[] Ids = new int[] { 1, 2, 3 };
int[] Ages = new int[] { 10, 20, 30 };
string[] Names = new string[] { "ali", "Javad", "amir" };

IEnumerable<(int Id, string Name, int Age)> Zip = Ids.Zip(Names, Ages);
foreach (var item in Zip)
{
    Console.WriteLine($"Result = {item.Id} {item.Name} {item.Age}");
}

//***********************

//TryGetNonEnumeratedCount Method
//It is used instead of the count method for better performance
var counts = Product.TryGetNonEnumeratedCount(out int count);
Console.WriteLine(count);
