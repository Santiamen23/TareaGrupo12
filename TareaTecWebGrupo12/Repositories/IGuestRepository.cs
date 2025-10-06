using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TareaTecWebGrupo12.Models;

namespace TareaTecWebGrupo12.Repositories
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
        Task Add(Guest guest);
        Task Delete(Guid id);
    }
}
