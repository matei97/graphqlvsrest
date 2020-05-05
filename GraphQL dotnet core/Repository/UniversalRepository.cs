using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoModels.Models;
using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Repository
{
    public class UniversalRepository
    {
        private readonly SchoolContext _context;

        public UniversalRepository(SchoolContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students;
        }


        public IEnumerable<Course> GetCoursesBy(int id)
        {
            var all = _context.Courses
                .Include(c => c.Department)
                .AsNoTracking();


            return id == default(int) ? all : all.Where(x => x.CourseID == id);
        }

        public Course AddCourse(Course course)
        {
            course.CourseID = GetNewId();
            var res = _context.Courses.Add(course).Entity;

            _context.SaveChanges();

            return _context.Courses.Include(c => c.Department).SingleOrDefault(x => x.CourseID == res.CourseID);
        }

        private int GetNewId()
        {
            return _context.Courses.OrderByDescending(x => x.CourseID).First().CourseID + 1;
        }
    }
}