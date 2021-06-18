using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared {

    public class QuizDto {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        public QuestionDto[] Questions { get; set; }

        public int Progress { get; set; }

        public int calculateProgress()
        {
            int counter = 0;
            foreach (QuestionDto question in Questions)
            {
                foreach (AnswerDto answer in question.Answers)
                {
                    if (!answer.CheckAnswer())
                    {
                        goto next;
                    }
                }
                counter++;
                next:;
            }
            Progress = counter;
            return Progress;
        }

        public int CourseId { get; set; }
    }

}
