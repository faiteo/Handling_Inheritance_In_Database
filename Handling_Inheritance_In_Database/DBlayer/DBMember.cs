using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Handling_Inheritance_In_Database.ModelLayer;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Handling_Inheritance_In_Database.DBlayer
{
    public class DBMember:IMember
    {
        public List<Member> GetAllMembers()
        {
            List<Member> memberListToReturn = new List<Member>();
            Member memObj = null;
            string connString = ConfigurationManager.ConnectionStrings["CS1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                string selectCmd = "SELECT * FROM Member";
                SqlCommand cmd = new SqlCommand(selectCmd, con);
                cmd.CommandType = CommandType.Text;

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if ((Member.MemberType)reader["membertype"] == Member.MemberType.GoldMember)
                        {
                            memObj = new GoldMember()
                            {
                                Firstname = reader["firstname"].ToString(),
                                Lastname = reader["lastname"].ToString(),
                                Address = reader["address"].ToString(),
                                City = reader["city"].ToString(),
                                Phonenum = reader["phonenumber"].ToString(),
                                Email = reader["email"].ToString(),
                                FacilityName = reader["facilityname"].ToString(),
                                DietistName = reader["dietistname"].ToString(),
                                Type = Member.MemberType.GoldMember
                            };
                            memberListToReturn.Add(memObj);
                        }
                        else
                        {
                            memObj = new SilverMember()
                            {
                                Firstname = reader["firstname"].ToString(),
                                Lastname = reader["lastname"].ToString(),
                                Address = reader["address"].ToString(),
                                City = reader["city"].ToString(),
                                Phonenum = reader["phonenumber"].ToString(),
                                Email = reader["email"].ToString(),
                                InstructorName = reader["instructorname"].ToString(),
                                Type = Member.MemberType.SilverMember
                            };
                            memberListToReturn.Add(memObj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return memberListToReturn;
        }




        public Member FindMember(int ID)
        {
            Member memberObjToReturn = null;

            string connString = ConfigurationManager.ConnectionStrings["CS1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                string selectCmd = "SELECT * FROM Member WHERE Id=@ID";
                SqlCommand cmd = new SqlCommand(selectCmd, con);
                cmd.CommandType = CommandType.Text;

                SqlParameter parameterID = new SqlParameter();
                parameterID.ParameterName = "@ID";
                parameterID.Value = ID;
                cmd.Parameters.Add(parameterID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if ((Member.MemberType)reader["membertype"] == Member.MemberType.GoldMember)
                        {
                            memberObjToReturn = new GoldMember()
                            {
                                MemberID = Convert.ToInt32( reader["Id"]),
                                Firstname = reader["firstname"].ToString(),
                                Lastname = reader["lastname"].ToString(),
                                Address = reader["address"].ToString(),
                                City = reader["city"].ToString(),
                                Phonenum = reader["phonenumber"].ToString(),
                                Email = reader["email"].ToString(),
                                FacilityName = reader["facilityname"].ToString(),
                                DietistName = reader["dietistname"].ToString(),
                                Type = Member.MemberType.GoldMember

                            };
                        }
                        else
                        {
                            memberObjToReturn = new SilverMember()
                            {
                                MemberID = Convert.ToInt32(reader["Id"]),
                                Firstname = reader["firstname"].ToString(),
                                Lastname = reader["lastname"].ToString(),
                                Address = reader["address"].ToString(),
                                City = reader["city"].ToString(),
                                Phonenum = reader["phonenumber"].ToString(),
                                Email = reader["email"].ToString(),
                                InstructorName = reader["instructorname"].ToString(),
                                Type = Member.MemberType.SilverMember
                            };
                        }
                    }

                    
                }

                }
            return memberObjToReturn;
        }



        public int InsertNewMember(Member memberObject)
        {
            int rowCount = 0;
           

            string connString = ConfigurationManager.ConnectionStrings["CS1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                string selectCmd = "INSERT INTO Member VALUES (@firstname, @lastname, @address, @city, @phonenumber, @email, @facilityname, @instructorname, @dietistname, @membertype)";

                SqlCommand cmd = new SqlCommand(selectCmd, con);
                cmd.CommandType = CommandType.Text;

                SqlParameter parameterFname = new SqlParameter
                {
                    ParameterName = "@firstname",
                    Value = memberObject.Firstname
                };
                cmd.Parameters.Add(parameterFname);


                SqlParameter parameterLastName = new SqlParameter
                {
                    ParameterName = "@lastname",
                    Value = memberObject.Lastname
                };
                cmd.Parameters.Add(parameterLastName);

                SqlParameter parameterAddr = new SqlParameter
                {
                    ParameterName = "@address",
                    Value = memberObject.Address
                };
                cmd.Parameters.Add(parameterAddr);


                SqlParameter parameterCity = new SqlParameter
                {
                    ParameterName = "@city",
                    Value = memberObject.City
                };
                cmd.Parameters.Add(parameterCity);


                SqlParameter parameterPhone = new SqlParameter
                {
                    ParameterName = "@phone",
                    Value = memberObject.Phonenum
                };
                cmd.Parameters.Add(parameterPhone);


                SqlParameter parameterEmail = new SqlParameter
                {
                    ParameterName = "@email",
                    Value = memberObject.Email
                };
                cmd.Parameters.Add(parameterEmail);

                SqlParameter parameterMembertype = new SqlParameter
                {
                    ParameterName = "@membertype",
                    Value = memberObject.Type
                };
                cmd.Parameters.Add(parameterMembertype);


                if (memberObject.GetType() == typeof(GoldMember))
                {
                    SqlParameter parameterFacility = new SqlParameter
                    {
                        ParameterName = "@facilityname",
                        Value = ((GoldMember)memberObject).FacilityName
                    };
                    cmd.Parameters.Add(parameterFacility);


                    SqlParameter parameterDiaetist = new SqlParameter
                    {
                        ParameterName = "@dietistname",
                        Value = ((GoldMember)memberObject).DietistName
                    };
                    cmd.Parameters.Add(parameterDiaetist);
                }
                else
                {
                    SqlParameter parameterInstructor = new SqlParameter
                    {
                        ParameterName = "@instructorname",
                        Value = ((SilverMember)memberObject).InstructorName
                    };
                    cmd.Parameters.Add(parameterInstructor);   
                }

                con.Open();
                if(cmd.ExecuteNonQuery() == 1)
                {
                    rowCount += rowCount;
                }
            }

            return rowCount;
        }



        public int DeleteMember(int memberID)
        {
            int rowCount = 0;
            string connString = ConfigurationManager.ConnectionStrings["CS1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                string deleteCmd = "DELETE FROM Member WHERE Id=@memberID";
                SqlCommand cmd = new SqlCommand(deleteCmd, con);
                cmd.CommandType = CommandType.Text;

                SqlParameter paramID = new SqlParameter();
                paramID.ParameterName = "@memberID";
                paramID.Value = memberID;
                cmd.Parameters.Add(paramID);

                con.Open();
                rowCount = cmd.ExecuteNonQuery();
            }
            return rowCount;

        }

        public int UpdateMember(Member memberObj)
        {
            throw new NotImplementedException();
        }




        public MemberBookingInfo GetMemberBooking(int memberID)
        {
            Member memObjFromDB = FindMember(memberID);
    
            MemberBookingInfo bookingInfoToReturn = null;
 
            FitnessClass fitnessClassObj;
            List<FitnessClass> listOfFitnessClass = new List<FitnessClass>();

            string connString = ConfigurationManager.ConnectionStrings["CS1"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand command1 = new SqlCommand(@"SELECT fc.Id, fc.Classname, fc.Instructorname, fc.Classtime, fc.Classdate 
                                                      FROM FitnessClass AS fc 
                                                      JOIN MemberBooking AS mb ON fc.Id=mb.Fitness_Class_ID
                                                      WHERE mb.MemberID= @memberID", con);
                command1.CommandType = CommandType.Text;

                SqlParameter paramID = new SqlParameter();
                paramID.ParameterName = "@memberID";
                paramID.Value = memberID;

                command1.Parameters.Add(paramID);

                con.Open();
                SqlDataReader reader = command1.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        fitnessClassObj = new FitnessClass()
                        {
                            ClassID = Convert.ToInt32(reader["Id"]),
                            ClassName = reader["Classname"].ToString(),
                            InstructorName = reader["Instructorname"].ToString(),
                            ClassTime = reader["Classtime"].ToString(),
                            ClassDate = reader["Classdate"].ToString()
                        };

                        listOfFitnessClass.Add(fitnessClassObj);
                    }
                }
                bookingInfoToReturn = new MemberBookingInfo()
                {
                    MemberID = memObjFromDB.MemberID,
                    MemberName = memObjFromDB.Firstname + " " + memObjFromDB.Lastname,
                    FitnessClassList = listOfFitnessClass
                };
       
                return bookingInfoToReturn;

            }

        }



  
    }
}