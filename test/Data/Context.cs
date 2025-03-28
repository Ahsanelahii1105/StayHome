﻿

using System.Data.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test.Models;
using test.Models.Menu;

namespace test.Data
{
    public class Context : DbContext
    {

        public  Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<ProfileCreator> ProfileCreator { get; set; }

        public DbSet<SallerProfileCreator> SallerProfileCreator { get; set; }

        public DbSet<AgentPropertyCreator> AgentPropertyCreator { get; set; }

        public DbSet<listningPropertyCreator> listningPropertyCreator { get; set; }

        public DbSet<SallerPropertyCreator> SallerPropertyCreator { get; set; }
    }
}

