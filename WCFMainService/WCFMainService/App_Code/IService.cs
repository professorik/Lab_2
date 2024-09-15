using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFMainService {

    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate="/GetStudents?minValue={minValue}&maxValue={maxValue}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Student> GetStudents(string minValue, string maxValue);
    }


    [DataContract]
    public class Student
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Patronymic { get; set; }

        [DataMember]
        public float GPA { get; set; }

        public Student(string firstName, string lastName, string patronymic, float gpa)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Patronymic = patronymic;
            this.GPA = gpa;
        }
    }
}