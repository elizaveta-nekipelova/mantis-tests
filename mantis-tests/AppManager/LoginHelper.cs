using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            if(! IsLoggedIn())
            {
                GoToLoginPage();
                driver.FindElement(By.Id("username")).SendKeys(account.Name);
                driver.FindElement(By.CssSelector("input[class*='btn-success']")).Click();
                driver.FindElement(By.Id("password")).SendKeys(account.Password);
                driver.FindElement(By.CssSelector("input[class*='btn-success']")).Click();
            }
        }

        public void GoToLoginPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.25.2/mantisbt-2.25.2/login_page.php";
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector(".user-info"));
        }
    }
}
