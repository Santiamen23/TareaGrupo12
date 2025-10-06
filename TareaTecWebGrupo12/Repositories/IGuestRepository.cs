using TareaTecWebGrupo12.Models;

namespace TareaTecWebGrupo12.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task Add(Event anEvent);
        Task Delete(Guid id);
    }
}