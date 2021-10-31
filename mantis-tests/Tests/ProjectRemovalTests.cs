using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void TestProjectRemoval()
        {
            if(app.Project.GetAll().Count == 0)
            {
                app.Project.Create(new ProjectData(GenerateRandomString(10)));
            }

            List<ProjectData> oldProjects = app.Project.GetAll();
            ProjectData projectToRemove = oldProjects[0];

            app.Project.Remove(projectToRemove);

            List<ProjectData> newProjects = app.Project.GetAll();

            oldProjects.Remove(projectToRemove);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
