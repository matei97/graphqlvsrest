using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoModels.Models;
using GraphQL.Types;

namespace ContosoUniversity.GraphQL.Types
{
    public class DepartmentType : ObjectGraphType<Department>
    {
        public DepartmentType()
        {
            Field(x => x.DepartmentID);
            Field(x => x.Name);
            Field(x => x.Budget);
            Field(x => x.StartDate);
//            Field(x => x.RowVersion);
        }
    }
}