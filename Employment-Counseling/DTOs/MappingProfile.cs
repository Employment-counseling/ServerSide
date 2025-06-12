using AutoMapper;
using Employment_Counseling.Entities;

namespace Employment_Counseling.DTOs
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<AnswerItem, AnswerItemDto>().ReverseMap();
            CreateMap<Costumer, CostumerDto>().ReverseMap();
            CreateMap<Counselor, CounselorDto>().ReverseMap();
            CreateMap<Package, PackageDto>().ReverseMap();
            CreateMap<QuestionItem, QuestionItemDto>().ReverseMap();
            CreateMap<Questionnaire, QuestionnaireDto>().ReverseMap();
            CreateMap<UserAnswers, UserAnswersDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
