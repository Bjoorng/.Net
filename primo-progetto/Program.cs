// See https://aka.ms/new-console-template for more information

// do
// {
//     if (int.TryParse(userChoice, out int year))
//     {
//         if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
//         {
//             Console.WriteLine("Leap Year");
//         }
//         else
//         {
//             Console.WriteLine("Not a  Leap Year");
//         }
//         Console.WriteLine("Insert a Year to use the method or E to exit: ");
//         userChoice = Console.ReadLine();
//     }
//     else
//     {
//         if (userChoice.ToUpper() != "E")
//         {
//             Console.WriteLine("Not a valid Input");
//             Console.WriteLine("Insert a Year to use the method or E to exit: ");
//             userChoice = Console.ReadLine();
//         }
//         else
//         {
//             cycle = false;
//             System.Console.WriteLine("Cycle exited. Thank You for trying It");
//         }
//     }
// } while (cycle);

// Console.WriteLine("Insert a Year to use the method or E to exit: ");



Boolean cycle = true;

do
{
    String userChoice = Console.ReadLine();
    if (userChoice.ToUpper() == "E")
    {
        cycle = false;
        System.Console.WriteLine("Cycle terminated. Thank You for trying It");
    }
    else if (int.TryParse(userChoice, out int year))
    {
        if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
        {
            Console.WriteLine("Leap Year");
        }
        else
        {
            Console.WriteLine("Not a  Leap Year");
        }
        Console.WriteLine("Insert a Year to use the method or E to exit: ");
    }
    else
    {
        if (userChoice == "")
        {
            Console.WriteLine("You need to insert a value");
            Console.WriteLine("Insert a Year to use the method or E to exit: ");
        }
        else
        {
            Console.WriteLine("Not a valid Input");
            Console.WriteLine("Insert a Year to use the method or E to exit: ");
        }
    }
} while (cycle);
