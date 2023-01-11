using OrionDAL.OAL.Metadata;
using OrionDAL.Web.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Entity
{
    public class Setting : BaseEntity
    {
        public string CompanyName { get; set; } = "";
        public string ContactName { get; set; } = "";
        public string Logo { get; set; } = "";
        public string FooterLogo { get; set; } = "";
        public string MobileLogo { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Mail { get; set; } = "";
        public string Adress { get; set; } = "";
        public string WorkTime { get; set; } = "";
        [FieldDefinition(Length = 0)]
        public string GoogleMapUrl { get; set; } = "";
        [FieldDefinition(Length = 4000)]
        public string FooterDescription { get; set; } = "";

        //Social Media
        public string Twitter { get; set; } = "";
        public string Instagram { get; set; } = "";
        public string Facebook { get; set; } = "";
        public string Linkedin { get; set; } = "";
        public string GooglePlus { get; set; } = "";
        public string Sahibinden { get; set; } = "";

        // About Page

        [FieldDefinition(Length = 0)]
        public string About { get; set; }
    }
}
