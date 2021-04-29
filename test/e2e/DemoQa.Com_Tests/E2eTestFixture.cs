using System;
using Core;
using DemoQa.Com_PageObjects;
using OpenQA.Selenium;

namespace DemoQa.Com_Tests
{
    public class E2ETestFixture : IDisposable
    {
        private DriverManager DriverManager { get; }
        protected readonly IWebDriver Driver;
        protected DemoQaPages DemoQaPages { get; }

        protected E2ETestFixture()
        {
            var testConfig = new Config().TestConfiguration;

            DriverManager = 
                new DriverManager(testConfig["e2e:browser"], 
                    testConfig["e2e:suturl"], 
                    int.Parse(testConfig["e2e:timeout"]));

            Driver = DriverManager.CreateDriver();

            DemoQaPages = new DemoQaPages(DriverManager);
        }

        public void Dispose()
        {
            DriverManager.Driver.Quit();
        }
    }
}