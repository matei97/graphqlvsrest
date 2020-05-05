using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace ContosoUniversity.GraphQL
{
    public class UniversitySchema : Schema
    {
        public UniversitySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<UniversityQuery>();
            Mutation = resolver.Resolve<UniversityMutation>();
            Subscription = resolver.Resolve<UniversitySubscription>();
        }
    }
}