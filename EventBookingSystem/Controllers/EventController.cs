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
        private readonly EventIntegrationService _eventInteractionService;
        public EventsController(EventService eventService, EventIntegrationService eventInteractionService)
        {
            _eventService = eventService;
            _eventInteractionService = eventInteractionService;
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


        [HttpPost("book")]
        public async Task<IActionResult> BookTicket([FromBody] CreateBookingDto dto)
            {
            var result = await _eventInteractionService.BookTicketAndUpdateEventAsync(dto);
            if (!result)
                return BadRequest("Could not book ticket or no tickets available.");

            return Ok("Ticket booked successfully.");
        }
    }
}
