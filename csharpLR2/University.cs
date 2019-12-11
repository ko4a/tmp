using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpLR2
{
    class University : IUniversity
    {

        public IEnumerable<IPerson> Persons { get { return Students.Concat<IPerson>(Teachers); } }

        public IEnumerable<Student> Students { get; private set; }

        public IEnumerable<Teacher> Teachers { get; private set; }

        public University()
        {
            this.Students = Enumerable.Empty<Student>();
            this.Teachers = Enumerable.Empty<Teacher>();
        }
        public void Add(IPerson person)
        {
            if( person is Student )
            {
                IEnumerable<Student> tmpStudentPersons = new Student[] { (Student)person };
                Students = Students.Concat(tmpStudentPersons);
            }

            if (person is Teacher)
            {
                IEnumerable<Teacher> tmpStudentPersons = new Teacher[] { (Teacher)person };
                Teachers = Teachers.Concat(tmpStudentPersons);
            }

        }

        public void Remove(IPerson person)
        {

            if (person is Student)
            {
                List<Student> tmpList = Students.ToList();
                tmpList.RemoveAll(x => arePersonsEqual(x, person));
                Students = tmpList;
            }

            if (person is Teacher)
            {
                List<Teacher> tmpList =  Teachers.ToList();
                tmpList.RemoveAll(x => arePersonsEqual(x, person));
                Teachers = tmpList;
                
            }

        }

        public IEnumerable<IPerson> FindByLastName(string lastName)
        {
            return this.Persons.Where(x => x.Lastname == lastName);
        }

        public IEnumerable<Teacher> FindByDepartment(string text)
        {
            return this.Teachers.Where(x => x.Department.Contains(text)).OrderBy(x => x.TeacherPosition);
        }
        private bool arePersonsEqual(IPerson person1, IPerson person2){
            return person1.ToString() == person2.ToString();
        }
    }
}
