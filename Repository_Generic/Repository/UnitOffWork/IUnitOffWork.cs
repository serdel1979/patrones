
using DesignPatterns.Respository;
using Patterns.UnitOW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOffWork
{
    public interface IUnitOffWork
    {
        IRepository<Beer> Beers { get; } 
        IRepository<Brand> Brands { get; }
        public void Save();
    }
}
