using CSharpQuizGUI.Models;
using CSharpQuizGUI.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSharpQuizGUI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizziesPage : ContentPage
    {
        QuizService service;
        public QuizziesPage(int quizCount)
        {
            
            InitializeComponent();
            this.QuizCount = quizCount;
            service = new QuizService();
            getQuizzes();
            
        }
        List<Frame> AnswerFrames = new List<Frame>();
        ObservableCollection<Quiz> quizItems;
        private int _currentIndex = 0;

        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { _currentIndex = value; }
        }

        private int _quizCount;

        public int QuizCount
        {
            get { return _quizCount; }
            set { _quizCount = value; }
        }
        public async void getQuizzes() {
           quizItems =  new ObservableCollection<Quiz>(await service.GetQuizzesAsync(QuizCount));
           ChangeCurrentQuestionStatus(1,quizItems.Count);
           ChangeQuestion(quizItems[CurrentIndex]);
        }

        private void ChangeCurrentQuestionStatus(int current, int max) {
            CurrentQuestionStatus.Text = $"{current}/{max}";
        }

 
        private void FrameClicked(object sender, EventArgs e)
        {
            foreach (var frame in AnswerFrames)
            {
                frame.BackgroundColor = Color.White;
            }
            ((sender as Button).Parent as Frame).BackgroundColor = Color.CadetBlue;
     
          
        }
        private void ChangeQuestion(Quiz quiz) {
            Answers.Children.Clear();
            QuizQuestionLabel.Text = quiz.Question;
            for (int i = 0; i < quiz.Answers.Count(); i++)
            {
                Label label = new Label();
                label.TextColor = Color.Black;
                label.FontSize = 16;

                int unicode = 65 + i;
                char character = (char)unicode;
                string text = character.ToString();
                label.Text = $"{text}) {quiz.Answers[i]}";
                Frame frame = new Frame();
                frame.HasShadow = true;
                frame.CornerRadius = 10;
                frame.BorderColor = Color.Gray;
                frame.Content = label;
                frame.Padding = new Thickness(20);
                frame.Margin = new Thickness(10);
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => {
                    for(int j = 0; j<Answers.Children.Count;j++) 
                    {
                        if (Answers.Children[j] == (s as Frame)) 
                        {
                            (s as Frame).BackgroundColor = Color.CadetBlue; 
                            quizItems[CurrentIndex].Useranswer = j; 
                        }
                        else
                            Answers.Children[j].BackgroundColor = Color.White;

                    }
                     
         
                };

                frame.GestureRecognizers.Add(tapGestureRecognizer);
                
                Answers.Children.Add(frame);
             
            }
            if (quiz.Useranswer != null)
            {
                Answers.Children[(int)quiz.Useranswer].BackgroundColor = Color.CadetBlue;
            }
        }
        private void NextButton_Clicked(object sender, EventArgs e)
        {
            ChangeQuestion(quizItems[++CurrentIndex]);
            ChangeCurrentQuestionStatus(CurrentIndex + 1, quizItems.Count);
            if (CurrentIndex == quizItems.Count -1) {

                NextButton.IsVisible = false;
            }
            if (PrevButton.IsVisible == false) PrevButton.IsVisible = true;
        }

        private void PrevButton_Clicked(object sender, EventArgs e)
        {
            ChangeQuestion(quizItems[--CurrentIndex]);
            ChangeCurrentQuestionStatus(CurrentIndex + 1, quizItems.Count);
            if (CurrentIndex == 0)
            {
                PrevButton.IsVisible = false;
            }
            if (NextButton.IsVisible == false) NextButton.IsVisible = true;
        }

    }
}