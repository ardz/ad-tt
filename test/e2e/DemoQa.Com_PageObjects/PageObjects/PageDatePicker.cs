using Core;
using OpenQA.Selenium;

namespace DemoQa.Com_PageObjects.PageObjects
{
    public class PageDatePicker : BasePage
    {
        protected sealed override string PageUrl { get; set; }
        
        public PageDatePicker(DriverManager driverManager) : base(driverManager)
        {
            PageUrl = "/date-picker";
        }

        private IWebElement DatePicker => Driver.FindElement(By.Id("datePickerMonthYearInput"));

        public PageDatePicker SetCalendarDate(string date)
        {
            var jse = (IJavaScriptExecutor) Driver;
            jse.ExecuteScript($"document.getElementById('datePickerMonthYearInput').value='{date}'");

            return this;
        }

        public string GetDate()
        {
            return DatePicker.Text;
        }
    }
}