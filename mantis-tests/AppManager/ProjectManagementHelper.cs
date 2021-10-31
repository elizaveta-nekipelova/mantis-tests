using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public List<ProjectData> GetAll()
        {
            manager.Navigator.GoToManageSection();
            manager.Navigator.GoToProjectsManageSection();
            var table = driver.FindElement(By.XPath("//*[@id='main-container']/div[2]/div[2]//div[2]/table"));
            List<IWebElement> rows = table.FindElements(By.XPath("//tbody//tr")).ToList();
            rows.RemoveAt(rows.Count() - 1); // Workaround to remove row from 'Global Categories'. Don't know how to get rid of it. In browser my selector return only one first table but in the code two tables are returned

            List<ProjectData> projects = new List<ProjectData>();

            foreach (IWebElement row in rows)
            {
                projects.Add(new ProjectData(row.Text.Split(' ').First()));
            }

            return projects;
        }

        public void Create(ProjectData project)
        {
            manager.Navigator.GoToManageSection();
            manager.Navigator.GoToProjectsManageSection();
            InitNewProjectCreation();
            FillInForm(project);
            SubmitProjectCreation();
        }

        public void Remove(ProjectData project)
        {
            manager.Navigator.GoToManageSection();
            manager.Navigator.GoToProjectsManageSection();
            OpenProject(project);
            driver.FindElement(By.CssSelector("[value='Delete Project']")).Click();
            driver.FindElement(By.CssSelector("[value='Delete Project']")).Click();
        }

        private void OpenProject(ProjectData project)
        {
            driver.FindElement(By.LinkText(project.Name)).Click();
        }

        public void InitNewProjectCreation()
        {
            driver.FindElements(By.CssSelector(".widget-body button"))[0].Click();
        }

        public void FillInForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            new SelectElement(driver.FindElement(By.Id("project-status"))).SelectByText(project.Status);
            new SelectElement(driver.FindElement(By.Id("project-view-state"))).SelectByText(project.ViewStatus);
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("[class$=' clearfix'] input")).Click();
        }
    }
}
