using System;
using User.Services.Interfaces;

namespace User.Services.Implimentations
{
	public class SuperHeroServices: ISuperHeroServices
	{
        private readonly DataContext _db;
		public SuperHeroServices(DataContext context)=>
            _db = context;

        public void Add(SuperHero superHero)
        {
            _db.SuperHeroes.Add(superHero);
            _db.SaveChanges();
        }

        public void Delete(Nullable<int> id)
        {
            var hero = _db.SuperHeroes.FirstOrDefault(x => x.Id == id);
            if (hero != null)
            {
                _db.SuperHeroes.Remove(hero);
                _db.SaveChanges();
            }
        }

        public SuperHero GetHero(Nullable<int> id)
        {
            if (id!.HasValue)
                return null;
            return _db.SuperHeroes.FirstOrDefault(x => x.Id == id.Value);
        }

        public List<SuperHero> GetHeroes()=>
            _db.SuperHeroes.AsNoTracking().ToList();

        public void Update(SuperHero superHero)
        {
            var hero = _db.SuperHeroes.FirstOrDefault(x => x.Id == superHero.Id);
            if (hero != null)
            {
                hero.Name = superHero.Name;
                hero.FirstName = superHero.FirstName;
                hero.LastName = superHero.LastName;
                hero.Place = superHero.Place;
                _db.SaveChangesAsync();
            }
        }
    }
}

