using System.Collections.Generic;
using millionaire.Models;
using millionaire.Repos;

namespace millionaire.Services
{
    public class MockQuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepo;

        public MockQuestionService(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }
        public List<Question> GetGivenAmountOfQuestions(int amount) => _questionRepo.GetGivenAmountOfQuestions(amount);
    }
}