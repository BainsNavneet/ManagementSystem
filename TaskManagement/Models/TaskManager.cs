using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagment.Models;

namespace TaskManagement.Models
{
    public class TaskManager
    {

        ApplicationDbContext db = new ApplicationDbContext();
        public void AddTaskToProject(string taskName, string projectName)
        {
            var project = db.Projects.FirstOrDefault(p => p.ProjectName == projectName);

            if (project != null)
            {
                var task = new Task();
                task.TaskName = taskName;
                project.Tasks.Add(task);
            }
            db.SaveChanges();
        }

        public void RemoveTaskFromProject(string taskName, string projectName)
        {
            var project = db.Projects.FirstOrDefault(p => p.ProjectName == projectName);

            if (project != null)
            {
                var task = project.Tasks.FirstOrDefault(t => t.TaskName == taskName);
                project.Tasks.Remove(task);
                db.SaveChanges();
            }
        }

        public void UpdateTask(string taskId)
        {
            var task = db.Tasks.Find(taskId);

            if (task != null)
            {
                if (task.Status == false)
                {
                    task.Status = true;
                }
                else
                {
                    task.Status = false;
                }
            }
            db.SaveChanges();
        }
    }
}