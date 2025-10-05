using TareaTecWebGrupo12.Models;

namespace TareaTecWebGrupo12.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket?> GetById(Guid id);
        Task Add(Ticket book);
        Task Delete(Guid id);
    }
}
