using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationSoapTests : AuthTestBase
    {
        [Test]
        public void TestProjectCreationSoap()
        {
            ProjectData projectToAdd = new ProjectData(GenerateRandomString(10));

            List<ProjectData> oldProjects = app.API.GetAll(adminAccount);

            if (oldProjects.Contains(projectToAdd))
            {
                Assert.Fail("Such project already exists");
            }
            else
            {
                app.Project.Create(projectToAdd);
            }

            List<ProjectData> newProjects = app.API.GetAll(adminAccount);

            oldProjects.Add(projectToAdd);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
