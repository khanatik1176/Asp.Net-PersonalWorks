using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, bool>,IAuth
    {
        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj == null) return false; 
            db.Users.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(string id)
        {
            return db.Users.FirstOrDefault(u => u.UserEmail == id); 
        }

        public User Update(User obj)
        {
            var exobj = Get(obj.UserEmail);
            if (exobj == null) return null; 

            exobj.Uid = obj.Uid;
            exobj.UserEmail = obj.UserEmail;
            exobj.UserPassword = obj.UserPassword;
            exobj.UD_id = obj.UD_id;
            db.SaveChanges();
            return exobj; 
        }

        public bool Authenticate(string uname, string pass)
        {
            var user = db.Users.SingleOrDefault(
        u => u.UserEmail.Equals(uname) && u.UserPassword.Equals(pass));
            return user != null;
        }

        public User Get(int id)
        {
           
            return db.Users.Find(id);
        }

        bool IRepo<User, int, bool>.Update(User obj)
        {
            return Update(obj) != null;
        }

        object IRepo<User, int, bool>.Authenticate(string uname, string pass)
        {
            return Authenticate(uname, pass);
        }
    }
}
