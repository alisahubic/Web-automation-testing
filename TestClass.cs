using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Threading;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using SignUpGmail;

namespace JOliver
{
    [TestClass]
    public class Test
    {

        SignUpPage signUpGmail;
        public static string GenderF = "Female";
        public static string GenderM = "Male";
        public static string GenderO = "Other";

        private readonly IWebDriver driver;
        public Test() { }
        public Test(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }

        [TestInitialize]
        public void SetupTest()
        {
            this.Driver = new ChromeDriver();
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(200));
            this.Driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TeardownTest()
        {
             this.Driver.Quit();
        }

        [TestMethod]
        public void CreateFemaleGoogleAccount()
        {
            string informationRequest = RestGetName.CreateRequest();
            BasicInformation informationResponse = RestGetName.MakeRequest(informationRequest);

            Tuple<string, string, string, string, string> returnedInfo =
                RestGetName.ReturnBasicInformation(informationResponse);

            signUpGmail = new SignUpPage(this.Driver); Thread.Sleep(1000);
            signUpGmail.Navigate(); Thread.Sleep(2500);
            signUpGmail.NextStepButton.Click(); Thread.Sleep(1000);  

            signUpGmail.FirstName.SendKeys(RestGetName.TakeName(returnedInfo.Item1, 0, ' ')); Thread.Sleep(500);
            if (RestGetName.TakeName(returnedInfo.Item1, 0, ' ').Contains("."))
                RestGetName.TakeName(returnedInfo.Item1, 0, ' ').Replace('.', 'a');
            signUpGmail.LastName.SendKeys(RestGetName.TakeName(returnedInfo.Item1, 1, ' ')); Thread.Sleep(500);
            signUpGmail.ChooseYourUsername.SendKeys(returnedInfo.Item2); Thread.Sleep(500);
            signUpGmail.CreatePassword.SendKeys(returnedInfo.Item3); Thread.Sleep(500);
            signUpGmail.ConfirmYourPassword.SendKeys(returnedInfo.Item3); Thread.Sleep(500);

            string month = RestGetName.TakeName(returnedInfo.Item4, 1, '-');
            switch (month)
            {
                case "01":
                    signUpGmail.BirthdayMonth.SendKeys("January"); Thread.Sleep(500);
                    break;
                case "02":
                    signUpGmail.BirthdayMonth.SendKeys("February"); Thread.Sleep(500);
                    break;
                case "03":
                    signUpGmail.BirthdayMonth.SendKeys("March"); Thread.Sleep(500);
                    break;
                case "04":
                    signUpGmail.BirthdayMonth.SendKeys("April"); Thread.Sleep(500);
                    break;
                case "05":
                    signUpGmail.BirthdayMonth.SendKeys("May"); Thread.Sleep(500);
                    break;
                case "06":
                    signUpGmail.BirthdayMonth.SendKeys("June"); Thread.Sleep(500);
                    break;
                case "07":
                    signUpGmail.BirthdayMonth.SendKeys("July"); Thread.Sleep(500);
                    break;
                case "08":
                    signUpGmail.BirthdayMonth.SendKeys("August"); Thread.Sleep(500);
                    break;
                case "09":
                    signUpGmail.BirthdayMonth.SendKeys("September"); Thread.Sleep(500);
                    break;
                case "10":
                    signUpGmail.BirthdayMonth.SendKeys("October"); Thread.Sleep(500);
                    break;
                case "11":
                    signUpGmail.BirthdayMonth.SendKeys("November"); Thread.Sleep(500);
                    break;
                case "12":
                    signUpGmail.BirthdayMonth.SendKeys("December"); Thread.Sleep(500);
                    break;

            }

            signUpGmail.BirthdayDay.SendKeys(RestGetName.TakeName(returnedInfo.Item4, 2, '-')); Thread.Sleep(500);
            signUpGmail.BirthdayYear.SendKeys(RestGetName.TakeName(returnedInfo.Item4, 0, '-')); Thread.Sleep(500);
            signUpGmail.Gender.SendKeys(GenderF); Thread.Sleep(500);
            signUpGmail.YourCurrentEmailAddress.SendKeys(RestGetName.TakeName(returnedInfo.Item1, 0, ' ') + "@" + returnedInfo.Item5);

            if (signUpGmail.TakenUsername.Displayed.Equals(true))
                signUpGmail.ChooseYourUsername.SendKeys(RestGetName.TakeName(returnedInfo.Item1, 0, ' '));
            

            if (signUpGmail.ShortLongUsername.Displayed.Equals(true))
                signUpGmail.ChooseYourUsername.SendKeys(RestGetName.TakeName(returnedInfo.Item1, 0, ' '));

            if (signUpGmail.NotValidEmailAddress.Displayed.Equals(true))
                signUpGmail.YourCurrentEmailAddress.Clear();

            signUpGmail.NextStepButton.Click(); Thread.Sleep(500);
            signUpGmail.CancelButton.Click();


        }


    }
}

