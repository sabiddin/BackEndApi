using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BackEndApi.Domain.Models;

namespace BackEndApi.Data
{
    public class BackEndApiDataContext : DbContext
    {
        public BackEndApiDataContext(DbContextOptions<BackEndApiDataContext> options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
