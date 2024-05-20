using BlazorTryout.Models;
namespace BlazorTryout.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = [
        new(){
            Id = 1,
            Name = "Street Fighters II",
            Genre = "Fighting",
            Price = 29.99M,
            ReleaseDate = new DateOnly(1994, 11, 15)
        },
        new(){
            Id = 2,
            Name = "Devil May Cry 3",
            Genre = "Action",
            Price = 39.99M,
            ReleaseDate = new DateOnly(2005, 06, 22)
        },
        new(){
            Id = 3,
            Name = "Megaman X",
            Genre = "Action",
            Price = 12.99M,
            ReleaseDate = new DateOnly(1989, 02, 11)
        },
        new(){
            Id = 4,
            Name = "Baldur's Gate 3",
            Genre = "RPG",
            Price = 69.99M,
            ReleaseDate = new DateOnly(2023, 04, 05)
        },
        new(){
            Id = 5,
            Name = "Final Fantasy VII",
            Genre = "RPG",
            Price = 69.99M,
            ReleaseDate = new DateOnly(2023, 04, 05)
        },
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames(){
        return games.ToArray();
    }

    public void AddGame(GameCreation game)
    {
        Genre genre = GetGenreById(game.GenreId);

        GameSummary newGame = new()
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(newGame);
    }

    public GameCreation GetGameDetails(int id)
    {
        GameSummary newGame = GetGameSummaryById(id);
        Genre genre = genres.Single(genre => string.Equals(
            genre.Name,
            newGame.Genre,
            StringComparison.OrdinalIgnoreCase
        ));
        return new GameCreation
        {
            Id = newGame.Id,
            Name = newGame.Name,
            GenreId = genre.Id.ToString(),
            Price = newGame.Price,
            ReleaseDate = newGame.ReleaseDate
        };
    }

    public void UpdateGame(GameCreation game){
        Genre genre = GetGenreById(game.GenreId);
        GameSummary existingGame = GetGameSummaryById(game.Id);

        existingGame.Name = game.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = game.Price;
        existingGame.ReleaseDate = game.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        GameSummary? newGame = GetGameSummaryById(id);
        ArgumentNullException.ThrowIfNull(newGame);
        games.Remove(newGame);
    }

    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? newGame = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(newGame);
        return newGame;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return genres.Single(genre => genre.Id == int.Parse(id));
    }
}
