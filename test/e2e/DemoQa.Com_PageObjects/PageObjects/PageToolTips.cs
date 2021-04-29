using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoQa.Com_PageObjects.PageObjects
{
    public class PageToolTips : BasePage
    {
        protected sealed override string PageUrl { get; set; }
        
        public PageToolTips(DriverManager driverManager) : base(driverManager)
        {
            PageUrl = "/tool-tips";
        }

        private IWebElement Button => Driver.FindElement(By.Id("toolTipButton"));
        private IWebElement Field => Driver.FindElement(By.Id("toolTipTextField"));

        public PageToolTips HoverOverButton()
        {
            var actions = new Actions(Driver);
            actions.MoveToElement(Button).Build().Perform();
            
            return this;
        }

        public PageToolTips HoverOverField()
        {
            var actions = new Actions(Driver);
            actions.MoveToElement(Field).Build().Perform();
            
            return this;
        }
    }
}