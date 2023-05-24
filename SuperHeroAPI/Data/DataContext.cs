using System;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data
{
	public class DataContext: DbContext
	{
		public DataContext(DbContextOptions<DataContext> options): base(options)
		{

		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Database=superherodb;Username=postgres;Password=password");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}

