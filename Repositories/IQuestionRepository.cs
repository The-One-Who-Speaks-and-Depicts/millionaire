using millionaire.Models;
using System.Collections.Generic;
namespace millionaire.Repos
{
    public interface IQuestionRepository
    {
        List<Question> GetAllQuestions();
        List<Question> GetGivenAmountOfQuestions(int amount);
    }
}