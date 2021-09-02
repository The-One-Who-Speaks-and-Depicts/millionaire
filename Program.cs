using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using millionaire.Data;
using millionaire.Models;

namespace millionaire
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try 
            {
                Utils.AddQuestionsAndAnswers();
            }
            catch 
            {
                Debug.WriteLine("No SQLite database found!");
            }            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
