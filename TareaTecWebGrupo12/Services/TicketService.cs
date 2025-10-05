using TareaTecWebGrupo12.Models;
using TareaTecWebGrupo12.Models.dtos;
using TareaTecWebGrupo12.Repositories;

namespace TareaTecWebGrupo12.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repo;

        public TicketService(ITicketRepository repo)
        {
             _repo = repo;
        }
        public async Task<Ticket> Create(CreateTicketDto dto)
        {
            var ticket = new Ticket
            {
                Notes = dto.Notes,
            };
            await _repo.Add(ticket);
            return ticket;
        }

        public async Task<bool> Delete(Guid id)
        {

            var existing = _repo.GetById(id);
            if (existing == null) return false;
            await _repo.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Ticket?> GetById(Guid id)
        {
            var book = _repo.GetById(id);
            return await book;
        }
    }
}
