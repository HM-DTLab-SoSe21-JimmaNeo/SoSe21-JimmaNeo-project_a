using SEIIApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace SEIIApp.Client.Services
{
    public class FeedbackBackendAccessService
    {
        private HttpClient HttpClient { get; set; }
        public FeedbackBackendAccessService(HttpClient client)
        {
            this.HttpClient = client;
        }

        private string GetFeedbackUrl()
        {
            return "api/feedback";
        }

        private string GetFeedbackUrlWithId(int id)
        {
            return $"{GetFeedbackUrl()}/{id}";
        }

        /// <summary>
        /// Returns a certain feedback by id
        /// </summary>
        public async Task<FeedbackDto> GetFeedbackById(int id)
        {
            return await HttpClient.GetFromJsonAsync<FeedbackDto>(GetFeedbackUrlWithId(id));
        }

        /// <summary>
        /// Returns all feedbackzes stored on the backend
        /// </summary>
        public async Task<FeedbackDto[]> GetFeedbackOverview()
        {
            return await HttpClient.GetFromJsonAsync<FeedbackDto[]>(GetFeedbackUrl());
        }

        /// <summary>
        /// Adds or updates a feedback on the backend. Returns the feedback if successful else null
        /// </summary>
        public async Task<FeedbackDto> AddOrUpdateFeedback(FeedbackDto dto)
        {
            var response = await HttpClient.PutAsJsonAsync(GetFeedbackUrl(), dto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<FeedbackDto>();
            }
            else return null;
        }

        /// <summary>
        /// Deletes a feedback and returns true if successful
        /// </summary>
        public async Task<bool> DeleteFeedback(int Id)
        {
            var response = await HttpClient.DeleteAsync(GetFeedbackUrlWithId(Id));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
