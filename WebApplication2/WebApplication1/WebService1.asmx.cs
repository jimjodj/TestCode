using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int ParseXML(XDocument XMLMsg)
        {
            int returnValue=0;
            

            XmlSchemaSet settings = new XmlSchemaSet();
            
            settings.Add(null, @"C:\Users\Jimmy\source\repos\WebApplication2\WebApplication1\XMLDataTest1.XSD");
           
            XMLMsg.Validate(settings, (o, e) =>
            {

                returnValue = -3;
            }); 
            if (returnValue == -3) { return returnValue; }
            IEnumerable<XElement> Defaults = from e in XMLMsg.Descendants("Declaration")
                                         where (string)e.Attribute("Command") == "DEFAULT"
                                         select e;

            if (Defaults.Count()==0)
            {
                returnValue = - 1;
            };
            IEnumerable<XElement> Dubs= from e in XMLMsg.Descendants("SiteID")
                                         where (string)e.Value == "DUB"
                                         select e;
            if (Dubs.Count()==0)
            {
                returnValue = - 2;
            };

            return returnValue;
        }
    }
}

