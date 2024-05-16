﻿using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }

}
