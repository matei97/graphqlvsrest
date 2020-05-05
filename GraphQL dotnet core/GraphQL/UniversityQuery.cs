using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.GraphQL.Types;
using ContosoUniversity.Repository;
using GraphQL.Types;

namespace ContosoUniversity.GraphQL
{
    public class UniversityQuery : ObjectGraphType
    {
        private readonly UniversalRepository _universalRepository;

        public UniversityQuery(UniversalRepository universalRepository)
        {
            _universalRepository = universalRepository;

            ConfigureStudents();
            ConfigureCourses();
            Field<string>("ab", context => "test");
        }

        private void ConfigureCourses()
        {
            Field<ListGraphType<CourseType>>("courses",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => _universalRepository.GetCoursesBy(context.GetArgument<int>("id")));
        }

        private void ConfigureStudents()
        {
            Field<ListGraphType<StudentType>>(
                "students",
                resolve: context => _universalRepository.GetAllStudents()
            );
        }
    }
}