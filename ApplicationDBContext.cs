﻿using Microsoft.EntityFrameworkCore;
using FormApi.Entities;

namespace FormApi
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<FormEntity> Forms { get; set; }
        public DbSet<PhoneRecord> PhoneRecords { get; set; }
        public DbSet<RelativeEntity> Relatives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Включаем Lazy Loading Proxies
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
