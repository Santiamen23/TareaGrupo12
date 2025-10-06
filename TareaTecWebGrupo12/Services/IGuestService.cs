using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TareaTecWebGrupo12.Models;
using TareaTecWebGrupo12.Models.dtos;

namespace TareaTecWebGrupo12.Services
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
        Task<Guest> Create(CreateGuestDto dto);
        Task<bool> Delete(Guid id);
    }
}
