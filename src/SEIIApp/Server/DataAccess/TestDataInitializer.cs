using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.DataAccess {

    public static class TestDataInitializer {

        /// <summary>
        /// Initialze test data (just for in-memory database)
        /// </summary>
        public static void InitializeTestData(Services.QuizService quizService) {
            for (int i = 0; i < 1; i++) {
                var quiz = TestDataGenerator.CreateQuiz();
                quiz.Name = "Quiz " + i;
                quizService.AddQuiz(quiz);
            }

        }

    }

}
