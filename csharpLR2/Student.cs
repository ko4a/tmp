using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpLR2
{
    class Student : IPerson
    {
        public string Name { get; set; }
        public string Patronomic{get; set; } 
        public string Lastname { get; set; }
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime Date { get; set; }
        public int Age { get; set; }
        public int Course { get; set; }
        public string Group { get; set; }
        public double AverageMark { get; set; }
        public Student() { }
        public Student(string name, string patronomic, string lastName, DateTime date, int age, int course, string group, double avgMark)
        {
            this.Name = name;
            this.Patronomic = patronomic;
            this.Lastname = lastName;
            this.Date = date;
            this.Age = age;
            this.Course = course;
            this.Group = group;
            this.AverageMark = avgMark;
        }

        public static Student Parse(string objectInJson)
        {
            return JsonConvert.DeserializeObject<Student>(objectInJson);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this,new JavaScriptDateTimeConverter());
        }
    }
}
