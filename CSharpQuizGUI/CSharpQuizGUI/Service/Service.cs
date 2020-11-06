using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Text;

namespace CSharpQuizGUI.Service
{
    abstract class Service
    {
 
        protected static readonly HttpClient client = new HttpClient();
        private string BASEURL =  @"http://192.168.88.13:5000/api/"; 
    


        public Uri QuizURL { get {
                return new Uri(BASEURL + "quiz/");    
            }
        }

    }
}
