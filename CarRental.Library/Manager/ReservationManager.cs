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
    public class ReservationManager : IReservationService
    {
        public void Create(Reservation reservation)
        {
            reservation.Save();
        }

        public void Delete(int id)
        {
            Transaction.Instance.ExecuteNonQuery("Delete from Reservation where Id = @prm0", id);
        }

        public Reservation GetById(int id)
        {
            return Transaction.Instance.Read<Reservation>("Select * from Reservation Where Id = @prm0", id) ?? new Reservation();
        }

        public List<Reservation> GetList()
        {
            return Transaction.Instance.ReadList<Reservation>("Select * from Reservation").ToList() ?? new List<Reservation>();
        }
    }
}
