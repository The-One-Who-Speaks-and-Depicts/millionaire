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
        public static int maxScore => 1000000;
        public int currentQuestion {get; set;}
        private readonly SQLiteQuestionService sqlitequestionservice;
        private readonly SQLiteAnswerService sqliteanswerservice;
        public List<Question> questions {get; set;}
        public List<Answer> answers {get; set;}

        public Game(int _amount, int _nextQuestion = 0, int _score = 0)
        {
            currentQuestion = _nextQuestion;
            score = _score;
            amount = _amount;
            step = maxScore/amount;
            sqlitequestionservice = new(new SQLiteQuestionRepository());
            sqliteanswerservice = new(new SQLiteAnswerRepository());
            questions = sqlitequestionservice.GetGivenAmountOfQuestions(amount);
            answers = sqliteanswerservice.GetGivenAmountOfAnswers(questions.Select(x => x.Id).ToList());
        }
    }
}