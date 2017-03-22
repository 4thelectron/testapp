using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FirstIslandBankCorporation.Tests.Controllers
{
    /// <summary>
    /// Mini statement test controller
    /// </summary>
    [TestClass]
    public class MiniStatementControllerTest
    {
        static IWebDriver driverGC;
        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            // to do 
            // initialize the chrome driver 
            driverGC = new ChromeDriver();
        }

        /// <summary>
        /// Entry Criteria : User name and password shouldn't be null or empty.
        /// Responsibility : Call user login method with mock data to test the user login functionality
        /// Selenium Report: Check the selenium report to verify the test result
        /// @throws  Exception
        /// </summary>
        [TestMethod]
        public void Login()
        {
            //To do
            try
            {
                // get the ui elements and set them appropriate values and test the login functionality , throw an  exception if it fails 
                var url = System.Configuration.ConfigurationManager.AppSettings["url"];
                var indextitle = System.Configuration.ConfigurationManager.AppSettings["HomeTitle"];
                driverGC.Navigate().GoToUrl(url);
                driverGC.FindElement(By.Id("Email")).SendKeys("ram@gmail.com");
                driverGC.FindElement(By.Id("Password")).SendKeys("Password@123");
                driverGC.FindElement(By.Id("Password")).SendKeys(Keys.Enter);

                if (!driverGC.Title.Equals(indextitle))
                    throw new Exception("");
            }
            catch (Exception)
            {
                // fail the test case
                Assert.IsTrue(false);
            }
        }

        /// <summary>
        /// Entry Criteria : User name and password shouldn't be null or empty.
        /// Responsibility : Call user login method with mock data to test the user login functionality and 
        ///                  land to the home page and clicks on view mini satement link and redirects the 
        ///                  view mini statement page after succesfull view of mini statement clicks Export button.
        /// Selenium Report: Check the selenium report to verify the test result
        /// @throws  Exception
        /// </summary>
        [TestMethod]
        public void ViewMiniStatement()
        {
            try
            {
                // set the startdate and enddate and get accounts , check the accounts and calculate interest for the respective checked accounts . throw an exception for any possible failure case
                var url = System.Configuration.ConfigurationManager.AppSettings["url"];
                var miniStatementTitle = System.Configuration.ConfigurationManager.AppSettings["MiniStatementTitle"];

                driverGC.Navigate().GoToUrl(url);
                driverGC.FindElement(By.Id("Email")).SendKeys("ram@gmail.com");
                driverGC.FindElement(By.Id("Password")).SendKeys("Password@123");
                driverGC.FindElement(By.Id("Password")).SendKeys(Keys.Enter);

                driverGC.FindElement(By.Id("2")).Click();

                driverGC.FindElement(By.Id("exporttoexcel")).Click();

                if (!driverGC.Title.Equals(miniStatementTitle))
                    throw new Exception("");

            }
            catch (Exception)
            {
                // fail the test case
                Assert.IsTrue(false);

            }
        }
    }
}
