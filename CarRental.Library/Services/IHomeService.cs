using CarRental.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Services
{
    public interface IHomeService
    {
        List<Home> GetList();
        Home GetById(int id);
        void Create(Home home);
        void Delete(int id);
    }
}
