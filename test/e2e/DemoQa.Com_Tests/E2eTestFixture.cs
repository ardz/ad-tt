using System;
using Core;
using DemoQa.Com_PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace DemoQa.Com_Tests
{

    
    public class E2ETestFixture : IDisposable
    {
        private DriverManager DriverManager { get; }
        private readonly IWebDriver _driver;
        public DemoQaPages DemoQaPages { get; }

        public E2ETestFixture()
        {
            var testConfig = new Config().TestConfiguration;

            DriverManager = 
                new DriverManager(testConfig["e2e:browser"], 
                    testConfig["e2e:suturl"], 
                    int.Parse(testConfig["e2e:timeout"]));

            _driver = DriverManager.CreateDriver();

            DemoQaPages = new DemoQaPages(DriverManager);
        }

        public string TestFileLocation(string fileName)
        {
            return System.IO.Directory.GetCurrentDirectory() + $"\\TestFiles\\{fileName}";
        }

        public void Dispose()
        {
            DriverManager.Driver.Close();
        }
    }
}