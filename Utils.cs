using millionaire.Data;
using millionaire.Models;
using System;
using System.Collections.Generic;

namespace millionaire
{
    static class Utils
    {
        public static void AddQuestionsAndAnswers()
        {
            using (var db = new MillionaireContext())
            {
                db.Add(new Question {
                    Id = 1,
                    text = "Who loves Paris?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 1,
                            text = "Maestro",
                            correct = "True",
                            questionId = 1,
                        },
                        new Answer()
                        {
                            Id = 2,
                            text = "Alaric",
                            correct = "False",
                            questionId = 1,
                        },
                        new Answer()
                        {
                            Id = 3,
                            text = "Stilico",
                            correct = "False",
                            questionId = 1,
                        },
                        new Answer()
                        {
                            Id = 4,
                            text = "Obelix",
                            correct = "False",
                            questionId = 1,
                        },
                    }
                });
                db.Add(new Question {
                    Id = 2,
                    text = "Who was the most famous German Roman commander?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 5,
                            text = "Asterix",
                            correct = "False",
                            questionId = 2,
                        },
                        new Answer()
                        {
                            Id = 6,
                            text = "Alaric",
                            correct = "False",
                            questionId = 2,
                        },
                        new Answer()
                        {
                            Id = 7,
                            text = "Stilico",
                            correct = "True",
                            questionId = 2,
                        },
                        new Answer()
                        {
                            Id = 8,
                            text = "Obelix",
                            correct = "False",
                            questionId = 2,
                        },
                    }
                });
                db.Add(new Question {
                    Id = 3,
                    text = "Which city proclaimed itself to be the Third Rome?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 9,
                            text = "Moscow",
                            correct = "True",
                            questionId = 3,
                        },
                        new Answer()
                        {
                            Id = 10,
                            text = "Saint Petersburg",
                            correct = "False",
                            questionId = 3,
                        },
                        new Answer()
                        {
                            Id = 11,
                            text = "Paris",
                            correct = "False",
                            questionId = 3,
                        },
                        new Answer()
                        {
                            Id = 12,
                            text = "London",
                            correct = "False",
                            questionId = 3,
                        },
                    }
                });
                db.Add(new Question {
                    Id = 4,
                    text = "When did the Rome fall?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 13,
                            text = "435",
                            correct = "False",
                            questionId = 4,
                        },
                        new Answer()
                        {
                            Id = 14,
                            text = "476",
                            correct = "True",
                            questionId = 4,
                        },
                        new Answer()
                        {
                            Id = 15,
                            text = "500",
                            correct = "False",
                            questionId = 4,
                        },
                        new Answer()
                        {
                            Id = 16,
                            text = "301",
                            correct = "False",
                            questionId = 4,
                        },
                    }
                });
                db.Add(new Question {
                    Id = 5,
                    text = "What was the INITIAL name of the Eastern Roman Empire capital?",
                    answers = new List<Answer>()
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
                    }
                });
                db.Add(new Question {
                    Id = 6,
                    text = "Who denounced the existence of the last Roman Empire?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 21,
                            text = "Peter the Great",
                            correct = "False",
                            questionId = 6,
                        },
                        new Answer()
                        {
                            Id = 22,
                            text = "Mehmed II",
                            correct = "False",
                            questionId = 6,
                        },
                        new Answer()
                        {
                            Id = 23,
                            text = "Napoleon",
                            correct = "False",
                            questionId = 6,
                        },
                        new Answer()
                        {
                            Id = 24,
                            text = "Franz II",
                            correct = "True",
                            questionId = 6,
                        },
                    }
                });
                db.Add(new Question {
                    Id = 7,
                    text = "From which year the Holy Roman empire started using the title with 'Germanic nation' in it?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 25,
                            text = "1512",
                            correct = "True",
                            questionId = 7,
                        },
                        new Answer()
                        {
                            Id = 26,
                            text = "962",
                            correct = "False",
                            questionId = 7,
                        },
                        new Answer()
                        {
                            Id = 27,
                            text = "1346",
                            correct = "False",
                            questionId = 7,
                        },
                        new Answer()
                        {
                            Id = 28,
                            text = "1803",
                            correct = "False",
                            questionId = 7,
                        },
                    }
                });
                db.Add(new Question {
                    Id = 8,
                    text = "Which city was the first capital of the Holy Roman Empire?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 29,
                            text = "Prague",
                            correct = "False",
                            questionId = 8,
                        },
                        new Answer()
                        {
                            Id = 30,
                            text = "Regensburg",
                            correct = "False",
                            questionId = 8,
                        },
                        new Answer()
                        {
                            Id = 31,
                            text = "Paris",
                            correct = "False",
                            questionId = 8,
                        },
                        new Answer()
                        {
                            Id = 32,
                            text = "Aachen",
                            correct = "True",
                            questionId = 8,
                        },
                    }
                });
                db.Add(new Question {
                    Id = 9,
                    text = "Which dinasty did the last monarch of the Holy Roman Empire belong to?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 33,
                            text = "Romanovs",
                            correct = "False",
                            questionId = 9,
                        },
                        new Answer()
                        {
                            Id = 34,
                            text = "Habsburgs",
                            correct = "True",
                            questionId = 9,
                        },
                        new Answer()
                        {
                            Id = 35,
                            text = "Windsors",
                            correct = "False",
                            questionId = 9,
                        },
                        new Answer()
                        {
                            Id = 36,
                            text = "Alexandrians",
                            correct = "False",
                            questionId = 9,
                        },
                    }
                });
                db.Add(new Question {
                    Id = 10,
                    text = "How many hills is the Rome built on?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 37,
                            text = "2",
                            correct = "False",
                            questionId = 10,
                        },
                        new Answer()
                        {
                            Id = 38,
                            text = "3",
                            correct = "False",
                            questionId = 10,
                        },
                        new Answer()
                        {
                            Id = 39,
                            text = "5",
                            correct = "False",
                            questionId = 10,
                        },
                        new Answer()
                        {
                            Id = 40,
                            text = "7",
                            correct = "True",
                            questionId = 10,
                        },
                    }
                });
                db.Add(new Question {
                    Id = 11,
                    text = "Which animal is the symbol of the Rome?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 41,
                            text = "Bear",
                            correct = "False",
                            questionId = 11,
                        },
                        new Answer()
                        {
                            Id = 42,
                            text = "Wolf",
                            correct = "True",
                            questionId = 11,
                        },
                        new Answer()
                        {
                            Id = 43,
                            text = "Fox",
                            correct = "False",
                            questionId = 11,
                        },
                        new Answer()
                        {
                            Id = 44,
                            text = "Rabbit",
                            correct = "False",
                            questionId = 11,
                        },
                    }
                });
                db.Add(new Question {
                    Id = 12,
                    text = "Which football club origins from Rome?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 45,
                            text = "Lazio",
                            correct = "True",
                            questionId = 12,
                        },
                        new Answer()
                        {
                            Id = 46,
                            text = "Juventus",
                            correct = "False",
                            questionId = 12,
                        },
                        new Answer()
                        {
                            Id = 47,
                            text = "Inter",
                            correct = "False",
                            questionId = 12,
                        },
                        new Answer()
                        {
                            Id = 48,
                            text = "Milan",
                            correct = "False",
                            questionId = 12,
                        },
                    }
                });
                db.Add(new Question {
                    Id = 13,
                    text = "Which sightseeing is the Rome famous for?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 49,
                            text = "The Colosseum",
                            correct = "True",
                            questionId = 13,
                        },
                        new Answer()
                        {
                            Id = 50,
                            text = "The Tower",
                            correct = "False",
                            questionId = 13,
                        },
                        new Answer()
                        {
                            Id = 51,
                            text = "The Pyramids",
                            correct = "False",
                            questionId = 13,
                        },
                        new Answer()
                        {
                            Id = 52,
                            text = "The Colossus",
                            correct = "False",
                            questionId = 13,
                        },
                    }
                });
                db.Add(new Question {
                    Id = 14,
                    text = "Who was the first Emperor of the Holy Roman Empire?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 53,
                            text = "Constantine",
                            correct = "False",
                            questionId = 14,
                        },
                        new Answer()
                        {
                            Id = 54,
                            text = "Caesar",
                            correct = "False",
                            questionId = 14,
                        },
                        new Answer()
                        {
                            Id = 55,
                            text = "Otton I",
                            correct = "True",
                            questionId = 14,
                        },
                        new Answer()
                        {
                            Id = 56,
                            text = "Clovis",
                            correct = "False",
                            questionId = 14,
                        },
                    }
                });
                db.Add(new Question {
                    Id = 15,
                    text = "How many kings ruled in Rome?",
                    answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 57,
                            text = "12",
                            correct = "False",
                            questionId = 15,
                        },
                        new Answer()
                        {
                            Id = 58,
                            text = "15",
                            correct = "False",
                            questionId = 15,
                        },
                        new Answer()
                        {
                            Id = 59,
                            text = "21",
                            correct = "False",
                            questionId = 15,
                        },
                        new Answer()
                        {
                            Id = 60,
                            text = "7",
                            correct = "True",
                            questionId = 15,
                        },
                    }
                });
                db.SaveChanges();
            }
        }
    }
}