using Core;

namespace DemoQa.Com_PageObjects.PageObjects
{
    public class PageModalDialogs : BasePage
    {
        protected sealed override string PageUrl { get; set; }
        public PageModalDialogs(DriverManager driverManager) : base(driverManager)
        {
            PageUrl = "/modal-dialogs";
        }
        
        
    }
}