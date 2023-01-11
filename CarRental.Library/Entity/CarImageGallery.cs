using OrionDAL.ActiveRecord;
using OrionDAL.OAL;
using OrionDAL.Web.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Entity
{
    public class CarImageGallery : BaseEntity
    {
        public string CarSmallImage { get; set; } = "";

        [NonPersistent]
        public int CarId { get; set; }

        public SharpPointer<Car> Car { get; set; }

        public CarImageGallery()
        {
            Car = new SharpPointer<Car>();
        }
    }
}
