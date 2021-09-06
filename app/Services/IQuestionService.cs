using millionaire.Models;
using System.Collections.Generic;

namespace millionaire.Services
{
    public interface IQuestionService
    {
        List<Question> GetGivenAmountOfQuestions(int amount);
    }
}