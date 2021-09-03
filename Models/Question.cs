using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace millionaire.Models
{
    public class Question
    {
        [Key]
        public int Id {get; set;}
        public string text {get; set;}
    } 
}