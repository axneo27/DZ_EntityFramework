using dz3.Entities;
using Microsoft.EntityFrameworkCore;

namespace dz3.Repositories { 
    public class PublisherRepository { 
        private readonly AppDbContext _context;

        public PublisherRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Publisher>> GetAllPublishersWithExplicitLoading(CancellationToken cancellationToken = default) {
            var publishers = await _context.Publishers.ToListAsync(cancellationToken);
            
            foreach (var publisher in publishers) {
                await _context.Entry(publisher)
                    .Reference(p => p.Games)
                    .LoadAsync(cancellationToken);
            }
            
            return publishers;
        }

        public async Task<Publisher?> GetPublisherById(int id, CancellationToken cancellationToken = default) {
            return await _context.Publishers.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task AddPublisher(Publisher publisher, CancellationToken cancellationToken = default) {
            await _context.Publishers.AddAsync(publisher, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdatePublisher(Publisher publisher, CancellationToken cancellationToken = default) {
            _context.Publishers.Update(publisher);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeletePublisher(int id, CancellationToken cancellationToken = default) {
            var publisher = await _context.Publishers.FindAsync(new object[] { id }, cancellationToken);
            if (publisher != null) {
                _context.Publishers.Remove(publisher);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<Game>> GetGamesByPublisher(string publisherName, CancellationToken cancellationToken = default) {
            var games = await _context.Publishers
                .Where(p => p.Name == publisherName)
                .SelectMany(p => _context.Games.Where(g => g.PublisherId == p.Id))
                .ToListAsync(cancellationToken);

            return games;
        }
    }
}