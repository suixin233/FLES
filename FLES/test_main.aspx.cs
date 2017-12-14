using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace FLES
{
    public partial class test_main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

        }

        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            //e.NewValues["ID"] = -1;
            //e.NewValues["Password"] = GetStringElements1("Password") == "" ? " " : GetStringElements1("Password");
            //e.NewValues["Name"] = GetStringElements1("Name") == "" ? " " : GetStringElements1("Name");

        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            //e.NewValues["ID"] = e.OldValues["ID"];
            //e.NewValues["Password"] = GetStringElements1("Password") == "" ? " " : GetStringElements1("Password");
            //e.NewValues["Name"] = GetStringElements1("Name") == "" ? " " : GetStringElements1("Name");
        }

        private string GetStringElements1(string element)
        {
            TextBox sub = this.ASPxGridView1.FindEditFormTemplateControl(element) as TextBox;
            return sub.Text;
        }
    }
}