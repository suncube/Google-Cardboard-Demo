using System;
using UnityEngine;
using UnityEngine.UI;

namespace ArithmeticGame
{
    public class UIController : MonoBehaviour
    {
        public Text Score;
        [Header("")]
        public AnswerNode[] AnswerNode;
        public Text QuestionText;
        public Action<float> OnAnswered;

        void Awake()
        {
            for (var index = 0; index < AnswerNode.Length; index++)
                AnswerNode[index].OnAnswered += SendAnswer;

            Score.text = "0";
        }

        private void SendAnswer(AnswerNode node)
        {
            if (OnAnswered != null)
                OnAnswered(node.AnswerValue);
        }

        public void ViewQuestion(MathQuestion question)
        {
            QuestionText.text = string.Format("{0} = ?", question.Question);
            var answerRange = question.GetAnswerRange(AnswerNode.Length);
            for (var index = 0; index < answerRange.Length; index++)
                AnswerNode[index].AnswerValue = answerRange[index];

        }
    }
}