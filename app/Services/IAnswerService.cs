using millionaire.Models;
using System.Collections.Generic;

namespace millionaire.Services
{
    public interface IAnswerService
    {
        List<Answer> GetGivenAmountOfAnswers(List<int> questionIds);
    }
}