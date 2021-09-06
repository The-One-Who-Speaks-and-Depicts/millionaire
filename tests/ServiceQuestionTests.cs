using System;
using Xunit;
using millionaire.Repos;
using millionaire.Models;
using millionaire.Services;
using System.Collections.Generic;

namespace tests
{
    public class ServiceQuestionTests
    {

        [Fact]
        public void CheckAmountofQuestions()
        {
            var mockRepo = new MockQuestionRepository();
            var mockService = new MockQuestionService(mockRepo);

            var questions = mockService.GetGivenAmountOfQuestions(15);

            Assert.Equal(15, questions.Count);            
        }
    }
}
