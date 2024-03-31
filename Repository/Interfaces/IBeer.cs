using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IBeer
    {
        IEnumerable<Beer> Get();
        Beer Get(int id);
        void Add(Beer beer);
        void Delete(long Id);
        void Update(Beer beer);
        void Save();
    }
}
