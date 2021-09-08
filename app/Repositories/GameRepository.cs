using millionaire.Models;
using System.Collections.Generic;
using millionaire.Data;
using System.Linq;
using System;
using millionaire.Services;

namespace millionaire.Repos
{
    public class GameRepository : IGameRepository
    {
        public Game GetGame(int amount, IQuestionService _questionService, IAnswerService _answerService)
        {
            Game game = new();
            Game.maxScore = 1000000;
            game.fifty_fifty_used = "No";
            game.gameOver = false;
            game.questions = _questionService.GetGivenAmountOfQuestions(amount);
            game.answers = _answerService.GetGivenAmountOfAnswers(game.questions.Select(x => x.Id).ToList());
            game.currentQuestion = 0;
            game.score = 0;
            game.amount = amount;
            if (game.mod == null)
            {
                game.mod = Game.maxScore % game.amount;
            }
            game.step = Game.maxScore/game.amount; 
            return game;
        }
    }
}