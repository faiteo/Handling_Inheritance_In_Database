using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Handling_Inheritance_In_Database.ModelLayer
{
    public class GoldMember:Member
    {
        private string facilityName;
        private string dietistName;


        public string FacilityName
        {
            get { return facilityName; }
            set { facilityName = value; }
        }


        public string DietistName
        {
            get { return dietistName; }
            set { dietistName = value; }
        }
    }
}