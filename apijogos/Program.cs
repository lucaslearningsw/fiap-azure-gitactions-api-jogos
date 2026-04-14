using apijogos.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.WithTitle("ApiJogos")
           .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

// Hardcoded list of games
var games = new List<Game>
{
    new Game { Id = 1, Name = "The Legend of Zelda" },
    new Game { Id = 2, Name = "Super Mario Bros" },
    new Game { Id = 3, Name = "God of War" },
    new Game { Id = 4, Name = "Elden Ring" },
    new Game { Id = 5, Name = "Cyberpunk 2077" }
};

// GET /games - Returns the list of all games
app.MapGet("/games", () =>
{
    return Results.Ok(games);
});

// POST /games - Returns true if the game name does NOT exist in the list
app.MapPost("/games", (Game newGame) =>
{
    bool nameIsAvailable = !games.Any(g =>
        g.Name.Equals(newGame.Name, StringComparison.OrdinalIgnoreCase));

    return Results.Ok(new { available = nameIsAvailable });
});

app.Run();
