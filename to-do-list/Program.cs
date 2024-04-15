// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

const string EXIT_CONSTANT = "E";
const string ADD_CONSTANT = "A";
const string LOOK_CONSTANT = "L";
const string YES_CONSTANT = "Y";
const string NO_CONSTANT = "N";

User user = new User("Bjoorng");

bool cycle = true;

Console.WriteLine("Insert your Username or [Q]uit:");
string login = Console.ReadLine() ?? string.Empty;

while (cycle)
{
    if (user.Name == login)
    {
        Console.WriteLine($"Welcome {user.Name}!");
        Console.WriteLine($"Select {ADD_CONSTANT} to create a new List or {LOOK_CONSTANT} to check the existing ones or {EXIT_CONSTANT} to exit the application!");
        string choice = Console.ReadLine() ?? string.Empty;
        switch (choice.ToUpper())
        {
            case ADD_CONSTANT:
                bool addListCycle = true;
                do
                {
                    Console.WriteLine($"Type the name of the list you wish to add or {EXIT_CONSTANT} to exit:");
                    choice = Console.ReadLine() ?? string.Empty;
                    if (!choice.ToUpper().Equals(EXIT_CONSTANT))
                    {
                        bool exists = false;
                        if (user.Tasks.Count != 0)
                        {
                            foreach (TaskList list in user.Tasks)
                            {
                                if (list.Action == choice)
                                {
                                    exists = true;
                                    Console.WriteLine("List already exists!");
                                }
                            }
                        }
                        if (!exists && !choice.Equals(""))
                        {
                            user.AddList(choice);
                            TaskList list = user.GetTaskList(choice);
                            Console.WriteLine($"List {choice} added!");
                            Console.WriteLine("Do you wish to add any items to this List right now?");
                            Console.WriteLine($"{YES_CONSTANT} or {NO_CONSTANT}");
                            choice = Console.ReadLine() ?? string.Empty;
                            switch (choice.ToUpper())
                            {
                                case YES_CONSTANT:
                                    bool itemCycle = true;
                                    do
                                    {
                                        Console.WriteLine($"Insert the task you wish to add or {EXIT_CONSTANT} to exit:");
                                        choice = Console.ReadLine() ?? string.Empty;
                                        if (!choice.ToUpper().Equals(EXIT_CONSTANT))
                                        {
                                            exists = false;
                                            if (list.Items.Count != 0)
                                            {
                                                foreach (Task task in list.Items)
                                                {
                                                    if (task.Action == choice)
                                                    {
                                                        exists = true;
                                                        Console.WriteLine($"{task.Action} already exists!");
                                                    }
                                                }
                                            }
                                            if (list.Items.Count != 0)
                                            {
                                                user.HasList(choice);
                                            }
                                            if (!exists && !choice.Equals(""))
                                            {
                                                list.AddTask(choice);
                                                Console.WriteLine($"{choice} added successfully!");
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
                                    Console.WriteLine("Invalid Input!");
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
                    if (user.Tasks.Count == 0)
                    {
                        Console.WriteLine("You have no lists to look at!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Available Lists: ");
                        foreach (TaskList list in user.Tasks)
                        {
                            Console.WriteLine($"{list.Number}. {list.Action}");
                        }
                        Console.WriteLine($"Type the name of the list you wish to check or {EXIT_CONSTANT} to get back");
                        choice = Console.ReadLine() ?? string.Empty;
                        if (!choice.ToUpper().Equals(EXIT_CONSTANT))
                        {
                            foreach (TaskList list in user.Tasks)
                            {
                                if (list.Action == choice)
                                {
                                    Console.WriteLine(list.Action);
                                    Console.WriteLine($"Type {ADD_CONSTANT} to insert a new item, {LOOK_CONSTANT} to see the tasks in the list or {EXIT_CONSTANT} to go back");
                                    choice = Console.ReadLine() ?? string.Empty;
                                    switch (choice.ToUpper())
                                    {
                                        case ADD_CONSTANT:
                                            bool itemCycle = true;
                                            do
                                            {
                                                Console.WriteLine($"Insert the task you wish to add or {EXIT_CONSTANT} to exit:");
                                                choice = Console.ReadLine() ?? string.Empty;
                                                if (choice.ToUpper() != EXIT_CONSTANT)
                                                {
                                                    bool exists = false;
                                                    if (list.Items.Count != 0)
                                                    {
                                                        foreach (Task task in list.Items)
                                                        {
                                                            if (task.Action == choice)
                                                            {
                                                                exists = true;
                                                                Console.WriteLine($"{task.Action} already exists!");
                                                            }
                                                        }
                                                    }
                                                    if (!exists && !choice.Equals(""))
                                                    {
                                                        list.AddTask(choice);
                                                        Console.WriteLine($"{choice} added successfully!");
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
                                            list.ShowList();
                                            break;
                                        case EXIT_CONSTANT:
                                            break;
                                        default:
                                            Console.WriteLine("Invalid choice");
                                            break;
                                    }
                                }
                                else if (choice.ToUpper().Equals(EXIT_CONSTANT))
                                {
                                    lookCycle = false;
                                }
                                else
                                {
                                    Console.WriteLine("Input doesn't match any of the existing lists! Try again!");
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
                Console.WriteLine("Invalid Input!");
                break;
        }
    }
    else if (login.ToUpper().Equals(EXIT_CONSTANT))
    {
        Console.WriteLine($"Goodbye {user.Name}! See you next time!");
        cycle = false;
    }
    else
    {
        Console.WriteLine("Invalid Username! Insert a valid Username or [Q]uit:");
        cycle = false;
    }
}

public abstract class ToDo
{

    public int Number { get; set; }
    public string Action { get; set; }

    public ToDo() { }

    public ToDo(int number, string action)
    {
        Number = number;
        Action = action;
    }

}

public class Task : ToDo
{

    public bool Completed { get; set; }

    public Task()
    {
        Completed = false;
    }

    public Task(int Number, string Action) : base(Number, Action)
    {
        Completed = false;
    }

}

public class TaskList : ToDo
{

    public List<Task> Items { get; set; }

    public TaskList() { }

    public TaskList(int Number, string Action) : base(Number, Action)
    {
        Items = new List<Task>();
    }

    public void ShowList()
    {
        Console.WriteLine(Action);
        foreach (Task task in Items)
        {
            Console.WriteLine($"{task.Number}: {task.Action}");
        }
    }

    public void AddTask(string item)
    {
        Items.Add(new Task(Items.Count + 1, item));
    }
}

public class User
{
    public string Name { get; set; }
    public List<TaskList> Tasks { get; set; }

    public User(string Name)
    {
        this.Name = Name;
        Tasks = new List<TaskList>();
    }

    public void AddList(string list)
    {
        Tasks.Add(new TaskList(Tasks.Count + 1, list));
    }

    public TaskList GetTaskList(string name)
    {
        TaskList List = new TaskList();
        foreach (TaskList list in Tasks)
        {
            if (list.Action == name)
            {
                List = list;
            }
        }
        return List;
    }

    public bool HasList(string name)
    {
        foreach (TaskList list in Tasks)
        {
            if (list.Action == name)
            {
                return true;
            }
        }
        return false;
    }

}