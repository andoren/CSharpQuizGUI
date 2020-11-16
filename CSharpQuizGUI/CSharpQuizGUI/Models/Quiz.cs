using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpQuizGUI.Models
{
    class Quiz
    {
        string _question;
        int _id;
        string _explanation;
        string[] _answers;
        string _correctAnswer;
        int? _userAnswer = null;
        public Quiz(int id, string question, string explanation, string[] answers, string correctAnswer)
        {
            _question = question ?? throw new ArgumentNullException(nameof(question));
            _id = id;
            _explanation = explanation ?? throw new ArgumentNullException(nameof(explanation));
            _answers = answers ?? throw new ArgumentNullException(nameof(answers));
            _correctAnswer = correctAnswer ?? throw new ArgumentNullException(nameof(correctAnswer));
        }

        public int? Useranswer { get {
                return _userAnswer;
            }
            set {
                _userAnswer = value;
            }
        }
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }
        public string Question
        {
            get
            {
                return _question;
            }
            set
            {
                _question = value;
            }
        }
        public string Explanation
        {
            get
            {
                return _explanation;
            }
            set
            {
                _explanation = value;
            }
        }

        public string[] Answers
        {
            get
            {
                return _answers;
            }
            set
            {
                _answers = value;
            }
        }
        public string CorrectAnswer
        {
            get
            {
                return _correctAnswer;
            }
            set
            {
                _correctAnswer = value;
            }
        }
    }
}

