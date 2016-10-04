using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ArithmeticGame
{
    public class GameController : MonoBehaviour
    {
        public UIController UIController;
        MathQuestionController MathQuestionController;
        private int score = 0;

        void Start ()
        {
            MathQuestionController = new MathQuestionController();
            UIController.OnAnswered += CheckAnswer;
            Invoke("GenerateQuestion", 1f);
        }

        private void CheckAnswer(float answer)
        {
            var isTrueAnswer = currentQuestion.CheckIsTrueAnswer(answer);
            Debug.Log(string.Format("[{0}] Your answer {1} Correct Answer {2}", isTrueAnswer, answer, currentQuestion.Answer));

            if (isTrueAnswer)
                score ++;
            else
                score --;

            UIController.Score.text = score.ToString();

            GenerateQuestion();
        }

        MathQuestion currentQuestion;
        void GenerateQuestion()
        {
            currentQuestion = MathQuestionController.GetMathQuestion();
            UIController.ViewQuestion(currentQuestion);
        }
    }
}