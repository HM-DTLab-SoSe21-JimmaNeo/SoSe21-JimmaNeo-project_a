using SEIIApp.Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.DataAccess
{

    public static class TestDataGenerator
    {

        private static string[] RandomWords = {
            "Frau", "Mittel", "Bürgersteig", "Dschungel", "Aufstand", "Gekocht", "Bilden", "Projekt", "Aerosol", "Ruhm", 
            "Schlucht", "Velodrom", "Herd", "Weben", "Linien", "Tenor", "Esel", "Relativ", "Schubkarre", "Einatmen", 
            "Juwel", "Dom", "Zweite", "Unterlegscheibe", "Kurz", "Schwer", "Kampf", "Apfel", "Bote", "Bauer",
        };

    /// <summary>
    /// Creates a test quiz definition, with the number of questions and the number of answers per question defined
    /// </summary>
    public static Quiz CreateQuiz()
    {
        Random rnd = new Random();
        var quiz = new Quiz();
        quiz.Questions = new List<Question>();

        for (int q = 0; q < 2+rnd.Next(8); q++)
        {
            var question = new Question();
            question.QuestionText = RandomWords[rnd.Next(RandomWords.Length)] + "?";
            question.Answers = new List<Answer>();


            for (int a = 0; a < 2 + rnd.Next(4); a++)
            {
                var answer = new Answer();
                answer.AnswerText = RandomWords[rnd.Next(RandomWords.Length)] + "!";
                 answer.IsCorrect = rnd.Next(3) > 1;
                question.Answers.Add(answer);
            }

            quiz.Questions.Add(question);
        }
        return quiz;
    }

}
}
