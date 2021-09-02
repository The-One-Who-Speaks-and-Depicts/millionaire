using millionaire.Models;
using System.Collections.Generic;
using millionaire.Data;
using System.Linq;
namespace millionaire.Repos
{
    public class SQLiteQuestionRepository : IQuestionRepository
    {
        public List<Question> GetAllQuestions()
        {
            using (var db = new MillionaireContext())
            {
                var questions = db.Questions.ToList();
                return questions;
            }            
        }
    }
}