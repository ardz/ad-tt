using Core;

namespace DemoQa.Com_PageObjects.PageObjects
{
    public class PageDatePicker : BasePage
    {
        protected sealed override string PageUrl { get; set; }
        
        public PageDatePicker(DriverManager driverManager) : base(driverManager)
        {
            PageUrl = "/date-picker";
        }

    }
}