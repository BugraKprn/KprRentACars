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
    public class HomeManager : IHomeService
    {
        public void Create(Home home)
        {
            home.Save();
        }

        public void Delete(int id)
        {
            Transaction.Instance.ExecuteNonQuery("Delete from Home where Id = @prm0", id);
        }

        public Home GetById(int id)
        {
            return Transaction.Instance.Read<Home>("Select * from Home Where Id = @prm0", id) ?? new Home();
        }

        public List<Home> GetList()
        {
            return Transaction.Instance.ReadList<Home>("Select * from Home").ToList() ?? new List<Home>();
        }
    }
}
