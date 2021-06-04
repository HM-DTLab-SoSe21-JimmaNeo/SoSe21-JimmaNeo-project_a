using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared
{
    public class Answer
    {
        [Required]
        public string Text { get; set; }

        public bool isSelected { get; set; }

        [Required]
        public bool isCorrect { get; set; }

        public bool checkAnswert()
        {
            return isSelected && isCorrect;
        }

        public string color = "light";
    }
}
