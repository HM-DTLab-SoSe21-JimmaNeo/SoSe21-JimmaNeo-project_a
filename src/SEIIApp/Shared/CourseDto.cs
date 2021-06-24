using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared
{
    public class CourseDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Desc { get; set; }

        public string Text { get; set; }

        public string Img { get; set; }


        public string VideoURL { get; set; }


        public string PdfURL { get; set; }

        public string QuizId { get; set; }

        // Progress Bereich
        public bool CourseVisited { get; set; }

        public int QuizProgress { get; set; }

        public bool pdfDownloaded { get; set; }

        public int Progress { get; set; }
    }
}
