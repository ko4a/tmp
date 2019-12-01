using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpLR2
{
    class Teacher : IPerson
    {
        public enum Position { Junior, Middle, Senior };

        public Position TeacherPosition { get; set; }
        public string Name { get; set; }
        public string Patronomic { get; set; }
        public string Lastname { get; set; }
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime Date { get; set; }
        public int Age { get; set; }

        public string Department { get; set; }
        public int Experience { get; set; }

        public static Teacher Parse(string objectInJson)
        {
            return JsonConvert.DeserializeObject<Teacher>(objectInJson);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JavaScriptDateTimeConverter());
        }

    }
}
