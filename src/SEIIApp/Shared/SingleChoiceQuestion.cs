using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared
{
    public class SingleChoiceQuestion
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public List<Answer> Options { get; set; }

        [Required]
        public int Solution { get; set; }
    }
}
