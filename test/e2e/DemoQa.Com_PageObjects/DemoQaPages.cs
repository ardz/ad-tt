using Core;
using DemoQa.Com_PageObjects.PageObjects;

namespace DemoQa.Com_PageObjects
{
    // wrapper class to return instances of Page Objects
    public class DemoQaPages
    {
        private DriverManager DriverManager { get; }
        
        public DemoQaPages(DriverManager driverManager)
        {
            DriverManager = driverManager;
        }

        public PageStudentRegistrationForm PageStudentRegistrationForm()
        {
            return new(DriverManager);
        }

        public PageAlerts PageAlerts()
        {
            return new(DriverManager);
        }

        public PageToolTips PageToolTips()
        {
            return new(DriverManager);
        }

        public PageDroppable PageDroppable()
        {
            return new(DriverManager);
        }

        public PageModalDialogs PageModalDialogs()
        {
            return new(DriverManager);
        }

        public PageDatePicker PageDatePicker()
        {
            return new PageDatePicker(DriverManager);
        }
    }
}
