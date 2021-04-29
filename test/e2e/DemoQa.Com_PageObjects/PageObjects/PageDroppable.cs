using System.Threading;
using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoQa.Com_PageObjects.PageObjects
{
    public class PageDroppable : BasePage
    {
        protected sealed override string PageUrl { get; set; }
        
        public PageDroppable(DriverManager driverManager) : base(driverManager)
        {
            PageUrl = "/droppable";
        }

        private IWebElement Item => Driver.FindElement(By.Id("draggable"));
        private IWebElement DropLocation => Driver.FindElement(By.Id("droppable"));

        public PageDroppable DragAndDrop()
        {
            var actions = new Actions(Driver);
            
            actions.DragAndDrop(Item, DropLocation).Build().Perform();
            
            // i've just added this so you can actually see it happen on the screen :/
            Thread.Sleep(2000);
            
            return this;
        }

        public bool DropSuccessful()
        {
            return DropLocation.GetAttribute("innerText") == "Dropped!";
        }
    }
}