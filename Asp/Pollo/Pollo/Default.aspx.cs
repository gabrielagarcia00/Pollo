﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pollo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       protected void btnPollo_Click(object sender, EventArgs e)
        {
            Server.Transfer("index.aspx", true); 
            Server.Transfer("Default.aspx", false); 
        }
    }
}