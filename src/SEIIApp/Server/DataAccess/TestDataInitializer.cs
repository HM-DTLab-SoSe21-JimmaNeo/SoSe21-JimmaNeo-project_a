using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEIIApp.Server.Domain;

namespace SEIIApp.Server.DataAccess {

    public static class TestDataInitializer {

        private static string[] titles = {
            "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota",
            "Kappa","Lambda","My","Ny","Xi","Omikron","Pi","Rho","Sigma","Tau","Ypsilon",
            "Phi","Chi","Psi","Omega"
        };

        /// <summary>
        /// Initialze test data (just for in-memory database)
        /// </summary>
        public static void InitializeQuizTestData(Services.QuizService quizService) {
            for (int i = 0; i < 5; i++) {
                var quiz = TestDataGenerator.CreateQuiz();
                quiz.Name = titles[i % titles.Length] + "-Quiz";
                quizService.AddQuiz(quiz);
            }

        }

        public static void InitializeCourseTestData(Services.CourseService courseService)
        {
            Course[] courses =  {
                                               new Course
                                                {
                                                   Id = 1,
                                                    Name = "Lorem ipsum",
                                                    Desc = "Ipsam omnis vel officiis voluptatem ut repellendus. Dolores maiores sapiente molestiae exercitationem ad qui ut officiis. Voluptatem est aliquam saepe deserunt. Debitis et quam laboriosam omnis consequatur earum rem explicabo.",
                                                    Text = "Lorem ipsum",
                                                    Progress = 100,
                                                    Img = "https://goafricahealth.com/wp-content/uploads/2017/10/34689294_l.jpg",
                                                    VideoURL = "C9udNPYVKr8",
                                                    PdfURL = "example_files/Pdf_Datei.pdf",
                                                    QuizId = "1"
                                               }, new Course
                                                {
                                                    Name = "Officiis dolor distinctio",
                                                    Desc = "Quasi eum aliquid dignissimos vel vitae. Cupiditate quaerat id consectetur dolores id. Officiis dolor distinctio qui ipsam nesciunt aut. Ea minus voluptatem optio pariatur explicabo. Quibusdam error molestias reprehenderit distinctio. Qui sed excepturi ullam dolorem ut omnis.",
                                                    Progress = 100,
                                                    Img = "https://adwonline.ae/wp-content/uploads/2020/05/Reem-Hospital-1024x683.jpg",
                                                    PdfURL = "example files/Pdf Datei.pdf"
                                                }, new Course
                                                {
                                                    Name = "Cupiditate",
                                                    Desc = "Ea impedit sapiente ullam tempore sit qui deleniti. Cupiditate in sequi eius tempora nesciunt nam. Laboriosam debitis sunt debitis illum.",
                                                    Img = "https://www.clipartkey.com/mpngs/m/126-1268626_black-baby-png-happy-african-babies.png",
                                                    Progress = 50,
                                                    PdfURL = "example files/Pdf Datei.pdf"

                                                }, new Course
                                                {
                                                    Name = "Voluptas placeat",
                                                    Desc = "Quod qui explicabo molestias a et alias voluptatum. Voluptas placeat nisi quo nihil et vitae vero eius. Repellat voluptatem perspiciatis cupiditate dolore nobis et. Voluptatem in inventore ducimus iusto. Nihil porro magni quos minima quasi voluptatem.",
                                                    Progress = 0,
                                                    Img = "https://static.vecteezy.com/system/resources/previews/000/458/152/original/vector-abstract-3d-success-design.jpg",
                                                    PdfURL = "example files/Pdf Datei.pdf"
                                                }

                                            };
            foreach(Course course in courses)
            {
                courseService.AddCourse(course);
            }

        }

    }

}
