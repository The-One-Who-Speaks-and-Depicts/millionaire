using millionaire.Controllers;
using millionaire.Models;
using Moq;
using Microsoft.Extensions.Logging;
using Xunit;
using System.Reflection;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using millionaire.Services;
using millionaire.Repos;

namespace tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            var logger = new Mock<ILogger<HomeController>>();
            var questionService = new Mock<IQuestionService>();
            var answerService = new Mock<IAnswerService>();
            var gameService = new Mock<IGameService>();
            HomeController hc = new(logger.Object, questionService.Object, answerService.Object, gameService.Object);

            var indexPage = hc.Index();

            Assert.NotNull(indexPage);
        }

        [Fact]
        public void nullGameTest_GameExists_GameNullified()
        {
            var logger = new Mock<ILogger<HomeController>>();
            var questionService = new Mock<IQuestionService>();
            var answerService = new Mock<IAnswerService>();
            var gameService = new Mock<IGameService>();
            HomeController hc = new(logger.Object, questionService.Object, answerService.Object, gameService.Object);
            var field = typeof(HomeController).GetField("game", 
                            BindingFlags.Static | 
                            BindingFlags.NonPublic);
            var game = new Game();
            field.SetValue(null, game);                       
            
            hc.Index();
            var currentGame = field.GetValue(null);

            Assert.Null(currentGame);
        }

        [Fact]
        public void RulesTest()
        {
            var logger = new Mock<ILogger<HomeController>>();
            var questionService = new Mock<IQuestionService>();
            var answerService = new Mock<IAnswerService>();
            var gameService = new Mock<IGameService>();
            HomeController hc = new(logger.Object, questionService.Object, answerService.Object, gameService.Object);

            var rulesPage = hc.Rules();

            Assert.NotNull(rulesPage);
        }

        [Fact]
        public void fiftyJustUsed_StateIsNow()
        {
            var gameService = new GameService(new GameRepository());
            var mockGame = new Mock<Game>().Object;
            mockGame.fifty_fifty_used = "No";            

            gameService.SwitchFiftyFiftyState(mockGame, "50:50");
            
            Assert.Equal("Now", mockGame.fifty_fifty_used);
        }

        [Fact]
        public void fiftyWasUsed_StateIsYes()
        {
            var gameService = new GameService(new GameRepository());
            var mockGame = new Mock<Game>().Object;
            mockGame.fifty_fifty_used = "Now";     

            gameService.SwitchFiftyFiftyState(mockGame, "Answer");
            
            Assert.Equal("Yes", mockGame.fifty_fifty_used);
        }

        [Fact]
        public void fiftyNotUsed_StateIsNo()
        {
            var gameService = new GameService(new GameRepository());
            var mockGame = new Mock<Game>().Object;
            mockGame.fifty_fifty_used = "No";

            gameService.SwitchFiftyFiftyState(mockGame, "Answer");
            
            Assert.Equal("No", mockGame.fifty_fifty_used);
        }

        [Fact]
        public void correctAnswerCheck_falseAnswerGiven()
        {
            var gameService = new GameService(new GameRepository());
            var game = new Mock<Game>().Object;
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

            gameService.CheckAnswer(game, 19, 3);
            
            Assert.Equal("You lost!", game.result);
        }
        [Fact]
        public void correctAnswerCheck_finalApproval()
        {
            var gameService = new GameService(new GameRepository());
            var game = new Mock<Game>().Object;
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
            game.amount = 3;
            millionaire.Models.Game.maxScore = 1000000;
            game.mod = millionaire.Models.Game.maxScore % game.amount;
            game.step = millionaire.Models.Game.maxScore / game.amount;
            game.score = millionaire.Models.Game.maxScore / game.amount * (game.amount - 1);
            gameService.CheckAnswer(game, 20, 3);
            
            Assert.Equal("You won!", game.result);
        }
        
        [Fact]
        public void correctAnswerCheck_questionListReduction()
        {
            var gameService = new GameService(new GameRepository());
            var currentGame = new Mock<Game>().Object;
            currentGame.amount = 3;
            currentGame.answers = new List<Answer>()
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
            currentGame.questions = new List<Question>()
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
            int count = currentGame.questions.Count;
            millionaire.Models.Game.maxScore = 1000000;
            currentGame.score = millionaire.Models.Game.maxScore / currentGame.amount * (currentGame.amount - 2);

            gameService.CheckAnswer(currentGame, 20, 4);
            
            Assert.NotEqual(count, currentGame.questions.Count);
        }
        [Fact]
        public void correctAnswerCheck_finalAdditionInFloatDivisionCase()
        {
            var gameService = new GameService(new GameRepository());
            var game = new Mock<Game>().Object;
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
            game.amount = 3;
            millionaire.Models.Game.maxScore = 1000000;
            game.mod = millionaire.Models.Game.maxScore % game.amount;
            game.step = millionaire.Models.Game.maxScore / game.amount;
            game.score = millionaire.Models.Game.maxScore / game.amount * (game.amount - 1);
            int score = game.score;

            gameService.Step(game, 3);

            Assert.NotEqual(score, millionaire.Models.Game.maxScore - game.step);
        }

        [Fact]
        public void correctAnswerCheck_StepAddition()
        {
            var gameService = new GameService(new GameRepository());
            var game = new Mock<Game>().Object;
            game.amount = 5;
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
            millionaire.Models.Game.maxScore = 1000000;
            game.mod = millionaire.Models.Game.maxScore % game.amount;
            game.step = millionaire.Models.Game.maxScore / game.amount;
            game.score = millionaire.Models.Game.maxScore / game.amount * (game.amount - 1);
            int score = game.score;

            gameService.Step(game, 5);
            
            Assert.Equal(score + game.step, game.score);
        }

        [Fact]
        public void correctAnswerCheck_gameNullification()
        {
            var logger = new Mock<ILogger<HomeController>>().Object;
            var questionService = new Mock<IQuestionService>().Object;
            var answerService = new Mock<IAnswerService>().Object;            
            var gameService = new GameService(new GameRepository());
            var mockController = new Mock<HomeController>(logger, questionService, answerService, gameService).Object;
            var game = new Mock<Game>().Object;
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
            game.score = 1000000;
            Type type = typeof(HomeController);
            FieldInfo info = type.GetField("game", BindingFlags.NonPublic | BindingFlags.Static);
            info.SetValue(null, game);

            mockController.Index();
            
            Assert.Null(info.GetValue(null));
        }
    }
}