using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

        private async void QuizButton_Clicked(object sender, EventArgs e)
        {
         
           
          
            await WaitMs(150);
            QuizFrame.IsVisible = true;
            ContainerGrid.RaiseChild(QuizFrame);
        }

        private void ChangeToQuizzez_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuizziesPage(((int)RandomQuizNumber.Value)));
            QuizFrame.IsVisible = false;
        }

        private void RandomQuizNumber_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ChoosenNumber.Text = ((int)RandomQuizNumber.Value).ToString();
        }

        private void LearButton_Clicked(object sender, EventArgs e)
        {

        }

        private void Scorebutton_Clicked(object sender, EventArgs e)
        {
            Toast.MakeText(Android.App.Application.Context, "Pontszámod :)", ToastLength.Long).Show();
        }

        private async void ExitButton_Clicked(object sender, EventArgs e)
        {
            Toast.MakeText(Android.App.Application.Context, "Viszlát", ToastLength.Short).Show();
            await WaitMs(500);
            Environment.Exit(0);
        }

        private Task WaitMs(int ms) {
            return Task.Run(() =>
            {
                
                Thread.Sleep(ms);
            });
            
        }
    }
}
