using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WoundExpert.Domain.Models;

namespace WoundExpert.Data
{
    public class WoundExpertDataContext : DbContext
    {
        public WoundExpertDataContext(DbContextOptions<WoundExpertDataContext> options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
