using CarRental.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Services
{
    public interface IContactService
    {
        List<Contact> GetList();
        Contact GetById(int id);
        void Create(Contact contact);
        void Delete(int id);
    }
}
