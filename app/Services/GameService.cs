using millionaire.Models;
using System.Collections.Generic;
using millionaire.Data;
using System.Linq;
using System;
using millionaire.Repos;

namespace millionaire.Services
{
    public class GameService : IGameService
    {

        private readonly IGameRepository _gameRepo;

        public GameService(IGameRepository gameRepo)
        {
            _gameRepo = gameRepo;
        }
        public Game GetGame(int amount, IQuestionService _questionService, IAnswerService _answerService) => _gameRepo.GetGame(amount, _questionService, _answerService);

        public Game CheckAnswer(Game game, int? chosenAnswer, int amount)
        {
            if (game.answers.Where(x => x.Id == chosenAnswer).First().correct == "True")
            {
                Step(game, amount);                            
            }
            else 
            {
                GameOver(game);
            }
            return game;
        }


        public Game GameOver(Game game)
        {
            game.gameOver = true;
            game.result = "You lost!";
            return game;
        }

        public Game SwitchFiftyFiftyState(Game game, string submit) 
        {
            switch (submit) 
            {
                case "50:50":
                    game.fifty_fifty_used = "Now";
                    return game;
                case "Answer":
                default:
                    if (game.fifty_fifty_used == "Now")
                    {
                        game.fifty_fifty_used = "Yes";
                    }
                    return game;
            }
        }

        public Game Step(Game game, int _amount)
        {
            game.amount = _amount;
            if (game.score < Game.maxScore)
            {
                game.score += game.step;
                if (Game.maxScore - game.score == game.mod)
                {
                    game.score = Game.maxScore;
                }
            }
            if (game.questions.Count > 1)
            {
                game.questions = game.questions.Where(x => x != game.questions[0]).ToList();
            }
            if (game.score == Game.maxScore) game.result = "You won!";
            return game;
        }
    }
}