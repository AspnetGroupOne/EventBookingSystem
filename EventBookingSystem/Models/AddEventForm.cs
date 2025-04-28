using System.ComponentModel.DataAnnotations;

namespace EventBookingSystem.Models
{
    public class AddEventForm
    {
        [DataType(DataType.Text)]
        [Display(Name = "Event Name", Prompt = "Enter Event Name")]
        [Required(ErrorMessage = "Event Name is required")]
        public string EventName { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Event Date", Prompt = "Enter Event Date")]
        [Required(ErrorMessage = "Event Date is required")]
        public DateTime EventDate { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Event Location", Prompt = "Enter Event Location")]
        [Required(ErrorMessage = "Event Location is required")]
        public string EventLocation { get; set; } = null!;
    }
}
