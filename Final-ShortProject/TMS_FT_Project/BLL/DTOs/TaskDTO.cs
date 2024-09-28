using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TaskDTO
    {
        public int Tid { get; set; }

        public string T_Name { get; set; }

        public string T_Description { get; set; }

        public DateTime T_Complete_Date { get; set; }

        public string T_Status { get; set; }

        public string UserEmail { get; set; }

        public string C_Name { get; set; }

        public List<SubTaskDTO> Subtasks { get; set; }

        public string Progress => CalculateProgress(T_Status);

        public string ExpireStatus { get; set; }
        public string ReminderStatus { get; set; }

        public TaskDTO()
        {
            Subtasks = new List<SubTaskDTO>();
        }

        private string CalculateProgress(string status)
        {
            switch (status.ToLower())
            {
                case "complete":
                    return "100%";
                case "in-progress":
                        return "50%";
                case "to-do":
                        return "0";
                case "incomplete":
                    return "0";
                default:
                    return "Unknown";

            }

        }

        public void UpdateExpireStatus()
        {
            if(T_Complete_Date < DateTime.Now)
            {
                ExpireStatus = "Expired";
            }    

            else
            {
                ExpireStatus = "Active";
            }
        }

        public void CheckForReminder()
        {
            var tomorrow = DateTime.Now.AddDays(1).Date;
            if (T_Complete_Date.Date == tomorrow)
            {
                ReminderStatus = "Tomorrow is your due date.";
            }
            else
            {
                ReminderStatus = "No upcoming due date.";
            }
        }



    }
}
