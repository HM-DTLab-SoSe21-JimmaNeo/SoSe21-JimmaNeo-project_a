using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Desc { get; set; }

        public string Text { get; set; }

        public string Img { get; set; }

    

        public string VideoURL { get; set; }
        public string PdfURL { get; set; }
        public string QuizId { get; set; }

        public int Progress { get; set; }
    }
}
