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
    public class FeedbackService
    {

        private DatabaseContext DatabaseContext { get; set; }
        private IMapper Mapper { get; set; }
        public FeedbackService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<Feedback> GetQueryableForFeedbacks()
        {
            return DatabaseContext
                .Feedback;
        }

        /// <summary>
        /// Returns all Feedback definitions. Includes also questions and their answers.
        /// </summary>
        public Feedback[] GetAllFeedbacks()
        {
            return GetQueryableForFeedbacks().ToArray();
        }

        /// <summary>
        /// Returns the Feedback with the given id. Includes also questions and their answers.
        /// </summary>
        public Feedback GetFeedbackWithId(int id)
        {
            return GetQueryableForFeedbacks().Where(Feedback => Feedback.Id == id).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück
        }

        /// <summary>
        /// Adds a Feedback.
        /// </summary>
        public Feedback AddFeedback(Feedback Feedback)
        {
            DatabaseContext.Feedback.Add(Feedback);
            DatabaseContext.SaveChanges();
            return Feedback;
        }

        /// <summary>
        /// Updates a Feedback.
        /// </summary>
        public Feedback UpdateFeedback(Feedback Feedback)
        {
            //Wenn wir ein Feedback aktualisieren, dann fragen wir das existierende Feedback ab und 
            //Mappen die Änderung hinein.

            var existingFeedback = GetFeedbackWithId(Feedback.Id);


            RemoveFeedback(existingFeedback);
            AddFeedback(Feedback);
            return Feedback;
        }

        /// <summary>
        /// Removes a Feedback and all dependencies.
        /// </summary>
        public void RemoveFeedback(Feedback Feedback)
        {
            DatabaseContext.Feedback.Remove(Feedback);
            DatabaseContext.SaveChanges();
        }

    }
}
