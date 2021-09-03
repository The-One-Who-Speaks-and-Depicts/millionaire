using System.Collections.Generic;

namespace millionaire.Models
{
    public class Game 
    {
        public int amount {get; set;}
        public List<Question> questions {get; set;}
    }
}