using millionaire.Models;
using System.Collections.Generic;
using millionaire.Data;
using System.Linq;
using System;
namespace millionaire.Repos
{
    public class SQLiteAnswerRepository : IAnswerRepository
    {
        public List<Answer> GetAllAnswers()
        {
            using (var db = new MillionaireContext())
            {
                var rand = new Random();
                var answers = db.Answers.ToList();
                return answers;
            }            
        }

        public List<Answer> GetGivenAmountOfAnswers(List<int> questionIds)
        {
            using (var db = new MillionaireContext())
            {
                var rand = new Random();
                var answers = db.Answers.Where(x => questionIds.Contains(x.questionId)).ToList();
                return answers;
            }
        }
    }
}