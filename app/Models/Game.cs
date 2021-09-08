using System.Collections.Generic;
using millionaire.Repos;
using millionaire.Services;
using System.Linq;

namespace millionaire.Models
{
    public class Game 
    {
        public int amount {get; set;}
        public int score {get; set;}
        public int step {get; set;}
        public int? mod {get; set;}
        public static int maxScore {get; set;}
        public int currentQuestion {get; set;}
        public List<Question> questions {get; set;}
        public List<Answer> answers {get; set;}
        public string chosenAnswer {get; set;}
        public bool gameOver {get; set;}
        public string result {get; set;}
        public string fifty_fifty_used {get; set;}     
        
    }
}