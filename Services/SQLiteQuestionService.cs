using millionaire.Models;
using millionaire.Repos;
using System.Collections.Generic;

namespace millionaire.Services
{
    public class SQLiteQuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepo;

        public SQLiteQuestionService(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public List<Question> GetAllQuestions() => _questionRepo.GetAllQuestions();
        public List<Question> GetGivenAmountOfQuestions(int amount) => _questionRepo.GetGivenAmountOfQuestions(amount);

    }
}