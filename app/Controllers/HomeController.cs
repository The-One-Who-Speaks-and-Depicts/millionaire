using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using millionaire.Models;
using millionaire.Repos;
using millionaire.Services;

namespace millionaire.Controllers
{
    public class HomeController : Controller
    {        
        private readonly ILogger<HomeController> _logger;
        private static IQuestionService _questionService;
        private static IAnswerService _answerService;
        private static IGameService _gameService;

        private static Game game;

        public HomeController(ILogger<HomeController> logger, IQuestionService questionService, IAnswerService answerService, IGameService gameService)
        {
            _logger = logger;
            _questionService = questionService;
            _answerService = answerService;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            if (game != null)
            {
                game = null;
            }
            return View(new AmountStorager());
        }

        public IActionResult Rules()
        {
            return View();
        }

        int? GetUserAnswer()
        {
            try 
            {
               return Convert.ToInt32(Request.Form["user-answer"].ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }


        public IActionResult Game(int amount, string submit) 
        {            
            if (game == null) 
            {
                game = _gameService.GetGame(amount, _questionService, _answerService);
                return View(game);
            }
            _gameService.SwitchFiftyFiftyState(game, submit);
            if (game.score == millionaire.Models.Game.maxScore) return Redirect("/Home/Index");
            int? chosenAnswer = GetUserAnswer();      
            if (chosenAnswer == null) return View(game); 
            _gameService.CheckAnswer(game, chosenAnswer, amount);  
            return View(game);            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
