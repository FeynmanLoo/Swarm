﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Quartz;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Swarm.Server
{
    public class Program
    {
        class MyJob : IJob
        {
            public Task Execute(IJobExecutionContext context)
            {
                return Task.CompletedTask;
            }
        }
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console(theme: ConsoleLogTheme).WriteTo.RollingFile("swarm.log")
                .CreateLogger();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().UseUrls("http://localhost:8000").UseSerilog();

        public static SystemConsoleTheme ConsoleLogTheme { get; set; } = new SystemConsoleTheme(
            new Dictionary<ConsoleThemeStyle, SystemConsoleThemeStyle>
            {
                [ConsoleThemeStyle.Text] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Black
                },
                [ConsoleThemeStyle.SecondaryText] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Black
                },
                [ConsoleThemeStyle.TertiaryText] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Black
                },
                [ConsoleThemeStyle.Invalid] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Yellow
                },
                [ConsoleThemeStyle.Null] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.White
                },
                [ConsoleThemeStyle.Name] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Black
                },
                [ConsoleThemeStyle.String] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Black
                },
                [ConsoleThemeStyle.Number] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Black
                },
                [ConsoleThemeStyle.Boolean] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Black
                },
                [ConsoleThemeStyle.Scalar] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Black
                },
                [ConsoleThemeStyle.LevelVerbose] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Gray,
                    Background = ConsoleColor.DarkGray
                },
                [ConsoleThemeStyle.LevelDebug] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.White,
                    Background = ConsoleColor.DarkGray
                },
                [ConsoleThemeStyle.LevelInformation] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.White,
                    Background = ConsoleColor.Blue
                },
                [ConsoleThemeStyle.LevelWarning] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.DarkGray,
                    Background = ConsoleColor.Yellow
                },
                [ConsoleThemeStyle.LevelError] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.White,
                    Background = ConsoleColor.Red
                },
                [ConsoleThemeStyle.LevelFatal] = new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.White,
                    Background = ConsoleColor.Red
                }
            });
    }
}