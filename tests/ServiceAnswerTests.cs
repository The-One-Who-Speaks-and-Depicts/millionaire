using System;
using Xunit;
using millionaire.Repos;
using millionaire.Models;
using millionaire.Services;
using System.Collections.Generic;

namespace tests
{
    public class ServiceAnswerTests
    {

        [Fact]
        public void CheckAmountofAnswers()
        {
            var mockRepo = new MockAnswerRepository();
            var mockService = new MockAnswerService(mockRepo);
            var questionIds = new List<int>() {1, 2, 3};

            var questions = mockService.GetGivenAmountOfAnswers(questionIds);

            Assert.Equal(questionIds.Count*4, questions.Count);            
        }
    }
}
