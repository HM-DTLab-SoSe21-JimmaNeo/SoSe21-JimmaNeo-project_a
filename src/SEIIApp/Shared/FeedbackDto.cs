using System.ComponentModel.DataAnnotations;


namespace SEIIApp.Shared
{
    public class FeedbackDto
    {
        [Required]
        public ContactInformationDto ContactInfo { get; set; }

        public string Category { get; set; }

        [Required(ErrorMessage = "Nachricht mit mindestens 20 Buchstaben angeben")]
        [MinLength(20)]
        public string Message { get; set; }
    }
}
