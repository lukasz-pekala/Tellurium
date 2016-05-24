﻿using System;
using MaintainableSelenium.VisualAssertions.Screenshots.Domain;

namespace MaintainableSelenium.VisualAssertions.TestRunersAdapters.Providers
{
    public class ConsoleTestRunnerAdapter:ITestRunnerAdapter
    {
        public bool IsPresent()
        {
            return true;
        }

        public void NotifyAboutTestSuccess(string testName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Test passed: {0}", testName);
            Console.ResetColor();
        }

        public void NotifyAboutTestFail(string testName, TestSession session, BrowserPattern pattern)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ResetColor();
        }
    }
}