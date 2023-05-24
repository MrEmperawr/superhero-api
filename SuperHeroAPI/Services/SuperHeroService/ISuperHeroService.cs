﻿using System;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
	public interface ISuperHeroService
	{
		Task<List<SuperHero>> GetAllHeroes();
		Task<SuperHero?> GetHero(int id);
		Task<List<SuperHero>?> AddHero(SuperHero hero);
        Task<List<SuperHero>?> UpdateHero(int id, SuperHero request);
        Task<List<SuperHero>?> DeletHero(int id);
    }
}

