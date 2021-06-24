using SEIIApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEIIApp.Client.Services {

    public class QuizBackendAccessService {

        private HttpClient HttpClient { get; set; }
        public QuizBackendAccessService(HttpClient client) {
            this.HttpClient = client;
        }

        private string GetQuizUrl() {
            return "api/quizdefinitions";
        }

        private string GetQuizUrlWithId(int id) {
            return $"{GetQuizUrl()}/{id}";
        }

        /// <summary>
        /// Returns a certain quiz by id
        /// </summary>
        public async Task<QuizDto> GetQuizById(int id) {
            return await HttpClient.GetFromJsonAsync<QuizDto>(GetQuizUrlWithId(id));
        }

        /// <summary>
        /// Returns all quizzes stored on the backend
        /// </summary>
        public async Task<QuizDto[]> GetQuizOverview() {
            return await HttpClient.GetFromJsonAsync<QuizDto[]>(GetQuizUrl());
        }

        /// <summary>
        /// Adds or updates a quiz on the backend. Returns the quiz if successful else null
        /// </summary>
        public async Task<QuizDto> AddOrUpdateQuiz(QuizDto dto) {
            var response = await HttpClient.PutAsJsonAsync(GetQuizUrl(), dto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                return await response.DeserializeResponseContent<QuizDto>();
            }
            else return null;
        }

        /// <summary>
        /// Deletes a quiz and returns true if successful
        /// </summary>
        public async Task<bool> DeleteQuiz(int quizId) {
            var response = await HttpClient.DeleteAsync(GetQuizUrlWithId(quizId));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

    }
}
