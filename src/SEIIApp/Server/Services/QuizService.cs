using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Services {
    public class QuizService {

        private DatabaseContext DatabaseContext { get; set; }
        private IMapper Mapper { get; set; }
        public QuizService(DatabaseContext db, IMapper mapper) {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<Quiz> GetQueryableForQuizzes() {
            return DatabaseContext
                .Quizzes
                .Include(quiz => quiz.Questions)
                    .ThenInclude(question => question.Answers);

            /* Diese Includes sagen der Datenbank, dass wir mit Joins arbeiten.
             * Wir holen daher aus den Datenbanken, in denen auch die Fragen zu einem Quiz und
             * die Antworten zu den Fragen gespeichert werden, die verbundenen Entitäten
             * aus der Datenbank.
             */
        }

        /// <summary>
        /// Returns all quiz definitions. Includes also questions and their answers.
        /// </summary>
        public Quiz[] GetAllQuizzes() {
            return GetQueryableForQuizzes().ToArray();
        }

        /// <summary>
        /// Returns the quiz with the given id. Includes also questions and their answers.
        /// </summary>
        public Quiz GetQuizWithId(int id) {
            return GetQueryableForQuizzes().Where(quiz => quiz.Id == id).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück
        }

        /// <summary>
        /// Adds a quiz.
        /// </summary>
        public Quiz AddQuiz(Quiz quiz) {
            DatabaseContext.Quizzes.Add(quiz);
            DatabaseContext.SaveChanges();
            return quiz;
        }

        /// <summary>
        /// Updates a quiz.
        /// </summary>
        public Quiz UpdateQuiz(Quiz quiz) {
            //Wenn wir ein Quiz aktualisieren, dann fragen wir das existierende Quiz ab und 
            //Mappen die Änderung hinein.

            var existingQuiz = GetQuizWithId(quiz.Id);

            Mapper.Map(quiz, existingQuiz); //we can map into the same object type

            DatabaseContext.Quizzes.Update(existingQuiz);
            DatabaseContext.SaveChanges();
            return existingQuiz;
        }

        /// <summary>
        /// Removes a quiz and all dependencies.
        /// </summary>
        public void RemoveQuiz(Quiz quiz) {
            DatabaseContext.Quizzes.Remove(quiz);
            DatabaseContext.SaveChanges();
        }

    }
}
