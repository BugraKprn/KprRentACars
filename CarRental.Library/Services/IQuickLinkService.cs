using CarRental.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Services
{
    public interface IQuickLinkService
    {
        List<QuickLink> GetList();
        QuickLink GetById(int id);
        void Create(QuickLink quickLink);
        void Delete(int id);
    }
}
