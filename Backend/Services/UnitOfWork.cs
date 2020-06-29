using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities.Models;
using Backend.Data;
namespace Backend.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private HamburguerContext _dbContext;
        private BaseRepository<Hamburguer> _hamburguer;
        private BaseRepository<User> _user;
        private BaseRepository<Ingredient> _ingredient;
        private BaseRepository<Restaurant> _restaurant;

        public UnitOfWork(HamburguerContext context)
        {
            _dbContext = context;
        }
        public IRepository<Hamburguer> Hamburguers {
            get
            {
                return _hamburguer ?? (_hamburguer = new BaseRepository<Hamburguer>(_dbContext));
            }
        }

        public IRepository<Ingredient> Ingredients
        {
            get
            {
                return _ingredient ?? (_ingredient = new BaseRepository<Ingredient>(_dbContext));
            }
        }
        public IRepository<Restaurant> Restaurants
        {
            get
            {
                return _restaurant ?? (_restaurant = new BaseRepository<Restaurant>(_dbContext));
            }
        }
        public IRepository<User> Users
        {
            get
            {
                return _user ?? (_user = new BaseRepository<User>(_dbContext));
            }
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
