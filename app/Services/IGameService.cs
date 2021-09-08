using millionaire.Models;
using System.Collections.Generic;

namespace millionaire.Services
{
    public interface IGameService
    {
        Game GetGame(int amount, IQuestionService _questionService, IAnswerService _answerService);
    }
}