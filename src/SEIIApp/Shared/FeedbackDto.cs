using System.ComponentModel.DataAnnotations;


namespace SEIIApp.Shared
{
    public class FeedbackDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email nicht zulässig")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name mit mindestens 2 Buchstaben und maximal 30")]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required(ErrorMessage = "Nachricht angeben")]
        public string Message { get; set; }

        public string CourseName { get; set; }
    }
}
