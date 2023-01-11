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
    public class QuickLinkManager : IQuickLinkService
    {
        public void Create(QuickLink quickLink)
        {
            quickLink.Save();
        }

        public void Delete(int id)
        {
            Transaction.Instance.ExecuteNonQuery("Delete from QuickLink where Id = @prm0", id);
        }

        public QuickLink GetById(int id)
        {
            return Transaction.Instance.Read<QuickLink>("Select * from QuickLink Where Id = @prm0", id) ?? new QuickLink();
        }

        public List<QuickLink> GetList()
        {
            return Transaction.Instance.ReadList<QuickLink>("Select * from QuickLink order by LinkOrder asc").ToList() ?? new List<QuickLink>();
        }
    }
}
