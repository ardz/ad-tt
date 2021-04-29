using System.Threading;
using Core;
using OpenQA.Selenium;

namespace DemoQa.Com_PageObjects.PageObjects
{
    public class PageModalDialogs : BasePage
    {
        protected sealed override string PageUrl { get; set; }
        public PageModalDialogs(DriverManager driverManager) : base(driverManager)
        {
            PageUrl = "/modal-dialogs";
        }

        private IWebElement ButtonSmallModal => Driver.FindElement(By.Id("showSmallModal"));
        private IWebElement ButtonCloseSmallModal => Driver.FindElement(By.Id("closeSmallModal"));

        public PageModalDialogs OpenAndCloseModal()
        {
            ButtonSmallModal.Click();
            Thread.Sleep(2000); // just so you can see it happen on screen
            ButtonCloseSmallModal.Click();
            
            return this;
        }
    }
}