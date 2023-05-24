﻿using System;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
	public interface ISuperHeroService
	{
		List<SuperHero> GetAllHeroes();
		SuperHero? GetHero(int id);
		List<SuperHero>? AddHero(SuperHero hero);
        List<SuperHero>? UpdateHero(int id, SuperHero request);
        List<SuperHero> DeletHero(int id);
    }
}
