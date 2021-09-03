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
        public static int maxScore => 1000000;
        public int currentQuestion {get; set;}
        private readonly SQLiteQuestionService sqlitequestionservice;
        private readonly SQLiteAnswerService sqliteanswerservice;
        public List<Question> questions {get; set;}
        public List<Answer> answers {get; set;}
        public string chosenAnswer {get; set;}

        public Game(int _amount)
        {
            currentQuestion = 0;
            score = 0;
            amount = _amount;
            if (mod == null)
            {
                mod = maxScore % amount;
            }
            step = maxScore/amount;
            sqlitequestionservice = new(new SQLiteQuestionRepository());
            sqliteanswerservice = new(new SQLiteAnswerRepository());
            questions = sqlitequestionservice.GetGivenAmountOfQuestions(amount);
            answers = sqliteanswerservice.GetGivenAmountOfAnswers(questions.Select(x => x.Id).ToList());
        }
    }
}