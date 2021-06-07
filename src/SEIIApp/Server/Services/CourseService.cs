using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Services
{
    public class CourseService
    {

        private DatabaseContext DatabaseContext { get; set; }
        private IMapper Mapper { get; set; }
        public CourseService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<Course> GetQueryableForCourses()
        {
            return DatabaseContext
                .Courses;
        }

        /// <summary>
        /// Returns all Course definitions. Includes also questions and their answers.
        /// </summary>
        public Course[] GetAllCourses()
        {
            return GetQueryableForCourses().ToArray();
        }

        /// <summary>
        /// Returns the Course with the given id. Includes also questions and their answers.
        /// </summary>
        public Course GetCourseWithId(int id)
        {
            return GetQueryableForCourses().Where(Course => Course.Id == id).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück
        }

        /// <summary>
        /// Adds a Course.
        /// </summary>
        public Course AddCourse(Course Course)
        {
            DatabaseContext.Courses.Add(Course);
            DatabaseContext.SaveChanges();
            return Course;
        }

        /// <summary>
        /// Updates a Course.
        /// </summary>
        public Course UpdateCourse(Course Course)
        {
            //Wenn wir ein Course aktualisieren, dann fragen wir das existierende Course ab und 
            //Mappen die Änderung hinein.

            var existingCourse = GetCourseWithId(Course.Id);


            RemoveCourse(existingCourse);
            AddCourse(Course);
            return Course;
        }

        /// <summary>
        /// Removes a Course and all dependencies.
        /// </summary>
        public void RemoveCourse(Course Course)
        {
            DatabaseContext.Courses.Remove(Course);
            DatabaseContext.SaveChanges();
        }

    }
}
