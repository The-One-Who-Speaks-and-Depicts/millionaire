using millionaire.Models;
using System.Collections.Generic;
using millionaire.Data;
using System.Linq;
using System;
namespace millionaire.Repos
{
    public class SQLiteQuestionRepository : IQuestionRepository
    {
        public List<Question> GetAllQuestions()
        {
            using (var db = new MillionaireContext())
            {
                var rand = new Random();
                var questions = db.Questions.OrderBy(x=>rand.Next()).ToList();
                return questions;
            }            
        }
    }
}