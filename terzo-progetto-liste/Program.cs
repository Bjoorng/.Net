// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// List<int> numbers = new List<int>();

// var intList = new List<int>();

// List<int> intList2 = new(); //versione C#12

// List<int> ints = [ 1, 2, 3, 4]; //versione C#12

// List<int> ints2 = new() {1, 2, 3};

// var listVar = new List<int>() {1, 2, 3, 4};

// numbers.Add(1);
// numbers.AddRange(ints2);
// numbers.Remove(1);
// numbers.RemoveAll(x => true);
// numbers.RemoveAt(8);
// numbers.Insert(1, 2); 

// foreach(var i in numbers);

System.Console.WriteLine("Insert Your values:");

List<int> numbers = new();
String userChoice = string.Empty;

do
{
    userChoice = Console.ReadLine();
    if (numbers.Count() == 0 && userChoice.ToUpper() == "E")
    {
        userChoice = string.Empty;
        Console.WriteLine("The List is EMPTY. Add Something before closing");
    }
    else
    {
        if (userChoice.ToUpper() == "E")
        {
            Console.WriteLine($"Min Value in the list: {numbers.Min()}");
            Console.WriteLine($"Max Value in the list: {numbers.Max()}");
            Console.WriteLine($"Sum: {numbers.Sum()}");
            Console.WriteLine($"Average: {numbers.Average()}");
            Console.WriteLine("Ascending order:");
            foreach (var number in numbers.OrderBy(x => x))
            {
                Console.Write($"{number} ,");
            }
            Console.WriteLine("\nCycle terminated. Thank You for trying It");
        }
        else if (int.TryParse(userChoice, out int number))
        {
            numbers.Add(number);
            Console.WriteLine("Insert a Number to keep going or E to exit: ");
        }
        else
        {
            if (userChoice == "")
            {
                Console.WriteLine("You need to insert a value");
                Console.WriteLine("Insert a Number to keep going or E to exit: ");
            }
            else
            {
                Console.WriteLine("Not a valid Input");
                Console.WriteLine("Insert a Number to keep going or E to exit: ");
            }
        }
    }
} while (userChoice.ToUpper() != "E");

