using TareaTecWebGrupo12.Models;
using TareaTecWebGrupo12.Models.dtos;

namespace TareaTecWebGrupo12.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket?> GetById(Guid id);
        Task<Ticket> Create(CreateTicketDto dto);
        Task<bool> Delete(Guid id);
    }
}
