using System;
using System.Threading;
using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static OpenQA.Selenium.Support.UI.ExpectedConditions; // deprecated

namespace DemoQa.Com_PageObjects.PageObjects
{
    public class PageAlerts : BasePage
    {
        protected sealed override string PageUrl { get; set; }
        
        public PageAlerts(DriverManager driverManager) : base(driverManager)
        {
            PageUrl = "/alerts";
        }

        private IWebElement FiveSecondTimerButton => Driver.FindElement(By.Id("timerAlertButton"));

        public PageAlerts ClickAndDismissAlert()
        {
            FiveSecondTimerButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            var alert = wait.Until(AlertIsPresent());
            
            alert.Accept();

            return this;
        }

        public PageAlerts ClickAndDismissAlertDirty(int seconds)
        {
            FiveSecondTimerButton.Click();
            
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            
            Driver.SwitchTo().Alert().Accept();

            return this;
        }
    }
}