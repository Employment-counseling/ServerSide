using Employment_Counseling.Entities.Enums;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employment_Counseling.Entities
{   
    public class QuestionItem
    {
        public Guid Id { get; set; } 
        public string Question { get; set; }
        public QuestionType QuestionType { get; set; }
        public string OptionsRaw { get; set; }

        [NotMapped]
        public List<string> Options
        {
            get => OptionsRaw?.Split(";;").ToList() ?? new List<string>();
            set => OptionsRaw = string.Join(";;", value);
        }
        public Guid QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
    }
}
