using dz3.Entities;
using Microsoft.EntityFrameworkCore;

namespace dz3.Repositories { 
    public class GameRepository { 
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context) {
            _context = context;
        }

        
        // eager loading
        public async Task<IEnumerable<Game>> GetAllGames(CancellationToken cancellationToken = default) {
            return await _context.Games
                .Include(g => g.Genres)
                .Include(g => g.Publisher)
                .ToListAsync(cancellationToken);
        }

        public async Task<Game?> GetGameById(int id, CancellationToken cancellationToken = default) {
            return await _context.Games.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task AddGame(Game game, CancellationToken cancellationToken = default) {
            await _context.Games.AddAsync(game, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateGame(Game game, CancellationToken cancellationToken = default) {
            _context.Games.Update(game);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteGame(int id, CancellationToken cancellationToken = default) {
            var game = await _context.Games.FindAsync(new object[] { id }, cancellationToken);
            if (game != null) {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<Game>> GetGamesByGenre(string genreName, CancellationToken cancellationToken = default) {
            return await _context.Games
                .Where(g => g.Genres.Any(genre => genre.Name == genreName))
                .ToListAsync(cancellationToken);
        }
    }
}