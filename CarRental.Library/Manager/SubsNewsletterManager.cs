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
    public class SubsNewsletterManager : ISubsNewsletterService
    {
        public void Create(SubsNewsletter subsNewsletter)
        {
            subsNewsletter.Save();
        }

        public void Delete(int id)
        {
            Transaction.Instance.ExecuteNonQuery("Delete from SubsNewsletter where Id = @prm0", id);
        }

        public SubsNewsletter GetById(int id)
        {
            return Transaction.Instance.Read<SubsNewsletter>("Select * from SubsNewsletter Where Id = @prm0", id) ?? new SubsNewsletter();
        }

        public List<SubsNewsletter> GetList()
        {
            return Transaction.Instance.ReadList<SubsNewsletter>("Select * from SubsNewsletter").ToList() ?? new List<SubsNewsletter>();
        }
    }
}
