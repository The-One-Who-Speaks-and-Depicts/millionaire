using millionaire.Models;
using System.Collections.Generic;
namespace millionaire.Repos
{
    public interface IAnswerRepository
    {
        List<Answer> GetGivenAmountOfAnswers(List<int> questionIds);
    }
}