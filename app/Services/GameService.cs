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
    }
}