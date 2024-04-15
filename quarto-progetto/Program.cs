// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

// public private o internal(INTERNAL PERMETTE DI ACCEDERE A DEI DATI SOLO DA UNA SPECIFICA ASSEMBLY)

using System.Security.Cryptography.X509Certificates;

public interface IPersona
{
    int sum(int a, int b);
}

public abstract class Persona
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double RAL { get; set; }

    public Persona(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

public class Dipendente : Persona
{

    public string Role { get; set; }

    public Dipendente(string firstName, string lastName, string role) : base(firstName, lastName)
    {
        Role = role;
    }

}

public class Dirigente : Persona
{

}