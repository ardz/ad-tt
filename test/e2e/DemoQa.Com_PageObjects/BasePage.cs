﻿using Core;
using OpenQA.Selenium;

namespace DemoQa.Com_PageObjects
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        private DriverManager DriverManager { get; set; }
        protected abstract string PageUrl { get; set; }

        protected BasePage(DriverManager driverManager)
        {
            Driver = driverManager.Driver;
            DriverManager = driverManager;
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(DriverManager.SutUrl + PageUrl);
        }

        public bool IsPageLoaded()
        {
            throw new System.NotImplementedException();
        }
    }
}