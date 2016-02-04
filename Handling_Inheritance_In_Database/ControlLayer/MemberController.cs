using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Handling_Inheritance_In_Database.ModelLayer;
using Handling_Inheritance_In_Database.DBlayer;

namespace Handling_Inheritance_In_Database.ControlLayer

{
    public class MemberController
    {

        IMember dbMember = new DBMember();

        public MemberController()
        {
           
        }

        public List<Member> GetAllMembers()
        {
            List<Member> allMember = dbMember.GetAllMembers();
            return allMember;
        }


        public Member FindAMember(int ID)
        {
            Member memberObj =  null;
            memberObj = dbMember.FindMember(ID);
            return memberObj;
        }


        public bool InsertNewMember(Member memberObj)
        {
            bool result = false;
            if(dbMember.InsertNewMember(memberObj) == 1)
            {
                result = true;
            }
            return result;
        }

        public bool DeleteMember(int ID)
        {
            bool result = false;
            if (dbMember.DeleteMember(ID) == 1)
            {
                return result = true;
            }
            else
            {
                return result;
            }
        }


        public MemberBookingInfo GetMemberBooking(int ID)
        {
            MemberBookingInfo result = dbMember.GetMemberBooking(ID);
            return result;
        }

    }
}