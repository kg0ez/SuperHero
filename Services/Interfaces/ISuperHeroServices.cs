using System;
namespace User.Services.Interfaces
{
	public interface ISuperHeroServices
	{
		List<SuperHero> GetHeroes();
		SuperHero GetHero(Nullable<int> id);
		void Add(SuperHero superHero);
		void Update(SuperHero superHero);
		void Delete(Nullable<int> id);
	}
}

