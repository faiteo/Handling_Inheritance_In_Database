<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Handling_Inheritance_In_Database.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/Style_Sheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtbxMemberID" runat="server"></asp:TextBox>
            <asp:Label ID="lblEnterMember" runat="server" Text="Enter Member ID"></asp:Label><br /><br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Member Bookings" /><br />
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
            
        </div>

        <h2><u>Member Booking Info:</u></h2>


        <asp:Label ID="lblmemberID" runat="server"  Text="Member ID: "></asp:Label><br />
        <asp:Label ID="lblmembername" runat="server"  Text="Member Name: "></asp:Label><br />

        <div id="content">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="booking">
                       
                        <b>Class ID:</b><asp:Label ID="lblClassID" runat="server" Text='<%#Eval("ClassID") %>'/><br />
                        <b>Class Name:</b> <asp:Label ID="lblClassName" runat="server" Text='<%#Eval("Classname") %>'/><br />
                        <b>Class Instructor:</b><asp:Label ID="lblInstructor" runat="server" Text='<%#Eval("Instructorname") %>'/><br />
                        <b>ClassTime:</b><asp:Label ID="lblClassTime" runat="server" Text='<%#Eval("Classtime") %>'/><br />
                        <b>Class Date:</b><asp:Label ID="lblClassDate" runat="server" Text='<%#Eval("Classdate") %>'/>                                
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>





    </form>
</body>
</html>
