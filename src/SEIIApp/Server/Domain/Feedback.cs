using System.ComponentModel.DataAnnotations;


namespace SEIIApp.Server.Domain
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Message { get; set; }

        public bool IsNew {get; set;}
    }
}
