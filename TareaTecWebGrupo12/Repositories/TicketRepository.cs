using Microsoft.EntityFrameworkCore;
using TareaTecWebGrupo12.Data;
using TareaTecWebGrupo12.Models;

namespace TareaTecWebGrupo12.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Ticket ticket)
        {
            await _context.tickets.AddAsync(ticket);
        }

        public async Task Delete(Guid id)
        {
            var ticket = await _context.tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (ticket != null)
            {
                _context.tickets.Remove(ticket);
            }
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _context.tickets.ToListAsync();
        }

        public async Task<Ticket?> GetById(Guid id)
        {
            return await _context.tickets.FirstOrDefaultAsync(x=>x.Id==id);
        }
    }
}
