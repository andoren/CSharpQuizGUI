using CSharpQuizGUI.Models;
using Java.Util.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpQuizGUI.Service
{
    class QuizService:Service
    {
        public async Task<List<Quiz>> GetQuizzesAsync(int count)
        {
       
            try
            {
               
                var response = await client.GetAsync(new Uri(QuizURL.OriginalString+"random/"+count));
                List<Quiz> Items = new List<Quiz>();
                if (response.IsSuccessStatusCode)
                {
                   
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Quiz>>(content);
                    return Items;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new List<Quiz>();
        }
       

    }
}
