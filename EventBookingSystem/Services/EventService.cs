using EventBookingSystem.DTOs;
using EventBookingSystem.Factories;
using EventBookingSystem.Models;
using EventBookingSystem.Repository;

namespace EventBookingSystem.Services
{
    public class EventService
    {
        private readonly EventRepository _eventRepository;

        public EventService(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<bool> AddEvent(AddEventForm project)
        {
            if (project == null)
                return false;

            var projectEntity = EventFactory.Create(project);

            return await _eventRepository.AddAsync(projectEntity);
        }

        public async Task<IEnumerable<EventDTO>> GetAllEventsAsync()
        {
            var events = await _eventRepository.GetAllAsync();
            return events.Select(e => new EventDTO
            {
                Id = e.Id,
                Name = e.Name,
                Date = e.Date,
                Location = e.Location
            });
        }
    }
}
