// See https://aka.ms/new-console-template for more information

// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

const string EXIT_CONSTANT = "E";
const string ADD_CONSTANT = "A";
const string LOOK_CONSTANT = "L";
const string DELETE_CONSTANT = "D";
const string YES_CONSTANT = "Y";
const string NO_CONSTANT = "N";
const string INVALID_INPUT_CONSTANT = "INVALID INPUT!";

User user = new User("Mario Rossi");
User user1 = new User("Stefano Verdi");
User user2 = new User("Francesca Neri");
List<User> users = new List<User> { user, user1, user2 };

bool cycle = true;

Console.WriteLine("Insert your Username or [Q]uit:");
string login = Console.ReadLine() ?? string.Empty;

while (cycle)
{
    if (!login.ToUpper().Equals(EXIT_CONSTANT))
    {
        foreach (User access in users)
        {
            if (access.Name == login)
            {
                Console.WriteLine($"Welcome {access.Name}!");
                Console.WriteLine($"Select {ADD_CONSTANT} to create a new Library or {LOOK_CONSTANT} to check the existing ones or {EXIT_CONSTANT} to exit the application!");
                string choice = Console.ReadLine() ?? string.Empty;
                switch (choice.ToUpper())
                {
                    case ADD_CONSTANT:
                        bool addListCycle = true;
                        do
                        {
                            Console.WriteLine($"Type the name of the Library you wish to add or {EXIT_CONSTANT} to exit:");
                            choice = Console.ReadLine() ?? string.Empty;
                            if (!choice.ToUpper().Equals(EXIT_CONSTANT))
                            {
                                bool exists = false;
                                if (access.Libraries.Count != 0)
                                {
                                    foreach (Library library in access.Libraries)
                                    {
                                        if (library.Name == choice)
                                        {
                                            exists = true;
                                            Console.WriteLine("List already exists!");
                                        }
                                    }
                                }
                                if (!exists && !choice.Equals(""))
                                {
                                    access.AddList(choice);
                                    Library library = access.GetLibrary(choice);
                                    Console.WriteLine($"List {library.Name} added!");
                                    Console.WriteLine("Do you wish to add any items to this List right now?");
                                    Console.WriteLine($"{YES_CONSTANT} or {NO_CONSTANT}");
                                    choice = Console.ReadLine() ?? string.Empty;
                                    switch (choice.ToUpper())
                                    {
                                        case YES_CONSTANT:
                                            bool itemCycle = true;
                                            do
                                            {
                                                Console.WriteLine($"Insert the title of the Book you wish to add or {EXIT_CONSTANT} to exit:");
                                                choice = Console.ReadLine() ?? string.Empty;
                                                if (!choice.ToUpper().Equals(EXIT_CONSTANT))
                                                {
                                                    exists = false;
                                                    if (library.Books.Count != 0)
                                                    {
                                                        foreach (Book book in library.Books)
                                                        {
                                                            if (book.Name == choice)
                                                            {
                                                                exists = true;
                                                                Console.WriteLine($"{book.Name} already exists!");
                                                            }
                                                        }
                                                    }
                                                    if (library.Books.Count != 0)
                                                    {
                                                        access.HasList(choice);
                                                    }
                                                    if (!exists && !choice.Equals(""))
                                                    {
                                                        Console.WriteLine($"Insert The Author's Name or {EXIT_CONSTANT} to exit:");
                                                        string authorName = Console.ReadLine() ?? string.Empty;
                                                        if (!authorName.ToUpper().Equals(EXIT_CONSTANT))
                                                        {
                                                            bool noError = true;
                                                            while (noError)
                                                            {
                                                                Console.WriteLine($"Insert the Year it was published in or {EXIT_CONSTANT} to exit:");
                                                                string year = Console.ReadLine() ?? string.Empty;
                                                                if (int.TryParse(year, out int y))
                                                                {
                                                                    library.AddBook(choice, authorName, y);
                                                                    Console.WriteLine($"{choice} added successfully!");
                                                                    break;
                                                                }
                                                                else if (year.ToUpper().Equals(EXIT_CONSTANT))
                                                                {
                                                                    Console.WriteLine($"Are You sure You want to end the creation process? {YES_CONSTANT} or {NO_CONSTANT}");
                                                                    choice = Console.ReadLine() ?? string.Empty;
                                                                    if (choice.Equals(YES_CONSTANT))
                                                                    {
                                                                        noError = true;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Please enter a valid year!");
                                                                    Console.WriteLine("Insert the Year it was published in:");
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine($"Are You sure You want to end the creation process? {YES_CONSTANT} or {NO_CONSTANT}");
                                                            choice = Console.ReadLine() ?? string.Empty;
                                                            if (choice.Equals(YES_CONSTANT))
                                                            {
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("There has to be a name for the item!");
                                                    }
                                                }
                                                else
                                                {
                                                    itemCycle = false;
                                                }
                                            } while (itemCycle);
                                            break;
                                        case NO_CONSTANT:
                                            break;
                                        default:
                                            Console.WriteLine(INVALID_INPUT_CONSTANT);
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("The List has to have a name!");
                                }
                            }
                            else
                            {
                                addListCycle = false;
                            }
                        } while (addListCycle);
                        break;
                    case LOOK_CONSTANT:
                        bool lookCycle = true;
                        do
                        {
                            if (access.Libraries.Count == 0)
                            {
                                Console.WriteLine("You have no Libraries to look at!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Available Lists: ");
                                foreach (Library library in access.Libraries)
                                {
                                    Console.WriteLine($"{library.Id}. {library.Name}");
                                }
                                Console.WriteLine($"Type the name of the Library you wish to check or {EXIT_CONSTANT} to get back");
                                choice = Console.ReadLine() ?? string.Empty;
                                if (!choice.ToUpper().Equals(EXIT_CONSTANT))
                                {
                                    foreach (Library library in access.Libraries)
                                    {
                                        if (library.Name == choice)
                                        {
                                            Console.WriteLine(library.Name);
                                            Console.WriteLine($"Type {ADD_CONSTANT} to insert a new item, {LOOK_CONSTANT} to see the Books inside kept in the Library or {EXIT_CONSTANT} to go back");
                                            choice = Console.ReadLine() ?? string.Empty;
                                            switch (choice.ToUpper())
                                            {
                                                case ADD_CONSTANT:
                                                    bool itemCycle = true;
                                                    do
                                                    {
                                                        Console.WriteLine($"Insert the Book you wish to add or {EXIT_CONSTANT} to exit:");

                                                        choice = Console.ReadLine() ?? string.Empty;
                                                        if (!choice.ToUpper().Equals(EXIT_CONSTANT))
                                                        {
                                                            bool exists = false;
                                                            if (library.Books.Count != 0)
                                                            {
                                                                foreach (Book book in library.Books)
                                                                {
                                                                    if (book.Name == choice)
                                                                    {
                                                                        exists = true;
                                                                        Console.WriteLine($"{book} already exists!");
                                                                    }
                                                                }
                                                            }
                                                            if (!exists && !choice.Equals(""))
                                                            {
                                                                Console.WriteLine($"Insert The Author's Name or {EXIT_CONSTANT} to exit:");
                                                                string authorName = Console.ReadLine() ?? string.Empty;
                                                                if (!authorName.ToUpper().Equals(EXIT_CONSTANT))
                                                                {
                                                                    bool noError = true;
                                                                    while (noError)
                                                                    {
                                                                        Console.WriteLine($"Insert the Year it was published in or {EXIT_CONSTANT} to exit:");
                                                                        choice = Console.ReadLine() ?? string.Empty;
                                                                        if (choice.ToUpper().Equals(EXIT_CONSTANT))
                                                                        {
                                                                            Console.WriteLine($"Are You sure You want to end the creation process? {YES_CONSTANT} or {NO_CONSTANT}");
                                                                            if (choice.ToUpper().Equals(YES_CONSTANT))
                                                                            {
                                                                                break;
                                                                            }
                                                                            string year = Console.ReadLine() ?? string.Empty;
                                                                            if (int.TryParse(year, out int y))
                                                                            {
                                                                                library.AddBook(choice, authorName, y);
                                                                                Console.WriteLine($"{choice} added successfully!");
                                                                                break;
                                                                            }
                                                                            else if (year.ToUpper().Equals(EXIT_CONSTANT))
                                                                            {
                                                                                noError = false;
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("Please enter a valid year!");
                                                                                Console.WriteLine("Insert the Year it was published in:");
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine($"Are You sure You want to end the creation process? {YES_CONSTANT} or {NO_CONSTANT}");
                                                                    choice = Console.ReadLine() ?? string.Empty;
                                                                    if (choice.ToUpper().Equals(YES_CONSTANT))
                                                                    {
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("There has to be a name for the item!");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            itemCycle = false;
                                                        }
                                                    } while (itemCycle);
                                                    break;
                                                case LOOK_CONSTANT:
                                                    library.ShowList();
                                                    Console.WriteLine($"Press {DELETE_CONSTANT} to delete a book or {EXIT_CONSTANT} to go back");
                                                    choice = Console.ReadLine() ?? string.Empty;
                                                    switch (choice.ToUpper())
                                                    {
                                                        case DELETE_CONSTANT:
                                                            Console.WriteLine("Insert the Index of the book you want to delete");
                                                            choice = Console.ReadLine() ?? string.Empty;
                                                            if (int.TryParse(choice, out int index) && library.HasBook(index))
                                                            {
                                                                Console.WriteLine($"Press {YES_CONSTANT} to delete the book or {NO_CONSTANT} to go back");
                                                                if (choice.ToUpper().Equals(YES_CONSTANT))
                                                                {
                                                                    library.DeleteBook(index);
                                                                    Console.WriteLine("Book deleted successfully!");
                                                                }

                                                            }
                                                            else if (int.TryParse(choice, out index) && !library.HasBook(index))
                                                            {
                                                                Console.WriteLine("That book does not exist!");
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine(INVALID_INPUT_CONSTANT);
                                                            }
                                                            break;
                                                        case EXIT_CONSTANT:
                                                            break;
                                                        default:
                                                            Console.WriteLine(INVALID_INPUT_CONSTANT);
                                                            break;
                                                    }
                                                    break;
                                                case EXIT_CONSTANT:
                                                    break;
                                                default:
                                                    Console.WriteLine($"{INVALID_INPUT_CONSTANT}");
                                                    break;
                                            }
                                        }
                                        else if (choice.ToUpper().Equals(EXIT_CONSTANT))
                                        {
                                            lookCycle = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Input doesn't match any of the existing Libraries! Try again!");
                                        }
                                    }
                                }
                                else
                                {
                                    lookCycle = false;
                                }
                            }
                        } while (lookCycle);
                        break;
                    case EXIT_CONSTANT:
                        cycle = false;
                        break;
                    default:
                        Console.WriteLine(INVALID_INPUT_CONSTANT);
                        break;
                }
            }
        }
    }
    else if (login.ToUpper().Equals(EXIT_CONSTANT))
    {
        Console.WriteLine($"Goodbye! See you next time!");
        cycle = false;
    }
    else
    {
        Console.WriteLine($"Invalid Username! Insert a valid Username or {EXIT_CONSTANT} to exit:");
        cycle = false;
    }
}

public class Book
{

    public int Id { get; set; }

    public string Name { get; set; }

    public string Author { get; set; }

    public int Published { get; set; }

    public Book()
    { }

    public Book(int number, string title, string author, int year)
    {
        Id = number;
        Name = title;
        Author = author;
        Published = year;
    }

}

public class Library
{

    public int Id { get; set; }

    public string Name { get; set; }

    public List<Book> Books { get; set; }

    public Library() { }

    public Library(int id, string name)
    {
        Id = id;
        Name = name;
        Books = new List<Book>();
    }

    public void ShowList()
    {
        Console.WriteLine($"Available Books:");
        foreach (Book book in Books)
        {
            Console.WriteLine($"Id:{book.Id} - Author:{book.Author}: {book.Name}");
        }
    }

    public Book GetBook(int index)
    {
        Book bookById = new Book();
        foreach (Book book in Books)
        {
            if (book.Id == index)
            {
                bookById = book;
            }
        }
        return bookById;
    }

    public void AddBook(string name, string author, int year)
    {
        Books.Add(new Book(Books.Count + 1, name, author, year));
    }

    public bool HasBook(int index)
    {
        bool hasBook = false;
        foreach (Book book in Books)
        {
            if (book.Id == index)
            {
                hasBook = true;
            }
        }
        return hasBook;
    }

    public void DeleteBook(int index)
    {
        foreach (Book book in Books)
        {
            if (book.Id == index)
            {
                Books.Remove(book);
                break;
            }
        }
    }
}

public class User
{
    public string Name { get; set; }

    public List<Library> Libraries { get; set; }

    public List<Book> BorrowedBooks { get; set; }

    public User(string fullName)
    {
        Name = fullName;
        Libraries = new List<Library>();
        BorrowedBooks = new List<Book>();
    }

    public void AddList(string list)
    {
        Libraries.Add(new Library(Libraries.Count + 1, list));
    }

    public Library GetLibrary(string name)
    {
        Library List = new Library();
        foreach (Library list in Libraries)
        {
            if (list.Name == name)
            {
                List = list;
            }
        }
        return List;
    }

    public bool HasList(string name)
    {
        bool hasList = false;
        foreach (Library list in Libraries)
        {
            if (list.Name == name)
            {
                hasList = true;
            }
            else
            {
                hasList = false;
            }
        }
        return hasList;
    }

    public void DeleteList(int index)
    {
        foreach (Library list in Libraries)
        {
            if (list.Id == index)
            {
                Libraries.Remove(list);
                break;
            }
        }
    }

    public void DeleteBook(int index)
    {
        foreach (Book book in BorrowedBooks)
        {
            if (book.Id == index)
            {
                BorrowedBooks.Remove(book);
                break;
            }
        }
    }

}