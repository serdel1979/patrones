
using DesignPatterns.Respository;
using Patterns.UnitOW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOffWork
{
    public class UnitOffWork : IUnitOffWork
    {

        private readonly PatternsContext _patternsContext;
        private IRepository<Beer> _beers;
        private IRepository<Brand> _brands;

        public UnitOffWork(PatternsContext patternsContext)
        {
            _patternsContext = patternsContext;
        }

        public IRepository<Beer> Beers
        {
            get
            {
                return _beers == null ?
                        _beers = new Repository<Beer>(_patternsContext) : _beers;
            }
        }

        public IRepository<Brand> Brands
        {
            get
            {
                return _brands == null ?
                       _brands = new Repository<Brand>(_patternsContext) : _brands;
            }
        }

        public void Save()
        {
            _patternsContext.SaveChanges();
        }
    }
}
