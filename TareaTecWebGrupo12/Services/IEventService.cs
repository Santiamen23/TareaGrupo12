using TareaTecWebGrupo12.Models;
using TareaTecWebGrupo12.Models.dtos;

namespace TareaTecWebGrupo12.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task<Event> Create(CreateEventDto dto);
        Task<bool> Delete(Guid id);
    }
}