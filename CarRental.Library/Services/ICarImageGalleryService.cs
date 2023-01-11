using CarRental.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Services
{
    public interface ICarImageGalleryService
    {
        List<CarImageGallery> GetList();
        CarImageGallery GetById(int id);
        void Create(CarImageGallery carImageGallery);
        void Delete(int id);
    }
}
