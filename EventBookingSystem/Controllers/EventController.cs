using EventBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    public class EventsController(EventService eventService) : Controller
    {
        private EventService _eventService = eventService;

        [HttpGet]
        public async Task<IActionResult> Admin()
        {
            var events = await _eventService.GetAllEventsAsync();
            return View(events);
        }
    }   
}
