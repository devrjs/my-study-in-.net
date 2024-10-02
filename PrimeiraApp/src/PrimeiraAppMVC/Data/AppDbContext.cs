﻿using Microsoft.EntityFrameworkCore;
using PrimeiraAppMVC.Models;

namespace PrimeiraAppMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
