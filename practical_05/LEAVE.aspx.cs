using System;
using System.Web.UI;

namespace caleneder
{
    public partial class LEAVE : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check employee name from Cookie
                if (Request.Cookies["empName"] != null)
                {
                    txtemp.Text =
                        Request.Cookies["empName"].Value;
                }

                // Get selected date from Session
                if (Session["LeaveDate"] != null)
                {
                    DateTime lvdt =
                        (DateTime)Session["LeaveDate"];

                    Label1.Text =
                        lvdt.ToString("dd-MM-yyyy");
                }
                else
                {
                    Label1.Text = "No Date Selected";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ename = txtemp.Text;
            string lvtype = DropDownList1.SelectedValue;
            string reason = txtReson.Text;

            // Store information in Session
            Session["empName"] = ename;
            Session["leaveType"] = lvtype;
            Session["Reason"] = reason;

            // Create Cookie if checkbox is selected
            if (CheckBox1.Checked)
            {
                Response.Cookies["empName"].Value = ename;

                // Cookie expires after 7 days
                Response.Cookies["empName"].Expires =
                    DateTime.Now.AddDays(7);
            }

            Label2.Text =
                "<b>Leave Application Submitted Successfully!</b><br/>" +
                "Employee Name: " + ename + "<br/>" +
                "Leave Type: " + lvtype + "<br/>" +
                "Reason: " + reason;
        }
    }
}