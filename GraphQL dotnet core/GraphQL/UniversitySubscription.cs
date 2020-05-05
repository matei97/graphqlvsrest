using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoModels.Models;
using ContosoUniversity.GraphQL.Types;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;

namespace ContosoUniversity.GraphQL
{
    public class UniversitySubscription : ObjectGraphType
    {
        private readonly CourseMessageService messageService;

        public UniversitySubscription(CourseMessageService messageService)
        {
            this.messageService = messageService;

            Name = "Subscription";

            AddField(new EventStreamFieldType
            {
                Name = "courseAdded",
                Type = typeof(CourseType),
                Resolver = new FuncFieldResolver<Course>
                    (ResolveMessage),
                Subscriber = new EventStreamResolver<Course>
                    (Subscribe)
            });
        }


        private Course ResolveMessage(ResolveFieldContext context)
        {
            return context.Source as Course;
        }

        private IObservable<Course> Subscribe(ResolveEventStreamContext context)
        {
            return messageService.Messages();
        }
    }
}