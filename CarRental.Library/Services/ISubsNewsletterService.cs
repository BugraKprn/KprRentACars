using CarRental.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Services
{
    public interface ISubsNewsletterService
    {
        List<SubsNewsletter> GetList();
        SubsNewsletter GetById(int id);
        void Create(SubsNewsletter subsNewsletter);
        void Delete(int id);
    }
}
