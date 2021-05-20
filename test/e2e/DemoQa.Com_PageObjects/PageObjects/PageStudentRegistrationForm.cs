using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoQa.Com_PageObjects.PageObjects
{
    
    public class PageStudentRegistrationForm : BasePage
    {
        protected sealed override string PageUrl { get; set; }
        
        public PageStudentRegistrationForm(DriverManager driverManager) : base(driverManager)
        {
            PageUrl = "/automation-practice-form";
        }

        // [FindsBy(How = How.Id, Using = "firstName")]
        // my preference is to just do this below instead of using the attributes above
        // it's easier to write and doesn't require an additional library, I know
        // some people prefer using the FindsBy attribute though
        private IWebElement FirstName => Driver.FindElement(By.Id("firstName"));
        private IWebElement LastName => Driver.FindElement(By.Id("lastName"));
        private IWebElement Email => Driver.FindElement(By.Id("userEmail"));
        private IWebElement MobileNumber => Driver.FindElement(By.Id("userNumber"));
        private IWebElement ButtonSubmit => Driver.FindElement(By.Id("submit"));
        private IWebElement Dob => Driver.FindElement(By.Id("dateOfBirthInput"));
        private IWebElement CurrentAddress => Driver.FindElement(By.Id("currentAddress"));
        private IWebElement ButtonUploadPicture => Driver.FindElement(By.Id("uploadPicture"));

        public PageStudentRegistrationForm SendStudentName(string firstName, string lastName)
        {
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);

            return this;
        }

        public PageStudentRegistrationForm SendEmail(string emailAddress)
        {
            Email.SendKeys(emailAddress);
            
            return this;
        }

        public PageStudentRegistrationForm SelectGender(string gender)
        {
            ExecuteJavaScriptClick(Driver
                .FindElement(By
                    // spelling of gender wrong
                    .XPath($"//div[@id='genterWrapper']//*[contains(text(),'{gender}')]/..//input")));

            return this;
        }

        public PageStudentRegistrationForm SendPhoneNumber(string number)
        {
            MobileNumber.SendKeys(number);
            
            return this;
        }

        public PageStudentRegistrationForm SendDateOfBirth(string dob)
        {
            Dob.Click();

            var dayMonthYear = dob.Split("/");

            CalendarDatePicker(dayMonthYear[0], dayMonthYear[1], dayMonthYear[2]);
            
            // this control has a deliberate bug in it you can't clear it properly
            // and the delete key causes the whole page back to go back
            // Dob.Clear();
            // Dob.SendKeys(dob);
            
            // var jse = (IJavaScriptExecutor) Driver;
            // jse.ExecuteScript($"document.getElementById('dateOfBirthInput').value='{dob}'");

            return this;
        }



        public PageStudentRegistrationForm SelectHobby(string hobby)
        {
            ExecuteJavaScriptClick(Driver
                .FindElement(By
                    .XPath($"//div[@id='hobbiesWrapper']//*[contains(text(),'{hobby}')]/..//input")));

            return this;
        }

        public PageStudentRegistrationForm SendCurrentAddress(string address)
        {
            CurrentAddress.SendKeys(address);

            return this;
        }

        public PageStudentRegistrationForm UploadPicture(string fileName)
        {
            ButtonUploadPicture.SendKeys(fileName);

            return this;
        }

        public bool MandatoryFieldsAreMissing()
        {
            var firstName = Driver.FindElement(By.CssSelector("input#firstName:invalid"));
            var lastName = Driver.FindElement(By.CssSelector("input#lastName:invalid"));
            var mobileNumber = Driver.FindElement(By.CssSelector("input#userNumber:invalid"));

            return firstName.Displayed && lastName.Displayed && mobileNumber.Displayed;
        }

        public bool RegistrationCompleteModalOpen()
        {
            // instead of checking the mandatory fields are set to invalid in the 
            // css (above), just check the modal appeared or didn't appear - pros and cons
            // they both kind of suck tbh :/ you can take this as far as you want and 
            // check the fields that have been entered on the modal but there's little point
            // if the modal only appears if all fields are completed that's enough

            try
            {
                Driver.FindElement(By.Id("example-modal-sizes-title-lg"));

                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public PageStudentRegistrationForm Submit()
        {
            ScrollIntoView(ButtonSubmit);
            ButtonSubmit.Click();

            return this;
        }
    }
}
