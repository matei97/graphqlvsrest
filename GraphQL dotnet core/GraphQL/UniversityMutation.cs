using ContosoModels.Models;
using ContosoUniversity.GraphQL.Types;
using ContosoUniversity.Repository;
using GraphQL.Types;

namespace ContosoUniversity.GraphQL
{
    public class UniversityMutation : ObjectGraphType
    {
        private readonly UniversalRepository _universalRepository;
        private readonly CourseMessageService _courseMessageService;

        public UniversityMutation(UniversalRepository universalRepository, CourseMessageService courseMessageService)
        {
            _universalRepository = universalRepository;
            _courseMessageService = courseMessageService;

            Name = "Mutation";

            Field<CourseType>(
                "createCourse",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CourseInputType>> {Name = "course"}),
                resolve: context =>
                {
                    var course = context.GetArgument<Course>("course");
                    var result = _universalRepository.AddCourse(course);

                    return _courseMessageService.AddMessage(result);
                });
        }
    }
}