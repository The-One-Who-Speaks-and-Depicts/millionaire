using System;
using Xunit;
using millionaire.Repos;
using millionaire.Models;
using System.Collections.Generic;

namespace tests
{
    public class RepositoryQuestionTests
    {

        [Fact]
        public void CheckAmountofQuestions()
        {
            var mockRepo = new MockQuestionRepository();

            var questions = mockRepo.GetGivenAmountOfQuestions(15);
            for (int i = 0; i < questions.Capacity; i++)
            {
                questions.Add(new Question());
            }            

            Assert.Equal(15, questions.Count);            
        }
    }
}
