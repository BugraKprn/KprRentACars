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
    public class SliderManager : ISliderService
    {
        public void Create(Slider slider)
        {
            slider.Save();
        }

        public void Delete(int id)
        {
            Transaction.Instance.ExecuteNonQuery("Delete from Slider where Id = @prm0", id);
        }

        public Slider GetById(int id)
        {
            return Transaction.Instance.Read<Slider>("Select * from Slider Where Id = @prm0", id) ?? new Slider();
        }

        public List<Slider> GetList()
        {
            return Transaction.Instance.ReadList<Slider>("Select * from Slider order by SliderOrder asc").ToList() ?? new List<Slider>();
        }
    }
}
