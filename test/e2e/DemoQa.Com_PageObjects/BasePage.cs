using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace DemoQa.Com_PageObjects
{
    /// <summary>
    /// Common page functionality across the system you're testing
    /// can be placed on here for re-use
    /// </summary>
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        private DriverManager DriverManager { get; set; }
        protected abstract string PageUrl { get; set; }

        protected BasePage(DriverManager driverManager)
        {
            DriverManager = driverManager;
            Driver = driverManager.Driver;
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(DriverManager.SutUrl + PageUrl);
        }

        protected void ExecuteJavaScriptClick(IWebElement element)
        {
            var jse = (IJavaScriptExecutor) Driver;
            jse.ExecuteScript("arguments[0].click();", element);
        }
    }
}
