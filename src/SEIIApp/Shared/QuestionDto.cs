﻿using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared
{
    public class QuestionDto
    {
        [Required]
        [StringLength(250, MinimumLength = 1)]
        public string QuestionText { get; set; }

        [Required]
        public AnswerDto[] Answers { get; set; }
    }
}
