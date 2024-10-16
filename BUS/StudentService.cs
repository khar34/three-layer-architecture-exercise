using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BUS
{
    public class StudentService
    {
        
        public List<Student> GetAll()
        {
            StudentContextDB context = new StudentContextDB();
            return context.Students.ToList();
        }
        public List<Student> GetAllHasNoMajor()
        {
            StudentContextDB context = new StudentContextDB();
            return context.Students.Where(p => p.MajorID == null).ToList();   
        }
        public static List<Student> GetAllHasNoMajor(int facultyID)
        {
            StudentContextDB context = new StudentContextDB();
            return context.Students.Where(p => p.MajorID == null && p.FacultyID == facultyID).ToList();
        }
        public static Student FindById(String studentID)
        {
            StudentContextDB context = new StudentContextDB();
            return context.Students.FirstOrDefault(p => p.StudentID == studentID);
        }
        public static void InsertUpdate(Student s)
        {
            StudentContextDB context = new StudentContextDB();
            context.Students.AddOrUpdate(s);
            context.SaveChanges();
        }

        public void UpdateAvatar(string studentID, string avatarFileName)
        {
            StudentContextDB context = new StudentContextDB();
            var student = context.Students.FirstOrDefault(s => s.StudentID == studentID);
            if (student != null)
            {
                student.Avatar = avatarFileName;
                context.SaveChanges();
            }
        }

        public string GetAvatarFileName(string studentID)
        {
            StudentContextDB context = new StudentContextDB();
            var student = context.Students.FirstOrDefault(s => s.StudentID == studentID);  // Assuming studentsList is a List<Student>
            return student?.Avatar;
        }


    }
}
