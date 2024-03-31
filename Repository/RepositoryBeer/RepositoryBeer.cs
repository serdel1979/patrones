using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryBeer
{
    internal class RepositoryBeer : IBeer
    {
        private readonly PatternsContext _patternsContext;

        public RepositoryBeer(PatternsContext patternsContext)
        {
            this._patternsContext = patternsContext;
        }

        public void Add(Beer beer)
        {
            _patternsContext.Beers.Add(beer);
        }

        public void Delete(long Id)
        {
            var beer = _patternsContext.Beers.Find(Id);
            _patternsContext.Beers.Remove(beer);
        }

        public IEnumerable<Beer> Get()
        {
            return _patternsContext.Beers.ToList();
        }

        public Beer Get(int id)
        {
           return _patternsContext.Beers.Find(id);
        }

        public void Update(Beer beer)
        {
            _patternsContext.Entry(beer).State = EntityState.Modified;
        }

        public void Save()
        {
            _patternsContext.SaveChanges();
        }


    }
}
