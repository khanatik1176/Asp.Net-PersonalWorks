using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserDetailsRepo : Repo, IRepo<UserDetails, int, bool>
    {
        public object Authenticate(string uname, string pass)
        {
            throw new NotImplementedException();
        }

        public bool Create(UserDetails obj)
        {
            db.UserDetails.Add(obj);
            return db.SaveChanges() > 0;

        }

        public bool Delete(int id)
        {
            var exobj = Get(id);

            if (exobj == null) return false;

          
            db.UserDetails.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<UserDetails> Get()
        {
            return db.UserDetails.ToList();
        }

        public UserDetails Get(int id)
        {
            return db.UserDetails.Find(id);
        }

        public bool Update(UserDetails obj)
        {
            var exobj = Get(obj.UD_id);

            exobj.UD_id = obj.UD_id;
            exobj.UD_Email = obj.UD_Email;
            exobj.UD_Name = obj.UD_Name;
            exobj.UD_PhoneNumber = obj.UD_PhoneNumber;
            exobj.UD_Address = obj.UD_Address;

            return db.SaveChanges() > 0;
        }
    }
}
