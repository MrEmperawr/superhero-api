using System;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
	public class SuperHeroService: ISuperHeroService
	{
        private static List<SuperHero> superHeroes = new List<SuperHero> {
                new SuperHero
                {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                },
                 new SuperHero
                {
                    Id = 2,
                    Name = "Iron Man",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "New York City"
                },
                  new SuperHero
                {
                    Id = 3,
                    Name = "Batman",
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Place = "Gotham City"
                },
                   new SuperHero
                {
                    Id = 4,
                    Name = "Aquaman",
                    FirstName = "Arthur",
                    LastName = "Curry",
                    Place = "Atlantis"
                },

            };

        public List<SuperHero> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return superHeroes;
        }

        public List<SuperHero> DeletHero(int id)
        {
            superHeroes.RemoveAll(hero => hero.Id == id);

            return superHeroes;
        }

        public List<SuperHero> GetAllHeroes()
        {
            return superHeroes;
        }

        public SuperHero? GetHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null) return null;
            return hero;
        }

        public List<SuperHero>? UpdateHero(int id, SuperHero request)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null) return null;
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return superHeroes;
        }
    }
}

