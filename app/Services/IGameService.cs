using millionaire.Models;
using System.Collections.Generic;

namespace millionaire.Services
{
    public interface IGameService
    {
        Game GetGame(int amount, IQuestionService _questionService, IAnswerService _answerService);
        void CheckAnswer(Game game, int? chosenAnswer, int amount);
        void GameOver(Game game);
        void SwitchFiftyFiftyState(Game game, string submit);
        void Step(Game game, int _amount);
    }
}