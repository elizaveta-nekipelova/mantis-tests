using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ApiHelper : HelperBase
    { 
        public ApiHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetAll(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            List<ProjectData> projectsList = new List<ProjectData>();

            List<Mantis.ProjectData> projects = client.mc_projects_get_user_accessible(account.Name, account.Password).ToList();

            foreach (Mantis.ProjectData project in projects)
            {
                projectsList.Add(new ProjectData() { Id = project.id, Name = project.name } );
            }

            return projectsList;
        }

        public void Create(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectMantis = new Mantis.ProjectData();
            projectMantis.name = project.Name;
            client.mc_project_add(account.Name, account.Password, projectMantis);
        }
    }
}
