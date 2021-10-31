using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager) { }

        public void GoToManageSection()
        {
            driver.FindElements(By.CssSelector(".sidebar li")).Last().Click();
        }

        public void GoToProjectsManageSection()
        {
            driver.FindElements(By.CssSelector(".row li"))[2].Click();
        }
    }
}
