using CarRental.Library.Entity;
using CarRental.Library.Services;
using OrionDAL.OAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Manager
{
    public class CarManager : ICarService
    {
        public void Create(Car car)
        {
            car.Save();
        }

        public void Delete(int id)
        {
            Transaction.Instance.ExecuteNonQuery("Delete from CarImageGallery where Car_Id=@prm0", id);
        }

        public Car GetById(int id)
        {
            return Transaction.Instance.Read<Car>("select * from Car where  Id=@prm0", id) ?? new Car();
        }

        public List<Car> GetByTrueCar()
        {
            return Transaction.Instance.ReadList<Car>("Select * from Car Where CarStatus = @prm0", true).ToList() ?? new List<Car>();
        }

        public List<Car> GetList()
        {
            return Transaction.Instance.ReadList<Car>("Select * from Car").ToList() ?? new List<Car>();
        }
    }
}
