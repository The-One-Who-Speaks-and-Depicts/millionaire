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
using Microsoft.EntityFrameworkCore;

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
            catch (DbUpdateException)
            {
                Console.WriteLine("Database is filled!");
            }
            catch (Exception)
            {
                Console.WriteLine("Some database issues");
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
