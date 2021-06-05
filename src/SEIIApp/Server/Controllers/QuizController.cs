using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Controllers {

    [ApiController]
    [Route("api/quizdefinitions")]
    public class QuizController : ControllerBase {
       
        private QuizService QuizService { get; set; }
        private IMapper Mapper { get; set; }

        public QuizController(QuizService quizService, IMapper mapper) {
            this.QuizService = quizService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return the quiz with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shared.QuizDto> GetQuiz([FromRoute] int id) {
            var quiz = QuizService.GetQuizWithId(id);
            if (quiz == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedQuiz = Mapper.Map<QuizDto>(quiz);
            return Ok(mappedQuiz);
        }

        /// <summary>
        /// Returns all quizzes names and ids.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<QuizDto[]> GetAllQuizzes() {
            var quizzes = QuizService.GetAllQuizzes();
            var mappedQuizzes = Mapper.Map<QuizDto[]>(quizzes);
            return Ok(mappedQuizzes);
        }

        /// <summary>
        /// Adds or updates a quiz definition.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<QuizDto> AddOrUpdateQuiz([FromBody] QuizDto model) {
            if (ModelState.IsValid) {
                //Das Modell ist dann valide, wenn es die per Annotation definierten
                //Eigenschaften erfüllt, ansonsten werden wir einen Fehler zurückliefern.

                //Wir "mappen" das gelieferte Modell zu unserer lokalen Domänen-Repräsentation
                var mappedModel = Mapper.Map<Quiz>(model);

                if(model.Id == 0) { //add
                    mappedModel = QuizService.AddQuiz(mappedModel);
                }
                else { //update
                    mappedModel = QuizService.UpdateQuiz(mappedModel);
                }

                //Wir liefern das geänderte Objekt auch wieder zurück
                model = Mapper.Map<QuizDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Removes a quiz definition.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteQuiz([FromRoute] int id) {
            var quiz = QuizService.GetQuizWithId(id);
            if (quiz == null) return StatusCode(StatusCodes.Status404NotFound);

            QuizService.RemoveQuiz(quiz);
            return Ok();
        }





    }
}
