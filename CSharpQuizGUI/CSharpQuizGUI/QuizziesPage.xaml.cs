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
        ObservableCollection<Quiz> quizItems;
        private int _quizCount;

        public int QuizCount
        {
            get { return _quizCount; }
            set { _quizCount = value; }
        }
        public async void getQuizzes() {
           quizItems =  new ObservableCollection<Quiz>(await service.GetQuizzesAsync(QuizCount));
            ChangeCurrentQuestionStatus(1,quizItems.Count);
        }

        private void ChangeCurrentQuestionStatus(int current, int max) {
            CurrentQuestionStatus.Text = $"{current}/{max}";
        }

    }
}