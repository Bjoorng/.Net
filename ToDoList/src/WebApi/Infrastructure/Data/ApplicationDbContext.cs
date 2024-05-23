﻿using Microsoft.EntityFrameworkCore;
using WebApi.Domains.Entities;

namespace WebApi.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<TodoList> TodoLists => Set<TodoList>();
        public DbSet<ListItem> ListItems => Set<ListItem>();
    }
}