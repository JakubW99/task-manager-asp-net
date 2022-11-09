﻿using Microsoft.EntityFrameworkCore;

namespace TaskManagaer.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<LAB.Models.Task> Tasks { get; set; }
        public string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "tasks.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder
       options)
        => options.UseSqlite($"Data Source={DbPath}");
      
    }
   

}

