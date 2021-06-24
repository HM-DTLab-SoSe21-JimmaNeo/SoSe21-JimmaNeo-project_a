using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEIIApp.Server.Domain;

namespace SEIIApp.Server.DataAccess
{

    public static class TestDataInitializer
    {

        private static string[] titles = {
            "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota",
            "Kappa","Lambda","My","Ny","Xi","Omikron","Pi","Rho","Sigma","Tau","Ypsilon",
            "Phi","Chi","Psi","Omega"
        };

        /// <summary>
        /// Initialze test data (just for in-memory database)
        /// </summary>
        public static void InitializeQuizTestData(Services.QuizService quizService)
        {
            /**
            var realQuiz = new Quiz();
            realQuiz.Name = "Vorbereitung";
            Question a = new Question();

            a.QuestionText = "Welche Aussagen zur Erstversorgung Neugeborener treffen zu?";
            a.Answers = new List<Answer>();
            a.Answers.Add(
                new Answer
                {
                    AnswerText = "Der Großteil aller Neugeboreren bedarf nach der Geburt keiner besonderen medizinischen Unterstützung."
                });
            a.Answers.Add(
                         new Answer
                         {
                             AnswerText = "Der Wärmeerhalt (36,5-37,5°C) nach Geburt ist für alle Gesunden Neugeborenen von großer Wichtigkeit."

                         });
            a.Answers.Add(new Answer
            {
                AnswerText = "Nur ca 30% aller Neugeborenen müssen nach Geburt beatmet werden."
            });
            a.Answers.Add(new Answer
            {
                AnswerText = "Ca. 10% aller Neugeborenen müssen nach Geburt intubiert werden."
            });
            a.Answers.Add(new Answer
            {
                AnswerText = "Die medikamentöse Therapie spielt eine größere Rolle als die Herz-Druck-Massage."
            });



            Question b = new Question
            {
                QuestionText = "Folgende Faktoren können sich negativ auf die Anpassung des Neugeborenen auswirken?",
                Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerText="Gestationsdiabetes (Schangerschaftsdiabetes) der Mutter"
                        }, new Answer
                        {
                            AnswerText="Abgang von dick grünem Fruchtwasser"
                        }, new Answer
                        {
                            AnswerText="Mehrlingsgeburt"
                        }, new Answer
                        {
                            AnswerText="Frühgeburtlichkeit unter der 34. Schwangerschaftswoche"
                        }, new Answer
                        {
                            AnswerText="akute vaginale Blutung von der Geburt"
                        }
                    }.ToList<Answer>()
            };
            Question c =
                 new Question
                 {
                     QuestionText = "Die effiziente Beatmung beeinträchtigter Neugeborener spielt eine Schlüsselrolle in der Erstversorgung nach Geburt. Welche Aussagen zur Beatmung treffen zu?",
                     Answers =  new Answer[]
                     {
                        new Answer
                        {
                            AnswerText="Eine Beatmung mit Maske und Beutel ist der Beatmung mit einem T-Stück-System (z.B.: Perivent/Neopuff) vorzuziehen"
                        },new Answer
                        {
                            AnswerText="Ein Beatmungsdruck von 20-30 cm H20 ist in aller Regel unbedenklich."
                        },new Answer
                        {
                            AnswerText="Der beste Parameter für die Effektivität der Beatmung ist die Hautfarbe (rosig werden) des Kindes"
                        },new Answer
                        {
                            AnswerText="Die initial zu verabreichende Sauerstoffkonzentration beträgt 40%."
                        },new Answer
                        {
                            AnswerText="Initial werden 5 Beatmungshübe verabreicht."
                        }
                     }.ToList()
                 };
            Question d =
                new Question
                {
                    QuestionText = "Bei der Reanimation von Neugeborenen unmittelbar nach Geburt ist das Verhältnis von Beatmungshüben zu Thoraxkompressionen:",
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerText = "Beatmung : Kompression = 2:30"
                        }, new Answer
                        {
                            AnswerText = "Beatmung : Kompression = 1:3"
                        }, new Answer
                        {
                            AnswerText = "Beatmung : Kompression = 2:3"
                        }, new Answer
                        {
                            AnswerText = "Beatmung : Kompression = 2:15"
                        }, new Answer
                        {
                            AnswerText = "Beatmung : Kompression = 1:15"
                        }
                    }.ToList()

                };
            realQuiz.Questions.Add(a);
            realQuiz.Questions.Add(b);
            realQuiz.Questions.Add(c);
            realQuiz.Questions.Add(d);
            quizService.AddQuiz(realQuiz);
            
            **/
            for (int i = 0; i < 5; i++)
            {
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
                                                    Name = "Was ist Neonatologie?",
                                                    Desc = "Erhalte einen Überblick über die Neonatologie.",
                                                    Text = "Die Neonatologie befasst sich mit den speziellen Problemen und deren Behandlung von Frühgeborenen und kranken Neugeborenen. In den letzten Jahrzehnten hat die Medizin im Bereich der Neonatologie immense Fortschritte gemacht: Es sind bessere Medikamente, die die Lungenreifung beschleunigen, bessere Beatmungsgeräte und Überwachungsgeräte für Herzaktionen (EKG), Sauerstoff-/Kohlendioxidaustausch (Kapnometer) sowie Sauerstoffsättigungsmesser verfügbar.Übliche Verfahren in der apparativen Diagnostik beim Früh- und Neugeborenen sind heute:<ul><li>Ultraschall, einschließlich Dopplersonographie</li><li>Röntgenuntersuchungen</li><li>Schnittbildverfahren(Computertomographie und Magnetresonanztomographie)</li></ul>",
                                                    Progress = 100,
                                                    VideoURL = "C9udNPYVKr8",
                                                    PdfURL = "/test/test.pdf",
                                                    QuizId = "1"
                                               }, new Course
                                                {
                                                    Name = "Officiis dolor distinctio",
                                                    Desc = "Quasi eum aliquid dignissimos vel vitae. Cupiditate quaerat id consectetur dolores id. Officiis dolor distinctio qui ipsam nesciunt aut. Ea minus voluptatem optio pariatur explicabo. Quibusdam error molestias reprehenderit distinctio. Qui sed excepturi ullam dolorem ut omnis.",
                                                    Progress = 100,
                                                    Img = "https://goafricahealth.com/wp-content/uploads/2017/10/34689294_l.jpg",
                                                    PdfURL = "/test/test.pdf"
                                                }, new Course
                                                {
                                                    Name = "Cupiditate",
                                                    Desc = "Ea impedit sapiente ullam tempore sit qui deleniti. Cupiditate in sequi eius tempora nesciunt nam. Laboriosam debitis sunt debitis illum.",
                                                    Img = "https://adwonline.ae/wp-content/uploads/2020/05/Reem-Hospital-1024x683.jpg",
                                                    Progress = 50,
                                                    PdfURL = "/test/test.pdf"

                                                }, new Course
                                                {
                                                    Name = "Voluptas placeat",
                                                    Desc = "Quod qui explicabo molestias a et alias voluptatum. Voluptas placeat nisi quo nihil et vitae vero eius. Repellat voluptatem perspiciatis cupiditate dolore nobis et. Voluptatem in inventore ducimus iusto. Nihil porro magni quos minima quasi voluptatem.",
                                                    Progress = 0,
                                                    Img = "https://www.clipartkey.com/mpngs/m/126-1268626_black-baby-png-happy-african-babies.png",
                                                    PdfURL = "/test/test.pdf"
                                                }

                                            };
            foreach (Course course in courses)
            {
                courseService.AddCourse(course);
            }

        }

        public static void InitializeFeedbackTestData(Services.FeedbackService feedbackService)
        {
           // Feedback feedback = new Feedback
           // {
          //      Category = "TEST", Email = "t@e.st", Message = "HALLO TEST", Name = "TESTER"
      //  };
        //    feedbackService.AddFeedback(feedback);
        }

    }

}
