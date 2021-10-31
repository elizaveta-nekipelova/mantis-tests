using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            ProjectData projectToAdd = new ProjectData(GenerateRandomString(10));

            List<ProjectData> oldProjects = app.Project.GetAll();

            if (oldProjects.Contains(projectToAdd))
            {
                Assert.Fail("Such project already exists");
            }
            else
            {
                app.Project.Create(projectToAdd);
            }

            List<ProjectData> newProjects = app.Project.GetAll();

            oldProjects.Add(projectToAdd);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
