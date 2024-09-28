using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BLL.Services
{
    public class TaskService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Task, TaskDTO>();
                cfg.CreateMap<TaskDTO, Task>();
                cfg.CreateMap<Subtask, SubTaskDTO>();
                cfg.CreateMap<SubTaskDTO, Subtask>();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, Category>();
            });

            return new Mapper(config);
        }

        public static bool Create(TaskDTO obj)
        {
            var data = GetMapper().Map<Task>(obj);
            data.Subtasks = new List<Subtask>();

            if (obj.Subtasks != null && obj.Subtasks.Count > 0)
            {
                foreach (var subTask in obj.Subtasks)
                {
                    var subTasks = GetMapper().Map<Subtask>(subTask);
                    subTasks.T_id = data.Tid;
                    data.Subtasks.Add(subTasks);
                }
            }




            return DataAccess.TaskData().Create(data);
        }


        public static List<TaskDTO> Get()
        {
            var data = DataAccess.TaskData().Get();
            return GetMapper().Map<List<TaskDTO>>(data);

        }

        public static TaskDTO Get(int id)
        {
            var data = DataAccess.TaskData().Get(id);
            return GetMapper().Map<TaskDTO>(data);
        }

        public static bool Update (TaskDTO obj)
        {
            var data = GetMapper().Map<Task>(obj);
            return DataAccess.TaskData().Update(data);
        }

        public static bool Delete(int id )
        {
            return DataAccess.TaskData().Delete(id);
        }

        public static bool UpdateTaskStatus(int TaskId, string status)
        {
            var task = DataAccess.TaskData().Get(TaskId);

            if (task == null) return false;

            task.T_Status = status;
           
            return DataAccess.TaskData().Update(task);
        }

        public static List<TaskDTO> GetTasksByStatus(string status)
        {
            var tasks = DataAccess.TaskData().GetTasksByStatus(status);
            return GetMapper().Map<List<TaskDTO>>(tasks);
        }

        public static List<TaskDTO> GetTaskByCat(string cat)
        {
            var tasks = DataAccess.TaskData().GetTaskByCat(cat);
            return GetMapper().Map<List<TaskDTO>>(tasks);
        }

        public static List<TaskDTO> GetUpcomingTasks(int days)
        {
            var upcomingDate = DateTime.Now.AddDays(days);
            var tasks = DataAccess.TaskData().Get()
                          .Where(t => t.T_Complete_Date <= upcomingDate)
                          .ToList();

            var taskExpire = GetMapper().Map<List<TaskDTO>>(tasks);

            foreach (var task in taskExpire)
            {
                task.UpdateExpireStatus();
                task.CheckForReminder();
            }

            return taskExpire;
        }
    }
}
