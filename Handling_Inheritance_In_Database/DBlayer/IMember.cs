using Handling_Inheritance_In_Database.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Handling_Inheritance_In_Database.DBlayer
{
    public interface IMember
    {
        //Get All Members
        List<Member> GetAllMembers();

	    //Finds a member by ID.
	    Member FindMember(int memberID);

	    //Creates and add a new Member.
        int InsertNewMember(Member memberObject);

	    //Delete a member.
	    int DeleteMember(int memberID);

        MemberBookingInfo GetMemberBooking(int memberID);

        //Update an existing member info.
	    int UpdateMember(Member memberObj);

    
    }
}
