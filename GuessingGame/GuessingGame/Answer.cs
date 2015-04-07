using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    public class Answer
    {
        public Answer(string question, string guess)
        {
            this.Guess = guess;
            this.Question = question;
        }

        public bool IsYes { get; set; }
        public string Guess { get; private set; }
        public string Question { get; private set; }
        public Answer AnswerYes { get; set; }
        public Answer AnswerNo { get; set; }

        public bool IsLastYes
        {
            get { return this.AnswerYes == null; }
        }
        public bool IsLastNo
        {
            get { return this.AnswerNo == null; }
        }
    }
}
