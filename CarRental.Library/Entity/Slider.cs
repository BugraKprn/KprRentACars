using OrionDAL.Web.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Entity
{
    public class Slider : BaseEntity
    {
        public string SliderImage { get; set; }
        public int SliderOrder { get; set; }
    }
}
