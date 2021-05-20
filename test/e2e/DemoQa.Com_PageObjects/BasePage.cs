using System.Linq;
using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQa.Com_PageObjects
{
    /// <summary>
    /// Common page functionality across the system you're testing
    /// can be placed on here for re-use
    /// </summary>
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        private IJavaScriptExecutor JavaScriptExecutor;
        private DriverManager DriverManager { get; set; }
        protected abstract string PageUrl { get; set; }

        protected BasePage(DriverManager driverManager)
        {
            DriverManager = driverManager;
            Driver = driverManager.Driver;
            JavaScriptExecutor = (IJavaScriptExecutor) Driver;
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(DriverManager.SutUrl + PageUrl);
        }
        
        // move into a helper class if there's more of these types of things going on
        // doesn't really belong on this class
        public static string[] DateSplitter(string date, string separator)
        {
            return date.Split(separator);
        }
        
        public void CalendarDatePicker(string day, string month, string year)
        {
            var monthSelect = new SelectElement(Driver
                .FindElement(By.ClassName("react-datepicker__month-select")));

            monthSelect.SelectByText(month);

            var yearSelect = new SelectElement(Driver.FindElement(By.ClassName("react-datepicker__year-select")));

            yearSelect.SelectByText(year);

            var allDays = Driver.FindElements(
                By.XPath($"//div[contains(@aria-label, '{month}')]"));

            allDays.First(x => x.Text == day).Click();
        }

        protected void ExecuteJavaScriptClick(IWebElement element)
        {
            JavaScriptExecutor.ExecuteScript("arguments[0].click();", element);
        }

        protected void ScrollIntoView(IWebElement element)
        {
            JavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
