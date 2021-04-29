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
            return new PageStudentRegistrationForm(DriverManager);
        }

        public PageAlerts PageAlerts()
        {
            return new PageAlerts(DriverManager);
        }
    }
}