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
        string rawData;
        private int _quizCount;

        public int QuizCount
        {
            get { return _quizCount; }
            set { _quizCount = value; }
        }
        public async void getQuizzes() {
            List<Quiz> items =  await service.GetQuizzesAsync(QuizCount);
            RawLabel.Text = items.Count.ToString();
        }
    }
}