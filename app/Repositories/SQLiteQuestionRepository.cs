using millionaire.Models;
using System.Collections.Generic;
using millionaire.Data;
using System.Linq;
using System;
namespace millionaire.Repos
{
    public class SQLiteQuestionRepository : IQuestionRepository
    {
        public List<Question> GetGivenAmountOfQuestions(int amount)
        {
            using (var db = new MillionaireContext())
            {
                var rand = new Random();
                var questions = db.Questions.AsEnumerable().OrderBy(x=>rand.Next()).Take(amount).ToList();
                return questions;
            }
        }
    }
}