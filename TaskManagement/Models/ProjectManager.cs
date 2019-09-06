using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagment.Models;

namespace TaskManagement.Models
{
    public class ProjectManager
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void AddNewProject(string projectName)
        {

            if (db.Projects.Find(projectName) != null)
            {
                return;
            }
            else
            {
                db.Projects.Add(new Project() { ProjectName = projectName });
            }
            db.SaveChanges();
        }
        public void RemoveProject(string projectName)
        {
            var project = db.Projects.Find(projectName);

            if (project != null)
            {
                db.Projects.Remove(project);
            }
            db.SaveChanges();
        }
        public void UpdateProject(string projectName)
        {
            var project = db.Projects.Find(projectName);

            if (project.Status == false)
            {
                project.Status = true;
            }
            db.SaveChanges();
        }
    }
}