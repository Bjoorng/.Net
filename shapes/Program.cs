// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using System.Runtime.InteropServices.Marshalling;
using System.Xml.Serialization;

const string RECTANGLE_CONSTANT = "R";
const string CIRCLE_CONSTANT = "C";
const string PERIMETRO_CONSTANT = "P";
const string AREA_CONSTANT = "A";
const string EXIT_CONSTANT = "E";
const string INPUT_ERROR_CONSTANT = "Input Non Valido";

bool keepGoing = true;

while (keepGoing)
{
    Console.WriteLine("Benvenuto nel calcolatore di forme geometriche");
    Console.WriteLine("Quale figura vuoi calcolare? [R]ettangolo o [C]erchio?");
    Console.WriteLine("Premi [E] per uscire");
    string userChoice = Console.ReadLine();

    switch (userChoice.ToUpper())
    {
        case RECTANGLE_CONSTANT:

            Console.WriteLine("inserisci la base del rettandolo");
            bool hasBase = int.TryParse(Console.ReadLine(), out int baseSize);
            Console.WriteLine("inserisci l'altezza' del rettandolo");
            bool hasHeight = int.TryParse(Console.ReadLine(), out int heightSize);

            if (hasBase && hasHeight)
            {
                bool keepCalculating = true;
                Rectangle rectangle = new Rectangle(baseSize, heightSize);
                while(keepCalculating){
                    Console.WriteLine("Vuoi calcolare il [P]erimetro o l'[A]rea? Vuoi un nuovo [R]ettangolo? [E] per uscire");
                    userChoice = Console.ReadLine();
                    switch (userChoice.ToUpper())
                    {
                        case PERIMETRO_CONSTANT:
                            Console.WriteLine($"Base: {rectangle.Side} - Altezza: {rectangle.Height}");
                            Console.WriteLine($"Perimetro del rettangolo: {rectangle.CalculatePerimeter()}");
                            break;
                        case AREA_CONSTANT:
                            Console.WriteLine($"Base: {rectangle.Side} - Altezza: {rectangle.Height}");
                            Console.WriteLine($"Area del rettangolo: {rectangle.CalculateArea()}");
                            break;
                        case RECTANGLE_CONSTANT:
                            Console.WriteLine("Inserisci una nuova base");
                            bool newBaseString = int.TryParse(Console.ReadLine(), out int newBase);
                            Console.WriteLine("Inserisci una nuova altezza");
                            bool newHeightString = int.TryParse(Console.ReadLine(), out int newHeight);
                            if(!newBaseString){
                                Console.WriteLine("Inserisci un numero valido per la base");
                            }else if(!newHeightString){
                                Console.WriteLine("Inserisci un numero valido per l'altezza");
                            }else{
                                rectangle = new Rectangle(newBase, newHeight);
                            }
                            break;   
                        case EXIT_CONSTANT:
                            keepCalculating = false;
                            break;    
                        default:
                            Console.WriteLine(INPUT_ERROR_CONSTANT);
                            break;
                    }
                }
            }
                else
                {
                    Console.WriteLine(INPUT_ERROR_CONSTANT);
                }
                break;
            case CIRCLE_CONSTANT:

            Console.WriteLine("inserisci in raggio del cerchio");
            bool hasRadius = int.TryParse(Console.ReadLine(), out int radius);

            if (hasRadius)
            {
                bool keepCalculating = true;
                Circle circle = new Circle(radius);
                while(keepCalculating){
                    Console.WriteLine("Vuoi calcolare il [P]erimetro o l'[A]rea? [E] per uscire");
                    userChoice = Console.ReadLine();
                    switch (userChoice.ToUpper())
                    {
                        case PERIMETRO_CONSTANT:
                            Console.WriteLine($"Raggio: {circle.Side}");
                            Console.WriteLine($"Circonferenza: {circle.CalculatePerimeter()}");
                            break;
                        case AREA_CONSTANT:
                            Console.WriteLine($"Raggio: {circle.Side}");
                            Console.WriteLine($"Area del cerchio: {circle.CalculateArea()}");
                            break;
                            case CIRCLE_CONSTANT:
                            Console.WriteLine("Inserisci un nuovo raggio");
                            bool newRadiusString = int.TryParse(Console.ReadLine(), out int newRadius);
                            if(!newRadiusString){
                                Console.WriteLine("Inserisci un numero valido per il raggio");
                            }else{
                                circle = new Circle(newRadius);
                            }
                            break;   
                        case EXIT_CONSTANT:
                            keepCalculating = false;
                            break;    
                        default:
                            Console.WriteLine(INPUT_ERROR_CONSTANT);
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine(INPUT_ERROR_CONSTANT);
            }
            break;
        case EXIT_CONSTANT:
            Console.WriteLine("Addios!");
            keepGoing = false;
            break;
        default:
            Console.WriteLine(INPUT_ERROR_CONSTANT);
            keepGoing = false;
            break;
    }
}

public interface IShape
{
    int Side { get; set; }

    public int CalculateArea();

    public int CalculatePerimeter();

}

public class Rectangle : IShape
{
    public int Side { get; set; }

    public int Height { get; set; }

    public Rectangle(int side1, int side2)
    {
        Side = side1;
        Height = side2;
    }

    public int CalculateArea()
    {
        int Area = Side * Height;
        return Area;
    }

    public int CalculatePerimeter()
    {
        int Perimeter = 2 * (Side + Height);
        return Perimeter;
    }

}

public class Circle : IShape
{
    public int Side { get; set; }

    public Circle(int side)
    {
        Side = side;
    }

    public int CalculateArea()
    {
        int Area = (int)(Math.PI * Math.Pow(Side, 2));
        return Area;
    }

    public int CalculatePerimeter()
    {
        int Perimeter = 2 * (int)(Math.PI * Side);
        return Perimeter;
    }
}