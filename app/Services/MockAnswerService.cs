using System.Collections.Generic;
using millionaire.Models;
using millionaire.Repos;

namespace millionaire.Services
{
    public class MockAnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepo;

        public MockAnswerService(IAnswerRepository answerRepo)
        {
            _answerRepo = answerRepo;
        }
        public List<Answer> GetGivenAmountOfAnswers(List<int> ids) => _answerRepo.GetGivenAmountOfAnswers(ids);
    }
}