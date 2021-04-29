using System;
using Core;
using DemoQa.Com_PageObjects;

namespace DemoQa.Com_Tests
{
    public class E2ETestFixture : IDisposable
    {
        private DriverManager DriverManager { get; }
        public DemoQaPages DemoQaPages { get; }

        public E2ETestFixture()
        {
            var testConfig = new Config().TestConfiguration;

            DriverManager = 
                new DriverManager(testConfig["e2e:browser"], 
                    testConfig["e2e:suturl"], 
                    int.Parse(testConfig["e2e:timeout"]));

            DriverManager.CreateDriver();

            DemoQaPages = new DemoQaPages(DriverManager);
        }

        public static string TestFileLocation(string fileName)
        {
            return System.IO.Directory.GetCurrentDirectory() + $"//TestFiles//{fileName}";
        }

        public void Dispose()
        {
            DriverManager.Driver.Quit();
        }
    }
}