using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SignUpGmail
{
    class SignUpPage
    {

        private readonly IWebDriver driver;
        private readonly string url = @"https://accounts.google.com/SignUp?service=mail&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&hl=en";
     
        public SignUpPage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public IWebElement NextStepButton
        {
            get { return this.driver.FindElement(By.Id("submitbutton")); }
            set { }
        }

        public IWebElement FirstName
        {
            get { return this.driver.FindElement(By.Id("FirstName")); }
            set { }
        }

        public IWebElement LastName
        {
            get { return this.driver.FindElement(By.Id("LastName")); }
            set { }
        }
        
        public IWebElement ChooseYourUsername {
            get {return this.driver.FindElement(By.Id("GmailAddress"));}
            set {}
        }

        public IWebElement CreatePassword
        {
            get { return this.driver.FindElement(By.Id("Passwd")); }
            set { }
        }

        public IWebElement ConfirmYourPassword
        {
            get { return this.driver.FindElement(By.Id("PasswdAgain")); }
            set { }
        }

        public IWebElement BirthdayMonth
        {
            get { return this.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/form/div[5]/fieldset/label[1]/span/div")); }
            set { }
        }

        public IWebElement BirthdayDay
        {
            get { return this.driver.FindElement(By.Id("BirthDay")); }
            set { }
        }

        public IWebElement BirthdayYear
        {
            get { return this.driver.FindElement(By.Id("BirthYear")); }
            set { }
        }

        public IWebElement Gender
        {
            get { return this.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/form/div[6]/label/div/div[1]")); }
            set { }
        }

        public IWebElement YourCurrentEmailAddress
        {
            get { return this.driver.FindElement(By.Id("RecoveryEmailAddress")); }
            set { }
        }

        public IWebElement TakenUsername
        {
            get{return this.driver.FindElement(By.Id("errormsg_0_GmailAddress"));}
            set { }
        }


        public IWebElement ShortLongUsername
        {
            get { return this.driver.FindElement(By.Id("errormsg_0_GmailAddress")); }
            set { }
        }


        public IWebElement NotValidEmailAddress
        {
            get
            {
                return this.driver.FindElement(By.Id("errormsg_0_RecoveryEmailAddress"));
            }
            set { }
        }

        public IWebElement NextSteps
        {
            get { return this.driver.FindElement(By.Id("submitbutton")); }
            set { }
        }

        public void Navigate()
        {
           this.driver.Navigate().GoToUrl(this.url);
             
        }

        public IWebElement CancelButton
        {
            get { return this.driver.FindElement(By.Id("cancelbutton")); }
            set { }
        }
    
    }
}
