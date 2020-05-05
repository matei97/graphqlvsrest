using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoModels.Models;
using GraphQL.Types;

namespace ContosoUniversity.GraphQL.Types
{
    public class StudentType : ObjectGraphType<Student>
    {
        public StudentType()
        {
            Field(t => t.ID);
            Field(t => t.LastName);
            Field(t => t.FullName);
            Field(t => t.EnrollmentDate);
        }
    }
}