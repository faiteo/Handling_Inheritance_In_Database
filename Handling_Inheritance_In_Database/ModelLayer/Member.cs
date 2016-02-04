using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Handling_Inheritance_In_Database.ModelLayer
{
    public class Member
    {
        protected int memberID;
        protected string firstName;
        protected string lastName;
        protected string phoneNum;
        protected string emailAdr;
        protected string homeAddr;
        protected string city;

        public int MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }


        public string Firstname
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string Lastname
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Phonenum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }

        public string Email
        {
            get { return emailAdr; }
            set { emailAdr = value; }
        }


        public string Address
        {
            get { return homeAddr; }
            set { homeAddr = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }



        public enum MemberType
        {
            GoldMember = 1,
            SilverMember = 2
        }

        public MemberType Type 
        {
            get; 
            set; 
        }
    }
}