using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpLR2
{
    interface IUniversity
    {
        IEnumerable<IPerson> Persons { get; }   // отсортировать в соответствии с вариантом 1-й лабы
        IEnumerable<Student> Students { get; }  // отсортировать в соответствии с вариантом 1-й лабы
        IEnumerable<Teacher> Teachers { get; }  // отсортировать в соответствии с вариантом 1-й лабы
        void Add(IPerson person);
        void Remove(IPerson person);
        IEnumerable<IPerson> FindByLastName(string lastName);
        // Для четных вариантов. Выдать всех преподавателей, название кафедры которых содержит

        // заданный текст. Отсортировать по должности.
        IEnumerable<Teacher> FindByDepartment(string text);
    }
}
