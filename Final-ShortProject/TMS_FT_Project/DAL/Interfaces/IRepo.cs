﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS,ID,RET>
    {
        RET Create(CLASS obj);
        List<CLASS> Get();
        CLASS Get(ID id);

        RET Update(CLASS obj);

        bool Delete(ID id);
        object Authenticate(string uname, string pass);
    }
}
