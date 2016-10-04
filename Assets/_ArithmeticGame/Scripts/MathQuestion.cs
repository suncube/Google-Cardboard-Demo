using System;
using Random = UnityEngine.Random;

namespace ArithmeticGame
{
    public class MathQuestion
    {
        public string Question;
        public float Answer;

        // generate answers
        public float[] GetAnswerRange(int count)
        {
            var position = Random.Range(0, count-1);
            var result = new float[count];
            result[position] = Answer;

            for (int i = 0; i < count; i++)
            { 
                if (position == i) continue;
                var max =(int) Answer*2;
                result[i] = Random.Range(-max, max);
            }
            return result;
        }
      
        public bool CheckIsTrueAnswer(float answer)
        {
            return Answer == answer;
        }
    }
}