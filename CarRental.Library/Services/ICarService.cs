using CarRental.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Services
{
    public interface ICarService
    {
        List<Car> GetList();
        Car GetById(int id);
        List<Car> GetByTrueCar();
        void Create(Car car);
        void Delete(int id);
    }
}
