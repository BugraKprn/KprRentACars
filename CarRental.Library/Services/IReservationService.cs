using CarRental.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Services
{
    public interface IReservationService
    {
        List<Reservation> GetList();
        Reservation GetById(int id);
        void Create(Reservation reservation);
        void Delete(int id);
    }
}
