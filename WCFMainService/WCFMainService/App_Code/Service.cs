using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using System.Globalization;
using System.Diagnostics;
using System.Xml.Linq;
using System.Linq;

namespace WCFMainService {
    public class Service : IService
    {
        private static readonly string XmlPath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "Students.xml");

        public List<Student> GetStudents(string minValue, string maxValue)
        {
            float MinValue = float.Parse(minValue, CultureInfo.InvariantCulture.NumberFormat);
            float MaxValue = float.Parse(maxValue, CultureInfo.InvariantCulture.NumberFormat);
            XDocument xdoc = XDocument.Load(XmlPath);
            IEnumerable<XElement> nodes = xdoc.Root.Elements().Where(
                s => isBetween(float.Parse(s.Element("gpa").Value, CultureInfo.InvariantCulture.NumberFormat), MinValue, MaxValue
            ));

            List<Student> result = new List<Student>();
            foreach (XElement student in nodes)
            {
                result.Add(new Student(
                    student.Element("name").Value, 
                    student.Element("surname").Value, 
                    student.Element("patronymic").Value,
                    float.Parse(student.Element("gpa").Value, CultureInfo.InvariantCulture.NumberFormat)
                ));
            }
            return result;
        }

        private bool isBetween(float gpa, float minValue, float maxValue)
        {
            return gpa >= minValue && gpa <= maxValue;
        }
    }
}