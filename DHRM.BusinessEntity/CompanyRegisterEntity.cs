using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHRM.BusinessEntity
{
   public class CompanyRegisterEntity
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string LogoName { get; set; }
        public byte[] Logo { get; set; }
        public string CompanyType { get; set; }
        public string ContactPerson { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Zip4 { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string NoRecordsFoundText { get; set; }
        public string FullAddress
        {
            get
            {
                string address = StreetAddress1;
                address += !string.IsNullOrEmpty(StreetAddress2) ? " " + StreetAddress2 : "";
                address += !string.IsNullOrEmpty(City) ? ", " + City : "";
                address += !string.IsNullOrEmpty(StateName) ? " " + StateName : "";
                address += !string.IsNullOrEmpty(ZipCode) ? " " + ZipCode : "";
                //address += !string.IsNullOrEmpty(Zip4) ? "-" + Zip4 : "";
                address += " " + CountryName;
                return address;
            }
        }

       
    }
   
}
