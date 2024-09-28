using DAL.EF.TableModels;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = DAL.EF.TableModels.Task;

namespace DAL
{
    public class DataAccess
    {
        public static ITaskRepo<Task, int, bool> TaskData()
        {
            return new TaskRepo();
        }

        public static IRepo<Category,int,bool> CategoryData()
        {
            return new CategoryRepo();
        }

        public static IRepo<User, int, bool>UserData()
        {
            return new UserRepo();
        }

        public static IRepo<UserDetails, int, bool> UserDetailsData()
        {
            return new UserDetailsRepo();
        }

        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
    }
}
