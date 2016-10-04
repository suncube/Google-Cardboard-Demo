using UnityEngine;

namespace ArithmeticGame
{
    public class MathQuestionController
    {
        public static int MaxOperationValue = 10;
      
        struct Question
        {
            public string MathFunction;
            public float MathValue;
        }

        public MathQuestion GetMathQuestion()
        {
            var question = GenerateQuestion();
            var result = new MathQuestion();

            result.Question = question.MathFunction;
            result.Answer = question.MathValue;

            return result;
        }

        private Question GenerateQuestion()
        {
            // generate a b 
            var a = Random.Range(-MaxOperationValue, MaxOperationValue);
            var b = Random.Range(-MaxOperationValue, MaxOperationValue);

            //  get operation symbol
            var operation = Random.Range(1, 4);
            var result = new Question();

            switch (operation)
            {
                case 1:// +
                    result.MathValue = a + b;
                    result.MathFunction = string.Format("{0} + {1}", a,b);
                    break;
                case 2:// -
                    result.MathValue = a - b;
                    result.MathFunction = string.Format("{0} - {1}", a, b);
                    break;
                case 3:// *
                    result.MathValue = a * b;
                    result.MathFunction = string.Format("{0} * {1}", a, b);
                    break;
                case 4:// /
                    result.MathValue = a / b;
                    result.MathFunction = string.Format("{0} / {1}", a, b);
                    break;
            }

            return result;
        }


    }
}