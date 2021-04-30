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
            DatePicker.Click();

            // naughty really, changing the data here but this is what happens with these calendar controls :shrug:
            var dayMonthYear = DateSplitter(date, "/");
            
            CalendarDatePicker(dayMonthYear[0], dayMonthYear[1], dayMonthYear[2]);

            return this;
        }

        public string GetDate()
        {
            return DatePicker.Text;
        }
    }
}