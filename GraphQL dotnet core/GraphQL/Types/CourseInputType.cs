using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoModels.Models;
using GraphQL.Types;

namespace ContosoUniversity.GraphQL.Types
{
    public class CourseInputType:InputObjectGraphType<Course>
    {
        public CourseInputType()
        {
            Field(x => x.Title);
            Field(x => x.Credits);
            Field(x => x.DepartmentID);
        }
    }
}
