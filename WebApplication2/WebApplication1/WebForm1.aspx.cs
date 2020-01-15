using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebApplication1.ServiceReference1;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //ServiceReference1. webService = new WebService();
            string FileName = "C:\\Users\\Jimmy\\source\\repos\\WebApplication2\\WebApplication1\\XMLDataTest.XML";
            string dataXML = System.IO.File.ReadAllText(FileName);
            XDocument x = XDocument.Load(FileName);
            WebService1 ws = new WebService1();
            int i = ws.ParseXML(x);
            
            //webService.
        }

}
}