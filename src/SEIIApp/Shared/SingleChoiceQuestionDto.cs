using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared
{
    public class SingleChoiceQuestionDto
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public List<AnswerDto> Options { get; set; }

        [Required]
        public int Solution { get; set; }
    }
}
