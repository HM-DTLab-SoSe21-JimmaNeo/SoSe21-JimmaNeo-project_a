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

    public class CourseBackendAccessService
    {

        private HttpClient HttpClient { get; set; }
        public CourseBackendAccessService(HttpClient client)
        {
            this.HttpClient = client;
        }

        private string GetCourseUrl()
        {
            return "api/coursedefinitions";
        }

        private string GetCourseUrlWithId(int id)
        {
            return $"{GetCourseUrl()}/{id}";
        }

        /// <summary>
        /// Returns a certain course by id
        /// </summary>
        public async Task<CourseDto> GetCourseById(int id)
        {
            return await HttpClient.GetFromJsonAsync<CourseDto>(GetCourseUrlWithId(id));
        }

        /// <summary>
        /// Returns all courses stored on the backend
        /// </summary>
        public async Task<CourseDto[]> GetCourseOverview()
        {
            return await HttpClient.GetFromJsonAsync<CourseDto[]>(GetCourseUrl());
        }

        /// <summary>
        /// Adds or updates a course on the backend. Returns the course if successful else null
        /// </summary>
        public async Task<CourseDto> AddOrUpdateCourse(CourseDto dto)
        {
            var response = await HttpClient.PutAsJsonAsync(GetCourseUrl(), dto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<CourseDto>();
            }
            else return null;
        }

        /// <summary>
        /// Deletes a course and returns true if successful
        /// </summary>
        public async Task<bool> DeleteCourse(int courseId)
        {
            var response = await HttpClient.DeleteAsync(GetCourseUrlWithId(courseId));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

    }
}
