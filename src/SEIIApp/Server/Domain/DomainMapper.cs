using AutoMapper;
using SEIIApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain {
    public class DomainMapper : Profile {

        public DomainMapper() {

            CreateMap<Quiz, QuizDto>()
                .ForMember(quizDto => quizDto.Questions, opts => opts.MapFrom(obj => obj.Questions.ToArray()));
            CreateMap<QuizDto, Quiz>()
                .ForMember(quizObj => quizObj.Questions, opts => opts.MapFrom(dto => dto.Questions.ToList()));

            CreateMap<Quiz, QuizDto>();
            CreateMap<Quiz, Quiz>();

            CreateMap<Question, QuestionDto>()
                .ForMember(questionDto => questionDto.Answers, opt => opt.MapFrom(obj => obj.Answers.ToArray()));
            CreateMap<QuestionDto, Question>()
                .ForMember(questionObj => questionObj.Answers, opt => opt.MapFrom(obj => obj.Answers.ToList()));

            CreateMap<Answer, AnswerDto>();
            CreateMap<AnswerDto, Answer>();

            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();

        }

    }
}
