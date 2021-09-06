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

            Assert.Equal(15, questions.Count);            
        }
    }
}
