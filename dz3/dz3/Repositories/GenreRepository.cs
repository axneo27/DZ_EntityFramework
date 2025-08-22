using Microsoft.EntityFrameworkCore;
using dz3.Entities;

namespace dz3.Repositories { 
    public class GenreRepository { 
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context) {
            _context = context;
        }

        // eager loading
        public async Task<IEnumerable<Genre>> GetAllGenres(CancellationToken cancellationToken = default) {
            return await _context.Genres
                .Include(g => g.Games)
                .ToListAsync(cancellationToken);
        }

        public async Task<Genre?> GetGenreById(int id, CancellationToken cancellationToken = default) {
            return await _context.Genres.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task AddGenre(Genre genre, CancellationToken cancellationToken = default) {
            await _context.Genres.AddAsync(genre, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateGenre(Genre genre, CancellationToken cancellationToken = default) {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteGenre(int id, CancellationToken cancellationToken = default) {
            var genre = await _context.Genres.FindAsync(new object[] { id }, cancellationToken);
            if (genre != null) {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<Genre>> GetGenresByGame(string gameTitle, CancellationToken cancellationToken = default) {
            return await _context.Genres
                .Where(g => g.Games.Any(game => game.Name == gameTitle))
                .ToListAsync(cancellationToken);
        }
    }
}