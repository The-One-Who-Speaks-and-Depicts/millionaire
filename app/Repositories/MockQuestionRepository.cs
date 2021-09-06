using System.Collections.Generic;
using millionaire.Models;


namespace millionaire.Repos
{
    public class MockQuestionRepository : IQuestionRepository
    {
        public List<Question> GetGivenAmountOfQuestions(int amount) {
            var questionsList = new List<Question>(amount);
            for (int i = 0; i < questionsList.Capacity; i++)
            {
                questionsList.Add(new Question());
            }
            return questionsList;
        }
    }
}