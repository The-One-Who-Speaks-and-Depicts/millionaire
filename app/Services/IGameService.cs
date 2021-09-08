using millionaire.Models;
using System.Collections.Generic;

namespace millionaire.Services
{
    public interface IGameService
    {
        Game GetGame(int amount, IQuestionService _questionService, IAnswerService _answerService);
        Game CheckAnswer(Game game, int? chosenAnswer, int amount);
        Game GameOver(Game game);
        Game SwitchFiftyFiftyState(Game game, string submit);
        Game Step(Game game, int _amount);
    }
}