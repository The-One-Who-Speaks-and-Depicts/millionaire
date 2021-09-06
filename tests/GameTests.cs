using millionaire.Controllers;
using millionaire.Models;
using Moq;
using Microsoft.Extensions.Logging;
using Xunit;
using System.Reflection;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            var logger = new Mock<ILogger<HomeController>>();
            HomeController hc = new(logger.Object);

            var indexPage = hc.Index();

            Assert.NotNull(indexPage);
        }

        [Fact]
        public void nullGameTest_GameExists_GameNullified()
        {
            var logger = new Mock<ILogger<HomeController>>();
            HomeController hc = new(logger.Object);
            var field = typeof(HomeController).GetField("game", 
                            BindingFlags.Static | 
                            BindingFlags.NonPublic);
            field.SetValue(null, new Game(5));                       
            
            hc.Index();
            var game = field.GetValue(null);

            Assert.Equal(null, game);
        }

        [Fact]
        public void RulesTest()
        {
            var logger = new Mock<ILogger<HomeController>>();
            HomeController hc = new(logger.Object);

            var rulesPage = hc.Rules();

            Assert.NotNull(rulesPage);
        }

        [Fact]
        public void fiftyJustUsed_StateIsNow()
        {
            var logger = new Mock<ILogger<HomeController>>();
            HomeController hc = new(logger.Object);
            var game = new Game(3);
            game.fifty_fifty_used = "No";
            var field = typeof(HomeController).GetField("game", 
                            BindingFlags.Static | 
                            BindingFlags.NonPublic);
            field.SetValue(null, game);

            hc.Game(3, "Fifty");
            var currentGame = (Game)field.GetValue(null);
            
            Assert.Equal("Now", currentGame.fifty_fifty_used);
        }

        [Fact]
        public void fiftyWasUsed_StateIsYes()
        {
            var logger = new Mock<ILogger<HomeController>>();
            HomeController hc = new(logger.Object);
            var game = new Game(3);
            game.fifty_fifty_used = "Now";
            var field = typeof(HomeController).GetField("game", 
                            BindingFlags.Static | 
                            BindingFlags.NonPublic);
            field.SetValue(null, game);

            hc.Game(3, "Answer");
            var currentGame = (Game)field.GetValue(null);
            
            Assert.Equal("Yes", currentGame.fifty_fifty_used);
        }
        [Fact]
        public void fiftyNotUsed_StateIsNo()
        {
            var logger = new Mock<ILogger<HomeController>>();
            HomeController hc = new(logger.Object);
            var game = new Game(3);
            game.fifty_fifty_used = "No";
            var field = typeof(HomeController).GetField("game", 
                            BindingFlags.Static | 
                            BindingFlags.NonPublic);
            field.SetValue(null, game);

            hc.Game(3, "Answer");
            var currentGame = (Game)field.GetValue(null);
            
            Assert.Equal("No", currentGame.fifty_fifty_used);
        }

        [Fact]
        public void correctAnswerCheck_falseAnswerGiven()
        {
            var logger = new Mock<ILogger<HomeController>>();
            HomeController hc = new(logger.Object);
            var game = new Game(3);
            game.answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 17,
                    text = "Istanbul",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 18,
                    text = "Constantinople",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 19,
                    text = "Jerusalem",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 20,
                    text = "Byzantium",
                    correct = "True",
                    questionId = 5,
                },
            };
            var field = typeof(HomeController).GetField("game", 
                            BindingFlags.Static | 
                            BindingFlags.NonPublic);
            field.SetValue(null, game);

            hc.Game(3, "Answer", "19");
            var currentGame = (Game)field.GetValue(null);
            
            Assert.Equal("You lost!", currentGame.result);
        }

        [Fact]
        public void correctAnswerCheck_finalApproval()
        {
            var logger = new Mock<ILogger<HomeController>>();
            HomeController hc = new(logger.Object);
            var game = new Game(3);
            game.answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 17,
                    text = "Istanbul",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 18,
                    text = "Constantinople",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 19,
                    text = "Jerusalem",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 20,
                    text = "Byzantium",
                    correct = "True",
                    questionId = 5,
                },
            };
            game.score = millionaire.Models.Game.maxScore / game.amount * (game.amount - 1);
            var field = typeof(HomeController).GetField("game", 
                            BindingFlags.Static | 
                            BindingFlags.NonPublic);
            field.SetValue(null, game);

            hc.Game(3, "Answer", "20");
            var currentGame = (Game)field.GetValue(null);
            
            Assert.Equal("You won!", currentGame.result);
        }

        [Fact]
        public void correctAnswerCheck_questionListReduction()
        {
            var logger = new Mock<ILogger<HomeController>>();
            HomeController hc = new(logger.Object);
            var game = new Game(3);
            game.answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 17,
                    text = "Istanbul",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 18,
                    text = "Constantinople",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 19,
                    text = "Jerusalem",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 20,
                    text = "Byzantium",
                    correct = "True",
                    questionId = 5,
                },
            };
            game.questions = new List<Question>()
            {
                new Question {
                    Id = 1,
                    text = "Who loves Paris?",                    
                },
                new Question {
                    Id = 2,
                    text = "Who was the most famous German Roman commander?",
                }
            };
            int count = game.questions.Count;
            game.score = millionaire.Models.Game.maxScore / game.amount * (game.amount - 2);
            var field = typeof(HomeController).GetField("game", 
                            BindingFlags.Static | 
                            BindingFlags.NonPublic);
            field.SetValue(null, game);

            hc.Game(3, "Answer", "20");
            var currentGame = (Game)field.GetValue(null);
            
            Assert.NotEqual(count, currentGame.questions.Count);
        }

        [Fact]
        public void correctAnswerCheck_gameNullification()
        {
            var logger = new Mock<ILogger<HomeController>>();
            HomeController hc = new(logger.Object);
            var game = new Game(3);
            game.answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 17,
                    text = "Istanbul",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 18,
                    text = "Constantinople",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 19,
                    text = "Jerusalem",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 20,
                    text = "Byzantium",
                    correct = "True",
                    questionId = 5,
                },
            };
            game.score = millionaire.Models.Game.maxScore;
            var field = typeof(HomeController).GetField("game", 
                            BindingFlags.Static | 
                            BindingFlags.NonPublic);
            field.SetValue(null, game);

            hc.Game(3, "Answer", "20");
            var currentGame = (Game)field.GetValue(null);
            
            Assert.Null(currentGame);
        }

        [Fact]
        public void correctAnswerCheck_finalAdditionInFloatDivisionCase()
        {
            var logger = new Mock<ILogger<HomeController>>();
            HomeController hc = new(logger.Object);
            var game = new Game(3);
            game.answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 17,
                    text = "Istanbul",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 18,
                    text = "Constantinople",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 19,
                    text = "Jerusalem",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 20,
                    text = "Byzantium",
                    correct = "True",
                    questionId = 5,
                },
            };
            game.questions = new List<Question>()
            {
                new Question {
                    Id = 1,
                    text = "Who loves Paris?",                    
                },
                new Question {
                    Id = 2,
                    text = "Who was the most famous German Roman commander?",
                }
            };
            game.score = millionaire.Models.Game.maxScore / game.amount * (game.amount - 1);
            int score = game.score;
            var field = typeof(HomeController).GetField("game", 
                            BindingFlags.Static | 
                            BindingFlags.NonPublic);
            field.SetValue(null, game);

            hc.Game(3, "Answer", "20");
            var currentGame = (Game)field.GetValue(null);
            
            Assert.NotEqual(score, millionaire.Models.Game.maxScore - currentGame.step);
        }

        [Fact]
        public void correctAnswerCheck_StepAddition()
        {
            var logger = new Mock<ILogger<HomeController>>();
            HomeController hc = new(logger.Object);
            var game = new Game(3);
            game.answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 17,
                    text = "Istanbul",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 18,
                    text = "Constantinople",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 19,
                    text = "Jerusalem",
                    correct = "False",
                    questionId = 5,
                },
                new Answer()
                {
                    Id = 20,
                    text = "Byzantium",
                    correct = "True",
                    questionId = 5,
                },
            };
            game.questions = new List<Question>()
            {
                new Question {
                    Id = 1,
                    text = "Who loves Paris?",                    
                },
                new Question {
                    Id = 2,
                    text = "Who was the most famous German Roman commander?",
                }
            };
            game.score = millionaire.Models.Game.maxScore / game.amount;
            int score = game.score;
            var field = typeof(HomeController).GetField("game", 
                            BindingFlags.Static | 
                            BindingFlags.NonPublic);
            field.SetValue(null, game);

            hc.Game(5, "Answer", "20");
            var currentGame = (Game)field.GetValue(null);
            
            Assert.Equal(score + currentGame.step, currentGame.score);
        }
    }
}