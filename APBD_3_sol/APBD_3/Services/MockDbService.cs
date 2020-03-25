using APBD_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_3.Services
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student{ IdStudent = 1, FirstName = " Ahmad" , LastName = "Alaziz", IndexNumber = "s19047"},
                new Student{ IdStudent = 2, FirstName = " Roman" , LastName = "Isayanko", IndexNumber = "s18847"},
                new Student{ IdStudent = 3, FirstName = " Alice" , LastName = "lashuk", IndexNumber = "s19047"},
            };
        }
        public IEnumerable<Student> getStudents()
        {
            return _students;
        }

        public void deleteStudent(int id)
        {
            _students = _students.Where(u => u.IdStudent != id).ToList();

        }

        public void UpdateStudent(Student s)
        {
            Student student = _students.First(uS => uS.IdStudent ==s.IdStudent);
            _students = _students.Where(u => u.IdStudent != s.IdStudent).ToList();
            _students.Append(student);

        }
    }
}
