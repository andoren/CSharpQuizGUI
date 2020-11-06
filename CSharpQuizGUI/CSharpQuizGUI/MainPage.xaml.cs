using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CSharpQuizGUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
           
        }

        private void QuizButton_Clicked(object sender, EventArgs e)
        {
         
            QuizFrame.IsVisible = true;
        }

        private void ChangeToQuizzez_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuizziesPage());
        }

        private void RandomQuizNumber_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ChoosenNumber.Text = ((int)RandomQuizNumber.Value).ToString();
        }
    }
}
