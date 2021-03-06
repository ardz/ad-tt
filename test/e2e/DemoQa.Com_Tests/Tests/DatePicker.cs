using System;
using System.Globalization;
using Xbehave;

namespace DemoQa.Com_Tests.Tests
{
    /// <summary>
    /// Must select a date using date picker from ‘Select Date’ field
    /// Must be 1 month from today’s date
    /// </summary>
    public class DatePicker : E2ETestFixture
    {
        [Scenario]
        public void ChooseDateOneMonthFromNow()
        {
            var futureDate = DateTime.Now.AddMonths(1);
            var month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(futureDate.Month);
            
            var date = $"{futureDate.Day:00}/{month}/{futureDate.Year}";

            DemoQaPages.PageDatePicker().NavigateTo();

            "Choose date one month from today"
                .x(() =>
                {
                    DemoQaPages.PageDatePicker()
                        .SetCalendarDate(date);

                    // it will just default back to the previous value when you click
                    // into it - automating calendars like this is a waste of time
                    // control should allow you to enter the date as a string for automated tests
                    // I suspect the test has been deliberately setup so you can't just use
                    // the javascript executor to change the date on the element in the DOM? (react maybe)
                    // it take loads of code to achieve this using element clicks/selects and it's
                    // not worth it, the date picker is just an inbuilt function of the whatever
                    // javascript library the front end has been written in, you don't need to 
                    // test it's functionality you just need to be able set the required value
                    // for whatever e2e test you're running and move on :) /end rant :)
                });
        }
    }
}
