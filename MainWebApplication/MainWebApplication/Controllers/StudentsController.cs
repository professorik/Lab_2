using MainWebApplication.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Http;
using System.Xml.Linq;

namespace MainWebApplication.Controllers
{
    public class StudentsController : ApiController
    {
        private static readonly string XmlPath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "Students.xml");

        public IHttpActionResult GetStudents(decimal minValue, decimal maxValue)
        {
            XDocument xdoc = XDocument.Load(XmlPath);
            IEnumerable<XElement> nodes = xdoc.Root.Elements().Where(
                s => isBetween(decimal.Parse(s.Element("gpa").Value, CultureInfo.InvariantCulture.NumberFormat), minValue, maxValue
            ));
            return Ok(nodes.Select(node => Student.map(node)));
        }

        [NonAction]
        private bool isBetween(decimal gpa, decimal minValue, decimal maxValue)
        {
            return gpa >= minValue && gpa <= maxValue;
        }
    }
}
