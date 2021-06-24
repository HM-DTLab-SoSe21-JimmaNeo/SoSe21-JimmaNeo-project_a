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

namespace SEIIApp.Server.Controllers
{

    [ApiController]
    [Route("api/feedback")]
    public class FeedbackController : ControllerBase
    {

        private FeedbackService FeedbackService { get; set; }
        private IMapper Mapper { get; set; }

        public FeedbackController(FeedbackService feedbackService, IMapper mapper)
        {
            this.FeedbackService = feedbackService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return the feedback with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shared.FeedbackDto> GetFeedback([FromRoute] int id)
        {
            var feedback = FeedbackService.GetFeedbackWithId(id);
            if (feedback == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedFeedback = Mapper.Map<FeedbackDto>(feedback);
            return Ok(mappedFeedback);
        }

        /// <summary>
        /// Returns all feedbacks names and ids.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<FeedbackDto[]> GetAllFeedbacks()
        {
            var feedbacks = FeedbackService.GetAllFeedbacks();
            var mappedFeedbacks = Mapper.Map<FeedbackDto[]>(feedbacks);
            return Ok(mappedFeedbacks);
        }

        /// <summary>
        /// Adds or updates a feedback definition.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FeedbackDto> AddOrUpdateFeedback([FromBody] FeedbackDto model)
        {
            if (ModelState.IsValid)
            {
                //Das Modell ist dann valide, wenn es die per Annotation definierten
                //Eigenschaften erfüllt, ansonsten werden wir einen Fehler zurückliefern.

                //Wir "mappen" das gelieferte Modell zu unserer lokalen Domänen-Repräsentation
                var mappedModel = Mapper.Map<Feedback>(model);

                if (model.Id == 0)
                { //add
                    mappedModel = FeedbackService.AddFeedback(mappedModel);
                }
                else
                { //update
                    mappedModel = FeedbackService.UpdateFeedback(mappedModel);
                }

                //Wir liefern das geänderte Objekt auch wieder zurück
                model = Mapper.Map<FeedbackDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Removes a feedback definition.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteFeedback([FromRoute] int id)
        {
            var feedback = FeedbackService.GetFeedbackWithId(id);
            if (feedback == null) return StatusCode(StatusCodes.Status404NotFound);

            FeedbackService.RemoveFeedback(feedback);
            return Ok();
        }

    }
       
}