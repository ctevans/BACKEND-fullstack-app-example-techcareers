using ClassToDoExample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassToDoExample.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //vZPBPK3Havt9ZrDxFgDqNacEKSWaJ6BL2Kv4OnVFAAI=
        }

        //CARE ABOUT STUFF HERE.
        public DbSet<TodoItem> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder cloned)
        {
            base.OnModelCreating(cloned);
        }
    }
}
