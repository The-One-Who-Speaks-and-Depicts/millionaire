using System.ComponentModel.DataAnnotations;

namespace millionaire.Models
{
    public class Answer
    {
        [Key]
        public int Id {get; set;}
        public string text {get; set;}
        public string correct {get; set;}
        public int questionId {get; set;}
    }
}