using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Authorization.Infrastructure;
//using System.Reflection.PortableExecutable;
using ToDo.Models.Domain;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Reflection.Emit;
using System.Resources;
using static System.Net.WebRequestMethods;
using System.Threading.Tasks;

namespace ToDo.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tasks>().HasKey(c => c.TaskId);
            modelBuilder.Entity<Tasks>().HasData(new Tasks { TaskId = 1, taskContent = "Clean the room", taskStatus = false });
            modelBuilder.Entity<Tasks>().HasData(new Tasks { TaskId = 5, taskContent = "Clean the room", taskStatus = false });

        }
    }
}