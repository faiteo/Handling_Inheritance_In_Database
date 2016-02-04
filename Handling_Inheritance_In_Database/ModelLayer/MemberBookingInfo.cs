using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Handling_Inheritance_In_Database.ModelLayer
{
    public class MemberBookingInfo
    {
        private int memberID;

        public int MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }
        private string memberName;

        public string MemberName
        {
            get { return memberName; }
            set { memberName = value; }
        }
        private List<FitnessClass> fitnessClassList;

        public List<FitnessClass> FitnessClassList
        {
            get { return fitnessClassList; }
            set { fitnessClassList = value; }
        }
    }
}