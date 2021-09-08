using millionaire.Models;
using System.Collections.Generic;
using millionaire.Services;
namespace millionaire.Repos
{
    public interface IGameRepository
    {
        Game GetGame(int amount, IQuestionService _questionService, IAnswerService _answerService);
    }
}