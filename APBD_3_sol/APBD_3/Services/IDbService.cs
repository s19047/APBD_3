using APBD_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_3.Services
{
    public interface IDbService
    {

        public IEnumerable<Student> getStudents();
        public void deleteStudent(int id);
        public void UpdateStudent(Student s);
    }
}
