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
    public class CarImageGalleryManager : ICarImageGalleryService
    {
        public void Create(CarImageGallery carImageGallery)
        {
            carImageGallery.Save();
        }

        public void Delete(int id)
        {
            Transaction.Instance.ExecuteNonQuery("Delete from Category where Id = @prm0", id);
        }

        public CarImageGallery GetById(int id)
        {
            return Transaction.Instance.Read<CarImageGallery>("Select * from CarImageGallery Where Id = @prm0", id) ?? new CarImageGallery();
        }

        public List<CarImageGallery> GetList()
        {
            return Transaction.Instance.ReadList<CarImageGallery>("Select CarImageGallery.Id, CarImageGallery.CarSmallImage, Car.CarName as CarName, CarImageGallery.Car_Id from CarImageGallery join Car on CarImageGallery.Car_Id = Car.Id").ToList() ?? new List<CarImageGallery>();
        }
    }
}
