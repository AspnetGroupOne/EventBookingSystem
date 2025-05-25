using EventBookingSystem.DTOs;
using EventBookingSystem.Entities;
using EventBookingSystem.Models;

namespace EventBookingSystem.Factories
{
    public static class EventFactory
    {
        public static EventEntity Create(AddEventForm form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            return new EventEntity
            {
                Name = form.EventName,
                Date = form.EventDate,
                Location = form.EventLocation,
                Description = form.EventDescription
            };
        }

        public static EventDTO Create(EventEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return new EventDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Date = entity.Date,
                Location = entity.Location,
                Description = entity.Description
            };
        }
    }
}
