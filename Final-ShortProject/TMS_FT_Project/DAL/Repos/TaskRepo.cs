using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task = DAL.EF.TableModels.Task;

namespace DAL.Repos
{
    internal class TaskRepo : Repo, ITaskRepo<Task, int, bool>
    {
        public bool Create(Task obj)
        {
            db.Tasks.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);

            if (exobj == null) return false;

            db.SubTasks.RemoveRange(exobj.Subtasks);
            db.Tasks.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Task> Get()
        {
            return db.Tasks.ToList();
        }

        public Task Get(int id)
        {
            return db.Tasks.Find(id);
        }

        public bool Update(Task obj)
        {
            var exobj = Get(obj.Tid);

            if (exobj == null) return false; 

            exobj.Tid = obj.Tid;
            exobj.T_Name = obj.T_Name;
            exobj.T_Description = obj.T_Description;
            exobj.T_Complete_Date = obj.T_Complete_Date;
            exobj.T_Status = obj.T_Status;
            exobj.UserEmail = obj.UserEmail;

            
            foreach (var subTask in obj.Subtasks)
            {
                var existingSubTask = exobj.Subtasks.FirstOrDefault(st => st.ST_id == subTask.ST_id);

                if (existingSubTask != null)
                {

                    existingSubTask.ST_id = subTask.ST_id;
                    existingSubTask.ST_Name = subTask.ST_Name;
                    existingSubTask.ST_Description = subTask.ST_Description;
                }
                else
                {
                    
                    exobj.Subtasks.Add(subTask);
                }
            }

            return db.SaveChanges() > 0;
        }

        public List<Task> GetTasksByStatus(string status)
        {
            return db.Tasks.Where(t => t.T_Status == status).ToList();
        }

        public object GetTasksbyStatus(string status)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetTaskByCat(string cat)
        {
            return db.Tasks
             .Where(t => t.C_Name.Equals(cat, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
