using OrionDAL.OAL.Metadata;
using OrionDAL.Web.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Entity
{
    public class Car : BaseEntity
    {
        public string CarName { get; set; } = "";
        public string CarPrice { get; set; } = "";
        public string CarDownPrice { get; set; } = "";
        public bool CarStatus { get; set; } = true;
        public string LargeImage { get; set; } = "";
        public string Kilometer { get; set; } = "";
        public string Model { get; set; } = "";
        public string BodyStyle { get; set; } = "";
        public string Color { get; set; } = "";
        public string Engine { get; set; } = "";
        public string Gear { get; set; } = "";
        public string FuelType { get; set; } = "";
        public string Condition { get; set; } = "";
        public string Seats { get; set; } = "";
        [FieldDefinition(Length = 0)]
        public string Overview { get; set; } = "";
        [FieldDefinition(Length = 0)]
        public string FeaturesAndOptions { get; set; } = "";
        [FieldDefinition(Length = 0)]
        public string Location { get; set; } = "";
    }
}
