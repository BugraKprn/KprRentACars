using OrionDAL.Web.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Entity
{
    public class Home : BaseEntity
    {
        public string HomeLocation { get; set; } = "";
        public string HomeMeter { get; set; } = "";
        public string HomeRoom { get; set; } = "";
        public string HomeFloor { get; set; } = "";
        public string HomePrice { get; set; } = "";
        public string HomeDownPrice { get; set; } = "";
        public string HomeBigImage { get; set; } = "";
    }
}
