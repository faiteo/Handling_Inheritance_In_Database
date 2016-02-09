using Handling_Inheritance_In_Database.DBlayer;
using Handling_Inheritance_In_Database.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Handling_Inheritance_In_Database.ControlLayer;
using System.ComponentModel;
using System.Data;

namespace Handling_Inheritance_In_Database
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmemberID.Visible = false;
            lblmembername.Visible = false;
            lblError.Visible = false;
            myHeader.Visible = true;
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            try 
            { 
            int idToFind;
            if (int.TryParse(txtbxMemberID.Text, out idToFind))
            {
                MemberController ctrlMem = new MemberController();
                MemberBookingInfo membooking = ctrlMem.GetMemberBooking(idToFind);
                lblmemberID.Visible = true;
                lblmemberID.Text += (membooking.MemberID).ToString();
                lblmembername.Visible = true;
                lblmembername.Text += membooking.MemberName;
                DataTable dt = ConvertListToDataTable<FitnessClass>(membooking.FitnessClassList);
                
                myHeader.Visible = true;
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }

            }
            catch
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter a Valid member ID, (between 101-108)";
                
            }
        }

        //method to help convert a list to DataTable
        public static DataTable ConvertListToDataTable<T>(List<T> listToConvert)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in listToConvert)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}
