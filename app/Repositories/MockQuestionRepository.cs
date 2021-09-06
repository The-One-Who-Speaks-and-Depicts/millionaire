using System.Collections.Generic;
using millionaire.Models;


namespace millionaire.Repos
{
    public class MockQuestionRepository : IQuestionRepository
    {
        public List<Question> GetGivenAmountOfQuestions(int amount) => new List<Question>(amount);
    }
}