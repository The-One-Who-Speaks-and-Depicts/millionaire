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
        public List<Question> questions {get; set;}
        public List<Answer> answers {get; set;}
        public string chosenAnswer {get; set;}
        public bool gameOver = false;
        public string result {get; set;}
        public string fifty_fifty_used = "No";
        
        public void CheckAnswer(int? chosenAnswer, int amount)
        {
            if (answers.Where(x => x.Id == chosenAnswer).First().correct == "True")
            {
                Step(amount);                            
            }
            else 
            {
                GameOver();
            }
        }


        void GameOver()
        {
            gameOver = true;
            result = "You lost!";
        }

        public void SwitchFiftyFiftyState(string submit) 
        {
            switch (submit) 
            {
                case "50:50":
                    fifty_fifty_used = "Now";
                    break;
                case "Answer":
                default:
                    if (fifty_fifty_used == "Now")
                    {
                        fifty_fifty_used = "Yes";
                    }
                    break;
            }
        }

        public void Step(int _amount)
        {
            amount = _amount;
            if (score < millionaire.Models.Game.maxScore)
            {
                score += step;
                if (millionaire.Models.Game.maxScore - score == mod)
                {
                    score = millionaire.Models.Game.maxScore;
                }
            }
            if (questions.Count > 1)
            {
                questions = questions.Where(x => x != questions[0]).ToList();
            }
            if (score == millionaire.Models.Game.maxScore) result = "You won!";
        }

        public Game(int _amount, IQuestionService _questionService, IAnswerService _answerService)
        {
            questions = _questionService.GetGivenAmountOfQuestions(_amount);
            answers = _answerService.GetGivenAmountOfAnswers(questions.Select(x => x.Id).ToList());
            currentQuestion = 0;
            score = 0;
            amount = _amount;
            if (mod == null)
            {
                mod = maxScore % amount;
            }
            step = maxScore/amount;            
        }
    }
}