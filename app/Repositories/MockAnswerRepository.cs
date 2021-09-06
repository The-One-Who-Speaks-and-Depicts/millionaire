using System.Collections.Generic;
using millionaire.Models;

namespace  millionaire.Repos
{
    public class MockAnswerRepository : IAnswerRepository
    {
        public List<Answer> GetGivenAmountOfAnswers(List<int> ids) {
            var answersList = new List<Answer>(ids.Count * 4);
            for (int i = 0; i < answersList.Capacity; i++) 
            {
                answersList.Add(new Answer());
            }
            return answersList;
        }
    }
}