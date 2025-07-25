using Microsoft.EntityFrameworkCore;
using dz1.Entities;
namespace dz1 {
    class Program {

        static void AddGames(AppDbConnect context) { 
            context.Games.Add(new Game { 
                Title = "FIFA 24",
                Studio = "EA Sports",
                Style = "Sports",
                ReleaseDate = new DateTime(2023, 9, 29)
            });
            context.Games.Add(new Game { 
                Title = "Call of Duty: Modern Warfare III",
                Studio = "Activision",
                Style = "Shooter",
                ReleaseDate = new DateTime(2023, 11, 10)
            });
            context.Games.Add(new Game { 
                Title = "The Legend of Zelda: Tears of the Kingdom",
                Studio = "Nintendo",
                Style = "Adventure",
                ReleaseDate = new DateTime(2023, 5, 12)
            });

            context.SaveChanges();
        }

        static void AddGames2(AppDbConnect context) {
            context.Games.Add(new Game { 
                Title = "Cyberpunk 2077",
                Studio = "CD Projekt Red",
                Style = "RPG",
                ReleaseDate = new DateTime(2020, 12, 10),
                GameMode = "Single-player",
                SoldCopies = 20000000
            });
            context.Games.Add(new Game { 
                Title = "The Witcher 3: Wild Hunt",
                Studio = "CD Projekt Red",
                Style = "RPG",
                ReleaseDate = new DateTime(2015, 5, 19),
                GameMode = "Single-player",
                SoldCopies = 30000000
            });

            context.SaveChanges();
        }

        static void ShowGames(AppDbConnect context) {
            var games = context.Games.ToList();
            foreach (var game in games) {
                Console.WriteLine($"Id: {game.Id}, Title: {game.Title}, Studio: {game.Studio}, Style: {game.Style}, Release Date: {game.ReleaseDate}");
            }
        }

        static void Main(string[] args)
        {
            //var dbContext = new AppDbConnect();
            
            //AddGames(dbContext);
            //ShowGames(dbContext);
            
            //AddGames2(dbContext);
            //ShowGames(dbContext);
        }
    }
}

