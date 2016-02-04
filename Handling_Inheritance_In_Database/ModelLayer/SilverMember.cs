using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Handling_Inheritance_In_Database.ModelLayer
{
    public class SilverMember:Member
    {
        private string instructorName;

        public string InstructorName
        {
            get { return instructorName; }
            set { instructorName = value; }
        }
    }
}