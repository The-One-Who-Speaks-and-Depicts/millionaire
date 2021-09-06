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

        private static Game game;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult Game(int amount, string submit) 
        {
            switch (submit)
            {
                case "Fifty":
                    game.fifty_fifty_used = "Now";
                    break;
                case "Answer":
                default:                    
                    if (game == null) 
                    {
                        game = new Game(amount); 
                    }
                    else
                    {
                        if (game.fifty_fifty_used == "Now") {
                            game.fifty_fifty_used = "Yes";
                        }
                        var userAnswer = Request.Form["user-answer"];
                        if (String.IsNullOrEmpty(userAnswer.ToString())) return View(game);
                        int chosenAnswer = Convert.ToInt32(userAnswer);
                        if (game.answers.Where(x => x.Id == chosenAnswer).First().correct == "True")
                        {
                            game.amount = amount;
                            if (game.score < millionaire.Models.Game.maxScore)
                            {
                                game.score += game.step;
                                if (millionaire.Models.Game.maxScore - game.score == game.mod)
                                {
                                    game.score = millionaire.Models.Game.maxScore;
                                }
                            }                
                            else 
                            {
                                game = null;
                                return Redirect("/Home/Index");
                            }                
                            if (game.questions.Count > 1)
                            {
                                game.questions = game.questions.Where(x => x != game.questions[0]).ToList();
                            }
                            if (game.score == millionaire.Models.Game.maxScore) game.result = "You won!";
                        }
                        else 
                        {
                            game.gameOver = true;
                            game.result = "You lost!";
                        }                                
                    }
                    break;
            }            
            
            return View(game);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
