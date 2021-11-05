using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalSoapTests : AuthTestBase
    {
        [Test]
        public void TestProjectRemovalSoap()
        {
            ProjectData project = new ProjectData()
            {
                Name = GenerateRandomString(10)
            };

            if (app.API.GetAll(adminAccount).Count == 0)
            {
                app.API.Create(adminAccount, project);
            }

            List<ProjectData> oldProjects = app.API.GetAll(adminAccount);
            ProjectData projectToRemove = oldProjects[0];

            app.Project.Remove(projectToRemove);

            List<ProjectData> newProjects = app.API.GetAll(adminAccount);

            oldProjects.Remove(projectToRemove);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
