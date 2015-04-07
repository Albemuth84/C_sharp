using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    public class TextStorage
    {
        private TextStorage() { }
        public const string TITLE = "Guessing Game";
        public const string SUGGESTION = "Think about an animal...";
        public const string CPU_WINS = "I win again!";
        public const string QUESTION = "Does the animal that you thought about {0}?";
        public const string GUESS = "Is the animal that you thought about a {0}?";
        public const string ADD_QUESTION = "A {0} ______ but a {1} does not (Fill it with an animal trait, like 'lives in water').";
        public const string ADD_GUESS = "What was the animal that you thought about?";
    }
}
