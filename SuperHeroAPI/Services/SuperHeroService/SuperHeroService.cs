using System;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
	public class SuperHeroService: ISuperHeroService
	{


        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            var superHeroes = await _context.SuperHeroes.ToListAsync();
            superHeroes.Add(hero);

            await _context.SaveChangesAsync();

            return superHeroes;
        }

        public async Task<List<SuperHero>?> DeletHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null) return null;
            _context.SuperHeroes.Remove(hero);

            await _context.SaveChangesAsync();

            return await GetAllHeroes();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null) return null;
            return hero;
        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null) return null;
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();

            return await GetAllHeroes();
        }

      
    }
}

