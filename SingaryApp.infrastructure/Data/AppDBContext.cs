using Microsoft.EntityFrameworkCore;
using SingrayApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingaryApp.infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
    }
}
