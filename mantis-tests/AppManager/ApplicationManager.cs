using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseUrl;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; }
        public LoginHelper Auth { get; }
        public NavigationHelper Navigator { get; }
        public ProjectManagementHelper Project { get; }
        public AdminHelper Admin { get; }
        public ApiHelper API { get; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseUrl = "http://localhost/mantisbt-2.25.2/mantisbt-2.25.2";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Auth = new LoginHelper(this, baseUrl);
            Navigator = new NavigationHelper(this);
            Project = new ProjectManagementHelper(this);
            Admin = new AdminHelper(this, baseUrl);
            API = new ApiHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseUrl + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
       
        public IWebDriver Driver { 
            get 
            {
                return driver;
            }
        }
    }
}
