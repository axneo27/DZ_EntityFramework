using dz3.Entities;

namespace dz3.Data { 
    public class Seeder { 
        public static void Seed(AppDbContext context) { 
            if (!context.Games.Any()) { 
                var genre1 = new Genre { Name = "Action" };
                var genre2 = new Genre { Name = "Adventure" };
                var genre3 = new Genre { Name = "RPG" };

                var publisher1 = new Publisher { Name = "Epic Games", Country = "USA", Founded = new DateTime(1991, 1, 1), Website = "https://www.epicgames.com" };
                var publisher2 = new Publisher { Name = "Valve", Country = "USA", Founded = new DateTime(1996, 8, 24), Website = "https://www.valvesoftware.com" };

                var game1 = new Game { Name = "Game One", ReleaseDate = new DateTime(2020, 5, 1), Price = 59.99M, Genres = new List<Genre> { genre1, genre2 }, Publisher = publisher1 };
                var game2 = new Game { Name = "Game Two", ReleaseDate = new DateTime(2021, 6, 15), Price = 49.99M, Genres = new List<Genre> { genre2, genre3 }, Publisher = publisher2 };
                var game3 = new Game { Name = "Game Three", ReleaseDate = new DateTime(2019, 11, 20), Price = 39.99M, Genres = new List<Genre> { genre1 }, Publisher = publisher1 };

                context.Games.AddRange(game1, game2, game3);
                context.SaveChanges();
            }
        }
    }
}