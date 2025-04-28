using EventBookingSystem.DTOs;
using EventBookingSystem.Repository;
using EventBookingSystem.Entities; // Ensure this namespace is included

namespace EventBookingSystem.Services
{
    public class EventService
    {
        private readonly EventRepository _eventRepository;

        public EventService(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
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
