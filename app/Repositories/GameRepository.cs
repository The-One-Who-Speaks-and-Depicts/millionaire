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
            return new Game(amount, _questionService, _answerService);
        }
    }
}