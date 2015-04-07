using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessingGame
{
    public class Game
    {
        public void Run()
        {
            //If you're reading these comments, you probably should start with the TrainOfThought.txt
            Answer answer = new Answer("lives in water", "shark");
            //The "eligible" guess should the first answer be "No"
            string eligibleGuess = "monkey";

            while (true)
            {
                //TEXT: "Think about an animal..."
                var result = MessageBox.Show(TextStorage.SUGGESTION, TextStorage.TITLE, MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                    return;
                //Now the fun begins
                ChooseAnswer(answer, eligibleGuess);
            }
        }

        private void ChooseAnswer(Answer answer, string eligibleGuess)
        {
            //TEXT: "Does the animal that you thought about {path.Question}?"
            answer.IsYes = Ask(TextStorage.QUESTION, answer.Question);

            if (answer.IsYes)
            {
                //In case of the answer being yes, the "eligible" guess at this time is the one bound to the answer itself
                eligibleGuess = answer.Guess;
                //If there are no answers left for "Yes", it tries to guess
                if (answer.IsLastYes)
                    Guess(answer, eligibleGuess);
                else
                    ChooseAnswer(answer.AnswerYes, eligibleGuess);
            }
            else
            {
                /* The same behaviour as above, but regarding the answer being "No". However, if there are no answers for a "No" left 
                * it will attempt to guess the eligible candidate that was defined last time "Yes" was the answer */
                if (answer.IsLastNo)
                    Guess(answer, eligibleGuess);
                else
                    ChooseAnswer(answer.AnswerNo, eligibleGuess);
            }
        }
        private void Guess(Answer answer, string eligibleGuess)
        {
            //In a guess attempt, "No" will always amount to adding a new question
            //TEXT: "Is the animal that you thought about a {eligibleGuess}?"
            if (Ask(TextStorage.GUESS, eligibleGuess))
                ShowCpuWinMessage();
            else
                AddNewQuestion(answer, eligibleGuess);
        }
        private bool Ask(string text, string value)
        {
            return MessageBox.Show(String.Format(text, value), TextStorage.TITLE, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
        private void ShowCpuWinMessage()
        {
            MessageBox.Show(TextStorage.CPU_WINS, TextStorage.TITLE, MessageBoxButtons.OK);
        }
        private void AddNewQuestion(Answer lastAnswer, string eligibleGuess)
        {
            //TEXT: "What was the animal that you thought about?"
            var guess = InputDialog.Show(TextStorage.TITLE, TextStorage.ADD_GUESS);
            //TEXT: "A {guess} ______ but a {eligibleGuess} does not (Fill it with an animal trait, like 'lives in water')."
            var question = InputDialog.Show(TextStorage.TITLE, String.Format(TextStorage.ADD_QUESTION, guess, eligibleGuess));

            //I suppose at this point, a check for empty strings could be added, but it is not in the sample program so I commented it out
            //if (String.IsNullOrEmpty(guess) || String.IsNullOrEmpty(question))
            //    return;

            var answer = new Answer(question, guess);
            if (lastAnswer.IsYes)
                lastAnswer.AnswerYes = answer;
            else
                lastAnswer.AnswerNo = answer;
        }
    }
}
  