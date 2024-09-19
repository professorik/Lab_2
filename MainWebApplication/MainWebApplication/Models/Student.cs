using System.Globalization;
using System.Xml.Linq;

namespace MainWebApplication.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public decimal GPA { get; set; }

        public Student(string firstName, string lastName, string patronymic, decimal gpa)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Patronymic = patronymic;
            this.GPA = gpa;
        }

        public static Student map(XElement student)
        {
            return new Student(
                student.Element("name").Value,
                student.Element("surname").Value,
                student.Element("patronymic").Value,
                decimal.Parse(student.Element("gpa").Value, CultureInfo.InvariantCulture.NumberFormat)
            );
        }
    }
}