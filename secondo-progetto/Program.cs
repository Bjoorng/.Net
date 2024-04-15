// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

// DICHIARAZIONE DI UN ARRAY

using System.Diagnostics.CodeAnalysis;

int[] numbers = new int[10];

numbers[0] = 0;

var intsvar = new int[10];

int[] numbers1 = [0, 1, 9, 5];

int[] numbers2 = new int[3] { 0, 1, 2 };

// for(int i = 0; i < numbers.Length; i++){
//     System.Console.WriteLine(numbers2[i]);
// }

// foreach(int number in numbers1){
//     System.Console.WriteLine(number);
// }

Console.WriteLine("Insert a number. Upon reaching 10 values You'll get the total!");

int getSum = 0;
for (int i = 0; i < numbers.Length; i++)
{
    String userValue = Console.ReadLine();
    if (!int.TryParse(userValue, out numbers[i]))
    {
        i--;
        Console.WriteLine("Insert a Valid Input!");
        Console.WriteLine(10 - (i+1) + " Numbers To Go!");
    }
}

Console.WriteLine(getSum);