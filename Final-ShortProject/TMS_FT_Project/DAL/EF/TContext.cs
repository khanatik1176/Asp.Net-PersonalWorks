using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL.EF
{
    public class TContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserDetails> UserDetails { get; set; }

        public DbSet<Token> Tokens { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Subtask> SubTasks { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
