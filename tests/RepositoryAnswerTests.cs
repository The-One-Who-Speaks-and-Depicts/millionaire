using Xunit;
using millionaire.Repos;
using System.Collections.Generic;

namespace tests
{
    public class RepositoryAnswerTests
    {
        [Fact]
        public void CheckAmountOfAnswers()
        {
            var questionIds = new List<int>() {1, 2, 3};
            var mockAnswerRepo = new MockAnswerRepository();

            var answers = mockAnswerRepo.GetGivenAmountOfAnswers(questionIds);

            Assert.Equal(questionIds.Count*4, answers.Count);
        }
    }
}