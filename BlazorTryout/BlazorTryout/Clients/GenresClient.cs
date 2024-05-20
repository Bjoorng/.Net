namespace BlazorTryout.Clients;

public class GenresClient
{
    private readonly List<Genre> Genres = [
        new(){
            Id= 1,
            Name = "Fighting"
        },
        new(){
            Id= 2,
            Name = "RPG"
        },
        new(){
            Id= 3,
            Name = "Racing"
        },
        new(){
            Id= 4,
            Name = "Action"
        },
        new(){
            Id= 5,
            Name = "Strategy"
        },
        new(){
            Id= 6,
            Name = "JRPG"
        }
    ];

    public Genre[] GetGenres(){
        return Genres.ToArray();
    }
}
