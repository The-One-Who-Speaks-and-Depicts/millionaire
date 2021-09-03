﻿using System;
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
        private readonly SQLiteQuestionService _sqliteservice = new(new SQLiteQuestionRepository()); 
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new AmountStorager());
        }

        public IActionResult Rules()
        {
            return View();
        }

        public IActionResult Game(int amount) 
        {
            Game game = new();
            game.amount = amount;
            game.questions = _sqliteservice.GetGivenAmountOfQuestions(amount);
            return View(game);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
