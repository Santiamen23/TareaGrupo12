using apiwithdb.Data;
using apiwithdb.Models;
using Microsoft.EntityFrameworkCore;

namespace apiwithdb.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Event anEvent)
        {
            await _context.Events.AddAsync(anEvent);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var anEvent = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (anEvent != null)
            {
                _context.Events.Remove(anEvent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event?> GetById(Guid id)
        {
            return await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}