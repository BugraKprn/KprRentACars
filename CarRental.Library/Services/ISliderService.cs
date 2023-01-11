using CarRental.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Services
{
    public interface ISliderService
    {
        List<Slider> GetList();
        Slider GetById(int id);
        void Create(Slider slider);
        void Delete(int id);
    }
}
