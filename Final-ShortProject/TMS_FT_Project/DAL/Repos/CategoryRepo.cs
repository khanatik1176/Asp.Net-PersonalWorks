using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repos
{
   internal class CategoryRepo : Repo, IRepo<Category, int, bool>
    {
        public object Authenticate(string uname, string pass)
        {
            throw new NotImplementedException();
        }

        public bool Create(Category obj)
        {
            db.Categories.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);

            if (exobj == null) return false;

            db.Categories.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Category> Get()
        {
            return db.Categories.Include(c => c.Tasks).ToList();
        }

        public Category Get(int id)
        {
          
            var category = db.Categories.FirstOrDefault(c => c.Cid == id);

   
            if (category != null)
            {
                return db.Categories.Include(c => c.Tasks)
                                    .FirstOrDefault(c => c.C_Name == category.C_Name);
            }

            return null;
        }

        public bool Update(Category obj)
        {
            var exobj = Get(obj.Cid);

            if (exobj == null) return false;

            exobj.Cid = obj.Cid;
            exobj.C_Name = obj.C_Name;

             return db.SaveChanges() > 0;
        }
    }
}
