using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared
{
    public class Course
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Desc { get; set; }

        [Required]
        public string Img { get; set; }

        // td: bools zu echten Klassen machen
        public bool Video;
        public bool Pdf;
        public bool Quiz;

        public int Progress { get; set; }
    }
}
