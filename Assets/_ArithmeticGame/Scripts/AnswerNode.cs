using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ArithmeticGame
{
    public class AnswerNode : MonoBehaviour, ICardboardGazeResponder
    {
        public Text Text;

        public Action<AnswerNode> OnAnswered;

        private float answerValue;
        public float AnswerValue {
            get { return answerValue; }
            set
            {
                answerValue = value;
                Text.text = string.Format("{0}", value);
            }
        }
        private int WaitSeconds = 1;

        void Start()
        {
            Text.text = string.Empty;
            SetGazedAt(false);
        }

        void SendAnswer()
        {
            if (OnAnswered != null)
                OnAnswered(this);
        }

        void SetGazedAt(bool gazedAt)
        {
            GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.white;
        }

        public void OnGazeEnter()
        {
            SetGazedAt(true);
            Invoke("SendAnswer", WaitSeconds);
        }

        public void OnGazeExit()
        {
            SetGazedAt(false);
            CancelInvoke("SendAnswer");
        }

        public void OnGazeTrigger() 
        {
            //empty
        }
    }
}