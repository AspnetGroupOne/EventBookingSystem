using EventBookingSystem.Models;
using EventBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;
        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
         {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] AddEventForm eventForm)
        {
            if (eventForm == null)
                return BadRequest("Invalid event data.");

            var result = await _eventService.AddEvent(eventForm);
            if (result)
                return Ok("Event added successfully.");

            return BadRequest("Failed to add event.");
        }
    }
}
