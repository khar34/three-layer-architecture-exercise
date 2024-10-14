using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class FacultyService
    {
        public List<Faculty> GetAll()
        {
            StudentContextDB context = new StudentContextDB();
            return context.Faculties.ToList();
        }

        public Faculty FindByName(string facultyName)
        {
            StudentContextDB context = new StudentContextDB();
            return context.Faculties.FirstOrDefault(f => f.FacultyName == facultyName);
        }
    }
}
