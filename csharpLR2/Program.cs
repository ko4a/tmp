using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpLR2
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuCase;
            var university = new University();
            var teacher = new Teacher()
            {
                TeacherPosition = Teacher.Position.Junior,
                Name = "Имя преподавателя",
                Patronomic = "Отчество преподавателя",
                Lastname = "Фамилия преподавателя",
                Date = DateTime.Now,
                Age = 30,
                Department ="Кафедра преподавателя",
                Experience = 5
            };
            var student = new Student()
            {
                Name = "Имя студента",
                Patronomic = "Отчество студента",
                Lastname = "Фамилия студента",
                Date = DateTime.Now,
                Age = 30,
                Course = 1,
                AverageMark = 99,
                Group = "Группа студента"
            };
            university.Add(teacher);
            university.Add(student);
            while (true)
            {
                Console.WriteLine("1 - Вывести всех из университета");
                Console.WriteLine("2 - Вывести преподавателей");
                Console.WriteLine("3 - Вывести студентов");
                Console.WriteLine("4 - Добавить преподавателя");
                Console.WriteLine("5 - Добавить студента");
                Console.WriteLine("6 - Удалить кого-либо");
                Console.WriteLine("7 - Поиск по фамилии");
                Console.WriteLine("8 - Поиск по кафедре");

                if (int.TryParse(Console.ReadLine(), out menuCase))
                {
                    Console.WriteLine();
                    switch (menuCase)
                    {
                        case 1:
                            if (university.Persons.Count() == 0) { Console.WriteLine("Никого нет."); }
                            else { university.Persons.ToList().ForEach(x => Console.WriteLine(x)); Console.WriteLine(); }
                            break;
                        case 2:
                            if (university.Teachers.Count() == 0) { Console.WriteLine("Преподавателей нет."); }
                            else { university.Teachers.ToList().ForEach(x => Console.WriteLine(x)); Console.WriteLine(); }
                            break;
                        case 3:
                            if (university.Students.Count() == 0) { Console.WriteLine("Студентов нет."); }
                            else { university.Students.ToList().ForEach(x => Console.WriteLine(x)); Console.WriteLine(); }
                            break;
                        case 4:
                            Console.WriteLine("Введите объект в json");
                            string jsonTeacher = Console.ReadLine();

                            try { university.Add(Teacher.Parse(jsonTeacher)); }
                            catch (Exception e) { Console.WriteLine(e.Message); }
                            
                            break;
                        case 5:
                            Console.WriteLine("Введите объект в json");
                            string jsonStudent = Console.ReadLine();

                            try { university.Add(Student.Parse(jsonStudent)); }
                            catch (Exception e) { Console.WriteLine(e.Message); }
                            break;
                        case 6:
                            Console.WriteLine("1 - удаление преподавателя");
                            Console.WriteLine("2 - удаление студента");
                            int subMenuCase = -1;
                            int.TryParse(Console.ReadLine(), out subMenuCase);

                            Console.WriteLine("Введите объект в json");
                            IPerson deletable =null;
                            string json = Console.ReadLine();
                            

                            switch (subMenuCase)
                            {
                                case 1:
                                    try
                                    {
                                        deletable = Teacher.Parse(json);
                                    }
                                    catch (Exception e) { Console.WriteLine("incorrect json"); }
                                    break;
                                case 2:
                                    try
                                    {
                                        deletable = Student.Parse(json);
                                    }
                                    catch (Exception e) { Console.WriteLine("incorrect json"); }

                                    break;
                            }

                            if (deletable != null)
                            {
                                university.Remove(deletable);
                            }
         
                            break;
                        case 7:
                            Console.WriteLine("Фамилия");
                            string lastname = Console.ReadLine();
                            university.FindByLastName(lastname).ToList().ForEach(x => Console.WriteLine(x));
                            break;
                        case 8:
                            Console.WriteLine("Кафедра");
                            string department = Console.ReadLine();
                            university.FindByDepartment(department).ToList().ForEach(x => Console.WriteLine(x));
                            break;

                    }
                }
            }
        }

    }
}
