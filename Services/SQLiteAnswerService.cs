using millionaire.Models;
using millionaire.Repos;
using System.Collections.Generic;

namespace millionaire.Services
{
    public class SQLiteAnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepo;

        public SQLiteAnswerService(IAnswerRepository answerRepo)
        {
            _answerRepo = answerRepo;
        }

        public List<Answer> GetAllAnswers() => _answerRepo.GetAllAnswers();
        public List<Answer> GetGivenAmountOfAnswers(List<int> questionIds) => _answerRepo.GetGivenAmountOfAnswers(questionIds);

    }
}