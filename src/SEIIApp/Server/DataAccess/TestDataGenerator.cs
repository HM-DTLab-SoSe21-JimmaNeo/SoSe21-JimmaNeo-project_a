using SEIIApp.Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.DataAccess {

    public static class TestDataGenerator {

        /// <summary>
        /// Creates a test quiz definition, with the number of questions and the number of answers per question defined
        /// </summary>
        public static Quiz CreateQuiz(int toIncludeTestQuestions = 3, int toIncludeTestAnswers = 5) {
            var quiz = new Quiz();
            quiz.Questions = new List<Question>();

            for (int q = 0; q < toIncludeTestQuestions; q++) {
                var question = new Question();
                question.QuestionText = "Question " + q.ToString();
                question.Answers = new List<Answer>();
                

                for (int a = 0; a < toIncludeTestAnswers; a++) {
                    var answer = new Answer();
                    answer.AnswerText = $"Answer for q {q}, a is {a}";
                    question.Answers.Add(answer);
                }

                quiz.Questions.Add(question);
            }
            return quiz;
        }

    }
}
