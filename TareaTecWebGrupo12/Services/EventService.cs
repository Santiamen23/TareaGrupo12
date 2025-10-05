using TareaTecWebGrupo12.Models;
using TareaTecWebGrupo12.Models.dtos;
using TareaTecWebGrupo12.Repositories;

namespace TareaTecWebGrupo12.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repo;
        public EventService(IEventRepository repo)
        {
            _repo = repo;
        }
        public async Task<Event> Create(CreateEventDto dto)
        {
            if (dto.Date < DateTime.Now)
            {
                throw new InvalidOperationException("Event date must be in the future.");
            }
            var anEvent = new Event
            {
                Id = Guid.NewGuid(),
                Title = dto.Title.Trim(),
                Date = dto.Date,
                Capacity = dto.Capacity
            };
            await _repo.Add(anEvent);
            return anEvent;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;
            await _repo.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Event?> GetById(Guid id)
        {
            var anEvent = _repo.GetById(id);
            return await anEvent;
        }
    }
}