using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;

namespace FLES.App_Code
{
    public class WebUlite
    {

        /// <summary>
        /// 根据角色返回相对应的导航
        /// </summary>
        /// <param name="Roles"></param>
        /// <returns></returns>
        public static DropDownList GetItemsByRole(DropDownList dplist, string[] Roles)
        {
            dplist.Items.Clear();
            dplist.Items.Add(new ListItem("Please select"));

            if (isHasRole(Roles, "SystemManager"))
            {
                ListItem listi = new ListItem("System Manager");
                dplist.Items.Add(listi);
            }
            if (isHasRole(Roles, "ProjectOwner"))
            {
                ListItem listi = new ListItem("Project Owner");
                dplist.Items.Add(listi);
            }
            if (isHasRole(Roles, "TestOwner"))
            {
                ListItem listi = new ListItem("Test Owner");
                dplist.Items.Add(listi);
            }
            if (isHasRole(Roles, "TA"))
            {
                ListItem listi = new ListItem("TA");
                dplist.Items.Add(listi);
            }
            if (isHasRole(Roles, "LayoutOwner"))
            {
                ListItem listi = new ListItem("Layout Owner");
                dplist.Items.Add(listi);
            }
            if (isHasRole(Roles, "LayoutDesignOwner"))
            {
                ListItem listi = new ListItem("Layout Design Owner");
                dplist.Items.Add(listi);
            }
            if (isHasRole(Roles, "Applicant"))
            {
                ListItem listi = new ListItem("Applicant");
                dplist.Items.Add(listi);
            }
            if (isHasRole(Roles, "SBAManager"))
            {
                ListItem listi = new ListItem("SBA Manager");
                dplist.Items.Add(listi);
            }
            if (isHasRole(Roles, "Supervisor"))
            {
                ListItem listi = new ListItem("Supervisor");
                dplist.Items.Add(listi);
            }
            if (isHasRole(Roles, "LabManager"))
            {
                ListItem listi = new ListItem("Lab Manager");
                dplist.Items.Add(listi);
            }

            return dplist;
        }

        /// <summary>
        /// 判断是否具有角色
        /// </summary>
        private static Boolean isHasRole(String[] roles, String role)
        {
            for (int i = 0; i < roles.Length; i++)
            {
                if (role == roles[i])
                    return true;
            }
            return false;
        }
    }
}