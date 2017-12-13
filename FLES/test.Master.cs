using System;
using System.Collections.Generic;
using System.Linq;
//using FLES.App_Code;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLES
{
    public partial class test : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.LoginName.Text = (string)Session["EmployeeNo"] == (string)Session["LoginName"] ? (string)Session["EmployeeNo"] : (string)Session["EmployeeNo"] + " " + (string)Session["LoginName"];
            //this.UserRole.Text = " - SBA Manager";
            //this.Time.Text = DateTime.Now.ToString("MM/dd/yyyy ") + DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("en-US"));
            //if (!IsPostBack)
            //{
            //    this.DropDownList1 = WebUlite.GetItemsByRole(this.DropDownList1, Session["UserRole"].ToString().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)); 
            //}
        }
    }
}