using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ovning30
{
    public partial class nagotKul : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string newContact = (string)Session["myContact"];
            Literal1.Text = newContact;
            
            
        }
    }
}