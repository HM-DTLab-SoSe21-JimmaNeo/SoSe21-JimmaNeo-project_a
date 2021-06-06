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
    [Route("api/coursedefinitions")]
    public class CourseController : ControllerBase
    {

        private CourseService CourseService { get; set; }
        private IMapper Mapper { get; set; }

        public CourseController(CourseService courseService, IMapper mapper)
        {
            this.CourseService = courseService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return the course with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shared.CourseDto> GetCourse([FromRoute] int id)
        {
            var course = CourseService.GetCourseWithId(id);
            if (course == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedCourse = Mapper.Map<CourseDto>(course);
            return Ok(mappedCourse);
        }

        /// <summary>
        /// Returns all courses names and ids.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CourseDto[]> GetAllCourses()
        {
            var courses = CourseService.GetAllCourses();
            var mappedCourses = Mapper.Map<CourseDto[]>(courses);
            return Ok(mappedCourses);
        }

        /// <summary>
        /// Adds or updates a course definition.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CourseDto> AddOrUpdateCourse([FromBody] CourseDto model)
        {
            if (ModelState.IsValid)
            {
                //Das Modell ist dann valide, wenn es die per Annotation definierten
                //Eigenschaften erfüllt, ansonsten werden wir einen Fehler zurückliefern.

                //Wir "mappen" das gelieferte Modell zu unserer lokalen Domänen-Repräsentation
                var mappedModel = Mapper.Map<Course>(model);

                if (model.Id == 0)
                { //add
                    mappedModel = CourseService.AddCourse(mappedModel);
                }
                else
                { //update
                    mappedModel = CourseService.UpdateCourse(mappedModel);
                }

                //Wir liefern das geänderte Objekt auch wieder zurück
                model = Mapper.Map<CourseDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Removes a course definition.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteCourse([FromRoute] int id)
        {
            var course = CourseService.GetCourseWithId(id);
            if (course == null) return StatusCode(StatusCodes.Status404NotFound);

            CourseService.RemoveCourse(course);
            return Ok();
        }





    }
}
