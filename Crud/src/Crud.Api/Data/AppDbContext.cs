﻿using Crud.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud.Api.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
