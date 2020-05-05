using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoModels.Models;
using GraphQL.Types;

namespace ContosoUniversity.GraphQL.Types
{
    public class CourseType : ObjectGraphType<Course>
    {
        public CourseType()
        {
            Field(t => t.CourseID);
            Field(t => t.Title);
            Field(t => t.Credits);
            Field(t => t.DepartmentID);
            Field<DepartmentType>("department",
                resolve: context => context.Source.Department);
        }
    }
}