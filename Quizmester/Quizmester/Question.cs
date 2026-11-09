using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmester
{
    // This class represents one question loaded from the Questions database table.
    internal class Question
    {
        // Database identifier for the question.
        public int Id;

        // The question text and its possible answers.
        public string Text;
        public string CorrectAnswer;
        public string WrongAnswer1;
        public string WrongAnswer2;
        public string WrongAnswer3;

        // Category used when the player starts a category quiz.
        public string Category;
    }
}
